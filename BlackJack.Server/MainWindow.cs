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
            
            Task.Run(() => { StartServerAndListen(LogResponse); });
        }

        void LogResponse(string msg)
        {
            this.Invoke(() =>
            {
                this.Text = msg;
            });
        }
        private void StartServerAndListen(Action<String> cbAction)
        {
            object[] oArr;
            string[] sArr = new[] {""};

            oArr = sArr;
            if (connection_ != null)
            {
                cbAction("Already listening");
                return;
            }
                
            var endPoint = new IPEndPoint(IPAddress.Any, 777);
            connection_ = new TcpClient(endPoint);

            connection_.Client.Listen(10);
            var incomimg = connection_.Client.Accept();
            while (true)
            {
                byte[] buffer = new byte[10240];
                var length = incomimg.Receive(buffer);

                var method = buffer.ToMethodSignature();

                break;
            }
            cbAction("Session is over!");
            connection_.Client.Close();
            connection_.Close();
            connection_ = null;
        }
    }
}
