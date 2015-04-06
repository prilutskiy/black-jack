using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public enum PlayerType
    {
        NotSet = 0,
        Player = 1,
        Dealer = 2,
    }

    public class Player
    {
        public PlayerType PlayerType { get; private set; }
        public Int32 Cash { get; private set; }
        public Int32 CardScore { get; private set; }
        public List<Card> Cards { get; private set; }

        public event EventHandler<CardEventArgs> CardTaken;
        public event EventHandler<CardEventArgs> HandCompleted;

        private void RecalculateCardScore()
        {
            var aceCount = 0;
            foreach (var card in Cards)
                if (card.Value == CardValue.Ace)
                    aceCount++;
            CardScore = 0;
            foreach (var card in Cards)
                CardScore += card.GetWeight();
            if (aceCount == 0) return;
            while (CardScore > 21)
            {
                if (aceCount == 0)
                    break;
                aceCount--;
                CardScore -= 10;
            }
        }

        public Player()
        {
            Cards = new List<Card>();
        }

        public void TakeCard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var c = CardFactory.SpawnCard();
                Cards.Add(c);
                RecalculateCardScore();
                if (CardTaken != null)
                    CardTaken(this, new CardEventArgs(this, c, this.CardScore));
            }
        }
    }
}
