namespace PC_Application.Transaction
{
    partial class frmCancelRequest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelRequest));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label15 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPacking = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtBatchno = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lstView = new System.Windows.Forms.ListView();
            this.Refno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ean_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brandname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manufacturing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Expiry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel1.Controls.Add(this.Label15);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1080, 7);
            this.Panel1.TabIndex = 46;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.White;
            this.Label15.Location = new System.Drawing.Point(12, 4);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(323, 23);
            this.Label15.TabIndex = 9;
            this.Label15.Text = "Rejection Of Generation Request";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.cboLine);
            this.GroupBox1.Controls.Add(this.cboPlant);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cboPacking);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 13F);
            this.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.GroupBox1.Location = new System.Drawing.Point(7, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1061, 66);
            this.GroupBox1.TabIndex = 47;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Line Selection";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(506, 34);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(70, 14);
            this.Label12.TabIndex = 28;
            this.Label12.Text = "Line Code";
            // 
            // cboLine
            // 
            this.cboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLine.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLine.ForeColor = System.Drawing.Color.Black;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(588, 29);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(129, 24);
            this.cboLine.TabIndex = 2;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // cboPlant
            // 
            this.cboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlant.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPlant.ForeColor = System.Drawing.Color.Black;
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Items.AddRange(new object[] {
            "Tertiary"});
            this.cboPlant.Location = new System.Drawing.Point(100, 30);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(130, 24);
            this.cboPlant.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "Plant Code";
            // 
            // cboPacking
            // 
            this.cboPacking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPacking.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPacking.ForeColor = System.Drawing.Color.Black;
            this.cboPacking.FormattingEnabled = true;
            this.cboPacking.Items.AddRange(new object[] {
            "Tertiary"});
            this.cboPacking.Location = new System.Drawing.Point(352, 30);
            this.cboPacking.Name = "cboPacking";
            this.cboPacking.Size = new System.Drawing.Size(132, 24);
            this.cboPacking.TabIndex = 1;
            this.cboPacking.SelectedIndexChanged += new System.EventHandler(this.cboPacking_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(248, 35);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(92, 14);
            this.Label11.TabIndex = 18;
            this.Label11.Text = "Packing Level";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.cboProduct);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txtBatchno);
            this.GroupBox2.Controls.Add(this.Label16);
            this.GroupBox2.Font = new System.Drawing.Font("Calibri", 13F);
            this.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.GroupBox2.Location = new System.Drawing.Point(7, 84);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1061, 67);
            this.GroupBox2.TabIndex = 48;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Product Selection (Optional)";
            // 
            // cboProduct
            // 
            this.cboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboProduct.ForeColor = System.Drawing.Color.Black;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(88, 32);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(394, 24);
            this.cboProduct.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(498, 38);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Batch No";
            // 
            // txtBatchno
            // 
            this.txtBatchno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchno.ForeColor = System.Drawing.Color.Black;
            this.txtBatchno.Location = new System.Drawing.Point(573, 33);
            this.txtBatchno.MaxLength = 14;
            this.txtBatchno.Name = "txtBatchno";
            this.txtBatchno.Size = new System.Drawing.Size(130, 21);
            this.txtBatchno.TabIndex = 4;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(15, 38);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(55, 14);
            this.Label16.TabIndex = 38;
            this.Label16.Text = "Product";
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetData.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnGetData.ForeColor = System.Drawing.Color.White;
            this.btnGetData.Location = new System.Drawing.Point(9, 30);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(185, 34);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "View Requests";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstView.CheckBoxes = true;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Refno,
            this.Ean_code,
            this.Brandname,
            this.batch,
            this.Qty,
            this.Balance,
            this.Manufacturing,
            this.Expiry});
            this.lstView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(4, 84);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(1051, 273);
            this.lstView.TabIndex = 53;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // Refno
            // 
            this.Refno.Text = "Request No";
            this.Refno.Width = 101;
            // 
            // Ean_code
            // 
            this.Ean_code.Text = "GTIN";
            this.Ean_code.Width = 172;
            // 
            // Brandname
            // 
            this.Brandname.Text = "Product Name";
            this.Brandname.Width = 319;
            // 
            // batch
            // 
            this.batch.Text = "Batch No";
            this.batch.Width = 159;
            // 
            // Qty
            // 
            this.Qty.Text = "Requested Qty";
            this.Qty.Width = 109;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance Qty";
            this.Balance.Width = 96;
            // 
            // Manufacturing
            // 
            this.Manufacturing.Text = "Mfg Date";
            this.Manufacturing.Width = 101;
            // 
            // Expiry
            // 
            this.Expiry.Text = "Expiry Date";
            this.Expiry.Width = 91;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstView);
            this.groupBox3.Controls.Add(this.btnGetData);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Location = new System.Drawing.Point(7, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1061, 359);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generated Request(s)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Controls.Add(this.lblLabel);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnReject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 33);
            this.panel2.TabIndex = 58;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkSelectAll.ForeColor = System.Drawing.Color.White;
            this.chkSelectAll.Location = new System.Drawing.Point(3, 9);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(88, 18);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.ForeColor = System.Drawing.Color.White;
            this.lblLabel.Location = new System.Drawing.Point(234, 10);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(247, 14);
            this.lblLabel.TabIndex = 62;
            this.lblLabel.Text = "0 No. Of Labels Printed Successfully";
            this.lblLabel.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnClear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnClear.Location = new System.Drawing.Point(976, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 32);
            this.btnClear.TabIndex = 61;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReject.BackgroundImage = global::PC_Application.Properties.Resources.Copy_new;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReject.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnReject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnReject.Location = new System.Drawing.Point(101, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(102, 29);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCancelRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 556);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel1);
            this.Name = "frmCancelRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial number request rejection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCancelRequest_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cboLine;
        internal System.Windows.Forms.ComboBox cboPlant;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboPacking;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox cboProduct;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtBatchno;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.ListView lstView;
        internal System.Windows.Forms.ColumnHeader Refno;
        internal System.Windows.Forms.ColumnHeader Ean_code;
        internal System.Windows.Forms.ColumnHeader Brandname;
        internal System.Windows.Forms.ColumnHeader batch;
        internal System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Balance;
        internal System.Windows.Forms.ColumnHeader Manufacturing;
        internal System.Windows.Forms.ColumnHeader Expiry;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lblLabel;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}