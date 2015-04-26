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
        public static Card SpawnCard(bool needCleaning = false)
        {
            if (needCleaning)
                ResetGenerator();
            Card c;
            while (true)
            {
                int suit = rand.Next(1, 5);
                int value = rand.Next(1, 14);
                c = new Card(suit, value);
                if (!AlreadySpawned.Contains(c))
                    break;
            }
            AlreadySpawned.Add(c);
            return c;
        }
        public static List<Card> AlreadySpawned = new List<Card>();

        private static void ResetGenerator()
        {
            AlreadySpawned.Clear();
        }
    }
}
