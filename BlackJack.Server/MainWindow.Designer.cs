namespace BlackJack.Server
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
            this.startServerBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // startServerBtn
            // 
            this.startServerBtn.Location = new System.Drawing.Point(12, 30);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(313, 23);
            this.startServerBtn.TabIndex = 0;
            this.startServerBtn.Text = "Start server in background thread";
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 89);
            this.Controls.Add(this.startServerBtn);
            this.Name = "MainWindow";
            this.Text = "Black Jack server application";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton startServerBtn;
    }
}

