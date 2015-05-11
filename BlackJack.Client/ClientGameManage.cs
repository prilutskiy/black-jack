using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;
using DevExpress.Data.Linq;
using DevExpress.XtraPrinting.Native;

namespace BlackJack.Client
{
    class ClientGameManager : IBjGameManager
    {
        public ClientGameManager(Connection connection)
        {
            Connection = connection;
        }
        private Connection Connection { get; set; }
        private GameType GameType = GameType.NotSet;
        private ServerResponse InvokeRemote(MethodInfo methodInfo, List<object> args, ServerRequest request)
        {
            var methodRequest = new MethodCallRequest()
            {
                Arguments = args,
                Signature = methodInfo.ToMethodSignature()
            };
            Connection.SendRequest(request);
            ServerResponse response = Connection.GetResponse();
            return response;
        }
        public GameState Initialize()
        {
            throw new NotImplementedException();
        }

        public GameState IncreaseBet(int value = 50)
        {
            var args = new List<object> { value };
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }


        public GameState DecreaseBet(int value = 50)
        {
            var args = new List<object> { value };
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Start()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Stop()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Double()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Stand()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Hit()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Login(string username, string pass)
        {
            var args = new List<object>() { username, pass };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var req = new ServerRequest()
            {
                Credentials = new Credentials(username, pass),
                GameType = GameType,
                RequestType = ServerMessageType.Auth
            };
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState Logoff()
        {
            var args = new List<object>();
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.Deauth
            };
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public GameState GetState()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.InGame
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }

        public bool IsAuthenticated()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                RequestType = ServerMessageType.CheckAuth
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.IsAuthenticated;
        }

        public GameState GetLeaderboard()
        {
            var args = new List<object>();
            var req = new ServerRequest()
            {
                GameType = GameType,
                RequestType = ServerMessageType.Leaderboard
            };
            var methodInfo = MethodBase.GetCurrentMethod() as MethodInfo;
            var response = InvokeRemote(methodInfo, args, req);
            return response.GameState;
        }
    }

}
