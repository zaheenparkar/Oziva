namespace PC_Application.Reports
{
    partial class frmTerRpt
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label15 = new System.Windows.Forms.Label();
            this.pnlView = new System.Windows.Forms.Panel();
            this.cboBatchCond = new System.Windows.Forms.ComboBox();
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.rdbMapped = new System.Windows.Forms.RadioButton();
            this.rdbRejected = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.Panel1.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.grpSelect.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel1.Controls.Add(this.Label15);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1145, 7);
            this.Panel1.TabIndex = 72;
            this.Panel1.Visible = false;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.White;
            this.Label15.Location = new System.Drawing.Point(12, 4);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(218, 23);
            this.Label15.TabIndex = 9;
            this.Label15.Text = "Mapping Job Creation";
            // 
            // pnlView
            // 
            this.pnlView.BackColor = System.Drawing.Color.White;
            this.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlView.Controls.Add(this.cboBatchCond);
            this.pnlView.Controls.Add(this.grpSelect);
            this.pnlView.Controls.Add(this.button2);
            this.pnlView.Controls.Add(this.btnSearch);
            this.pnlView.Controls.Add(this.button1);
            this.pnlView.Controls.Add(this.label6);
            this.pnlView.Controls.Add(this.txtBatch);
            this.pnlView.Controls.Add(this.lblRecord);
            this.pnlView.Controls.Add(this.groupBox3);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1145, 565);
            this.pnlView.TabIndex = 73;
            // 
            // cboBatchCond
            // 
            this.cboBatchCond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchCond.Font = new System.Drawing.Font("Calibri", 12F);
            this.cboBatchCond.FormattingEnabled = true;
            this.cboBatchCond.Items.AddRange(new object[] {
            "=",
            "Like"});
            this.cboBatchCond.Location = new System.Drawing.Point(88, 8);
            this.cboBatchCond.Name = "cboBatchCond";
            this.cboBatchCond.Size = new System.Drawing.Size(56, 27);
            this.cboBatchCond.TabIndex = 71;
            // 
            // grpSelect
            // 
            this.grpSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelect.Controls.Add(this.rdbMapped);
            this.grpSelect.Controls.Add(this.rdbRejected);
            this.grpSelect.Controls.Add(this.rdbAll);
            this.grpSelect.Font = new System.Drawing.Font("Calibri", 12F);
            this.grpSelect.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grpSelect.Location = new System.Drawing.Point(3, 38);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(1138, 57);
            this.grpSelect.TabIndex = 69;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "Select Criteria";
            // 
            // rdbMapped
            // 
            this.rdbMapped.AutoSize = true;
            this.rdbMapped.Font = new System.Drawing.Font("Verdana", 9F);
            this.rdbMapped.ForeColor = System.Drawing.Color.Black;
            this.rdbMapped.Location = new System.Drawing.Point(274, 23);
            this.rdbMapped.Name = "rdbMapped";
            this.rdbMapped.Size = new System.Drawing.Size(75, 18);
            this.rdbMapped.TabIndex = 2;
            this.rdbMapped.TabStop = true;
            this.rdbMapped.Text = "Mapped";
            this.rdbMapped.UseVisualStyleBackColor = true;
            // 
            // rdbRejected
            // 
            this.rdbRejected.AutoSize = true;
            this.rdbRejected.Font = new System.Drawing.Font("Verdana", 9F);
            this.rdbRejected.ForeColor = System.Drawing.Color.Black;
            this.rdbRejected.Location = new System.Drawing.Point(130, 23);
            this.rdbRejected.Name = "rdbRejected";
            this.rdbRejected.Size = new System.Drawing.Size(80, 18);
            this.rdbRejected.TabIndex = 1;
            this.rdbRejected.TabStop = true;
            this.rdbRejected.Text = "Rejected";
            this.rdbRejected.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAll.ForeColor = System.Drawing.Color.Black;
            this.rdbAll.Location = new System.Drawing.Point(13, 23);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(39, 18);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(556, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 26);
            this.button2.TabIndex = 67;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(321, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(420, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 26);
            this.button1.TabIndex = 66;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 65;
            this.label6.Text = "Batch No :";
            // 
            // txtBatch
            // 
            this.txtBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatch.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtBatch.Location = new System.Drawing.Point(149, 9);
            this.txtBatch.MaxLength = 14;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(147, 27);
            this.txtBatch.TabIndex = 0;
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Calibri", 11F);
            this.lblRecord.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRecord.Location = new System.Drawing.Point(10, 532);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(118, 18);
            this.lblRecord.TabIndex = 64;
            this.lblRecord.Text = "0 record(s) found.";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstView);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Location = new System.Drawing.Point(3, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1137, 419);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tertiary Summarised Report";
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(4, 21);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(1117, 392);
            this.lstView.TabIndex = 53;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // frmTerRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 565);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.pnlView);
            this.Name = "frmTerRpt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTerRpt_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Panel pnlView;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtBatch;
        internal System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.RadioButton rdbMapped;
        private System.Windows.Forms.RadioButton rdbRejected;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.ComboBox cboBatchCond;
    }
}