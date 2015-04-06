namespace BlackJack.Client
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.newGameButon = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.doubleButton = new System.Windows.Forms.Button();
            this.standButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 316);
            this.listBox1.TabIndex = 0;
            // 
            // newGameButon
            // 
            this.newGameButon.Location = new System.Drawing.Point(12, 334);
            this.newGameButon.Name = "newGameButon";
            this.newGameButon.Size = new System.Drawing.Size(318, 23);
            this.newGameButon.TabIndex = 1;
            this.newGameButon.Text = "Start game";
            this.newGameButon.UseVisualStyleBackColor = true;
            this.newGameButon.Click += new System.EventHandler(this.newGameButon_Click);
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(12, 375);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(88, 23);
            this.hitButton.TabIndex = 1;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // doubleButton
            // 
            this.doubleButton.Location = new System.Drawing.Point(126, 375);
            this.doubleButton.Name = "doubleButton";
            this.doubleButton.Size = new System.Drawing.Size(88, 23);
            this.doubleButton.TabIndex = 1;
            this.doubleButton.Text = "Double";
            this.doubleButton.UseVisualStyleBackColor = true;
            this.doubleButton.Click += new System.EventHandler(this.doubleButton_Click);
            // 
            // standButton
            // 
            this.standButton.Location = new System.Drawing.Point(242, 375);
            this.standButton.Name = "standButton";
            this.standButton.Size = new System.Drawing.Size(88, 23);
            this.standButton.TabIndex = 1;
            this.standButton.Text = "Stand";
            this.standButton.UseVisualStyleBackColor = true;
            this.standButton.Click += new System.EventHandler(this.standButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dealer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(398, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 57);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(629, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 57);
            this.label4.TabIndex = 2;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(506, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 117);
            this.label5.TabIndex = 2;
            this.label5.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 468);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.standButton);
            this.Controls.Add(this.doubleButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.newGameButon);
            this.Controls.Add(this.listBox1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button newGameButon;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button doubleButton;
        private System.Windows.Forms.Button standButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

