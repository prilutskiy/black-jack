#pragma once
using namespace System;
using namespace BlackJack::Common;
namespace BlackJack
{
	namespace Client
	{
		public ref class ClientGameManager : IBjGameManager
		{	
		private:
			void Clear()
			{
				EndGame = false;
				doubleFactor = 1.0;
				Winner = nullptr;
				dealer->cards->Clear(); dealer->CardScore = 0;
				userPlayer->cards->Clear(); userPlayer->CardScore = 0;
			}
		public:
			Player^ userPlayer;
			Player^ dealer;	
			Player^ Winner;
			GameStage gameStage = GameStage::NotSet;
			Int32 Bet = 100;
			Double doubleFactor = 1.0;
			event EventHandler<CardEventArgs^>^ GameOver;
			bool EndGame = false;
		public:
			virtual void DoNothing()
			{
				System::Windows::Forms::MessageBox::Show("Hello, world!");
			}
			ClientGameManager()
			{
				doubleFactor = 1.0;
				Winner = nullptr;
				userPlayer = gcnew Player();  userPlayer->PlayerType = PlayerType::Player;
				dealer = gcnew Player(); dealer->PlayerType = PlayerType::Dealer;
			}
			void StartGame()
			{
				Clear();
				dealer->TakeCard(2);

				userPlayer->TakeCard(2);
				CalculateWinner();
			}

			void DoubleBet()
			{
				if (EndGame)
					throw gcnew InvalidOperationException("Game is over");
				doubleFactor = 2.0;
				EndGame = true;
				userPlayer->TakeCard(1);
				if (userPlayer->CardScore > 21)
				{
					CalculateWinner();
					return;
				}
				while (dealer->CardScore < 16)
					dealer->TakeCard(1);
				CalculateWinner();
			}
			
			void Enough()
			{
				if (EndGame)
					throw gcnew InvalidOperationException("Game is over");
				EndGame = true;
				while (dealer->CardScore < 16)
					dealer->TakeCard(1);
				CalculateWinner();
			}
			void OneMoreCard()
			{
				if (EndGame)
					throw gcnew InvalidOperationException("Game is over");
				userPlayer->TakeCard(1);
				if (userPlayer->CardScore >= 21)
				{
					EndGame = true;
					CalculateWinner();
				}
			}
			Player^ CreateDraftPlayer()
			{
				auto p = gcnew Player();
				p->Username = "Draw";
				return p;
			}
			void CalculateWinner()
			{
				if (!EndGame)
				{
					if (IsBlackJack(dealer) && IsBlackJack(userPlayer))
						Winner = CreateDraftPlayer();
					else 
					{
						if (IsBlackJack(dealer))
							Winner = dealer;
						if (IsBlackJack(userPlayer))
							Winner = userPlayer;
					}
				}
				else
				{
					if (dealer->CardScore == 21)
						if (userPlayer->CardScore == 21)
							Winner = CreateDraftPlayer();
						else
							Winner = dealer;
					else if (userPlayer->CardScore == 21)
						if (dealer->CardScore == 21)
							Winner = CreateDraftPlayer();
						else
							Winner = userPlayer;
					else if (userPlayer->CardScore > 21)
						Winner = dealer;
					else if (userPlayer->CardScore > dealer->CardScore)
						Winner = userPlayer;
					else if (dealer->CardScore > userPlayer->CardScore)
						Winner = dealer;
					else
						Winner = CreateDraftPlayer();
				}
				
				/*
				if (dealer->CardScore == 21)
					Winner = dealer;
				else if (userPlayer->CardScore > 21)
					Winner = dealer;
				else if (dealer->CardScore > 21)
					Winner = userPlayer;
				else if (userPlayer->CardScore == dealer->CardScore)
				{
					Winner = gcnew Player();
					Winner->Username = "Draw";
				}
				*/
				CalculatePrize();
			}
			bool IsBlackJack(Player^ player)
			{
				if (player->cards->Count == 2 && player->CardScore == 21)
					return true;
				return false;
			}
			void CalculatePrize()
			{
				int prize = Bet;
				if (Winner == nullptr)
					return;
				if (Winner->Username == "Draw")
					return;

				if (IsBlackJack(Winner))
					doubleFactor *= 1.5;
				if (Winner->PlayerType == PlayerType::Player)
					userPlayer->Cash += prize * doubleFactor;
				else
					userPlayer->Cash -= prize * doubleFactor;
				GameOver(this, gcnew CardEventArgs(Winner, nullptr, Winner->CardScore));
			}
		};
	}
}
