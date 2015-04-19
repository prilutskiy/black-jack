using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

 
namespace BlackJack.Common
{
    [DataContract]
    public class GameState
    {
        public GameState(Player player, Player dealer, bool gameIsOver, Player winner, int bet, double doubleFactor, String exMsg)
        {
            Player = player;
            Dealer = dealer;
            GameIsOver = gameIsOver;
            Winner = winner;
            Bet = bet;
            ErrorMessage = exMsg;
            DoubleFactor = doubleFactor;
        }

        [DataMember]
        public Double DoubleFactor { get; set; }
        [DataMember]
        public Player Player { get; private set; }
        [DataMember]
        public Player Dealer { get; private set; }
        [DataMember]
        public Boolean GameIsOver { get; private set; }
        [DataMember]
        public Player Winner { get; private set; }
        [DataMember]
        public Int32 Bet { get; private set; }
        [DataMember]
        public String ErrorMessage { get; set; }
    }
}
