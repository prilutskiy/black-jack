#pragma once
using namespace System;


namespace BlackJack{
	namespace Common {
		ref class Player;
		ref class Card;
		public ref class CardEventArgs : EventArgs
		{
		public:
			CardEventArgs() : EventArgs()
			{
			}
			CardEventArgs(Player^ p, Card^ c, Int32 cardScore)
			{
				this->Card = c;
				this->Player = p;
				this->CardScore = cardScore;
			}
		public:
			initonly Player^ Player;
			initonly Card^ Card;
			initonly Int32 CardScore;
		};
	}
}