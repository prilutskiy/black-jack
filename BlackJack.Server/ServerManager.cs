using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJack.Common;

namespace BlackJack.Server
{
    public class ServerEventArgs : EventArgs
    {
        public String Message { get; set; }
        public Socket ClientSocket { get; set; }
    }
    /// <summary>
    /// Must be instantiated in different from form thread for user experience improvement
    /// </summary>  
    class ServerManager : IDisposable
    {
        public ServerManager()
        {
            serverThread = new Thread(StartListening);
            serverThread.IsBackground = true;
        }

        public void Start()
        {
            serverThread.Start();
            WriteLog("Server started", null);
        }

        private Thread serverThread;
        private object syncRoot = new object();
        private int maxConnections = 2;
        private TcpClient server;
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 777);
        List<Thread> runningThreads = new List<Thread>();
        public event EventHandler<ServerEventArgs> ServerStateChanged;
        private void StartListening()
        {
            server = new TcpClient(endPoint);
            server.Client.Listen(maxConnections);
            WriteLog("Listening started", null);
            while (true)
            {
                var incoming = server.Client.Accept();
                var workThread = new Thread(new ParameterizedThreadStart(ProcessClientConnection));
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
                    object requestedMethodResult = gm.CallMethodByRequest(methodCallRequest);
                    var response = new ServerResponse { Message = "Hello!" };
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

        private bool CheckCredentials(object cred) 
        {
            throw new NotImplementedException();
        }

        private void WriteLog(string msg, Socket clientSocket)
        {
            if (ServerStateChanged != null)
                ServerStateChanged(this, new ServerEventArgs{Message = msg, ClientSocket = clientSocket});
        }
        public void Dispose()
        {
            StopListening();
            server.Close();
            if (serverThread != null && serverThread.ThreadState != ThreadState.Aborted)
                serverThread.Abort();
        }

        ~ServerManager()
        {
            Dispose();
        }
}
}
