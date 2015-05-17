using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Windows.Forms;
using Awesomium.Core;
using BlackJack.Common;

namespace BlackJack.Client
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class MainWindow : Form
    {
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            webView.ExecuteJavascript("checkConnection();");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView.Reload(true);
        }

        #region Initialization

        private ClientGameManager gm;
        private bool connected;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            refreshBtn.Visible = true;
#else
            refreshBtn.Visible = false;
#endif

            webView.DocumentReady += WebViewOnDocumentReady;
            webView.Source = new Uri(Path.Combine(Application.StartupPath, @"pages\index.html"));
        }

        private void Connect()
        {
            var tcp = new TcpClient();
            tcp.Connect(Program.ConnectionInfo.IpAddress, Program.ConnectionInfo.Port);
            var connection = new Connection(tcp.Client);
            var result = connection.ReceiveHandshake();
            gm = new ClientGameManager(connection);
            connected = true;
        }

        private bool initialLoad = true;

        private void WebViewOnDocumentReady(object sender, DocumentReadyEventArgs e)
        {
            JSObject jsobject = webView.CreateGlobalJavascriptObject("jsobject");
            var t = GetType();
            var pubMethods =
                t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly |
                             BindingFlags.Instance);
            foreach (var method in pubMethods)
            {
                var checkReturnType = (method.ReturnType == typeof (JSValue));
                var parameters = method.GetParameters();
                var checkParameters = parameters.Length == 2 && parameters[0].ParameterType == typeof (Object) &&
                                      typeof (EventArgs).IsAssignableFrom((parameters[1].ParameterType));
                if (checkReturnType && checkParameters)
                {
                    var methodRef =
                        (JavascriptMethodHandler)
                            Delegate.CreateDelegate(typeof (JavascriptMethodHandler), this, method);
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
            var state = gm.Start(GameType.Classic);
            var json = GameStateToJson(state);
            return json;
        }

        private static string GameStateToJson(GameState state)
        {
            var stream = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof (GameState));
            ser.WriteObject(stream, state);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var json = sr.ReadToEnd();
            return json;
        }

        private JSValue exitGameJs(object sender, JavascriptMethodEventArgs e)
        {
            Close();
            Application.Exit();
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

        private JSValue getAuthInfoJs(object sender, JavascriptMethodEventArgs e)
        {
            gm.Connection.SendRequest(new ServerRequest {RequestType = ServerMessageType.AuthInfo});
            var resp = gm.Connection.GetResponse().Username;
            return resp;
        }

        private JSValue isGameReadyJs(object sender, JavascriptMethodEventArgs e)
        {
            gm.Connection.SendRequest(new ServerRequest {RequestType = ServerMessageType.IsGameReady});
            var isReady = gm.Connection.GetResponse().IsReady;
            return isReady.ToString();
        }

        private JSValue getLeaderboardJs(object sender, JavascriptMethodEventArgs e)
        {
            var state = gm.GetLeaderboard();
            if (state.AppStage != "leaderboard") throw new InvalidOperationException();
            var json = GameStateToJson(state);
            return json;
        }

        #endregion
    }
}