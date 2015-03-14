#pragma once
using namespace BlackJack::Common;
namespace BlackJack
{
	namespace Client
	{
		public ref class ClientGameManager : IBjGameManager
		{	
		public:
			Player^ userPlayer;
			Player^ dealer;	
		public:
			virtual void DoNothing()
			{
				System::Windows::Forms::MessageBox::Show("Hello, world!");
			}
			ClientGameManager()
			{
				userPlayer = gcnew Player();
				dealer = gcnew Player();
			}
			void StartGame()
			{
				dealer->TakeCard(2);
				userPlayer->TakeCard(2);
			}
		};
	}
}

