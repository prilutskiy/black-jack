using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;

namespace BlackJack.Server
{
    public partial class MainWindow : Form
    {
        private readonly ServerManager serverManager = new ServerManager();
        private TcpClient connection_;
        private readonly List<IPlugin> _loadedPluginInstances = new List<IPlugin>();
        private readonly List<Type> _loadedPluginTypes = new List<Type>(); 
        public MainWindow()
        {
            InitializeComponent();
            serverManager.ServerStateChanged += AddMessageToEventLog;
        }
        //private void startServerBtn_Click(object sender, EventArgs e)
        //{
        //    startServerBtn.Enabled = false;
        //    serverManager.Start();
        //}
        public void AddMessageToEventLog(object sender, ServerEventArgs args)
        {
            var item = new ListViewItem(DateTime.Now.ToString());
            item.SubItems.Add(args.Message);
            if (args.ClientSocket != null)
            {
                var addr = args.ClientSocket.RemoteEndPoint as IPEndPoint;
                item.SubItems.Add(addr != null ? addr.Address.ToString() : "");
            }

            Action crossThreadAction = () => logListview.Items.Insert(0, item);
            logListview.Invoke(crossThreadAction);
        }

        private void UnloadAllPlugins()
        {
            foreach(var pluginInstance in _loadedPluginInstances)
                pluginInstance.Dispose();
            _loadedPluginInstances.Clear();
            _loadedPluginTypes.Clear();
        }
        private void LoadPluginsFromDefaultLocation()
        {
            var excList = new List<InvalidOperationException>();
            var pluginDir = Environment.CurrentDirectory;
            foreach (var file in Directory.GetFiles(pluginDir, "*.dll"))
            {
                List<Type> types = LoadTypesFromAssemblyFile(file);
                foreach (var type in types)
                {
                    if (_loadedPluginTypes.Any(t => t.GetHashCode().Equals(type.GetHashCode())))
                        excList.Add(new InvalidOperationException(String.Format("{0}: Cannot load plugin if its already loaded.", type.FullName)));
                    else 
                        _loadedPluginTypes.Add(type);
                }
            }
            if (_loadedPluginTypes.Count == 0)
            {
                MessageBox.Show("No plugins found. Place suitable *.dll libraries in program folder",
                    "Plugins not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var type in _loadedPluginTypes)
            {
                var instance = (IPlugin)Activator.CreateInstance(type);
                _loadedPluginInstances.Add(instance);
            }
            foreach (var instance in _loadedPluginInstances)
            {
                var context = new ServerContext();
                FillContext(context);
                instance.DoWork(context);
            }
            
            if (excList.Count > 0)
                throw new AggregateException(excList);
        }

        private List<Type> LoadTypesFromAssemblyFile(string file)
        {
            var result = new List<Type>();
            try
            {
                var assembly =  Assembly.LoadFile(file);
                if (assembly != null)
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                        if (type.GetInterface(typeof(IPlugin).FullName) != null && !(type.IsInterface || type.IsAbstract))
                            result.Add(type);
                }
            }
            catch (ArgumentNullException) { }
            catch (BadImageFormatException){ }
            catch (FileLoadException){ }
            catch (FileNotFoundException){ }
            catch (ReflectionTypeLoadException) { }
            catch (AmbiguousMatchException) { }
            return result;
        }

        private void FillContext(ServerContext context)
        {
            context.TabControl = tabControl;
            context.CurrentProcess = Process.GetCurrentProcess();
            serverManager.FillContext(context);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Black Jack client-server application with plugins support. \nMax Prilutskiy © 2015",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);}

        private void watchThisProjectOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/prilutskiy/black-jack");
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invoke(() =>
            {
                startToolStripMenuItem.Enabled = false;
                startToolStripBtn.Enabled = false;

                restartToolStripBtn.Enabled = true;
                restartToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                stopToolStripBtn.Enabled = true;
            });
            serverManager.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invoke(() =>
            {
                startToolStripMenuItem.Enabled = true;
                startToolStripBtn.Enabled = true;

                restartToolStripBtn.Enabled = false;
                restartToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                stopToolStripBtn.Enabled = false;
            });
            serverManager.Stop();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMessageToEventLog(sender, new ServerEventArgs(){Message = "Restarting server..."});
            stopToolStripMenuItem_Click(sender, e);
            startToolStripMenuItem_Click(sender, e);
            AddMessageToEventLog(sender, new ServerEventArgs() { Message = "Server restarted" });
        }

        private void loadPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UnloadAllPlugins();
                LoadPluginsFromDefaultLocation();
            }
            catch (AggregateException ex)
            {
                var excText = ex.InnerExceptions.Aggregate("", (current, exc) => current + (exc.Message + "\n"));
                excText = excText.Trim('\n');
                MessageBox.Show(excText);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnloadAllPlugins();
        }

        private void unloadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllPlugins();
        }

    }
}