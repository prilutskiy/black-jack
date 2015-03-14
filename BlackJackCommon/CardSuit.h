#pragma once

namespace BlackJack
{
	namespace Common 
	{
		enum class CardSuit : System::Int32
		{
			NotSet = 0,
			Spades = 1,
			Clubs = 2,
			Hearts = 3,
			Diamonds = 4,
		};
		enum class CardValue : System::Int32
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
		};
	}
}