using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading;
using BlackJack.Common;

namespace BlackJack.Server
{
    internal class ServerManager : IDisposable
    {
        #region Private members
        private readonly IPlayerFactory playerFactory = new StubPlayerFactory();
        private readonly IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 777);
        private readonly int maxConnections = 10;
        private readonly List<Thread> runningThreads = new List<Thread>();
        private readonly Thread serverThread;
        private readonly object syncRoot = new object();
        private TcpClient server;
        private void StartListening()
        {
            server = new TcpClient(endPoint);
            server.Client.Listen(maxConnections);
            WriteLog("Listening started", null);
            while (true)
            {
                var incoming = server.Client.Accept();
                var workThread = new Thread(ProcessClientConnection);
                workThread.IsBackground = true;
                lock (syncRoot)
                {
                    runningThreads.Add(workThread);
                }
                workThread.Start(incoming);
            }
        }
        private void StopListening()
        {
            //server.Close(); can crash because of cross-thread operation. server may be in wainting-for-clients state.
            lock (syncRoot)
            {
                foreach (var thread in runningThreads)
                {
                    thread.Abort();
                }
                runningThreads.Clear();
            }
        }
        private bool CheckCredentials(Credentials cred)
        {
            return true;
        }
        private void WriteLog(string msg, Socket clientSocket)
        {
            if (ServerStateChanged != null)
                ServerStateChanged(this, new ServerEventArgs { Message = msg, ClientSocket = clientSocket });
        }
        ~ServerManager()
        {
            Dispose();
        }
        #endregion

        public event EventHandler<ServerEventArgs> ServerStateChanged;
        public ServerManager()
        {
            serverThread = new Thread(StartListening) {IsBackground = true};
        }
        public void Start()
        {
            serverThread.Start();
            WriteLog("Server started", null);
        }
        public void Dispose()
        {
            StopListening();
            server.Close();
            if (serverThread != null && serverThread.ThreadState != ThreadState.Aborted)
                serverThread.Abort();
        }
        public void ProcessClientConnection(object clientObj)
        {
            var clientSocket = clientObj as Socket;
            try
            {
                WriteLog("Client connected", clientSocket);
                var client = new Connection(clientSocket);
                if (!client.SendHandshake()) throw new InvalidOperationException("Handshake error");
                
                lock(Untrusted)
                    Untrusted.Add(client);
                //if reached here - ok
                while (true)
                {
                    var request = client.ReceiveRequest();
                    ServerResponse response;
                    switch (request.RequestType)
                    {
                        case ServerMessageType.NotSet:
                            throw new InvalidOperationException("Message type not set");
                        case ServerMessageType.CheckAuth:
                            bool isAuth;
                            lock (Trusted)
                                isAuth = Trusted.Contains(client);
                            client.SendResponse(new ServerResponse
                            {
                                IsAuthenticated = isAuth, 
                                ResponseType = ServerMessageType.CheckAuth
                            });
                            break;
                        case ServerMessageType.Auth:
                            var creds = request.Credentials;
                            var result = CheckCredentials(creds);
                            
                            response = new ServerResponse
                            {
                                ResponseType = ServerMessageType.Auth,
                                AuthSucceed = result
                            };

                            client.SendResponse(response);
                            if (result)
                            {
                                client.PlayerInstance = playerFactory.LoadFromDataStorage(creds.Username);
                                lock (Untrusted)
                                    Untrusted.Remove(client);
                                lock (Trusted)
                                    Trusted.Add(client);
                            }
                            
                            break;
                        case ServerMessageType.Deauth:
                            lock (Trusted)
                                Trusted.Remove(client);
                            lock (Untrusted)
                                    Untrusted.Add(client);
                            response = new ServerResponse
                            {
                                ResponseType = ServerMessageType.Auth,
                                AuthSucceed = true
                            };

                            client.SendResponse(response);
                            break;
                        case ServerMessageType.StartGame:
                            //THREAD-UNSAFE
                            if (Untrusted.Contains(client)) //if not authenticated
                            {
                                response = new ServerResponse
                                {
                                    ResponseType = ServerMessageType.Error,
                                    ErrorMessage = "Access denied. Please, authorize"
                                };
                                client.SendResponse(response);
                            }
                            else
                            {
                                var gameType = request.GameType;
                                OnStartGameRequest(client.PlayerInstance, gameType);
                                response = new ServerResponse
                                {
                                    ResponseType = ServerMessageType.StartGame,
                                    MatchState = MatchState.Waiting
                                };
                                client.SendResponse(response);
                            }
                            break;
                        case ServerMessageType.InGame:
                            break;
                        case ServerMessageType.Leaderboard:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            catch (SerializationException ex)
            {
                WriteLog(ex.Message, clientSocket);
            }
            catch (SocketException ex)
            {
                WriteLog(ex.Message, clientSocket);
            }
            finally
            {
                //if we reached here, game is about to exit. needa terminate session and clear resources
                var curThreadId = Thread.CurrentThread.ManagedThreadId;
                var threadInstance = runningThreads.FirstOrDefault(t => t.ManagedThreadId == curThreadId);
                lock (syncRoot)
                {
                    runningThreads.Remove(threadInstance);
                }
            }
        }

        public readonly Queue<Player> DuelQueue = new Queue<Player>();
        public readonly Queue<Player> ClassicQueue = new Queue<Player>();
        public readonly List<ServerGameManager> DuelGames = new List<ServerGameManager>();
        public readonly List<ServerGameManager> ClassicGames = new List<ServerGameManager>();

        public readonly List<Connection> Untrusted = new List<Connection>();
        public readonly List<Connection> Trusted = new List<Connection>();

        void OnStartGameRequest(Player player, GameType type)
        {
            //if authenticated
            if (type == GameType.Classic)
            {
                ClassicQueue.Enqueue(player);
            }
            else if (type == GameType.Duel)
            {
                DuelQueue.Enqueue(player);
            }
            else
            {
                throw new InvalidOperationException();
            }
            ProcessQueues();
        }

        void ProcessQueues()
        {
            lock (ClassicQueue)
                while (ClassicQueue.Count > 1)
                {
                    var player1 = ClassicQueue.Dequeue();
                    var player2 = playerFactory.Create(PlayerType.Dealer, "Dealer");
                    var game = new ServerGameManager(player1, player2);
                    ClassicGames.Add(game);
                }
            lock(DuelQueue)
                while (DuelQueue.Count/2 > 1)
                {
                    var player1 = DuelQueue.Dequeue();
                    var player2 = DuelQueue.Dequeue();
                    var game = new ServerGameManager(player1, player2);
                    DuelGames.Add(game);
                }
        }
    }
}