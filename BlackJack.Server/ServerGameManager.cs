using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Server
{
    class ServerGameManager : IBjGameManager
    {
        public GameState Initialize()
        {
            throw new NotImplementedException();
        }

        public GameState IncreaseBet(int value)
        {
            throw new NotImplementedException();
        }

        public GameState DecreaseBet(int value)
        {
            throw new NotImplementedException();
        }

        public GameState Start()
        {
            throw new NotImplementedException();
        }

        public GameState Double()
        {
            throw new NotImplementedException();
        }

        public GameState Stand()
        {
            throw new NotImplementedException();
        }

        public GameState Hit()
        {
            throw new NotImplementedException();
        }

        public GameState Terminate()
        {
            throw new NotImplementedException();
        }

        public GameState Login(string username, string pass)
        {
            throw new NotImplementedException();
        }

        public object CallMethodByRequest(MethodCallRequest methodCallRequest)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
