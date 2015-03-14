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
			CardEventArgs(Player^ p, Card^ c)
			{
				this->Card = c;
				this->Player = p;
			}
		public:
			Player^ Player;
			Card^ Card;
		};
	}
}