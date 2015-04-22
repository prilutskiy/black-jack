using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using BlackJack.Common;

namespace BlackJack.Server
{
    public partial class MainWindow : Form
    {
        private ServerManager serverManager = new ServerManager();
        public MainWindow()
        {
            InitializeComponent();
            serverManager.ServerStateChanged += AddMessageToEventLog;
        }

        private TcpClient connection_;

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            startServerBtn.Enabled = false;
            serverManager.Start();
        }

        public void AddMessageToEventLog(object sender, ServerEventArgs args)
        {
            var item = new ListViewItem();
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add(args.Message);
            serverLogListView.Items.Add(item);
        }
    }
}
