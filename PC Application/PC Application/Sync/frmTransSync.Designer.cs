namespace PC_Application.Sync
{
    partial class frmTransSync
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Batch Details");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Request Generation");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Secondary Data");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Tertiary Data");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Relation Data");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Tertiary Rejection");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Secondary Rejection");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransSync));
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblCentral = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnSec = new System.Windows.Forms.Button();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel3.Controls.Add(this.Label8);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(988, 32);
            this.Panel3.TabIndex = 52;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.Location = new System.Drawing.Point(12, 4);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(223, 23);
            this.Label8.TabIndex = 9;
            this.Label8.Text = "Transaction Data Sync";
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.btnConnect);
            this.Panel2.Controls.Add(this.lblLocal);
            this.Panel2.Controls.Add(this.lblCentral);
            this.Panel2.Controls.Add(this.lstView);
            this.Panel2.Location = new System.Drawing.Point(0, 38);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(988, 363);
            this.Panel2.TabIndex = 54;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.Maroon;
            this.btnConnect.Location = new System.Drawing.Point(11, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 75);
            this.btnConnect.TabIndex = 65;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblLocal
            // 
            this.lblLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocal.ForeColor = System.Drawing.Color.White;
            this.lblLocal.Location = new System.Drawing.Point(150, 65);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(381, 31);
            this.lblLocal.TabIndex = 2;
            this.lblLocal.Text = "Local Server Connected";
            this.lblLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCentral
            // 
            this.lblCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCentral.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentral.ForeColor = System.Drawing.Color.White;
            this.lblCentral.Location = new System.Drawing.Point(150, 21);
            this.lblCentral.Name = "lblCentral";
            this.lblCentral.Size = new System.Drawing.Size(381, 31);
            this.lblCentral.TabIndex = 1;
            this.lblCentral.Text = "Central Server Connected";
            this.lblCentral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.CheckBoxes = true;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            this.lstView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lstView.Location = new System.Drawing.Point(11, 115);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(964, 219);
            this.lstView.TabIndex = 0;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Transaction";
            this.columnHeader1.Width = 331;
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSync.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSync.BackgroundImage")));
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSync.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ForeColor = System.Drawing.Color.Maroon;
            this.btnSync.Location = new System.Drawing.Point(16, 407);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(125, 35);
            this.btnSync.TabIndex = 65;
            this.btnSync.Text = "Sync Data";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Visible = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnSec
            // 
            this.btnSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSec.BackgroundImage")));
            this.btnSec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSec.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSec.ForeColor = System.Drawing.Color.Maroon;
            this.btnSec.Location = new System.Drawing.Point(219, 407);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(125, 35);
            this.btnSec.TabIndex = 66;
            this.btnSec.Text = "Sync Sec Data";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Visible = false;
            // 
            // frmTransSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(988, 454);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel3);
            this.Name = "frmTransSync";
            this.Text = "Transcation Data Sync";
            this.Load += new System.EventHandler(this.frmTransSync_Load);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblCentral;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Button btnSync;
        internal System.Windows.Forms.Button btnSec;
    }
}