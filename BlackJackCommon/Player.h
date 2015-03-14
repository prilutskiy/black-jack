#pragma once
#include "Card.h"
#include "CardFactory.h"
#include "CardEventArgs.h"

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;

namespace BlackJack{
	namespace Common {
		public ref class Player
		{
		public:
			
			List<Card^>^ cards;
			event EventHandler<CardEventArgs^>^ CardTaken;
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
					
					CardTaken(this, gcnew CardEventArgs(this, c));
				}
			}
		};		
	}
}

