#pragma once
#include "CardSuit.h"
using namespace System;


namespace BlackJack{
	namespace Common {
		public ref class Card
		{
			CardSuit suit = CardSuit::NotSet;
			CardValue value = CardValue::NotSet;
			String^ cardImgFilePath = "";
		public:
			Card(int suit, int value)
			{
				this->suit = (CardSuit)suit;
				this->value = (CardValue)value;
				this->cardImgFilePath = String::Format("\\{0}\\{1}.png", suit, value);
			}
		public:
			CardSuit GetSuit()
			{
				return suit;
			}
			CardValue GetValue()
			{
				return value;
			}
			/*Converts CardSuit enum instance to its string representation*/
			static String ^ SuitToString(CardSuit suit)
			{
				switch (suit)
				{
				case BlackJack::Common::CardSuit::NotSet:
					return "NotSet";
					break;
				case BlackJack::Common::CardSuit::Spades:
					return "Spades";
					break;
				case BlackJack::Common::CardSuit::Clubs:
					return "Clubs";
					break;
				case BlackJack::Common::CardSuit::Hearts:
					return "Hearts";
					break;
				case BlackJack::Common::CardSuit::Diamonds:
					return "Diamonds";
					break;
				default:
					throw gcnew InvalidOperationException();
					break;
				}
			}
			/*Converts CardValue enum instance to its string representation*/
			static String ^ ValueToString(CardValue value)
			{
				switch (value)
				{
				case BlackJack::Common::CardValue::NotSet:
					return "NotSet";
					break;
				case BlackJack::Common::CardValue::Ace:
					return "Ace";
					break;
				case BlackJack::Common::CardValue::Two:
					return "Two";
					break;
				case BlackJack::Common::CardValue::Three:
					return "Three";
					break;
				case BlackJack::Common::CardValue::Four:
					return "Four";
					break;
				case BlackJack::Common::CardValue::Five:
					return "Five";
					break;
				case BlackJack::Common::CardValue::Six:
					return "Six";
					break;
				case BlackJack::Common::CardValue::Seven:
					return "Seven";
					break;
				case BlackJack::Common::CardValue::Eight:
					return "Eight";
					break;
				case BlackJack::Common::CardValue::Nine:
					return "Nine";
					break;
				case BlackJack::Common::CardValue::Ten:
					return "Ten";
					break;
				case BlackJack::Common::CardValue::Jack:
					return "Jack";
					break;
				case BlackJack::Common::CardValue::Queen:
					return "Queen";
					break;
				case BlackJack::Common::CardValue::King:
					return "King";
					break;
				default:
					throw gcnew InvalidOperationException();
					break;
				}
			}
		};
	}
}