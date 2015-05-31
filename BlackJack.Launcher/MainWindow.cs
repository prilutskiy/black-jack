using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using BlackJack.Common;

namespace BlackJack.Launcher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPrevConfig();
        }

        private void LoadPrevConfig()
        {
            var address = String.Empty;
            if (!File.Exists(Path.Combine(Application.StartupPath, ConnectionInfo.DeafultConfigFileName)))
                return;
            try
            {
                using (var stream = new FileStream(Path.Combine(Application.StartupPath, ConnectionInfo.DeafultConfigFileName), FileMode.Open))
                {
                    var xmlSer = new XmlSerializer(typeof (ConnectionInfo));
                    var obj = xmlSer.Deserialize(stream) as ConnectionInfo;
                    address = obj.IpAddress;
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Cannot read configuration file. " + ex.Message, "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Cannot read configuration file. " + ex.Message, "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            finally
            {
                textBox1.Text = address;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            var ValidIpAddressRegex = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

            if (!Regex.IsMatch(textBox1.Text, ValidIpAddressRegex))
                MessageBox.Show("Invalid address ", "Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            try
            {
                using (var stream = new FileStream(Path.Combine(Application.StartupPath, ConnectionInfo.DeafultConfigFileName), FileMode.Create))
                {
                    var xmlSer = new XmlSerializer(typeof(ConnectionInfo));
                    xmlSer.Serialize(stream, new ConnectionInfo() { IpAddress = textBox1.Text });
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Cannot save configuration. " + ex.Message, "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Cannot save configuration. " + ex.Message, "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (!CheckServerState(textBox1.Text))
            {
                MessageBox.Show(String.Format("{0}: Server unavailible", textBox1.Text));
                return;
                
            }
            var clientAppPath = Path.Combine(Application.StartupPath, "BlackJack.Client.exe");
            Process.Start(clientAppPath);
            this.Close();
        }

        private bool CheckServerState(string text)
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect(text, 777);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}