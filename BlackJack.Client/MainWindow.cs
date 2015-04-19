using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
        private ClientGameManager gm = new ClientGameManager();

        public MainWindow()
        {
            InitializeComponent();
            webView.DocumentReady += WebViewOnDocumentReady;
        }

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
            var state = gm.Terminate();
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


        #endregion


    }
}
