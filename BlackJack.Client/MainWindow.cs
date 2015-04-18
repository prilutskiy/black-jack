using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Core;
using BlackJack.Common;

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

        private JSValue test(object sender, JavascriptMethodEventArgs args)
        {
            var req = String.Empty;
            foreach (var v in args.Arguments)
                req += v.ToString() + " ";

            MessageBox.Show("Arguments:\n" + req, "Hello from js", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            return "ACCEPTED: " + req;
        }
        private JSValue test2(object sender, JavascriptMethodEventArgs args)
        {
            var req = String.Empty;
            foreach (var v in args.Arguments)
                req += v.ToString() + " ";

            MessageBox.Show("Arguments:\n" + req, "Hello from js", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            return "ACCEPTED" + req;
        }

        #region UI Event Handlers
        private void Redraw(GameState state)
        {
            if (state.Exception != null)
            {
                var viewItem = new ListViewItem("");
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add(state.Exception.Message);
                listView1.Items.Add(viewItem);
                return;
            }
            var item = new ListViewItem(state.Player.CardScore.ToString());
            item.SubItems.Add(state.Dealer.CardScore.ToString());
            item.SubItems.Add(state.GameIsOver.ToString());
            item.SubItems.Add(state.Bet.ToString());
            item.SubItems.Add(state.Player.Cash.ToString());
            item.SubItems.Add(state.Winner == null ? "" : state.Winner.PlayerType.ToString());
            listView1.Items.Add(item);
        }

        private void newGameButon_Click(object sender, EventArgs e)
        {
            var state = gm.Start();
            Redraw(state);
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            var state = gm.Terminate();
            Redraw(state);
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            var state = gm.Hit();
            Redraw(state);
        }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            var state = gm.Double();
            Redraw(state);
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            var state = gm.Stand();
            Redraw(state);
        }
        private void increaseBet_Click(object sender, EventArgs e)
        {
            var state = gm.IncreaseBet(100);
            Redraw(state);
        }
        private void decreaseBet_Click(object sender, EventArgs e)
        {
            var state = gm.DecreaseBet(100);
            Redraw(state);
        }
        #endregion

        private void clearButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

    }
}
