using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    [DataContract]
    public enum PlayerType
    {
        NotSet = 0,
        Player = 1,
        Dealer = 2,
        Draw = 3,
    }

    [DataContract]
    public class Player
    {
        [DataMember]
        public Guid Id { get; set; }
        public void ChangeCash(int value)
        {
            Cash += value;
        }
        [DataMember]
        public PlayerType PlayerType { get; private set; }
        [DataMember]
        public Int32 Cash { get; private set; }
        [DataMember]
        public Int32 CardScore { get; private set; }
        [DataMember]
        public String Username { get; internal set; }
        [DataMember]
        public List<Card> Cards { get; private set; }

        public bool GameFound { get; set; }

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
        public Player(PlayerType playerType, string username = "")
        {
            this.PlayerType = playerType;
            Cards = new List<Card>();
            Username = username;
            Cash = 1000;
        }

        public void Populate(Player player)
        {
            Id = player.Id;
            Cash = player.Cash;
            Username = player.Username;
            PlayerType = player.PlayerType;
            Cards = new List<Card>();
        }
        public void TakeCard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var c = CardFactory.SpawnCard();
                Cards.Add(c);
                RecalculateCardScore();
            }
        }
        public void Clear()
        {
            Cards.Clear();
            CardScore = 0;
        }
    }
}
