using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Server
{
    /// <summary>
    /// Must be instantiated in different from form thread for user experience improvement
    /// </summary>
    class ServerManager : IDisposable
    {
        public ServerManager()
        {
            serverThread = new Thread(StartListening);
            serverThread.Start();
        }

        private Thread serverThread;
        private object syncRoot = new object();
        private int maxConnections = 2;
        private TcpClient server;
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 777);
        List<Thread> runningThreads = new List<Thread>(); 
        public void StartListening()
        {
            server = new TcpClient(endPoint);
            server.Client.Listen(maxConnections);

            while (true)
            {
                var incoming = server.Client.Accept();
                var workThread = new Thread(new ParameterizedThreadStart(ProcessClientConnection));
                lock (syncRoot)
                {
                    runningThreads.Add(workThread);
                }
                workThread.Start(incoming);
            }
        }

        public void StopListening()
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

            var client = clientObj as Socket;
            client.SendHandshake();
            var gm = new ServerGameManager();
            //if we reached here, auth successful
            while (true)
            {
                /*
                //check whether user is authenticated with each iteration
                var methodCallRequest = client.ReceiveMethodCallRequest();
                //requested method call here. return some 'state' element. fill it with 
                //some kind of exception, if requested method call is not permitted due to auth state
                object requestedMethodResult = gm.CallMethodByRequest(methodCallRequest);
                client.SendResponse(requestedMethodResult);
                //
                if (methodCallRequest.Name == "Terminate")
                    break;
                */
            }
            //if we reached here, game is about to exit. needa terminate session and clear resources
            var curThreadId = Thread.CurrentThread.ManagedThreadId;
            var threadInstance = runningThreads.FirstOrDefault(t => t.ManagedThreadId == curThreadId);
            lock (syncRoot)
            {
                runningThreads.Remove(threadInstance);
            }
        }

        private bool CheckCredentials(object cred)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            StopListening();
            if (serverThread != null && serverThread.ThreadState != ThreadState.Aborted)
                serverThread.Abort();
        }

        ~ServerManager()
        {
            Dispose();
        }
}
}
