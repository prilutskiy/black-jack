using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack.Server
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddMessageToEventLog(String msg)
        {
            var item = new ListViewItem();
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add(msg);
            serverLogListView.Items.Add(item);
        }
    }
}
