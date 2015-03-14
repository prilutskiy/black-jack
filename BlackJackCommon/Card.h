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
				this->cardImgFilePath = String::Format("\{0}\{1}.png", suit, value);
			}
			virtual String^ ToString() override
			{
				return String::Format("Suit: {0}\nValue: {1}\nRelative img path: {2}", 
					CardSuitToString(suit), CardValueToString(value));
			}
		public:
			static String^ CardSuitToString(CardSuit suit)
			{
				return gcnew String(suit.ToString());
			}
			static String^ CardValueToString(CardValue value)
			{
				return gcnew String(value.ToString());
			}
		};
	}
}