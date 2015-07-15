namespace WPSocketServer {
    partial class frmMain {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblUsersDescription = new System.Windows.Forms.Label();
            this.lblUsersOnlineCount = new System.Windows.Forms.Label();
            this.lblUserSocketsDescription = new System.Windows.Forms.Label();
            this.lblUserSockets = new System.Windows.Forms.Label();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.cmdShowUsers = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsersDescription
            // 
            this.lblUsersDescription.AutoSize = true;
            this.lblUsersDescription.Location = new System.Drawing.Point(9, 33);
            this.lblUsersDescription.Name = "lblUsersDescription";
            this.lblUsersDescription.Size = new System.Drawing.Size(37, 13);
            this.lblUsersDescription.TabIndex = 0;
            this.lblUsersDescription.Text = "Users:";
            // 
            // lblUsersOnlineCount
            // 
            this.lblUsersOnlineCount.AutoSize = true;
            this.lblUsersOnlineCount.Location = new System.Drawing.Point(361, 33);
            this.lblUsersOnlineCount.Name = "lblUsersOnlineCount";
            this.lblUsersOnlineCount.Size = new System.Drawing.Size(13, 13);
            this.lblUsersOnlineCount.TabIndex = 1;
            this.lblUsersOnlineCount.Text = "0";
            // 
            // lblUserSocketsDescription
            // 
            this.lblUserSocketsDescription.AutoSize = true;
            this.lblUserSocketsDescription.Location = new System.Drawing.Point(9, 57);
            this.lblUserSocketsDescription.Name = "lblUserSocketsDescription";
            this.lblUserSocketsDescription.Size = new System.Drawing.Size(46, 13);
            this.lblUserSocketsDescription.TabIndex = 2;
            this.lblUserSocketsDescription.Text = "Sockets";
            // 
            // lblUserSockets
            // 
            this.lblUserSockets.AutoSize = true;
            this.lblUserSockets.Location = new System.Drawing.Point(361, 57);
            this.lblUserSockets.Name = "lblUserSockets";
            this.lblUserSockets.Size = new System.Drawing.Size(13, 13);
            this.lblUserSockets.TabIndex = 3;
            this.lblUserSockets.Text = "0";
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Interval = 5000;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // cmdShowUsers
            // 
            this.cmdShowUsers.Enabled = false;
            this.cmdShowUsers.Location = new System.Drawing.Point(174, 83);
            this.cmdShowUsers.Name = "cmdShowUsers";
            this.cmdShowUsers.Size = new System.Drawing.Size(75, 23);
            this.cmdShowUsers.TabIndex = 4;
            this.cmdShowUsers.Text = "Users";
            this.cmdShowUsers.UseVisualStyleBackColor = true;
            this.cmdShowUsers.Click += new System.EventHandler(this.cmdShowUsers_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(12, 83);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 5;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Enabled = false;
            this.cmdStop.Location = new System.Drawing.Point(93, 83);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 6;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(361, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Server Closed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Status:";
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(469, 118);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdShowUsers);
            this.Controls.Add(this.lblUserSockets);
            this.Controls.Add(this.lblUserSocketsDescription);
            this.Controls.Add(this.lblUsersOnlineCount);
            this.Controls.Add(this.lblUsersDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "WPSocketServer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsersDescription;
        private System.Windows.Forms.Label lblUsersOnlineCount;
        private System.Windows.Forms.Label lblUserSocketsDescription;
        private System.Windows.Forms.Label lblUserSockets;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private System.Windows.Forms.Button cmdShowUsers;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
    }
}

