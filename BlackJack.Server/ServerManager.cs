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
        private bool CheckCredentials(object cred)
        {
            throw new NotImplementedException();
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
                client.SendHandshake();

                var gm = new ServerGameManager();
                while (true)
                {
                    //check whether user is authenticated with each iteration
                    var methodCallRequest = client.ReceiveMethodCallRequest();
                    //requested method call here. return some 'state' element. fill it with 
                    //some kind of exception, if requested method call is not permitted due to auth state
                    var requestedMethodResult = gm.CallMethodByRequest(methodCallRequest);
                    var response = new ServerResponse {Message = "Hello!"};
                    client.SendResponse(response);
                    //
                    if (methodCallRequest.Signature.Name == "Terminate")
                        break;
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

    }
}