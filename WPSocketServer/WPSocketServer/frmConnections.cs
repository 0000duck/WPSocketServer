using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPSocketServer.Business.Objects;

namespace WPSocketServer {
    public partial class frmConnections : Form {
        public frmConnections() {
            InitializeComponent();
        }

        private void frmConnections_Load(object sender, EventArgs e) {
            lvwConnections.Columns.Clear();
            lvwConnections.Columns.Add(new ColumnHeader() {
                Text = "Id"
            });
            lvwConnections.Columns.Add(new ColumnHeader() {
                Text = "Server"
            });
            lvwConnections.Columns.Add(new ColumnHeader() {
                Text = "Port"
            });
            lvwConnections.Columns.Add(new ColumnHeader() {
                Text = "Connected"
            });
        }
        public void AddToListView(int id, string server, long port, bool connected) {
            var item = lvwConnections.Items.Add(new ListViewItem() {
                Text = id.ToString(),
            });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() {
                Text = server
            });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() {
                Text = port.ToString()
            });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() {
                Text = connected.ToString()
            });
        }
    }
}
