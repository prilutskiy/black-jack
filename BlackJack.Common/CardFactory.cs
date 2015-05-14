using System;
using System.Collections.Generic;

namespace BlackJack.Common
{
    public static class CardFactory
    {
        private static readonly Random rand = new Random();
        public static List<Card> AlreadySpawned = new List<Card>();

        public static Card SpawnCard(bool needCleaning = false)
        {
            if (needCleaning)
                ResetGenerator();
            Card c;
            while (true)
            {
                var suit = rand.Next(1, 5);
                var value = rand.Next(1, 14);
                c = new Card(suit, value);
                if (!AlreadySpawned.Contains(c))
                    break;
            }
            AlreadySpawned.Add(c);
            return c;
        }

        private static void ResetGenerator()
        {
            AlreadySpawned.Clear();
        }
    }
}