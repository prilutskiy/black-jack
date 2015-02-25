#pragma once

namespace BlackJackServer {

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
	public:
		MainForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

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
	private: System::Windows::Forms::MenuStrip^  serverMenuStrip;
	protected:
	protected:
	private: System::Windows::Forms::ToolStripMenuItem^  fileToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  newToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  openToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator;
	private: System::Windows::Forms::ToolStripMenuItem^  saveToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  saveAsToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator1;
	private: System::Windows::Forms::ToolStripMenuItem^  printToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  printPreviewToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator2;
	private: System::Windows::Forms::ToolStripMenuItem^  exitToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  toolsToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  customizeToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  optionsToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  helpToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  aboutToolStripMenuItem;
	private: System::Windows::Forms::StatusStrip^  statusStrip1;
	private: System::Windows::Forms::ToolStripStatusLabel^  clientsLabel;
	private: System::Windows::Forms::ToolStripStatusLabel^  memusageLabel;
	private: DevExpress::XtraTab::XtraTabControl^  xtraTabControl;
	private: DevExpress::XtraTab::XtraTabPage^  xtraTabPage1;
	private: DevExpress::XtraEditors::GroupControl^  logGroupControl;
	private: DevExpress::XtraTab::XtraTabPage^  xtraTabPage2;
	private: DevExpress::XtraEditors::GroupControl^  statGroupControl;
	private: DevExpress::XtraTab::XtraTabPage^  xtraTabPage3;
	private: DevExpress::XtraEditors::GroupControl^  resGroupControl;
	private: DevExpress::XtraCharts::ChartControl^  chartControl1;
	private: DevExpress::XtraEditors::GroupControl^  msgGroupControl;
	private: System::Windows::Forms::ListView^  logMsgListView;
	private: System::Windows::Forms::ColumnHeader^  columnHeader1;
	private: System::Windows::Forms::ColumnHeader^  columnHeader2;
	private: System::Windows::Forms::ColumnHeader^  columnHeader3;
	private: System::Windows::Forms::ColumnHeader^  columnHeader4;
	private: DevExpress::XtraEditors::GroupControl^  logFiltersGroupControl;
	private: DevExpress::XtraEditors::CheckEdit^  errorsCheckEdit;
	private: DevExpress::XtraEditors::CheckEdit^  prizesCheckEdit;
	private: DevExpress::XtraEditors::CheckEdit^  connectionCheckEdit;
	private: DevExpress::XtraEditors::CheckEdit^  methodCheckEdit;
	protected:
	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MainForm::typeid));
			DevExpress::XtraCharts::XYDiagram^  xyDiagram1 = (gcnew DevExpress::XtraCharts::XYDiagram());
			DevExpress::XtraCharts::Series^  series1 = (gcnew DevExpress::XtraCharts::Series());
			DevExpress::XtraCharts::SplineAreaSeriesView^  splineAreaSeriesView1 = (gcnew DevExpress::XtraCharts::SplineAreaSeriesView());
			DevExpress::XtraCharts::Series^  series2 = (gcnew DevExpress::XtraCharts::Series());
			DevExpress::XtraCharts::SplineAreaSeriesView^  splineAreaSeriesView2 = (gcnew DevExpress::XtraCharts::SplineAreaSeriesView());
			DevExpress::XtraCharts::SplineAreaSeriesView^  splineAreaSeriesView3 = (gcnew DevExpress::XtraCharts::SplineAreaSeriesView());
			this->serverMenuStrip = (gcnew System::Windows::Forms::MenuStrip());
			this->fileToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->newToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->saveToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->saveAsToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator1 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->printToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->printPreviewToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator2 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->exitToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolsToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->customizeToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->optionsToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->helpToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->aboutToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->statusStrip1 = (gcnew System::Windows::Forms::StatusStrip());
			this->clientsLabel = (gcnew System::Windows::Forms::ToolStripStatusLabel());
			this->memusageLabel = (gcnew System::Windows::Forms::ToolStripStatusLabel());
			this->xtraTabControl = (gcnew DevExpress::XtraTab::XtraTabControl());
			this->xtraTabPage1 = (gcnew DevExpress::XtraTab::XtraTabPage());
			this->logGroupControl = (gcnew DevExpress::XtraEditors::GroupControl());
			this->msgGroupControl = (gcnew DevExpress::XtraEditors::GroupControl());
			this->logMsgListView = (gcnew System::Windows::Forms::ListView());
			this->columnHeader1 = (gcnew System::Windows::Forms::ColumnHeader());
			this->columnHeader2 = (gcnew System::Windows::Forms::ColumnHeader());
			this->columnHeader3 = (gcnew System::Windows::Forms::ColumnHeader());
			this->columnHeader4 = (gcnew System::Windows::Forms::ColumnHeader());
			this->logFiltersGroupControl = (gcnew DevExpress::XtraEditors::GroupControl());
			this->errorsCheckEdit = (gcnew DevExpress::XtraEditors::CheckEdit());
			this->prizesCheckEdit = (gcnew DevExpress::XtraEditors::CheckEdit());
			this->connectionCheckEdit = (gcnew DevExpress::XtraEditors::CheckEdit());
			this->methodCheckEdit = (gcnew DevExpress::XtraEditors::CheckEdit());
			this->xtraTabPage2 = (gcnew DevExpress::XtraTab::XtraTabPage());
			this->statGroupControl = (gcnew DevExpress::XtraEditors::GroupControl());
			this->xtraTabPage3 = (gcnew DevExpress::XtraTab::XtraTabPage());
			this->resGroupControl = (gcnew DevExpress::XtraEditors::GroupControl());
			this->chartControl1 = (gcnew DevExpress::XtraCharts::ChartControl());
			this->serverMenuStrip->SuspendLayout();
			this->statusStrip1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->xtraTabControl))->BeginInit();
			this->xtraTabControl->SuspendLayout();
			this->xtraTabPage1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->logGroupControl))->BeginInit();
			this->logGroupControl->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->msgGroupControl))->BeginInit();
			this->msgGroupControl->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->logFiltersGroupControl))->BeginInit();
			this->logFiltersGroupControl->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->errorsCheckEdit->Properties))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->prizesCheckEdit->Properties))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->connectionCheckEdit->Properties))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->methodCheckEdit->Properties))->BeginInit();
			this->xtraTabPage2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->statGroupControl))->BeginInit();
			this->xtraTabPage3->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->resGroupControl))->BeginInit();
			this->resGroupControl->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chartControl1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(xyDiagram1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(series1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(series2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView3))->BeginInit();
			this->SuspendLayout();
			// 
			// serverMenuStrip
			// 
			this->serverMenuStrip->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {
				this->fileToolStripMenuItem,
					this->toolsToolStripMenuItem, this->helpToolStripMenuItem
			});
			this->serverMenuStrip->Location = System::Drawing::Point(0, 0);
			this->serverMenuStrip->Name = L"serverMenuStrip";
			this->serverMenuStrip->Size = System::Drawing::Size(805, 24);
			this->serverMenuStrip->TabIndex = 0;
			this->serverMenuStrip->Text = L"menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this->fileToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(10) {
				this->newToolStripMenuItem,
					this->openToolStripMenuItem, this->toolStripSeparator, this->saveToolStripMenuItem, this->saveAsToolStripMenuItem, this->toolStripSeparator1,
					this->printToolStripMenuItem, this->printPreviewToolStripMenuItem, this->toolStripSeparator2, this->exitToolStripMenuItem
			});
			this->fileToolStripMenuItem->Name = L"fileToolStripMenuItem";
			this->fileToolStripMenuItem->Size = System::Drawing::Size(37, 20);
			this->fileToolStripMenuItem->Text = L"&File";
			// 
			// newToolStripMenuItem
			// 
			this->newToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"newToolStripMenuItem.Image")));
			this->newToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->newToolStripMenuItem->Name = L"newToolStripMenuItem";
			this->newToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::N));
			this->newToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->newToolStripMenuItem->Text = L"&New";
			// 
			// openToolStripMenuItem
			// 
			this->openToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"openToolStripMenuItem.Image")));
			this->openToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->openToolStripMenuItem->Name = L"openToolStripMenuItem";
			this->openToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::O));
			this->openToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->openToolStripMenuItem->Text = L"&Open";
			// 
			// toolStripSeparator
			// 
			this->toolStripSeparator->Name = L"toolStripSeparator";
			this->toolStripSeparator->Size = System::Drawing::Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this->saveToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"saveToolStripMenuItem.Image")));
			this->saveToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->saveToolStripMenuItem->Name = L"saveToolStripMenuItem";
			this->saveToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::S));
			this->saveToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->saveToolStripMenuItem->Text = L"&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this->saveAsToolStripMenuItem->Name = L"saveAsToolStripMenuItem";
			this->saveAsToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->saveAsToolStripMenuItem->Text = L"Save &As";
			// 
			// toolStripSeparator1
			// 
			this->toolStripSeparator1->Name = L"toolStripSeparator1";
			this->toolStripSeparator1->Size = System::Drawing::Size(143, 6);
			// 
			// printToolStripMenuItem
			// 
			this->printToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"printToolStripMenuItem.Image")));
			this->printToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->printToolStripMenuItem->Name = L"printToolStripMenuItem";
			this->printToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::P));
			this->printToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->printToolStripMenuItem->Text = L"&Print";
			// 
			// printPreviewToolStripMenuItem
			// 
			this->printPreviewToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"printPreviewToolStripMenuItem.Image")));
			this->printPreviewToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->printPreviewToolStripMenuItem->Name = L"printPreviewToolStripMenuItem";
			this->printPreviewToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->printPreviewToolStripMenuItem->Text = L"Print Pre&view";
			// 
			// toolStripSeparator2
			// 
			this->toolStripSeparator2->Name = L"toolStripSeparator2";
			this->toolStripSeparator2->Size = System::Drawing::Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this->exitToolStripMenuItem->Name = L"exitToolStripMenuItem";
			this->exitToolStripMenuItem->Size = System::Drawing::Size(146, 22);
			this->exitToolStripMenuItem->Text = L"E&xit";
			// 
			// toolsToolStripMenuItem
			// 
			this->toolsToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {
				this->customizeToolStripMenuItem,
					this->optionsToolStripMenuItem
			});
			this->toolsToolStripMenuItem->Name = L"toolsToolStripMenuItem";
			this->toolsToolStripMenuItem->Size = System::Drawing::Size(48, 20);
			this->toolsToolStripMenuItem->Text = L"&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this->customizeToolStripMenuItem->Name = L"customizeToolStripMenuItem";
			this->customizeToolStripMenuItem->Size = System::Drawing::Size(130, 22);
			this->customizeToolStripMenuItem->Text = L"&Customize";
			// 
			// optionsToolStripMenuItem
			// 
			this->optionsToolStripMenuItem->Name = L"optionsToolStripMenuItem";
			this->optionsToolStripMenuItem->Size = System::Drawing::Size(130, 22);
			this->optionsToolStripMenuItem->Text = L"&Options";
			// 
			// helpToolStripMenuItem
			// 
			this->helpToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->aboutToolStripMenuItem });
			this->helpToolStripMenuItem->Name = L"helpToolStripMenuItem";
			this->helpToolStripMenuItem->Size = System::Drawing::Size(44, 20);
			this->helpToolStripMenuItem->Text = L"&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this->aboutToolStripMenuItem->Name = L"aboutToolStripMenuItem";
			this->aboutToolStripMenuItem->Size = System::Drawing::Size(116, 22);
			this->aboutToolStripMenuItem->Text = L"&About...";
			// 
			// statusStrip1
			// 
			this->statusStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) { this->clientsLabel, this->memusageLabel });
			this->statusStrip1->Location = System::Drawing::Point(0, 453);
			this->statusStrip1->Name = L"statusStrip1";
			this->statusStrip1->Size = System::Drawing::Size(805, 22);
			this->statusStrip1->TabIndex = 1;
			this->statusStrip1->Text = L"statusStrip1";
			// 
			// clientsLabel
			// 
			this->clientsLabel->Name = L"clientsLabel";
			this->clientsLabel->Size = System::Drawing::Size(62, 17);
			this->clientsLabel->Text = L"Clients: {x}";
			// 
			// memusageLabel
			// 
			this->memusageLabel->Name = L"memusageLabel";
			this->memusageLabel->Size = System::Drawing::Size(105, 17);
			this->memusageLabel->Text = L"Memory usage: {x}";
			// 
			// xtraTabControl
			// 
			this->xtraTabControl->Dock = System::Windows::Forms::DockStyle::Fill;
			this->xtraTabControl->HeaderLocation = DevExpress::XtraTab::TabHeaderLocation::Left;
			this->xtraTabControl->HeaderOrientation = DevExpress::XtraTab::TabOrientation::Horizontal;
			this->xtraTabControl->Location = System::Drawing::Point(0, 24);
			this->xtraTabControl->Name = L"xtraTabControl";
			this->xtraTabControl->SelectedTabPage = this->xtraTabPage1;
			this->xtraTabControl->Size = System::Drawing::Size(805, 429);
			this->xtraTabControl->TabIndex = 2;
			this->xtraTabControl->TabPages->AddRange(gcnew cli::array< DevExpress::XtraTab::XtraTabPage^  >(3) {
				this->xtraTabPage1, this->xtraTabPage2,
					this->xtraTabPage3
			});
			// 
			// xtraTabPage1
			// 
			this->xtraTabPage1->Controls->Add(this->logGroupControl);
			this->xtraTabPage1->Name = L"xtraTabPage1";
			this->xtraTabPage1->Size = System::Drawing::Size(735, 423);
			this->xtraTabPage1->Text = L"Logs";
			// 
			// logGroupControl
			// 
			this->logGroupControl->Controls->Add(this->msgGroupControl);
			this->logGroupControl->Controls->Add(this->logFiltersGroupControl);
			this->logGroupControl->Dock = System::Windows::Forms::DockStyle::Fill;
			this->logGroupControl->Location = System::Drawing::Point(0, 0);
			this->logGroupControl->Name = L"logGroupControl";
			this->logGroupControl->Size = System::Drawing::Size(735, 423);
			this->logGroupControl->TabIndex = 0;
			this->logGroupControl->Text = L"Server log meassages";
			// 
			// msgGroupControl
			// 
			this->msgGroupControl->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->msgGroupControl->Controls->Add(this->logMsgListView);
			this->msgGroupControl->Location = System::Drawing::Point(189, 24);
			this->msgGroupControl->Name = L"msgGroupControl";
			this->msgGroupControl->Size = System::Drawing::Size(539, 394);
			this->msgGroupControl->TabIndex = 2;
			this->msgGroupControl->Text = L"Messages";
			// 
			// logMsgListView
			// 
			this->logMsgListView->Columns->AddRange(gcnew cli::array< System::Windows::Forms::ColumnHeader^  >(4) {
				this->columnHeader1,
					this->columnHeader2, this->columnHeader3, this->columnHeader4
			});
			this->logMsgListView->Dock = System::Windows::Forms::DockStyle::Fill;
			this->logMsgListView->FullRowSelect = true;
			this->logMsgListView->GridLines = true;
			this->logMsgListView->Location = System::Drawing::Point(2, 21);
			this->logMsgListView->Name = L"logMsgListView";
			this->logMsgListView->Size = System::Drawing::Size(535, 371);
			this->logMsgListView->TabIndex = 0;
			this->logMsgListView->UseCompatibleStateImageBehavior = false;
			this->logMsgListView->View = System::Windows::Forms::View::Details;
			// 
			// columnHeader1
			// 
			this->columnHeader1->Text = L"Time";
			this->columnHeader1->Width = 67;
			// 
			// columnHeader2
			// 
			this->columnHeader2->Text = L"Message";
			this->columnHeader2->Width = 271;
			// 
			// columnHeader3
			// 
			this->columnHeader3->Text = L"User";
			this->columnHeader3->Width = 116;
			// 
			// columnHeader4
			// 
			this->columnHeader4->Text = L"IP";
			// 
			// logFiltersGroupControl
			// 
			this->logFiltersGroupControl->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->logFiltersGroupControl->Controls->Add(this->errorsCheckEdit);
			this->logFiltersGroupControl->Controls->Add(this->prizesCheckEdit);
			this->logFiltersGroupControl->Controls->Add(this->connectionCheckEdit);
			this->logFiltersGroupControl->Controls->Add(this->methodCheckEdit);
			this->logFiltersGroupControl->Location = System::Drawing::Point(5, 24);
			this->logFiltersGroupControl->Name = L"logFiltersGroupControl";
			this->logFiltersGroupControl->Size = System::Drawing::Size(178, 394);
			this->logFiltersGroupControl->TabIndex = 1;
			this->logFiltersGroupControl->Text = L"Filters";
			// 
			// errorsCheckEdit
			// 
			this->errorsCheckEdit->Location = System::Drawing::Point(5, 108);
			this->errorsCheckEdit->Name = L"errorsCheckEdit";
			this->errorsCheckEdit->Properties->Caption = L"Show errors";
			this->errorsCheckEdit->Size = System::Drawing::Size(168, 19);
			this->errorsCheckEdit->TabIndex = 0;
			// 
			// prizesCheckEdit
			// 
			this->prizesCheckEdit->Location = System::Drawing::Point(5, 83);
			this->prizesCheckEdit->Name = L"prizesCheckEdit";
			this->prizesCheckEdit->Properties->Caption = L"Show prizes won";
			this->prizesCheckEdit->Size = System::Drawing::Size(168, 19);
			this->prizesCheckEdit->TabIndex = 0;
			// 
			// connectionCheckEdit
			// 
			this->connectionCheckEdit->Location = System::Drawing::Point(5, 58);
			this->connectionCheckEdit->Name = L"connectionCheckEdit";
			this->connectionCheckEdit->Properties->Caption = L"Show connection info";
			this->connectionCheckEdit->Size = System::Drawing::Size(168, 19);
			this->connectionCheckEdit->TabIndex = 0;
			// 
			// methodCheckEdit
			// 
			this->methodCheckEdit->Location = System::Drawing::Point(5, 33);
			this->methodCheckEdit->Name = L"methodCheckEdit";
			this->methodCheckEdit->Properties->Caption = L"Show method invocation";
			this->methodCheckEdit->Size = System::Drawing::Size(168, 19);
			this->methodCheckEdit->TabIndex = 0;
			// 
			// xtraTabPage2
			// 
			this->xtraTabPage2->Controls->Add(this->statGroupControl);
			this->xtraTabPage2->Name = L"xtraTabPage2";
			this->xtraTabPage2->Size = System::Drawing::Size(735, 423);
			this->xtraTabPage2->Text = L"Statistics";
			// 
			// statGroupControl
			// 
			this->statGroupControl->Dock = System::Windows::Forms::DockStyle::Fill;
			this->statGroupControl->Location = System::Drawing::Point(0, 0);
			this->statGroupControl->Name = L"statGroupControl";
			this->statGroupControl->Size = System::Drawing::Size(735, 423);
			this->statGroupControl->TabIndex = 0;
			this->statGroupControl->Text = L"Game statistics";
			// 
			// xtraTabPage3
			// 
			this->xtraTabPage3->Controls->Add(this->resGroupControl);
			this->xtraTabPage3->Name = L"xtraTabPage3";
			this->xtraTabPage3->Size = System::Drawing::Size(735, 423);
			this->xtraTabPage3->Text = L"Resources";
			// 
			// resGroupControl
			// 
			this->resGroupControl->Controls->Add(this->chartControl1);
			this->resGroupControl->Dock = System::Windows::Forms::DockStyle::Fill;
			this->resGroupControl->Location = System::Drawing::Point(0, 0);
			this->resGroupControl->Name = L"resGroupControl";
			this->resGroupControl->Size = System::Drawing::Size(735, 423);
			this->resGroupControl->TabIndex = 3;
			this->resGroupControl->Text = L"System resources usage";
			// 
			// chartControl1
			// 
			xyDiagram1->AxisX->VisibleInPanesSerializable = L"-1";
			xyDiagram1->AxisX->WholeRange->AutoSideMargins = false;
			xyDiagram1->AxisX->WholeRange->SideMarginsValue = 0;
			xyDiagram1->AxisY->VisibleInPanesSerializable = L"-1";
			this->chartControl1->Diagram = xyDiagram1;
			this->chartControl1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->chartControl1->Location = System::Drawing::Point(2, 21);
			this->chartControl1->Name = L"chartControl1";
			this->chartControl1->PaletteName = L"Blue";
			series1->Name = L"CPU usage";
			series1->View = splineAreaSeriesView1;
			series2->Name = L"RAM usage";
			series2->View = splineAreaSeriesView2;
			this->chartControl1->SeriesSerializable = gcnew cli::array< DevExpress::XtraCharts::Series^  >(2) { series1, series2 };
			splineAreaSeriesView3->Transparency = static_cast<System::Byte>(0);
			this->chartControl1->SeriesTemplate->View = splineAreaSeriesView3;
			this->chartControl1->Size = System::Drawing::Size(731, 400);
			this->chartControl1->TabIndex = 0;
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(805, 475);
			this->Controls->Add(this->xtraTabControl);
			this->Controls->Add(this->statusStrip1);
			this->Controls->Add(this->serverMenuStrip);
			this->MainMenuStrip = this->serverMenuStrip;
			this->Name = L"MainForm";
			this->ShowIcon = false;
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Black Jack Server";
			this->serverMenuStrip->ResumeLayout(false);
			this->serverMenuStrip->PerformLayout();
			this->statusStrip1->ResumeLayout(false);
			this->statusStrip1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->xtraTabControl))->EndInit();
			this->xtraTabControl->ResumeLayout(false);
			this->xtraTabPage1->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->logGroupControl))->EndInit();
			this->logGroupControl->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->msgGroupControl))->EndInit();
			this->msgGroupControl->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->logFiltersGroupControl))->EndInit();
			this->logFiltersGroupControl->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->errorsCheckEdit->Properties))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->prizesCheckEdit->Properties))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->connectionCheckEdit->Properties))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->methodCheckEdit->Properties))->EndInit();
			this->xtraTabPage2->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->statGroupControl))->EndInit();
			this->xtraTabPage3->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->resGroupControl))->EndInit();
			this->resGroupControl->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(xyDiagram1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(series1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(series2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(splineAreaSeriesView3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chartControl1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

};
}
