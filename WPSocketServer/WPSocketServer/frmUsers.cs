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
    public partial class frmUsers : Form {
        public frmUsers() {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e) {
            lvwUsers.Columns.Clear();
            lvwUsers.Columns.Add(new ColumnHeader() {
                Text = "UserId"
            });
            lvwUsers.Columns.Add(new ColumnHeader() {
                Text = "Email"
            });
            foreach (var user in GlobalObjects.Users.GetAll()) {
                var item = lvwUsers.Items.Add(new ListViewItem() {
                    Text = user.UserModel.UserId.ToString()
                });
                item.SubItems.Add(user.UserModel.EmailAddress);
            }
        }

        private void cmdDisconnect_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in lvwUsers.SelectedItems) {
                var index = int.Parse(item.Text);
                GlobalObjects.Users.Destroy(GlobalObjects.GetUser(index));
                lvwUsers.Items.Remove(item);
            }
        }

        private void cmdConnections_Click(object sender, EventArgs e) {
            var f = new frmConnections();
            foreach (ListViewItem item in lvwUsers.SelectedItems) {
                var id = int.Parse(item.Text);
                foreach (var _item in GlobalObjects.UserSockets.Get(id)) {
                    f.AddToListView(_item.Model.ConnectionId, _item.Model.Server, _item.Model.Port, _item.Model.Connected);
                }
            }
            f.Show();
        }
    }
}
