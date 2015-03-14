#pragma once
using namespace BlackJack::Common;
namespace BlackJack
{
	namespace Client
	{
		public ref class ClientGameManager : IBjGameManager
		{			
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
			Player^ userPlayer;
			Player^ dealer;
		};
	}
}

