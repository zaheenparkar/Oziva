namespace PC_Application.Scanning
{
    partial class frmDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cboPackLvl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lstView);
            this.GroupBox1.Controls.Add(this.lblMessage);
            this.GroupBox1.Controls.Add(this.Panel2);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(943, 441);
            this.GroupBox1.TabIndex = 50;
            this.GroupBox1.TabStop = false;
            // 
            // lstView
            // 
            this.lstView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstView.Font = new System.Drawing.Font("Verdana", 9F);
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(3, 120);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(937, 293);
            this.lstView.TabIndex = 11;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(3, 413);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(937, 25);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblDevice);
            this.Panel2.Controls.Add(this.cboPackLvl);
            this.Panel2.Controls.Add(this.label2);
            this.Panel2.Controls.Add(this.lblmsg);
            this.Panel2.Controls.Add(this.btnConnect);
            this.Panel2.Controls.Add(this.btnSync);
            this.Panel2.Controls.Add(this.btnClose);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(3, 16);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(937, 104);
            this.Panel2.TabIndex = 0;
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDevice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.White;
            this.lblDevice.Location = new System.Drawing.Point(12, 67);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(191, 23);
            this.lblDevice.TabIndex = 63;
            this.lblDevice.Text = "Device is not connected";
            this.lblDevice.Visible = false;
            // 
            // cboPackLvl
            // 
            this.cboPackLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackLvl.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPackLvl.FormattingEnabled = true;
            this.cboPackLvl.Items.AddRange(new object[] {
            "(Select)",
            "Inward Scanning",
            "Outward Scanning",
            "Secondary Scanning",
            "Tertiary Scanning",
            "Parent Child Scanning",
            "Secondary Barcode Rejection",
            "Tertiary Barcode Rejection"});
            this.cboPackLvl.Location = new System.Drawing.Point(118, 18);
            this.cboPackLvl.Name = "cboPackLvl";
            this.cboPackLvl.Size = new System.Drawing.Size(284, 29);
            this.cboPackLvl.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 47;
            this.label2.Text = "Select Type :";
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblmsg.Location = new System.Drawing.Point(20, 42);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 25);
            this.lblmsg.TabIndex = 46;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(408, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(125, 30);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSync.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnSync.ForeColor = System.Drawing.Color.White;
            this.btnSync.Location = new System.Drawing.Point(539, 16);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(125, 30);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Sync Data";
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(670, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel3.Controls.Add(this.Label8);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(943, 32);
            this.Panel3.TabIndex = 49;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.Location = new System.Drawing.Point(12, 4);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(255, 26);
            this.Label8.TabIndex = 9;
            this.Label8.Text = "Download Data From Device";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(943, 473);
            this.lblStatus.TabIndex = 48;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 473);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Scanning Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.GroupBox1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ListView lstView;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblmsg;
        internal System.Windows.Forms.Button btnConnect;
        internal System.Windows.Forms.Button btnSync;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboPackLvl;
        internal System.Windows.Forms.Label lblDevice;
    }
}