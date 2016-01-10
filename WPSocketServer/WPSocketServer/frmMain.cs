// teamnexgen.ddns.net
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using WPSocketServer.Business.Objects;
namespace WPSocketServer {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e) {
            try {

            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Timer Update UI Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrUpdateUI_Tick(object sender, EventArgs e) {
            try {
                lblUserSockets.Text = GlobalObjects.UserSockets.Count().ToString();
                lblUsersOnlineCount.Text = GlobalObjects.Users.Count().ToString();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Show users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdShowUsers_Click(object sender, EventArgs e) {
            try {
                var f = new frmUsers();
                f.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cmdStart_Click(object sender, EventArgs e) {
            cmdShowUsers.Enabled = true;
            cmdStop.Enabled = true;
            cmdStart.Enabled = false;
            lblStatus.Text = "Server Open";
            tmrUpdateUI.Start();
            GlobalObjects.EntryPoint();
        }
        private void cmdStop_Click(object sender, EventArgs e) {
            cmdShowUsers.Enabled = false;
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            lblStatus.Text = "Server Closed";
            tmrUpdateUI.Stop();
            lblUsersOnlineCount.Text = "0";
            lblUserSockets.Text = "0";
        }
    }
}