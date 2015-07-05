namespace WPSocketServer {
    partial class frmConnections {
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
            this.lvwConnections = new System.Windows.Forms.ListView();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwConnections
            // 
            this.lvwConnections.Location = new System.Drawing.Point(12, 12);
            this.lvwConnections.Name = "lvwConnections";
            this.lvwConnections.Size = new System.Drawing.Size(260, 241);
            this.lvwConnections.TabIndex = 0;
            this.lvwConnections.UseCompatibleStateImageBehavior = false;
            this.lvwConnections.View = System.Windows.Forms.View.Details;
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Location = new System.Drawing.Point(12, 259);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(75, 23);
            this.cmdDisconnect.TabIndex = 1;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            // 
            // frmConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.cmdDisconnect);
            this.Controls.Add(this.lvwConnections);
            this.Name = "frmConnections";
            this.Text = "Connections";
            this.Load += new System.EventHandler(this.frmConnections_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwConnections;
        private System.Windows.Forms.Button cmdDisconnect;
    }
}