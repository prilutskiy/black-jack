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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchThisProjectOnGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.serverLogTab = new DevExpress.XtraTab.XtraTabPage();
            this.logListview = new System.Windows.Forms.ListView();
            this.timeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.restartToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadPluginsToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.gitToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.serverLogTab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.restartToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "&Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Enabled = false;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPluginToolStripMenuItem,
            this.unloadAllToolStripMenuItem});
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginsToolStripMenuItem.Text = "&Plugins";
            // 
            // loadPluginToolStripMenuItem
            // 
            this.loadPluginToolStripMenuItem.Name = "loadPluginToolStripMenuItem";
            this.loadPluginToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadPluginToolStripMenuItem.Text = "Load all";
            this.loadPluginToolStripMenuItem.Click += new System.EventHandler(this.loadPluginToolStripMenuItem_Click);
            // 
            // unloadAllToolStripMenuItem
            // 
            this.unloadAllToolStripMenuItem.Name = "unloadAllToolStripMenuItem";
            this.unloadAllToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.unloadAllToolStripMenuItem.Text = "Unload all";
            this.unloadAllToolStripMenuItem.Click += new System.EventHandler(this.unloadAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.watchThisProjectOnGitHubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // watchThisProjectOnGitHubToolStripMenuItem
            // 
            this.watchThisProjectOnGitHubToolStripMenuItem.Name = "watchThisProjectOnGitHubToolStripMenuItem";
            this.watchThisProjectOnGitHubToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.watchThisProjectOnGitHubToolStripMenuItem.Text = "Watch this project on GitHub";
            this.watchThisProjectOnGitHubToolStripMenuItem.Click += new System.EventHandler(this.watchThisProjectOnGitHubToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabControl.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabControl.Location = new System.Drawing.Point(0, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.serverLogTab;
            this.tabControl.Size = new System.Drawing.Size(730, 404);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.serverLogTab});
            // 
            // serverLogTab
            // 
            this.serverLogTab.Controls.Add(this.logListview);
            this.serverLogTab.Name = "serverLogTab";
            this.serverLogTab.Size = new System.Drawing.Size(640, 398);
            this.serverLogTab.Text = "Server log       ";
            // 
            // logListview
            // 
            this.logListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumn,
            this.messageColumn,
            this.ipColumn});
            this.logListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListview.FullRowSelect = true;
            this.logListview.GridLines = true;
            this.logListview.Location = new System.Drawing.Point(0, 0);
            this.logListview.MultiSelect = false;
            this.logListview.Name = "logListview";
            this.logListview.Size = new System.Drawing.Size(640, 398);
            this.logListview.TabIndex = 0;
            this.logListview.UseCompatibleStateImageBehavior = false;
            this.logListview.View = System.Windows.Forms.View.Details;
            // 
            // timeColumn
            // 
            this.timeColumn.Text = "DateTime";
            this.timeColumn.Width = 136;
            // 
            // messageColumn
            // 
            this.messageColumn.Text = "Message";
            this.messageColumn.Width = 376;
            // 
            // ipColumn
            // 
            this.ipColumn.Text = "Address";
            this.ipColumn.Width = 91;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripBtn,
            this.stopToolStripBtn,
            this.restartToolStripBtn,
            this.toolStripSeparator2,
            this.loadPluginsToolStripBtn,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.helpToolStripBtn,
            this.gitToolStripBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startToolStripBtn
            // 
            this.startToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripBtn.Image")));
            this.startToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripBtn.Name = "startToolStripBtn";
            this.startToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.startToolStripBtn.Text = "toolStripButton1";
            this.startToolStripBtn.ToolTipText = "Start server";
            this.startToolStripBtn.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripBtn
            // 
            this.stopToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripBtn.Enabled = false;
            this.stopToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripBtn.Image")));
            this.stopToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripBtn.Name = "stopToolStripBtn";
            this.stopToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripBtn.Text = "toolStripButton2";
            this.stopToolStripBtn.ToolTipText = "Stop server";
            this.stopToolStripBtn.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripBtn
            // 
            this.restartToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.restartToolStripBtn.Enabled = false;
            this.restartToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripBtn.Image")));
            this.restartToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restartToolStripBtn.Name = "restartToolStripBtn";
            this.restartToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.restartToolStripBtn.Text = "toolStripButton3";
            this.restartToolStripBtn.ToolTipText = "Restart server";
            this.restartToolStripBtn.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // loadPluginsToolStripBtn
            // 
            this.loadPluginsToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadPluginsToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("loadPluginsToolStripBtn.Image")));
            this.loadPluginsToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadPluginsToolStripBtn.Name = "loadPluginsToolStripBtn";
            this.loadPluginsToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.loadPluginsToolStripBtn.Text = " ";
            this.loadPluginsToolStripBtn.ToolTipText = " Load plugins";
            this.loadPluginsToolStripBtn.Click += new System.EventHandler(this.loadPluginToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Unload plugins";
            this.toolStripButton1.Click += new System.EventHandler(this.unloadAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripBtn
            // 
            this.helpToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripBtn.Image")));
            this.helpToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripBtn.Name = "helpToolStripBtn";
            this.helpToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripBtn.Text = "He&lp";
            this.helpToolStripBtn.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gitToolStripBtn
            // 
            this.gitToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gitToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("gitToolStripBtn.Image")));
            this.gitToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gitToolStripBtn.Name = "gitToolStripBtn";
            this.gitToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.gitToolStripBtn.Text = "toolStripButton5";
            this.gitToolStripBtn.ToolTipText = "Visit GitHub";
            this.gitToolStripBtn.Click += new System.EventHandler(this.watchThisProjectOnGitHubToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 481);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Black Jack server application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.serverLogTab.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage serverLogTab;
        private System.Windows.Forms.ListView logListview;
        private System.Windows.Forms.ColumnHeader timeColumn;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.ColumnHeader ipColumn;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchThisProjectOnGitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startToolStripBtn;
        private System.Windows.Forms.ToolStripButton stopToolStripBtn;
        private System.Windows.Forms.ToolStripButton restartToolStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton loadPluginsToolStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton helpToolStripBtn;
        private System.Windows.Forms.ToolStripButton gitToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem unloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

