using System;

namespace BlackJack.Common
{
    public static class CardExtensions
    {
        public static Int32 GetWeight(this Card card)
        {
            switch (card.Value)
            {
                case CardValue.NotSet:
                    throw new InvalidOperationException("CardValue not set");
                case CardValue.Ace:
                    return 11;
                case CardValue.Two:
                    return 2;
                case CardValue.Three:
                    return 3;
                case CardValue.Four:
                    return 4;
                case CardValue.Five:
                    return 5;
                case CardValue.Six:
                    return 6;
                case CardValue.Seven:
                    return 7;
                case CardValue.Eight:
                    return 8;
                case CardValue.Nine:
                    return 9;
                case CardValue.Ten:
                    return 10;
                case CardValue.Jack:
                    return 10;
                case CardValue.Queen:
                    return 10;
                case CardValue.King:
                    return 10;
                default:
                    throw new NotSupportedException("Unexpected enum value");
            }
        }
    }
}