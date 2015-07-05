using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPSocket;
namespace WPSocketClientTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private AsyncSocket _socket;
        private void Form1_Load(object sender, EventArgs e) {
            _socket = new AsyncSocket();
            _socket.CouldNotConnect += _socket_CouldNotConnect;
            _socket.SocketConnected += _socket_SocketConnected;
            _socket.SocketDataArrival += _socket_SocketDataArrival;
            _socket.SocketDisconnected += _socket_SocketDisconnected;
            _socket.SocketError += _socket_SocketError;
        }

        private void _socket_SocketError(Exception ex) {
            ResetSocket();
        }

        private void _socket_SocketDisconnected(string SocketID) {
            ResetSocket();
        }

        private void _socket_SocketDataArrival(string SocketID, string SocketData, byte[] lBytes, int lBytesRead) {
            var msg = txtIncoming.Text + Environment.NewLine + SocketData;
            this.UIThread(() => txtIncoming.Text = msg);
            var splt = SocketData.Split(':');
            switch (splt[0]) {
                case "msg":
                    switch (splt[1].Trim()) {
                        case "Authentication Success":
                            this.UIThread(() => cmdDestroy.Enabled = true);
                            this.UIThread(() => cmdList.Enabled = true);
                            this.UIThread(() => cmdMonitor.Enabled = true);
                            this.UIThread(() => cmdSend.Enabled = true);
                            this.UIThread(() => cmdCreate.Enabled = true);
                            this.UIThread(() => cmdDisconnect.Enabled = true);
                            this.UIThread(() => cmdAuth.Enabled = false);
                            this.UIThread(() => cmd_Connect.Enabled = true);
                            this.UIThread(() => cmdStopMonitoring.Enabled = true);
                            break;
                    }
                    break;
            }
        }

        private void _socket_SocketConnected(string SocketID) {
            this.UIThread(() => cmdConnect.Text = "Disconnect");
            this.UIThread(() => cmdClose.Enabled = true);
            this.UIThread(() => cmdAuth.Enabled = true);
        }

        private void _socket_CouldNotConnect(string SocketID) {
            this.UIThread(() => cmdConnect.Text = "Connect");
        }

        private void cmdSend_Click(object sender, EventArgs e) {
            _socket.Send(txtOutgoing.Text + Environment.NewLine);
            txtOutgoing.Text = "";
        }

        private void cmdConnect_Click(object sender, EventArgs e) {
            if (cmdConnect.Text == "Connect") {
                _socket.Connect(txtServer.Text, long.Parse(txtPort.Text));
            } else {
                _socket.Send("close" + Environment.NewLine);
                System.Threading.Thread.Sleep(200);
                _socket.Close();
            }
        }

        private void cmdAuth_Click(object sender, EventArgs e) {
            try {
                _socket.Send("auth guide_X@live.com talaxian#1");
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cmdList_Click(object sender, EventArgs e) {
            try {
                _socket.Send("list");
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cmdMonitor_Click(object sender, EventArgs e) {
            try {
                _socket.Send("monitor " + txtMonitorId.Text);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e) {
            try {
                _socket.Send("create " + txtCreateServer.Text + " " + txtCreatePort.Text + " 1");
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cmd_Connect_Click(object sender, EventArgs e) {
            try {
                _socket.Send("connect " + txtMonitorId.Text);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cmdDestroy_Click(object sender, EventArgs e) {
            _socket.Send("destroy " + txtMonitorId.Text);
        }

        private void button1_Click(object sender, EventArgs e) {
            _socket.Send("disconnect " + txtMonitorId.Text);
        }

        private void cmdClose_Click(object sender, EventArgs e) {
            _socket.Send("close " + txtMonitorId.Text);
            System.Threading.Thread.Sleep(200);
            _socket.Close();
            ResetSocket();
        }
        private void ResetSocket() {
            this.UIThread(() => cmdConnect.Text = "Connect");
            this.UIThread(() => cmdConnect.Enabled = true);
            this.UIThread(() => cmdDestroy.Enabled = false);
            this.UIThread(() => cmdList.Enabled = false);
            this.UIThread(() => cmdMonitor.Enabled = false);
            this.UIThread(() => cmdDisconnect.Enabled = false);
            this.UIThread(() => cmdSend.Enabled = false);
            this.UIThread(() => cmdCreate.Enabled = false);
            this.UIThread(() => cmdClose.Enabled = false);
            this.UIThread(() => cmdAuth.Enabled = false);
            this.UIThread(() => cmdStopMonitoring.Enabled = false);
            this.UIThread(() => cmd_Connect.Enabled = false);
            System.Threading.Thread.Sleep(200);
            _socket = new AsyncSocket();
            _socket.CouldNotConnect += _socket_CouldNotConnect;
            _socket.SocketConnected += _socket_SocketConnected;
            _socket.SocketDataArrival += _socket_SocketDataArrival;
            _socket.SocketDisconnected += _socket_SocketDisconnected;
        }

        private void cmdStopMonitoring_Click(object sender, EventArgs e) {
            _socket.Send("stopmonitoring " + txtMonitorId.Text);
        }
    }
}