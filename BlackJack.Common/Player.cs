using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlackJack.Common
{
    [Serializable]
    [DataContract]
    public enum PlayerType
    {
        NotSet = 0,
        Player = 1,
        Dealer = 2,
        Draw = 3
    }

    [Serializable]
    [DataContract]
    public class Player : IUser
    {
        public Player(PlayerType playerType, string username = "")
        {
            PlayerType = playerType;
            Cards = new List<Card>();
            Username = username;
            Cash = 1000;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public PlayerType PlayerType { get;  set; }

        [DataMember]
        public Int32 Cash { get;  set; }

        [DataMember]
        public Int32 CardScore { get; private set; }

        [DataMember]
        public String Username { get;  set; }

        [DataMember]
        public List<Card> Cards { get; private set; }

        public bool GameFound { get; set; }

        public void ChangeCash(int value)
        {
            Cash += value;
        }

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
            for (var i = 0; i < count; i++)
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