using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using BlackJack.Common;

namespace BlackJack.Client
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (!TryLoadConfig())
                return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        private static bool TryLoadConfig()
        {
            try
            {
                using (var stream = new FileStream(ConnectionInfo.DeafultConfigFilePath, FileMode.Open))
                {
                    var xmlSer = new XmlSerializer(typeof(ConnectionInfo));
                    var obj = xmlSer.Deserialize(stream) as ConnectionInfo;
                    ConnectionInfo.IpAddress = obj.IpAddress;
                    ConnectionInfo.Port = obj.Port == 0 ? ConnectionInfo.DefaultPort : obj.Port;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static readonly ConnectionInfo ConnectionInfo = new ConnectionInfo();
    }
}