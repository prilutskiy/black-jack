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
        public MainWindow()
        {
            InitializeComponent();
        }

        private TcpClient connection_;
        private void startServerBtn_Click(object sender, EventArgs e)
        {
            startServerBtn.Enabled = false;
            var serverManager = new ServerManager();
            serverManager.Start();
        }
    }
}
