using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public static class CardFactory
    {
        private static Random rand = new Random();
        public static Card SpawnCard()
        {
            int suit = rand.Next(1, 4);
            int value = rand.Next(1, 13);
            var c = new Card(suit, value);
            return c;
        }
    }
}
