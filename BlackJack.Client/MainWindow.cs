using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Core;
using BlackJack.Common;
using Newtonsoft.Json;

namespace BlackJack.Client
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class MainWindow : Form
    {
        #region Initialization

        private ClientGameManager gm;
        private bool connected = false;
        public MainWindow()
        {
            InitializeComponent();
            webView.DocumentReady += WebViewOnDocumentReady;
            webView.Source = new Uri(Path.Combine(Application.StartupPath, @"..\..\..\", @"pages\index.html"));
        }

        private void Connect()
        {
            var tcp = new TcpClient();
            tcp.Connect("127.0.0.1", 777);
            var connection = new Connection(tcp.Client);
            var result = connection.ReceiveHandshake();
            gm = new ClientGameManager(connection);
            connected = true;
        }

        private bool initialLoad = true;

        private void WebViewOnDocumentReady(object sender, DocumentReadyEventArgs e)
        {
            JSObject jsobject = webView.CreateGlobalJavascriptObject("jsobject");
            Type t = this.GetType();
            var pubMethods = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (var method in pubMethods)
            {
                bool checkReturnType = (method.ReturnType == typeof(JSValue));
                var parameters = method.GetParameters();
                bool checkParameters = parameters.Length == 2 && parameters[0].ParameterType == typeof(Object) && typeof(EventArgs).IsAssignableFrom((parameters[1].ParameterType));
                if (checkReturnType && checkParameters)
                {
                    var methodRef = (JavascriptMethodHandler)Delegate.CreateDelegate(typeof(JavascriptMethodHandler), this, method);
                    jsobject.Bind(methodRef);
                }
            }
        }
        #endregion

        #region HTML UI Event Handlers

        private JSValue connectJs(object sender, JavascriptMethodEventArgs args)
        {
            if (!initialLoad) return true.ToString();
            initialLoad = false;
            if (!connected)
            {
                try
                {
                    Connect();
                }
                catch (SocketException ex)
                {
                    //MessageBox.Show(ex.Message, "Connection unavailible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false.ToString();
                }
            }
                    return true.ToString();
        }
        private JSValue getAuthStateJs(object sender, JavascriptMethodEventArgs e)
        {
            var authState = gm.IsAuthenticated();
            return authState.ToString();
        }
        private JSValue newGameJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Start();
            var json = GameStateToJson(state);
            return json;
        }
        private static string GameStateToJson(GameState state)
        {
            var stream = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(GameState));
            ser.WriteObject(stream, state);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var json = sr.ReadToEnd();
            return json;
        }
        private JSValue exitGameJs(object sender, JavascriptMethodEventArgs e)
        {
            this.Close();
            return null;
        } 
        private JSValue leaveGameJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Stop();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue hitJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Hit();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue doubleJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Double();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue standJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Stand();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue increaseBetJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.IncreaseBet();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue decreaseBetJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.DecreaseBet();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue logInJs(object sender, JavascriptMethodEventArgs e)
        {
            var username = e.Arguments.FirstOrDefault() == null ? "" : e.Arguments.FirstOrDefault().ToString();
            var pass = e.Arguments.ElementAtOrDefault(1) == null ? "" : e.Arguments.ElementAtOrDefault(1).ToString();
            var state = gm.Login(username, pass);
            //var json = GameStateToJson(state);
            return "STUB";
        }
        private JSValue logOutJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.Logoff();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue getStateJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.GetState();
            var json = GameStateToJson(state);
            return json;
        }
        private JSValue getLeaderboardJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.GetLeaderboard();
            if (state.AppStage != "leaderboard") throw new InvalidOperationException();
            var json = GameStateToJson(state);
            return json;
        }
        #endregion

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            webView.ExecuteJavascript("checkConnection();");
        }

    }
}
