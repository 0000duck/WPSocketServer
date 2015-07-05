namespace WPSocketClientTest {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtOutgoing = new System.Windows.Forms.TextBox();
            this.txtIncoming = new System.Windows.Forms.TextBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAuth = new System.Windows.Forms.Button();
            this.cmdList = new System.Windows.Forms.Button();
            this.cmdMonitor = new System.Windows.Forms.Button();
            this.txtMonitorId = new System.Windows.Forms.TextBox();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtCreateServer = new System.Windows.Forms.TextBox();
            this.txtCreatePort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreateDescription = new System.Windows.Forms.TextBox();
            this.cmd_Connect = new System.Windows.Forms.Button();
            this.cmdDestroy = new System.Windows.Forms.Button();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.cmdStopMonitoring = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(121, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(196, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "teamnexgen.ddns.net";
            // 
            // txtOutgoing
            // 
            this.txtOutgoing.Location = new System.Drawing.Point(121, 288);
            this.txtOutgoing.Name = "txtOutgoing";
            this.txtOutgoing.Size = new System.Drawing.Size(115, 20);
            this.txtOutgoing.TabIndex = 2;
            // 
            // txtIncoming
            // 
            this.txtIncoming.Location = new System.Drawing.Point(121, 119);
            this.txtIncoming.Multiline = true;
            this.txtIncoming.Name = "txtIncoming";
            this.txtIncoming.Size = new System.Drawing.Size(196, 163);
            this.txtIncoming.TabIndex = 3;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(121, 90);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(196, 23);
            this.cmdConnect.TabIndex = 4;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.Enabled = false;
            this.cmdSend.Location = new System.Drawing.Point(242, 288);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 20);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(121, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(196, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "5999";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // cmdAuth
            // 
            this.cmdAuth.Enabled = false;
            this.cmdAuth.Location = new System.Drawing.Point(15, 119);
            this.cmdAuth.Name = "cmdAuth";
            this.cmdAuth.Size = new System.Drawing.Size(100, 23);
            this.cmdAuth.TabIndex = 8;
            this.cmdAuth.Text = "Auth";
            this.cmdAuth.UseVisualStyleBackColor = true;
            this.cmdAuth.Click += new System.EventHandler(this.cmdAuth_Click);
            // 
            // cmdList
            // 
            this.cmdList.Enabled = false;
            this.cmdList.Location = new System.Drawing.Point(392, 235);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(100, 23);
            this.cmdList.TabIndex = 9;
            this.cmdList.Text = "List";
            this.cmdList.UseVisualStyleBackColor = true;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // cmdMonitor
            // 
            this.cmdMonitor.Enabled = false;
            this.cmdMonitor.Location = new System.Drawing.Point(392, 119);
            this.cmdMonitor.Name = "cmdMonitor";
            this.cmdMonitor.Size = new System.Drawing.Size(100, 23);
            this.cmdMonitor.TabIndex = 10;
            this.cmdMonitor.Text = "Monitor";
            this.cmdMonitor.UseVisualStyleBackColor = true;
            this.cmdMonitor.Click += new System.EventHandler(this.cmdMonitor_Click);
            // 
            // txtMonitorId
            // 
            this.txtMonitorId.Location = new System.Drawing.Point(121, 64);
            this.txtMonitorId.Name = "txtMonitorId";
            this.txtMonitorId.Size = new System.Drawing.Size(196, 20);
            this.txtMonitorId.TabIndex = 11;
            this.txtMonitorId.Text = "0";
            // 
            // cmdCreate
            // 
            this.cmdCreate.Enabled = false;
            this.cmdCreate.Location = new System.Drawing.Point(392, 90);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(100, 23);
            this.cmdCreate.TabIndex = 12;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Enabled = false;
            this.cmdClose.Location = new System.Drawing.Point(15, 148);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 23);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtCreateServer
            // 
            this.txtCreateServer.Location = new System.Drawing.Point(392, 38);
            this.txtCreateServer.Name = "txtCreateServer";
            this.txtCreateServer.Size = new System.Drawing.Size(100, 20);
            this.txtCreateServer.TabIndex = 14;
            this.txtCreateServer.Text = "irc.freenode.org";
            // 
            // txtCreatePort
            // 
            this.txtCreatePort.Location = new System.Drawing.Point(392, 64);
            this.txtCreatePort.Name = "txtCreatePort";
            this.txtCreatePort.Size = new System.Drawing.Size(100, 20);
            this.txtCreatePort.TabIndex = 15;
            this.txtCreatePort.Text = "6667";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Server:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Description:";
            // 
            // txtCreateDescription
            // 
            this.txtCreateDescription.Location = new System.Drawing.Point(392, 12);
            this.txtCreateDescription.Name = "txtCreateDescription";
            this.txtCreateDescription.Size = new System.Drawing.Size(100, 20);
            this.txtCreateDescription.TabIndex = 18;
            // 
            // cmd_Connect
            // 
            this.cmd_Connect.Enabled = false;
            this.cmd_Connect.Location = new System.Drawing.Point(392, 148);
            this.cmd_Connect.Name = "cmd_Connect";
            this.cmd_Connect.Size = new System.Drawing.Size(100, 23);
            this.cmd_Connect.TabIndex = 21;
            this.cmd_Connect.Text = "Connect";
            this.cmd_Connect.UseVisualStyleBackColor = true;
            this.cmd_Connect.Click += new System.EventHandler(this.cmd_Connect_Click);
            // 
            // cmdDestroy
            // 
            this.cmdDestroy.Enabled = false;
            this.cmdDestroy.Location = new System.Drawing.Point(392, 177);
            this.cmdDestroy.Name = "cmdDestroy";
            this.cmdDestroy.Size = new System.Drawing.Size(100, 23);
            this.cmdDestroy.TabIndex = 22;
            this.cmdDestroy.Text = "Destroy";
            this.cmdDestroy.UseVisualStyleBackColor = true;
            this.cmdDestroy.Click += new System.EventHandler(this.cmdDestroy_Click);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Enabled = false;
            this.cmdDisconnect.Location = new System.Drawing.Point(392, 206);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(100, 23);
            this.cmdDisconnect.TabIndex = 23;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdStopMonitoring
            // 
            this.cmdStopMonitoring.Enabled = false;
            this.cmdStopMonitoring.Location = new System.Drawing.Point(392, 264);
            this.cmdStopMonitoring.Name = "cmdStopMonitoring";
            this.cmdStopMonitoring.Size = new System.Drawing.Size(100, 23);
            this.cmdStopMonitoring.TabIndex = 24;
            this.cmdStopMonitoring.Text = "Stop Monitoring";
            this.cmdStopMonitoring.UseVisualStyleBackColor = true;
            this.cmdStopMonitoring.Click += new System.EventHandler(this.cmdStopMonitoring_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ConnectionId:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 320);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdStopMonitoring);
            this.Controls.Add(this.cmdDisconnect);
            this.Controls.Add(this.cmdDestroy);
            this.Controls.Add(this.cmd_Connect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCreateDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCreatePort);
            this.Controls.Add(this.txtCreateServer);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.txtMonitorId);
            this.Controls.Add(this.cmdMonitor);
            this.Controls.Add(this.cmdList);
            this.Controls.Add(this.cmdAuth);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.txtIncoming);
            this.Controls.Add(this.txtOutgoing);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtOutgoing;
        private System.Windows.Forms.TextBox txtIncoming;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAuth;
        private System.Windows.Forms.Button cmdList;
        private System.Windows.Forms.Button cmdMonitor;
        private System.Windows.Forms.TextBox txtMonitorId;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtCreateServer;
        private System.Windows.Forms.TextBox txtCreatePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreateDescription;
        private System.Windows.Forms.Button cmd_Connect;
        private System.Windows.Forms.Button cmdDestroy;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdStopMonitoring;
        private System.Windows.Forms.Label label6;
    }
}

