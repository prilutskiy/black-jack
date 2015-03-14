#pragma once
#include "ClientGameManager.h"
namespace BlackJack{
	namespace Client {

		using namespace System;
		using namespace System::ComponentModel;
		using namespace System::Collections;
		using namespace System::Windows::Forms;
		using namespace System::Data;
		using namespace System::Drawing;

		/// <summary>
		/// Summary for MainForm
		/// </summary>
		public ref class MainForm : public System::Windows::Forms::Form
		{
#pragma region Windows Form Designer generated code
		protected:
			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			~MainForm()
			{
				if (components)
				{
					delete components;
				}
			}
		private: System::Windows::Forms::ListBox^  listBox1;
		private: System::Windows::Forms::Button^  takeCardButton;
		private: System::Windows::Forms::Button^  doubleButton;
		private: System::Windows::Forms::Button^  enoughButton;
		private: System::Windows::Forms::Button^  newGameButton;
		protected:

		protected:


		private:
			/// <summary>
			/// Required designer variable.
			/// </summary>
			System::ComponentModel::Container ^components;

			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			void InitializeComponent(void)
			{
				this->listBox1 = (gcnew System::Windows::Forms::ListBox());
				this->takeCardButton = (gcnew System::Windows::Forms::Button());
				this->doubleButton = (gcnew System::Windows::Forms::Button());
				this->enoughButton = (gcnew System::Windows::Forms::Button());
				this->newGameButton = (gcnew System::Windows::Forms::Button());
				this->SuspendLayout();
				// 
				// listBox1
				// 
				this->listBox1->FormattingEnabled = true;
				this->listBox1->Location = System::Drawing::Point(12, 12);
				this->listBox1->Name = L"listBox1";
				this->listBox1->ScrollAlwaysVisible = true;
				this->listBox1->Size = System::Drawing::Size(304, 342);
				this->listBox1->TabIndex = 0;
				// 
				// takeCardButton
				// 
				this->takeCardButton->Location = System::Drawing::Point(79, 396);
				this->takeCardButton->Name = L"takeCardButton";
				this->takeCardButton->Size = System::Drawing::Size(75, 23);
				this->takeCardButton->TabIndex = 1;
				this->takeCardButton->Text = L"Take card";
				this->takeCardButton->UseVisualStyleBackColor = true;
				this->takeCardButton->Click += gcnew System::EventHandler(this, &MainForm::takeCardButton_Click);
				// 
				// doubleButton
				// 
				this->doubleButton->Location = System::Drawing::Point(160, 396);
				this->doubleButton->Name = L"doubleButton";
				this->doubleButton->Size = System::Drawing::Size(75, 23);
				this->doubleButton->TabIndex = 2;
				this->doubleButton->Text = L"Double bet";
				this->doubleButton->UseVisualStyleBackColor = true;
				this->doubleButton->Click += gcnew System::EventHandler(this, &MainForm::doubleButton_Click);
				// 
				// enoughButton
				// 
				this->enoughButton->Location = System::Drawing::Point(241, 396);
				this->enoughButton->Name = L"enoughButton";
				this->enoughButton->Size = System::Drawing::Size(75, 23);
				this->enoughButton->TabIndex = 3;
				this->enoughButton->Text = L"Enough";
				this->enoughButton->UseVisualStyleBackColor = true;
				this->enoughButton->Click += gcnew System::EventHandler(this, &MainForm::enoughButton_Click);
				// 
				// newGameButton
				// 
				this->newGameButton->Location = System::Drawing::Point(160, 360);
				this->newGameButton->Name = L"newGameButton";
				this->newGameButton->Size = System::Drawing::Size(75, 23);
				this->newGameButton->TabIndex = 4;
				this->newGameButton->Text = L"New game";
				this->newGameButton->UseVisualStyleBackColor = true;
				this->newGameButton->Click += gcnew System::EventHandler(this, &MainForm::newGameButton_Click);
				// 
				// MainForm
				// 
				this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
				this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
				this->ClientSize = System::Drawing::Size(380, 457);
				this->Controls->Add(this->newGameButton);
				this->Controls->Add(this->enoughButton);
				this->Controls->Add(this->doubleButton);
				this->Controls->Add(this->takeCardButton);
				this->Controls->Add(this->listBox1);
				this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::Fixed3D;
				this->MaximizeBox = false;
				this->Name = L"MainForm";
				this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
				this->Text = L"Balck Jack";
				this->ResumeLayout(false);

			}
#pragma endregion


		public:
			MainForm(void)
			{
				InitializeComponent();
				auto img = gcnew Bitmap("back.png");
				this->BackgroundImage = img;
				gm->userPlayer->CardTaken += gcnew System::EventHandler<BlackJack::Common::CardEventArgs ^>(this, &BlackJack::Client::MainForm::OnCardTaken);
				gm->dealer->CardTaken += gcnew System::EventHandler<BlackJack::Common::CardEventArgs ^>(this, &BlackJack::Client::MainForm::OnCardTaken);
				gm->GameOver += gcnew System::EventHandler<BlackJack::Common::CardEventArgs ^>(this, &BlackJack::Client::MainForm::OnGameOver);
			}
			ClientGameManager^gm = gcnew ClientGameManager();
		private: System::Void takeCardButton_Click(System::Object^  sender, System::EventArgs^  e) {
			gm->OneMoreCard();
		}
		private: System::Void newGameButton_Click(System::Object^  sender, System::EventArgs^  e) {
			listBox1->Items->Clear();
			gm->StartGame();
		}
		private: System::Void doubleButton_Click(System::Object^  sender, System::EventArgs^  e) {
			gm->DoubleBet();
		}
		private: System::Void enoughButton_Click(System::Object^  sender, System::EventArgs^  e) {
			gm->Enough();
		}
				 void OnCardTaken(System::Object ^sender, BlackJack::Common::CardEventArgs ^e)
				 {
					 listBox1->Items->Add(String::Format("{0} takes {2}({4}) of {1}. {0}'s card score: {3}",
						 e->Player->PlayerType == PlayerType::Dealer ? "Dealer" : "Player",
						 Card::SuitToString(e->Card->GetSuit()),
						 Card::ValueToString(e->Card->GetValue()),
						 e->CardScore,
						 Player::GetCardWeight(e->Card->GetValue())));
				 }
				 void OnGameOver(System::Object ^sender, BlackJack::Common::CardEventArgs ^e)
				 {
					 MessageBox::Show(String::Format("{0} won the game with {1} points",
						 e->Player->PlayerType == PlayerType::Dealer ? "Dealer" : "Player",
						 e->CardScore));
				 }
		};
	}
}