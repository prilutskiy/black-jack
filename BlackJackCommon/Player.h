#pragma once
#include "CardFactory.h"
#include "CardEventArgs.h"
#include "PlayerType.h"

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;

namespace BlackJack{
	namespace Common {
		public ref class Player
		{
		public:
			PlayerType PlayerType = PlayerType::NotSet;
			Int32 Cash = 1000;
			Int32 CardScore = 0;
			String^ Username = "";
			List<Card^>^ cards;
			event EventHandler<CardEventArgs^>^ CardTaken;
			event EventHandler<CardEventArgs^>^ HandCompleted;
			static Int32 GetCardWeight(CardValue cValue)
			{
				switch (cValue)
				{
				case BlackJack::Common::CardValue::NotSet:
					throw gcnew InvalidOperationException("CardValue not set");
					break;
				case BlackJack::Common::CardValue::Ace:
					return 11;
					break;
				case BlackJack::Common::CardValue::Two:
					return 2;
					break;
				case BlackJack::Common::CardValue::Three:
					return 3;
					break;
				case BlackJack::Common::CardValue::Four:
					return 4;
					break;
				case BlackJack::Common::CardValue::Five:
					return 5;
					break;
				case BlackJack::Common::CardValue::Six:
					return 6;
					break;
				case BlackJack::Common::CardValue::Seven:
					return 7;
					break;
				case BlackJack::Common::CardValue::Eight:
					return 8;
					break;
				case BlackJack::Common::CardValue::Nine:
					return 9;
					break;
				case BlackJack::Common::CardValue::Ten:
					return 10;
					break;
				case BlackJack::Common::CardValue::Jack:
					return 10;
					break;
				case BlackJack::Common::CardValue::Queen:
					return 10;
					break;
				case BlackJack::Common::CardValue::King:
					return 10;
					break;
				default:
					throw gcnew NotSupportedException("Unexpected enum value");
					break;
				}
			}
		private:
			void RecalculateCardScore()
			{
				Int32 aceCount = 0;
				for each (Card^ card in cards)
					if (card->GetValue() == CardValue::Ace)
						aceCount++;
				CardScore = 0;
				for each (Card^ card in cards)
					CardScore += GetCardWeight(card->GetValue());
				if (aceCount == 0) return;
				while (CardScore > 21)
				{
					if (aceCount == 0)
						break;
					aceCount--;
					CardScore -= 10;
				}
			}
		public:
			Player()
			{
				cards = gcnew List<Card^>();
			}
			void TakeCard(int count)
			{
				for (int i = 0; i < count; i++)
				{
					auto c = CardFactory::SpawnCard();
					cards->Add(c);	
					RecalculateCardScore();					
					CardTaken(this, gcnew CardEventArgs(this, c, this->CardScore));
				}
			}
		};		
	}
}

