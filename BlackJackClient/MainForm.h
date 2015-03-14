#pragma once

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
				this->SuspendLayout();
				// 
				// MainForm
				// 
				this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
				this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
				this->ClientSize = System::Drawing::Size(380, 457);
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
			}
		};
	}
}