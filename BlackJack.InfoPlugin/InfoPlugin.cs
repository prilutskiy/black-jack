using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BlackJack.Common;
using BlackJack.Server;
using DevExpress.Data.PLinq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Timer = System.Threading.Timer;

namespace BlackJack.InfoPlugin
{
    public class InfoPlugin : IPlugin, IDisposable
    {
        private Timer _viewUpdateTimer;

        public void Dispose()
        {
            if (_viewUpdateTimer != null)
                _viewUpdateTimer.Dispose();
        }

        public string Name
        {
            get { return "Game server load"; }
        }

        public void DoWork(ServerContext context)
        {
            InitializeComponents();
            _viewUpdateTimer = new Timer(this.UpdateViewFromContext, context, 0, 1000);
            //UpdateViewFromContext(context);
            context.TabControl.TabPages.Add(gameInfoTab);
        }

        private void InitializeComponents()
        {
            // 
            // gameInfoTab
            // 
            gameInfoTab.Controls.Add(groupControl1);
            gameInfoTab.Name = "gameInfoTab";
            gameInfoTab.Size = new Size(638, 343);
            gameInfoTab.Text = "Game info";
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(groupControl5);
            groupControl1.Controls.Add(groupControl4);
            groupControl1.Controls.Add(groupControl3);
            groupControl1.Controls.Add(groupControl2);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(638, 343);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Game info";
            // 
            // groupControl5
            // 
            groupControl5.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                    | AnchorStyles.Left)
                                   | AnchorStyles.Right;
            groupControl5.Controls.Add(xtraTabControl1);
            groupControl5.Location = new Point(204, 24);
            groupControl5.Name = "groupControl5";
            groupControl5.Size = new Size(427, 314);
            groupControl5.TabIndex = 2;
            groupControl5.Text = "Detailed player info";
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(2, 21);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(423, 291);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new[]
            {
                xtraTabPage1,
                xtraTabPage2
            });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(onlineListView);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(417, 263);
            xtraTabPage1.Text = "In game";
            // 
            // onlineListView
            // 
            onlineListView.Columns.AddRange(new[]
            {
                columnHeader1,
                columnHeader2,
                columnHeader4,
                columnHeader5
            });
            onlineListView.Dock = DockStyle.Fill;
            onlineListView.FullRowSelect = true;
            onlineListView.GridLines = true;
            onlineListView.Location = new Point(0, 0);
            onlineListView.Name = "onlineListView";
            onlineListView.Size = new Size(417, 263);
            onlineListView.TabIndex = 0;
            onlineListView.UseCompatibleStateImageBehavior = false;
            onlineListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Player ID";
            columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Username";
            columnHeader2.Width = 92;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Cash";
            columnHeader4.Width = 54;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "IP address";
            columnHeader5.Width = 94;
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(totalListView);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(417, 263);
            xtraTabPage2.Text = "Total";
            // 
            // totalListView
            // 
            totalListView.Columns.AddRange(new[]
            {
                columnHeader6,
                columnHeader7,
                columnHeader8,
                columnHeader9
            });
            totalListView.Dock = DockStyle.Fill;
            totalListView.FullRowSelect = true;
            totalListView.GridLines = true;
            totalListView.Location = new Point(0, 0);
            totalListView.Name = "totalListView";
            totalListView.Size = new Size(417, 263);
            totalListView.TabIndex = 1;
            totalListView.UseCompatibleStateImageBehavior = false;
            totalListView.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Player ID";
            columnHeader6.Width = 65;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Username";
            columnHeader7.Width = 92;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Password";
            columnHeader8.Width = 93;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Cash";
            columnHeader9.Width = 46;
            // 
            // groupControl4
            // 
            groupControl4.Controls.Add(totalPlayersLabel);
            groupControl4.Controls.Add(label4);
            groupControl4.Controls.Add(playersInGameLabel);
            groupControl4.Controls.Add(label5);
            groupControl4.Location = new Point(5, 236);
            groupControl4.Name = "groupControl4";
            groupControl4.Size = new Size(193, 102);
            groupControl4.TabIndex = 1;
            groupControl4.Text = "Players";
            // 
            // totalPlayersLabel
            // 
            totalPlayersLabel.AutoSize = true;
            totalPlayersLabel.Location = new Point(155, 67);
            totalPlayersLabel.Name = "totalPlayersLabel";
            totalPlayersLabel.Size = new Size(13, 13);
            totalPlayersLabel.TabIndex = 1;
            totalPlayersLabel.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 67);
            label4.Name = "label4";
            label4.Size = new Size(96, 13);
            label4.TabIndex = 0;
            label4.Text = "Players registered: ";
            // 
            // playersInGameLabel
            // 
            playersInGameLabel.AutoSize = true;
            playersInGameLabel.Location = new Point(155, 42);
            playersInGameLabel.Name = "playersInGameLabel";
            playersInGameLabel.Size = new Size(13, 13);
            playersInGameLabel.TabIndex = 1;
            playersInGameLabel.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 42);
            label5.Name = "label5";
            label5.Size = new Size(78, 13);
            label5.TabIndex = 0;
            label5.Text = "Players in game: ";
            // 
            // groupControl3
            // 
            groupControl3.Controls.Add(untrustedLabel);
            groupControl3.Controls.Add(trustedLabel);
            groupControl3.Controls.Add(label8);
            groupControl3.Controls.Add(label9);
            groupControl3.Location = new Point(5, 145);
            groupControl3.Name = "groupControl3";
            groupControl3.Size = new Size(193, 85);
            groupControl3.TabIndex = 0;
            groupControl3.Text = "Details";
            // 
            // untrustedLabel
            // 
            untrustedLabel.AutoSize = true;
            untrustedLabel.Location = new Point(155, 57);
            untrustedLabel.Name = "untrustedLabel";
            untrustedLabel.Size = new Size(13, 13);
            untrustedLabel.TabIndex = 1;
            untrustedLabel.Text = "0";
            // 
            // trustedLabel
            // 
            trustedLabel.AutoSize = true;
            trustedLabel.Location = new Point(155, 32);
            trustedLabel.Name = "trustedLabel";
            trustedLabel.Size = new Size(13, 13);
            trustedLabel.TabIndex = 1;
            trustedLabel.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 32);
            label8.Name = "label8";
            label8.Size = new Size(110, 13);
            label8.TabIndex = 0;
            label8.Text = "Trusted connections: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 57);
            label9.Name = "label9";
            label9.Size = new Size(120, 13);
            label9.TabIndex = 0;
            label9.Text = "Untrusted connections: ";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(availibleConnectionsLabel);
            groupControl2.Controls.Add(currentConnectionsLabel);
            groupControl2.Controls.Add(maxConnectionsLabel);
            groupControl2.Controls.Add(label2);
            groupControl2.Controls.Add(label3);
            groupControl2.Controls.Add(label1);
            groupControl2.Location = new Point(5, 24);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(193, 115);
            groupControl2.TabIndex = 0;
            groupControl2.Text = "Connections";
            // 
            // availibleConnectionsLabel
            // 
            availibleConnectionsLabel.AutoSize = true;
            availibleConnectionsLabel.Location = new Point(152, 85);
            availibleConnectionsLabel.Name = "availibleConnectionsLabel";
            availibleConnectionsLabel.Size = new Size(13, 13);
            availibleConnectionsLabel.TabIndex = 1;
            availibleConnectionsLabel.Text = "0";
            // 
            // currentConnectionsLabel
            // 
            currentConnectionsLabel.AutoSize = true;
            currentConnectionsLabel.Location = new Point(152, 59);
            currentConnectionsLabel.Name = "currentConnectionsLabel";
            currentConnectionsLabel.Size = new Size(13, 13);
            currentConnectionsLabel.TabIndex = 1;
            currentConnectionsLabel.Text = "0";
            // 
            // maxConnectionsLabel
            // 
            maxConnectionsLabel.AutoSize = true;
            maxConnectionsLabel.Location = new Point(152, 34);
            maxConnectionsLabel.Name = "maxConnectionsLabel";
            maxConnectionsLabel.Size = new Size(13, 13);
            maxConnectionsLabel.TabIndex = 1;
            maxConnectionsLabel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 85);
            label2.Name = "label2";
            label2.Size = new Size(113, 13);
            label2.TabIndex = 0;
            label2.Text = "Availible connections: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 34);
            label3.Name = "label3";
            label3.Size = new Size(94, 13);
            label3.TabIndex = 0;
            label3.Text = "Max connections: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 59);
            label1.Name = "label1";
            label1.Size = new Size(108, 13);
            label1.TabIndex = 0;
            label1.Text = "Current connections: ";
        }

        private int _prevOnlineCount = 0;
        private int _prevTotalCount = 0;
        private readonly object _syncRootTotal = new object();
        private readonly object _syncRootOnline = new object();
        public void UpdateViewFromContext(object contextObj)
        {
            var context = contextObj as ServerContext;
            var maxConnections = context.MaxConnections;
            var currentConnections = context.RunningThreads.Count;
            var availibleConnections = maxConnections - currentConnections;
            ICollection<IUser> allUsers = null;

            gameInfoTab.Invoke(() => { allUsers = context.AppRepository.GetAllPlayers(); });

            var inGameUsers = from tuple in context.ClassicGames select tuple.Item1;

            gameInfoTab.Invoke(() =>
            {
                maxConnectionsLabel.Text = maxConnections.ToString();
                currentConnectionsLabel.Text = currentConnections.ToString();
                availibleConnectionsLabel.Text = availibleConnections.ToString();

                trustedLabel.Text = context.Trusted.Count.ToString();
                untrustedLabel.Text = context.Untrusted.Count.ToString();

                playersInGameLabel.Text = context.ClassicGames.Count.ToString();
                totalPlayersLabel.Text = allUsers.Count.ToString();
            });

            lock(_syncRootOnline)
                if (_prevOnlineCount != inGameUsers.Count())
                {
                    _prevOnlineCount = inGameUsers.Count();
                    onlineListView.Invoke(() => onlineListView.Items.Clear());
                    foreach (var player in inGameUsers)
                    {

                        var userConnection = context.Trusted.SingleOrDefault(c => c.PlayerInstance.Id == player.Id);
                        var endPoint = userConnection.Socket.RemoteEndPoint as IPEndPoint;
                        var address = endPoint.Address.ToString();
                        var item = new ListViewItem(player.Id.ToString());
                        item.SubItems.Add(player.Username);
                        item.SubItems.Add(player.Cash.ToString());
                        item.SubItems.Add(address);
                        onlineListView.Invoke(() => { onlineListView.Items.Add(item); });
                    }
                }

            lock (_syncRootTotal)
                if (_prevTotalCount != allUsers.Count)
                {
                    _prevTotalCount = allUsers.Count;
                    totalListView.Invoke(() => totalListView.Items.Clear());
                    foreach (var user in allUsers)
                    {
                        var item = new ListViewItem(user.Id.ToString());
                        item.SubItems.Add(user.Username);
                        item.SubItems.Add((user as User).Password);
                        item.SubItems.Add(user.Cash.ToString());
                        if (!totalListView.Items.Contains(item))
                            totalListView.Invoke(() => { totalListView.Items.Add(item); });
                    }
                }

        }

        ~InfoPlugin()
        {
            Dispose();
        }

        #region WinForms controls declarations

        private readonly Label availibleConnectionsLabel = new Label();
        private readonly ColumnHeader columnHeader1 = new ColumnHeader();
        private readonly ColumnHeader columnHeader2 = new ColumnHeader();
        private readonly ColumnHeader columnHeader4 = new ColumnHeader();
        private readonly ColumnHeader columnHeader5 = new ColumnHeader();
        private readonly ColumnHeader columnHeader6 = new ColumnHeader();
        private readonly ColumnHeader columnHeader7 = new ColumnHeader();
        private readonly ColumnHeader columnHeader8 = new ColumnHeader();
        private readonly ColumnHeader columnHeader9 = new ColumnHeader();
        private readonly Label currentConnectionsLabel = new Label();
        private readonly XtraTabPage gameInfoTab = new XtraTabPage();
        private readonly GroupControl groupControl1 = new GroupControl();
        private readonly GroupControl groupControl2 = new GroupControl();
        private readonly GroupControl groupControl3 = new GroupControl();
        private readonly GroupControl groupControl4 = new GroupControl();
        private readonly GroupControl groupControl5 = new GroupControl();
        private readonly Label label1 = new Label();
        private readonly Label label2 = new Label();
        private readonly Label label3 = new Label();
        private readonly Label label4 = new Label();
        private readonly Label label5 = new Label();
        private readonly Label label8 = new Label();
        private readonly Label label9 = new Label();
        private readonly Label maxConnectionsLabel = new Label();
        private readonly ListView onlineListView = new ListView();
        private readonly Label playersInGameLabel = new Label();
        private readonly ListView totalListView = new ListView();
        private readonly Label totalPlayersLabel = new Label();
        private readonly Label trustedLabel = new Label();
        private readonly Label untrustedLabel = new Label();
        private readonly XtraTabControl xtraTabControl1 = new XtraTabControl();
        private readonly XtraTabPage xtraTabPage1 = new XtraTabPage();
        private readonly XtraTabPage xtraTabPage2 = new XtraTabPage();

        #endregion
    }
}