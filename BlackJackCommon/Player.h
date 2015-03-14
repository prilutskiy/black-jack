#pragma once
#include "Card.h"
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;

namespace BlackJack{
	namespace Common {
		public ref class Player
		{
		public:
			List<Card^>^ cards;
		public:
			Player(){}
			void TakeCard(int count)
			{
				throw gcnew NotImplementedException();
			}
		};
	}
}

