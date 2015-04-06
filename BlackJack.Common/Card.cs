using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public enum CardSuit : int
    {
        NotSet = 0,
        Spades = 1,
        Clubs = 2,
        Hearts = 3,
        Diamonds = 4,
    }

    public enum CardValue : int
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
        King = 13,
    }
    public class Card
    {
        public Card(int suit, int value)
        {
            this.Suit = (CardSuit) suit;
            this.Value = (CardValue) value;
            cardImgPath = String.Format("\\{0}\\{1}.png", suit, value);
        }

        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }
        private String cardImgPath = String.Empty;

        static String SuitToString(CardSuit suit)
			{
				switch (suit)
				{
				case BlackJack.Common.CardSuit.NotSet:
					return "NotSet";
					break;
				case BlackJack.Common.CardSuit.Spades:
					return "Spades";
					break;
				case BlackJack.Common.CardSuit.Clubs:
					return "Clubs";
					break;
				case BlackJack.Common.CardSuit.Hearts:
					return "Hearts";
					break;
				case BlackJack.Common.CardSuit.Diamonds:
					return "Diamonds";
					break;
				default:
					throw new InvalidOperationException();
					break;
				}
			}

        static String ValueToString(CardValue value)
			{
				switch (value)
				{
				case BlackJack.Common.CardValue.NotSet:
					return "NotSet";
					break;
				case BlackJack.Common.CardValue.Ace:
					return "Ace";
					break;
				case BlackJack.Common.CardValue.Two:
					return "Two";
					break;
				case BlackJack.Common.CardValue.Three:
					return "Three";
					break;
				case BlackJack.Common.CardValue.Four:
					return "Four";
					break;
				case BlackJack.Common.CardValue.Five:
					return "Five";
					break;
				case BlackJack.Common.CardValue.Six:
					return "Six";
					break;
				case BlackJack.Common.CardValue.Seven:
					return "Seven";
					break;
				case BlackJack.Common.CardValue.Eight:
					return "Eight";
					break;
				case BlackJack.Common.CardValue.Nine:
					return "Nine";
					break;
				case BlackJack.Common.CardValue.Ten:
					return "Ten";
					break;
				case BlackJack.Common.CardValue.Jack:
					return "Jack";
					break;
				case BlackJack.Common.CardValue.Queen:
					return "Queen";
					break;
				case BlackJack.Common.CardValue.King:
					return "King";
					break;
				default:
					throw new InvalidOperationException();
					break;
				}
			}
    }


}
