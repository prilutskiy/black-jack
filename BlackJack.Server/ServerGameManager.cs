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
        public ServerGameManager(Player player1, Player player2)
        {
            player1.GameFound = true;
            player2.GameFound = true;
            Initialize(player1, player2);
        }

        public GameState Initialize(Player player1, Player player2)
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

        public GameState Stop()
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

        public GameState Login(string username, string pass)
        {
            throw new NotImplementedException();
        }

        public GameState Logoff()
        {
            throw new NotImplementedException();
        }

        public GameState GetState()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public GameState GetLeaderboard()
        {
            throw new NotImplementedException();
        }
    }
}
