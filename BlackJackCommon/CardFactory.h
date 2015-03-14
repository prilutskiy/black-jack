#pragma once
#include "Card.h"
using namespace System;

namespace BlackJack
{
	namespace Common 
	{
		static public ref class CardFactory
		{
		public:
			static Random^ rand = gcnew Random();
			static Card^ SpawnCard()
			{
				int suit = rand->Next(1, 4);
				int value = rand->Next(1, 13);
				auto c = gcnew Card(suit, value);
				return c;
			}
		};
	}
}
