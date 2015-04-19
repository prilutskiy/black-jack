﻿namespace BlackJack.Client
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webView = new Awesomium.Windows.Forms.WebControl(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.debugPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Size = new System.Drawing.Size(900, 600);
            this.webView.Source = new System.Uri("http://localhost:32105/", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(870, 541);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Player score";
            this.columnHeader1.Width = 71;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dealer score";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Game over";
            this.columnHeader4.Width = 64;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Bet";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Player cash";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Winner";
            this.columnHeader7.Width = 65;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Error";
            this.columnHeader6.Width = 238;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.newGameButon_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 550);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 550);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Double";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.doubleButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 550);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Stand";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.standButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(327, 550);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Terminate";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(408, 550);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Bet + 100";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.increaseBet_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(489, 550);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "Bet - 100";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.decreaseBet_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(570, 550);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear log";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // debugPanel
            // 
            this.debugPanel.Controls.Add(this.listView1);
            this.debugPanel.Controls.Add(this.clearButton);
            this.debugPanel.Controls.Add(this.button1);
            this.debugPanel.Controls.Add(this.button7);
            this.debugPanel.Controls.Add(this.button2);
            this.debugPanel.Controls.Add(this.button6);
            this.debugPanel.Controls.Add(this.button3);
            this.debugPanel.Controls.Add(this.button5);
            this.debugPanel.Controls.Add(this.button4);
            this.debugPanel.Location = new System.Drawing.Point(12, 12);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(876, 576);
            this.debugPanel.TabIndex = 5;
            this.debugPanel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.webView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackJack";
            this.debugPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Awesomium.Windows.Forms.WebControl webView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel debugPanel;



    }
}

