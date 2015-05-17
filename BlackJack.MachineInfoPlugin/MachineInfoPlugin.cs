using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using BlackJack.Server;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Microsoft.SqlServer.Server;
using Timer = System.Threading.Timer;

namespace BlackJack.MachineInfoPlugin
{
    public class MachineInfoPlugin : IPlugin
    {
        ~MachineInfoPlugin()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (_viewUpdateTimer != null)
                _viewUpdateTimer.Dispose();
            Context.TabControl.TabPages.Remove(machineInfoTab);
            if (!machineInfoTab.IsDisposed)
                machineInfoTab.Dispose();
        }

        public string Name
        {
            get { return "Machine info plugin"; }
        }
        private Timer _viewUpdateTimer;
        private ServerContext Context;
        public void DoWork(ServerContext context)
        {
            Context = context;
            InitializeComponents();
            _viewUpdateTimer = new Timer(this.UpdateViewFromContext, context, 0, 1000);
            context.TabControl.TabPages.Add(machineInfoTab);
        }

        private int _prevModulesCount = 0;
        private int _prevThreadCount = 0;
        private void UpdateViewFromContext(object state)
        {
            var context = state as ServerContext;
            var proc = context.CurrentProcess;
            var modules = proc.Modules;
            var threads = proc.Threads;

            machineInfoTab.Invoke(() =>
            {
                gcMemoryLabel.Text = FormatBytes(GC.GetTotalMemory(false));
                physMemoryLabel.Text = FormatBytes(proc.PrivateMemorySize64);
                virtMemoryLabel.Text = FormatBytes(proc.VirtualMemorySize64);
                pagedMemoryLabel.Text = FormatBytes(proc.PagedMemorySize64);

                pidLabel.Text = proc.Id.ToString();
                pnameLabel.Text = proc.ProcessName;
                priorityLabel.Text = proc.BasePriority.ToString();
                handlesLabel.Text = proc.HandleCount.ToString();
                modulesLabel.Text = modules.Count.ToString();

                threadCountLabel.Text = threads.Count.ToString();

                if (_prevModulesCount != modules.Count)
                {
                    _prevModulesCount = modules.Count;
                    modulesListView.Items.Clear();
                    var list = new List<String>();
                    foreach (ProcessModule module in modules)
                        list.Add(module.ModuleName);
                    list.Sort();
                    foreach (var m in list)
                        modulesListView.Items.Add(m);
                }

                if (_prevThreadCount != threads.Count)
                {
                    _prevThreadCount = threads.Count;
                    threadListView.Items.Clear();
                    var list = new List<ListViewItem>();
                    foreach (ProcessThread t in threads)
                    {
                        try
                        {
                            var item = new ListViewItem(t.Id.ToString());
                            item.SubItems.Add(t.CurrentPriority.ToString());
                            item.SubItems.Add(t.PriorityLevel.ToString());
                            item.SubItems.Add(t.ThreadState.ToString());
                            list.Add(item);
                        }
                        catch (Exception) { }
                    }
                    list.Sort(new Comparison<ListViewItem>((left, right) => Convert.ToInt32(left.Text) > Convert.ToInt32(right.Text) ? Convert.ToInt32(left.Text) < Convert.ToInt32(right.Text)? -1 : 1 : 0));
                    threadListView.Items.AddRange(list.ToArray());
                } 
            });
        }

