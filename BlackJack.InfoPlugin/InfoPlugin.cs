using System.Windows.Forms;
using BlackJack.Server;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace BlackJack.InfoPlugin
{
    public class InfoPlugin : IPlugin
    {
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private void InitializeComponents()
        {
            xtraTabPage1 = new XtraTabPage();
            groupControl1 = new GroupControl();
            label1 = new Label();

            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(638, 343);
            this.xtraTabPage1.Text = "Game info";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(638, 343);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Game information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
        }
        public void DoWork(ServerContext context)
        {
            InitializeComponents();
            context.TabControl.TabPages.Add(xtraTabPage1);
        }
    }
}