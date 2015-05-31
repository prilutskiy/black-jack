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
        private static readonly BlackJackRepository _repo = new BlackJackRepository();
        private readonly PlayerFactory playerFactory = new DbPlayerFactory();
        private readonly IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 777);
        private readonly int maxConnections = 100;
        private readonly List<Thread> runningThreads = new List<Thread>();
        private Thread serverThread;
        private readonly object syncRoot = new object();
        private TcpClient server;

        public readonly List<Tuple<Player, Player, ServerGameManager>> ClassicGames =
            new List<Tuple<Player, Player, ServerGameManager>>();

        public readonly Queue<Player> ClassicQueue = new Queue<Player>();
        public readonly List<Connection> Trusted = new List<Connection>();
        public readonly List<Connection> Untrusted = new List<Connection>();


        private Object ProcessInGameRequest(IBjGameManager game, ServerRequest request)
        {
            var requestedMethod = request.RequestedMethod;
            var localMethod = game.GetType().GetMethod(requestedMethod.Signature.Name);
            var result = localMethod.Invoke(game, requestedMethod.Arguments.ToArray());
            return result;
        }

        private bool IsGameReady(Player p)
        {
            var result = true;
            lock (ClassicQueue)
                if (ClassicQueue.Contains(p))
                    result &= false;
            return result;
        }

        private void OnStartGameRequest(Player player, GameType type)
        {
            //if authenticated
            if (type == GameType.Classic)
            {
                ClassicQueue.Enqueue(player);
            }
            else
            {
                throw new InvalidOperationException();
            }
            ProcessQueues();
        }

        private void ProcessQueues()
        {
            lock (ClassicQueue)
                while (ClassicQueue.Count > 0)
                {
                    var player1 = ClassicQueue.Dequeue();
                    var player2 = playerFactory.Create(PlayerType.Dealer, "Dealer");
                    var game = new ServerGameManager(player1, player2, _repo);
                    var pair = new Tuple<Player, Player, ServerGameManager>(player1, null, game);
                    if (!ClassicGames.Any(t => t.Item1 == player1))
                        ClassicGames.Add(pair);
                }
        }

        private IBjGameManager GetGameByConnection(Connection client)
        {
            var player = client.PlayerInstance;
            var game = ClassicGames.SingleOrDefault(p => p.Item1 == player || p.Item2 == player).Item3;
            return game;
        }



        private void StartListening()
        {
            try
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
            catch (SocketException ex)
            {
                WriteLog(ex.Message, null);
            }
            
        }

        private void StopListening()
        {
            lock (syncRoot)
            {
                foreach (var thread in runningThreads)
                {
                    thread.Abort();
                }
                runningThreads.Clear();
            }
            WriteLog("Listening stopped", null);
        }
        public ServerManager()
        {
            
        }
        public void Start()
        {
            WriteLog("Starting server...", null);
            serverThread = new Thread(StartListening) { IsBackground = true };
            serverThread.Start();
        }

        public void Stop()
        {
            WriteLog("Stopping server...", null);
            StopListening();
            server.Close();
            serverThread.Abort();
        }

        private bool CheckCredentials(Credentials cred)
        {
            bool result;
            if (!_repo.UserExists(cred.Username))
            {
                _repo.AddPlayer(cred.Username, cred.Password);
                result = true;
            }
            else
                result = _repo.CheckCredentials(cred.Username, cred.Password);
            return result;
        }

        private void WriteLog(string msg, Socket clientSocket)
        {
            if (ServerStateChanged != null)
                ServerStateChanged(this, new ServerEventArgs { Message = msg, ClientSocket = clientSocket });
        }


        public void Dispose()
        {
            try
            {
                StopListening();
                server.Close();
                if (serverThread != null && serverThread.ThreadState != ThreadState.Aborted)
                    serverThread.Abort();
            }
            catch (Exception)
            {
                
            }
            
        }

        public event EventHandler<ServerEventArgs> ServerStateChanged;

        public void FillContext(ServerContext context)
        {
            context.ClassicGames = ClassicGames;
            context.ClassicQueue = ClassicQueue;
            context.MaxConnections = maxConnections;
            context.EndPoint = endPoint;
            context.RunningThreads = runningThreads;
            context.Trusted = Trusted;
            context.Untrusted = Untrusted;
            context.AppRepository = _repo;
        }

        public void ProcessClientConnection(object clientObj)
        {
            var clientSocket = clientObj as Socket;
            WriteLog("Client connected", clientSocket);
            var client = new Connection(clientSocket);
            try
            {
                if (!client.SendHandshake()) throw new InvalidOperationException("Handshake error");

                lock (Untrusted)
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
                        case ServerMessageType.AuthInfo:
                            var resp = new ServerResponse {Username = client.PlayerInstance.Username};
                            client.SendResponse(resp);
                            break;
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
                            var logMsg = result
                                ? String.Format("{0} authenticated", creds.Username)
                                : String.Format("{0} authentication failed", creds.Username);
                            WriteLog(logMsg, client.Socket);
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
                            WriteLog(String.Format("{0} deauthenticated", client.PlayerInstance.Username), client.Socket);
                            client.SendResponse(response);
                            break;
                        case ServerMessageType.StartGame:
                            lock (Untrusted)
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
                                    var g = GetGameByConnection(client);
                                    g.Stop();
                                    g.Start(gameType);
                                    response = new ServerResponse
                                    {
                                        ResponseType = ServerMessageType.StartGame,
                                        MatchState =
                                            IsGameReady(client.PlayerInstance)
                                                ? MatchState.GameFound
                                                : MatchState.Waiting,
                                        GameState =
                                            IsGameReady(client.PlayerInstance)
                                                ? GetGameByConnection(client).GetState()
                                                : null
                                    };
                                    client.SendResponse(response);
                                }
                            break;
                        case ServerMessageType.IsGameReady:
                            var isReady = IsGameReady(client.PlayerInstance);
                            response = new ServerResponse
                            {
                                IsReady = isReady
                            };
                            client.SendResponse(response);
                            break;
                        case ServerMessageType.InGame:
                            var game = GetGameByConnection(client);
                            var gameState = ProcessInGameRequest(game, request);
                            if (request.RequestedMethod.Signature.Name == "Stop")
                            {
                                var toRemove = ClassicGames.SingleOrDefault(t => t.Item1 == client.PlayerInstance);
                                ClassicGames.Remove(toRemove);
                            }
                            response = new ServerResponse();
                            if (gameState is bool)
                                response.IsAuthenticated = (bool) gameState;
                            else if (gameState is GameState)
                                response.GameState = gameState as GameState;
                            else
                                throw new InvalidOperationException();
                            client.SendResponse(response);
                            break;
                        case ServerMessageType.Leaderboard:
                            var table = _repo.GetLeaderboard(10);
                            resp = new ServerResponse()
                            {
                                GameState = new GameState(null, null, false, null, 0, 0, null)
                                {
                                    Leaderboard = table,
                                    AppStage = "leaderboard"
                                }
                            };
                            client.SendResponse(resp);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                WriteLog(ex.Message, clientSocket);
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
                lock(Trusted)
                    if (Trusted.Contains(client))
                        Trusted.Remove(client);
                lock(Untrusted)
                    if (Untrusted.Contains(client))
                        Untrusted.Remove(client);
                WriteLog("Client disconnected", client.Socket);
            }
        }

        ~ServerManager()
        {
            Dispose();
        }

    }
}