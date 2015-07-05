namespace WPSocketServer {
    partial class frmUsers {
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
            this.lvwUsers = new System.Windows.Forms.ListView();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.cmdConnections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwUsers
            // 
            this.lvwUsers.Location = new System.Drawing.Point(12, 12);
            this.lvwUsers.Name = "lvwUsers";
            this.lvwUsers.Size = new System.Drawing.Size(260, 240);
            this.lvwUsers.TabIndex = 0;
            this.lvwUsers.UseCompatibleStateImageBehavior = false;
            this.lvwUsers.View = System.Windows.Forms.View.Details;
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Location = new System.Drawing.Point(12, 258);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(75, 23);
            this.cmdDisconnect.TabIndex = 1;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // cmdConnections
            // 
            this.cmdConnections.Location = new System.Drawing.Point(93, 258);
            this.cmdConnections.Name = "cmdConnections";
            this.cmdConnections.Size = new System.Drawing.Size(75, 23);
            this.cmdConnections.TabIndex = 2;
            this.cmdConnections.Text = "Connections";
            this.cmdConnections.UseVisualStyleBackColor = true;
            this.cmdConnections.Click += new System.EventHandler(this.cmdConnections_Click);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.cmdConnections);
            this.Controls.Add(this.cmdDisconnect);
            this.Controls.Add(this.lvwUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsers";
            this.Text = "WPSocketServer - Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwUsers;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdConnections;

    }
}