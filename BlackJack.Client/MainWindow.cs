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
        private GameManager gm = new GameManager();
        
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
        private void Redraw()
        {
            List<PictureBox> dealerCardsPbList = null;
            List<PictureBox> playerCardsPbList = null;
            int currentBet = -1;


        }

        private void newGameButon_Click(object sender, EventArgs e)
        {
            gm.Start();
            Redraw();
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            gm.Exit();
            Redraw();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            gm.Hit();
            Redraw();
        }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            gm.Double();
            Redraw();
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            gm.Stand();
            Redraw();
        }
        #endregion
    }
}