        private String FormatBytes(long byteCount)
        {
            var result = "B";
            if (byteCount > 1024)
            {
                byteCount /= 1024;
                result = "KB";
            }
            if (byteCount > 1024)
            {
                byteCount /= 1024;
                result = "MB";
            } 
            if (byteCount > 1024)
            {
                byteCount /= 1024;
                result = "GB";
            }
            return String.Format("{0} {1}", byteCount, result);
        }
        private void InitializeComponents()
        {
            // 
            // machineInfoTab
            // 
            this.machineInfoTab.Controls.Add(this.groupControl1);
            this.machineInfoTab.Name = "machineInfoTab";
            this.machineInfoTab.Size = new System.Drawing.Size(650, 398);
            this.machineInfoTab.Text = "Machine info";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupControl4);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(650, 398);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Server machine information";
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl4.Controls.Add(this.modulesListView);
            this.groupControl4.Controls.Add(this.label13);
            this.groupControl4.Controls.Add(this.modulesLabel);
            this.groupControl4.Controls.Add(this.handlesLabel);
            this.groupControl4.Controls.Add(this.label11);
            this.groupControl4.Controls.Add(this.priorityLabel);
            this.groupControl4.Controls.Add(this.label10);
            this.groupControl4.Controls.Add(this.pnameLabel);
            this.groupControl4.Controls.Add(this.label12);
            this.groupControl4.Controls.Add(this.pidLabel);
            this.groupControl4.Controls.Add(this.label9);
            this.groupControl4.Location = new System.Drawing.Point(5, 147);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(250, 246);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "Process info";
            // 
            // modulesListView
            // 
            this.modulesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
            this.modulesListView.FullRowSelect = true;
            this.modulesListView.GridLines = true;
            this.modulesListView.Location = new System.Drawing.Point(5, 126);
            this.modulesListView.Name = "modulesListView";
            this.modulesListView.Size = new System.Drawing.Size(240, 115);
            this.modulesListView.TabIndex = 2;
            this.modulesListView.UseCompatibleStateImageBehavior = false;
            this.modulesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Module name";
            this.columnHeader7.Width = 215;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Modules loaded: ";
            // 
            // modulesLabel
            // 
            this.modulesLabel.AutoSize = true;
            this.modulesLabel.Location = new System.Drawing.Point(100, 110);
            this.modulesLabel.Name = "modulesLabel";
            this.modulesLabel.Size = new System.Drawing.Size(13, 13);
            this.modulesLabel.TabIndex = 1;
            this.modulesLabel.Text = "0";
            // 
            // handlesLabel
            // 
            this.handlesLabel.AutoSize = true;
            this.handlesLabel.Location = new System.Drawing.Point(100, 90);
            this.handlesLabel.Name = "handlesLabel";
            this.handlesLabel.Size = new System.Drawing.Size(13, 13);
            this.handlesLabel.TabIndex = 1;
            this.handlesLabel.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Opened handles: ";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(100, 70);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(13, 13);
            this.priorityLabel.TabIndex = 1;
            this.priorityLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Base priority: ";
            // 
            // pnameLabel
            // 
            this.pnameLabel.AutoSize = true;
            this.pnameLabel.Location = new System.Drawing.Point(100, 50);
            this.pnameLabel.Name = "pnameLabel";
            this.pnameLabel.Size = new System.Drawing.Size(13, 13);
            this.pnameLabel.TabIndex = 1;
            this.pnameLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Process name: ";
            // 
            // pidLabel
            // 
            this.pidLabel.AutoSize = true;
            this.pidLabel.Location = new System.Drawing.Point(100, 30);
            this.pidLabel.Name = "pidLabel";
            this.pidLabel.Size = new System.Drawing.Size(13, 13);
            this.pidLabel.TabIndex = 1;
            this.pidLabel.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Process ID: ";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.threadListView);
            this.groupControl3.Controls.Add(this.threadCountLabel);
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Location = new System.Drawing.Point(261, 24);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(382, 369);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Thread usage";
            // 
            // threadListView
            // 
            this.threadListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.threadListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.threadListView.FullRowSelect = true;
            this.threadListView.GridLines = true;
            this.threadListView.Location = new System.Drawing.Point(5, 54);
            this.threadListView.Name = "threadListView";
            this.threadListView.Size = new System.Drawing.Size(372, 310);
            this.threadListView.TabIndex = 2;
            this.threadListView.UseCompatibleStateImageBehavior = false;
            this.threadListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current priority";
            this.columnHeader2.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Priority level";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thread state";
            this.columnHeader4.Width = 85;
            // 
            // threadCountLabel
            // 
            this.threadCountLabel.AutoSize = true;
            this.threadCountLabel.Location = new System.Drawing.Point(190, 30);
            this.threadCountLabel.Name = "threadCountLabel";
            this.threadCountLabel.Size = new System.Drawing.Size(13, 13);
            this.threadCountLabel.TabIndex = 1;
            this.threadCountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "System threads used by application: ";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.label8);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.pagedMemoryLabel);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.virtMemoryLabel);
            this.groupControl2.Controls.Add(this.physMemoryLabel);
            this.groupControl2.Controls.Add(this.gcMemoryLabel);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Location = new System.Drawing.Point(5, 24);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(250, 117);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Memory usage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Paged allocated: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Virtual allocated: ";
            // 
            // pagedMemoryLabel
            // 
            this.pagedMemoryLabel.AutoSize = true;
            this.pagedMemoryLabel.Location = new System.Drawing.Point(100, 90);
            this.pagedMemoryLabel.Name = "pagedMemoryLabel";
            this.pagedMemoryLabel.Size = new System.Drawing.Size(13, 13);
            this.pagedMemoryLabel.TabIndex = 1;
            this.pagedMemoryLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Physical allocated: ";
            // 
            // virtMemoryLabel
            // 
            this.virtMemoryLabel.AutoSize = true;
            this.virtMemoryLabel.Location = new System.Drawing.Point(100, 70);
            this.virtMemoryLabel.Name = "virtMemoryLabel";
            this.virtMemoryLabel.Size = new System.Drawing.Size(13, 13);
            this.virtMemoryLabel.TabIndex = 1;
            this.virtMemoryLabel.Text = "0";
            // 
            // physMemoryLabel
            // 
            this.physMemoryLabel.AutoSize = true;
            this.physMemoryLabel.Location = new System.Drawing.Point(100, 50);
            this.physMemoryLabel.Name = "physMemoryLabel";
            this.physMemoryLabel.Size = new System.Drawing.Size(13, 13);
            this.physMemoryLabel.TabIndex = 1;
            this.physMemoryLabel.Text = "0";
            // 
            // gcMemoryLabel
            // 
            this.gcMemoryLabel.AutoSize = true;
            this.gcMemoryLabel.Location = new System.Drawing.Point(100, 30);
            this.gcMemoryLabel.Name = "gcMemoryLabel";
            this.gcMemoryLabel.Size = new System.Drawing.Size(13, 13);
            this.gcMemoryLabel.TabIndex = 1;
            this.gcMemoryLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Allocated by GC: ";
        }

        #region WinForms controls

        private XtraTabPage machineInfoTab = new XtraTabPage();
        private GroupControl groupControl1 = new GroupControl();
        private GroupControl groupControl2 = new GroupControl();
        private GroupControl groupControl4 = new GroupControl();
        private ListView modulesListView = new ListView();
        private ColumnHeader columnHeader7 = new ColumnHeader();
        private Label label13 = new Label();
        private Label modulesLabel = new Label();
        private Label handlesLabel = new Label();
        private Label label11 = new Label();
        private Label priorityLabel = new Label();
        private Label label10 = new Label();
        private Label pnameLabel = new Label();
        private Label label12 = new Label();
        private Label pidLabel = new Label();
        private Label label9 = new Label();
        private GroupControl groupControl3 = new GroupControl();
        private ListView threadListView = new ListView();
        private ColumnHeader columnHeader1 = new ColumnHeader();
        private ColumnHeader columnHeader2 = new ColumnHeader();
        private ColumnHeader columnHeader3 = new ColumnHeader();
        private ColumnHeader columnHeader4 = new ColumnHeader();
        private ColumnHeader columnHeader5 = new ColumnHeader();
        private ColumnHeader columnHeader6 = new ColumnHeader();
        private Label threadCountLabel = new Label();
        private Label label3 = new Label();
        private Label label8 = new Label();
        private Label label5 = new Label();
        private Label pagedMemoryLabel = new Label();
        private Label label1 = new Label();
        private Label virtMemoryLabel = new Label();
        private Label physMemoryLabel = new Label();
        private Label gcMemoryLabel = new Label();
        private Label label2 = new Label();

        #endregion
    }
}