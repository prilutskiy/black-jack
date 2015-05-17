using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;

namespace BlackJack.Server
{
    public partial class MainWindow : Form
    {
        private readonly ServerManager serverManager = new ServerManager();
        private TcpClient connection_;
        public MainWindow()
        {
            InitializeComponent();
            serverManager.ServerStateChanged += AddMessageToEventLog;
        }
        private void startServerBtn_Click(object sender, EventArgs e)
        {
            startServerBtn.Enabled = false;
            serverManager.Start();
        }
        public void AddMessageToEventLog(object sender, ServerEventArgs args)
        {
            var item = new ListViewItem(DateTime.Now.ToString());
            item.SubItems.Add(args.Message);
            if (args.ClientSocket != null)
            {
                var addr = args.ClientSocket.RemoteEndPoint as IPEndPoint;
                item.SubItems.Add(addr != null ? addr.Address.ToString() : "");
            }

            Action crossThreadAction = () => logListview.Items.Add(item);
            logListview.Invoke(crossThreadAction);
        }

        private void pluginBtn_Click(object sender, EventArgs e)
        {
            Type pluginType = typeof(IPlugin); 
            var pluginAssemblies = new List<Type>();
                var pluginDir = Path.Combine(Environment.CurrentDirectory);
            if (!Directory.Exists(pluginDir))
                Directory.CreateDirectory(pluginDir);
            foreach (var file in Directory.GetFiles(pluginDir, "*.dll"))
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.LoadFile(file);
                }
                catch (BadImageFormatException)
                {
                    continue;
                }
                if (assembly != null)
                {
                    Type[] types;
                    try { types = assembly.GetTypes();}
                    catch(ReflectionTypeLoadException)
                    {continue;}
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                pluginAssemblies.Add(type);
                            }
                        }
                    }
                }
            }
            ICollection<IPlugin> plugins = new List<IPlugin>(pluginAssemblies.Count);
            foreach (Type type in pluginAssemblies)
            {
                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                plugins.Add(plugin);
            }
            foreach (var plugin in plugins)
            {
                var context = new ServerContext();
                FillContext(context);
                plugin.DoWork(context);
            }
        }

        public void FillContext(ServerContext context)
        {
            context.TabControl = tabControl;
            serverManager.FillContext(context);
        }
    }
}