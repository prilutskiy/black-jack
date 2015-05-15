using System;

namespace BlackJack.Common
{
    public class CardEventArgs : EventArgs
    {
        public readonly Card Card;
        public readonly Int32 CardScore;
        public readonly Player Player;

        public CardEventArgs()
        {
        }

        public CardEventArgs(Player p, Card c, Int32 cardScore)
        {
            Player = p;
            Card = c;
            CardScore = cardScore;
        }
    }
}