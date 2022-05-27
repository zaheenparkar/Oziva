namespace PC_Application.Transaction
{
    partial class frmGenReq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenReq));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpHomo = new System.Windows.Forms.GroupBox();
            this.cboPackSize = new System.Windows.Forms.ComboBox();
            this.cboBatch = new System.Windows.Forms.ComboBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.cboERP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGTIN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackSize = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.expiry = new System.Windows.Forms.DateTimePicker();
            this.mfgdate = new System.Windows.Forms.DateTimePicker();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.lblLabelType = new System.Windows.Forms.Label();
            this.cboLabelType = new System.Windows.Forms.ComboBox();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPacking = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label15 = new System.Windows.Forms.Label();
            this.dtgDtl = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.GroupBox3.SuspendLayout();
            this.grpHomo.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDtl)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.Controls.Add(this.txtQty);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Font = new System.Drawing.Font("Calibri", 13F);
            this.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.GroupBox3.Location = new System.Drawing.Point(6, 277);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(1210, 72);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Input Request Qty";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.Black;
            this.txtQty.Location = new System.Drawing.Point(113, 31);
            this.txtQty.MaxLength = 6;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(108, 21);
            this.txtQty.TabIndex = 130;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(6, 34);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(94, 14);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "No of Labels :";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(11, 503);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(179, 40);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Save Generation Data";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpHomo
            // 
            this.grpHomo.Controls.Add(this.cboPackSize);
            this.grpHomo.Controls.Add(this.cboBatch);
            this.grpHomo.Controls.Add(this.lblExpiry);
            this.grpHomo.Controls.Add(this.cboERP);
            this.grpHomo.Controls.Add(this.label7);
            this.grpHomo.Controls.Add(this.label4);
            this.grpHomo.Controls.Add(this.cboGTIN);
            this.grpHomo.Controls.Add(this.label1);
            this.grpHomo.Controls.Add(this.txtPackSize);
            this.grpHomo.Controls.Add(this.Label10);
            this.grpHomo.Controls.Add(this.Label3);
            this.grpHomo.Controls.Add(this.Label16);
            this.grpHomo.Controls.Add(this.cboProduct);
            this.grpHomo.Controls.Add(this.Label5);
            this.grpHomo.Controls.Add(this.Label17);
            this.grpHomo.Controls.Add(this.expiry);
            this.grpHomo.Controls.Add(this.mfgdate);
            this.grpHomo.Controls.Add(this.txtBatch);
            this.grpHomo.Font = new System.Drawing.Font("Calibri", 13F);
            this.grpHomo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grpHomo.Location = new System.Drawing.Point(8, 95);
            this.grpHomo.Name = "grpHomo";
            this.grpHomo.Size = new System.Drawing.Size(1210, 176);
            this.grpHomo.TabIndex = 1;
            this.grpHomo.TabStop = false;
            this.grpHomo.Text = "Product Selection";
            // 
            // cboPackSize
            // 
            this.cboPackSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackSize.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPackSize.ForeColor = System.Drawing.Color.Black;
            this.cboPackSize.FormattingEnabled = true;
            this.cboPackSize.Location = new System.Drawing.Point(320, 134);
            this.cboPackSize.Name = "cboPackSize";
            this.cboPackSize.Size = new System.Drawing.Size(147, 24);
            this.cboPackSize.TabIndex = 132;
            this.cboPackSize.Visible = false;
            // 
            // cboBatch
            // 
            this.cboBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatch.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboBatch.ForeColor = System.Drawing.Color.Black;
            this.cboBatch.FormattingEnabled = true;
            this.cboBatch.Location = new System.Drawing.Point(98, 25);
            this.cboBatch.Name = "cboBatch";
            this.cboBatch.Size = new System.Drawing.Size(146, 24);
            this.cboBatch.TabIndex = 4;
            this.cboBatch.SelectedIndexChanged += new System.EventHandler(this.cboBatch_SelectedIndexChanged);
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiry.ForeColor = System.Drawing.Color.Black;
            this.lblExpiry.Location = new System.Drawing.Point(521, 107);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(136, 13);
            this.lblExpiry.TabIndex = 50;
            this.lblExpiry.Text = "0 Days (Expiry Period)";
            // 
            // cboERP
            // 
            this.cboERP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboERP.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboERP.ForeColor = System.Drawing.Color.Black;
            this.cboERP.FormattingEnabled = true;
            this.cboERP.Location = new System.Drawing.Point(355, 25);
            this.cboERP.Name = "cboERP";
            this.cboERP.Size = new System.Drawing.Size(147, 24);
            this.cboERP.TabIndex = 2;
            this.cboERP.SelectedIndexChanged += new System.EventHandler(this.cboERP_SelectedIndexChanged);
            this.cboERP.TextChanged += new System.EventHandler(this.cboERP_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(268, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 47;
            this.label7.Text = "ERP Code :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(252, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "No. / Pcs.";
            // 
            // cboGTIN
            // 
            this.cboGTIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGTIN.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboGTIN.ForeColor = System.Drawing.Color.Black;
            this.cboGTIN.FormattingEnabled = true;
            this.cboGTIN.Location = new System.Drawing.Point(575, 24);
            this.cboGTIN.Name = "cboGTIN";
            this.cboGTIN.Size = new System.Drawing.Size(147, 24);
            this.cboGTIN.TabIndex = 1;
            this.cboGTIN.SelectedIndexChanged += new System.EventHandler(this.cboGTIN_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(521, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "GTIN :";
            // 
            // txtPackSize
            // 
            this.txtPackSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackSize.ForeColor = System.Drawing.Color.Black;
            this.txtPackSize.Location = new System.Drawing.Point(98, 136);
            this.txtPackSize.MaxLength = 5;
            this.txtPackSize.Name = "txtPackSize";
            this.txtPackSize.Size = new System.Drawing.Size(147, 21);
            this.txtPackSize.TabIndex = 5;
            this.txtPackSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackSize_KeyPress);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(11, 103);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(76, 14);
            this.Label10.TabIndex = 4;
            this.Label10.Text = "Mfg. Date :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(11, 28);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Batch No :";
            // 
            // Label16
            // 
            this.Label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(11, 67);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(64, 14);
            this.Label16.TabIndex = 38;
            this.Label16.Text = "Product :";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboProduct.ForeColor = System.Drawing.Color.Black;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(98, 63);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(409, 24);
            this.cboProduct.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(263, 105);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(88, 14);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Expiry Date :";
            // 
            // Label17
            // 
            this.Label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(11, 138);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(75, 14);
            this.Label17.TabIndex = 40;
            this.Label17.Text = "Pack Size :";
            // 
            // expiry
            // 
            this.expiry.CustomFormat = "MM/dd/yyyy";
            this.expiry.Enabled = false;
            this.expiry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.expiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry.Location = new System.Drawing.Point(355, 101);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(143, 23);
            this.expiry.TabIndex = 7;
            // 
            // mfgdate
            // 
            this.mfgdate.CustomFormat = "MM/dd/yyyy";
            this.mfgdate.Enabled = false;
            this.mfgdate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.mfgdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mfgdate.Location = new System.Drawing.Point(98, 100);
            this.mfgdate.Name = "mfgdate";
            this.mfgdate.Size = new System.Drawing.Size(147, 23);
            this.mfgdate.TabIndex = 6;
            this.mfgdate.ValueChanged += new System.EventHandler(this.mfgdate_ValueChanged);
            // 
            // txtBatch
            // 
            this.txtBatch.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtBatch.ForeColor = System.Drawing.Color.Black;
            this.txtBatch.Location = new System.Drawing.Point(97, 26);
            this.txtBatch.MaxLength = 30;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(147, 22);
            this.txtBatch.TabIndex = 131;
            this.txtBatch.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.cboLine);
            this.GroupBox1.Controls.Add(this.lblLabelType);
            this.GroupBox1.Controls.Add(this.cboLabelType);
            this.GroupBox1.Controls.Add(this.cboPlant);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cboPacking);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 13F);
            this.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.GroupBox1.Location = new System.Drawing.Point(6, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1210, 78);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Line Selection";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(720, 31);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(79, 14);
            this.Label12.TabIndex = 28;
            this.Label12.Text = "Line Code :";
            // 
            // cboLine
            // 
            this.cboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLine.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLine.ForeColor = System.Drawing.Color.Black;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(802, 26);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(107, 24);
            this.cboLine.TabIndex = 3;
            // 
            // lblLabelType
            // 
            this.lblLabelType.AutoSize = true;
            this.lblLabelType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelType.ForeColor = System.Drawing.Color.Black;
            this.lblLabelType.Location = new System.Drawing.Point(490, 33);
            this.lblLabelType.Name = "lblLabelType";
            this.lblLabelType.Size = new System.Drawing.Size(83, 14);
            this.lblLabelType.TabIndex = 26;
            this.lblLabelType.Text = "Label Type :";
            // 
            // cboLabelType
            // 
            this.cboLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabelType.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLabelType.ForeColor = System.Drawing.Color.Black;
            this.cboLabelType.FormattingEnabled = true;
            this.cboLabelType.Location = new System.Drawing.Point(577, 28);
            this.cboLabelType.Name = "cboLabelType";
            this.cboLabelType.Size = new System.Drawing.Size(132, 24);
            this.cboLabelType.TabIndex = 2;
            this.cboLabelType.SelectedIndexChanged += new System.EventHandler(this.cboLabelType_SelectedIndexChanged);
            // 
            // cboPlant
            // 
            this.cboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlant.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlant.ForeColor = System.Drawing.Color.Black;
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Items.AddRange(new object[] {
            "Tertiary"});
            this.cboPlant.Location = new System.Drawing.Point(107, 30);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(114, 24);
            this.cboPlant.TabIndex = 0;
            this.cboPlant.SelectedIndexChanged += new System.EventHandler(this.cboPlant_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "Plant Code :";
            // 
            // cboPacking
            // 
            this.cboPacking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPacking.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPacking.ForeColor = System.Drawing.Color.Black;
            this.cboPacking.FormattingEnabled = true;
            this.cboPacking.Items.AddRange(new object[] {
            "Tertiary"});
            this.cboPacking.Location = new System.Drawing.Point(341, 30);
            this.cboPacking.Name = "cboPacking";
            this.cboPacking.Size = new System.Drawing.Size(131, 24);
            this.cboPacking.TabIndex = 1;
            this.cboPacking.SelectedIndexChanged += new System.EventHandler(this.cboPacking_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(237, 35);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(101, 14);
            this.Label11.TabIndex = 18;
            this.Label11.Text = "Packing Level :";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel1.Controls.Add(this.Label15);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1229, 7);
            this.Panel1.TabIndex = 45;
            this.Panel1.Visible = false;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.White;
            this.Label15.Location = new System.Drawing.Point(12, 4);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(210, 23);
            this.Label15.TabIndex = 9;
            this.Label15.Text = "Serial No Generation";
            // 
            // dtgDtl
            // 
            this.dtgDtl.AllowUserToAddRows = false;
            this.dtgDtl.AllowUserToDeleteRows = false;
            this.dtgDtl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDtl.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDtl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDtl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column12,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column13,
            this.Column14});
            this.dtgDtl.Location = new System.Drawing.Point(1205, 505);
            this.dtgDtl.Name = "dtgDtl";
            this.dtgDtl.ReadOnly = true;
            this.dtgDtl.Size = new System.Drawing.Size(12, 10);
            this.dtgDtl.TabIndex = 49;
            this.dtgDtl.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Packing Level";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Line Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Label Type";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GTIN Code";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Description";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Pack Size";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Batch No";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Mfg Date";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Exp Date";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Qty";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Plant Code";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Flag";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "ID";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "ERP ITEM CODE";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1229, 10);
            this.panel2.TabIndex = 58;
            this.panel2.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Maroon;
            this.btnRefresh.Location = new System.Drawing.Point(12, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(136, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Complete";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Location = new System.Drawing.Point(160, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmGenReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1229, 566);
            this.Controls.Add(this.grpHomo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtgDtl);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGenReq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serial No Generation";
            this.Load += new System.EventHandler(this.frmGenReq_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.grpHomo.ResumeLayout(false);
            this.grpHomo.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDtl)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox txtQty;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.GroupBox grpHomo;
        internal System.Windows.Forms.ComboBox cboGTIN;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cboProduct;
        internal System.Windows.Forms.TextBox txtPackSize;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.DateTimePicker expiry;
        internal System.Windows.Forms.DateTimePicker mfgdate;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cboLine;
        internal System.Windows.Forms.Label lblLabelType;
        internal System.Windows.Forms.ComboBox cboLabelType;
        internal System.Windows.Forms.ComboBox cboPlant;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboPacking;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.DataGridView dtgDtl;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.ComboBox cboERP;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label lblExpiry;
        internal System.Windows.Forms.ComboBox cboBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        internal System.Windows.Forms.TextBox txtBatch;
        internal System.Windows.Forms.ComboBox cboPackSize;

    }
}