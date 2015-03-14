#pragma once

namespace BlackJack
{
	namespace Common
	{
		public enum class GameStage
		{
			NotSet = 0,
			PlayerTakes,
			DealerTakes,
			DealerTakesUpTo21
		};

	}
}