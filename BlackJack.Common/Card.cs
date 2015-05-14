using System;
using System.Runtime.Serialization;

namespace BlackJack.Common
{
    [Serializable]
    [DataContract]
    public enum CardSuit
    {
        NotSet = 0,
        Spades = 1,
        Clubs = 2,
        Hearts = 3,
        Diamonds = 4
    }

    [Serializable]
    [DataContract]
    public enum CardValue
    {
        NotSet = 0,
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    [Serializable]
    [DataContract]
    public class Card
    {
        public Card(int suit, int value)
        {
            Suit = (CardSuit) suit;
            Value = (CardValue) value;
            CardImgPath = String.Format("Images/Cards/{0}/{1}.png", suit, value);
        }

        [DataMember]
        public CardSuit Suit { get; private set; }

        [DataMember]
        public CardValue Value { get; private set; }

        [DataMember]
        public String CardImgPath { get; private set; }
    }
}