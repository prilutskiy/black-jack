using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public class GameState
    {
        public GameState(Player player, Player dealer, bool gameIsOver, Player winner, int bet, Exception ex)
        {
            Player = player;
            Dealer = dealer;
            GameIsOver = gameIsOver;
            Winner = winner;
            Bet = bet;
            Exception = ex;
        }
        public Player Player { get; private set; }
        public Player Dealer { get; private set; }
        public Boolean GameIsOver { get; private set; }
        public Player Winner { get; private set; }
        public Int32 Bet { get; private set; }

        public Exception Exception { get; set; }
    }
}
