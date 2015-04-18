using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public class CardEventArgs : EventArgs
    {
        public CardEventArgs()
        {
        }

        public CardEventArgs(Player p, Card c, Int32 cardScore)
        {
            Player = p;
            Card = c;
            CardScore = cardScore;
        }

        public readonly Player Player;
        public readonly Card Card;
        public readonly Int32 CardScore;
    }
}
