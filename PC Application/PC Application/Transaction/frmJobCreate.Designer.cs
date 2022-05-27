namespace PC_Application.Transaction
{
    partial class frmJobCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobCreate));
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
            this.lblExpiry = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJobPackSize = new System.Windows.Forms.TextBox();
            this.cboJobBatch = new System.Windows.Forms.ComboBox();
            this.cboGTIN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.Refno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Plant_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PackLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GTIN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Batch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PackSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnJobCreate = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.pnlView = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel1.Controls.Add(this.Label15);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1364, 7);
            this.Panel1.TabIndex = 46;
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
            this.GroupBox1.Location = new System.Drawing.Point(8, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1309, 77);
            this.GroupBox1.TabIndex = 48;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Line Selection";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(526, 41);
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
            this.cboLine.Location = new System.Drawing.Point(611, 37);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(134, 24);
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
            this.cboPlant.Location = new System.Drawing.Point(97, 36);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(140, 24);
            this.cboPlant.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 41);
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
            this.cboPacking.Location = new System.Drawing.Point(357, 37);
            this.cboPacking.Name = "cboPacking";
            this.cboPacking.Size = new System.Drawing.Size(143, 24);
            this.cboPacking.TabIndex = 1;
            this.cboPacking.SelectedIndexChanged += new System.EventHandler(this.cboPacking_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(253, 42);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(101, 14);
            this.Label11.TabIndex = 18;
            this.Label11.Text = "Packing Level :";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.lblExpiry);
            this.GroupBox2.Controls.Add(this.cboProduct);
            this.GroupBox2.Controls.Add(this.Label17);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.label5);
            this.GroupBox2.Controls.Add(this.txtJobPackSize);
            this.GroupBox2.Controls.Add(this.cboJobBatch);
            this.GroupBox2.Controls.Add(this.cboGTIN);
            this.GroupBox2.Controls.Add(this.label4);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label16);
            this.GroupBox2.Font = new System.Drawing.Font("Calibri", 13F);
            this.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.GroupBox2.Location = new System.Drawing.Point(8, 96);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1309, 172);
            this.GroupBox2.TabIndex = 49;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Product Selection";
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.BackColor = System.Drawing.Color.White;
            this.lblExpiry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExpiry.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiry.ForeColor = System.Drawing.Color.Black;
            this.lblExpiry.Location = new System.Drawing.Point(336, 126);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(83, 16);
            this.lblExpiry.TabIndex = 72;
            this.lblExpiry.Text = "31/08/2015";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboProduct.ForeColor = System.Drawing.Color.Black;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(94, 37);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(400, 24);
            this.cboProduct.TabIndex = 3;
            this.cboProduct.TextChanged += new System.EventHandler(this.cboProduct_TextChanged);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(16, 124);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(75, 14);
            this.Label17.TabIndex = 67;
            this.Label17.Text = "Pack Size :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(276, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 71;
            this.label1.Text = "Expiry :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "Product :";
            // 
            // txtJobPackSize
            // 
            this.txtJobPackSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobPackSize.ForeColor = System.Drawing.Color.Black;
            this.txtJobPackSize.Location = new System.Drawing.Point(97, 121);
            this.txtJobPackSize.MaxLength = 5;
            this.txtJobPackSize.Name = "txtJobPackSize";
            this.txtJobPackSize.Size = new System.Drawing.Size(97, 21);
            this.txtJobPackSize.TabIndex = 6;
            // 
            // cboJobBatch
            // 
            this.cboJobBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJobBatch.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboJobBatch.ForeColor = System.Drawing.Color.Black;
            this.cboJobBatch.FormattingEnabled = true;
            this.cboJobBatch.Items.AddRange(new object[] {
            "Tertiary"});
            this.cboJobBatch.Location = new System.Drawing.Point(336, 77);
            this.cboJobBatch.Name = "cboJobBatch";
            this.cboJobBatch.Size = new System.Drawing.Size(159, 24);
            this.cboJobBatch.TabIndex = 5;
            this.cboJobBatch.SelectedIndexChanged += new System.EventHandler(this.cboBatch_SelectedIndexChanged);
            // 
            // cboGTIN
            // 
            this.cboGTIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGTIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGTIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGTIN.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboGTIN.ForeColor = System.Drawing.Color.Black;
            this.cboGTIN.FormattingEnabled = true;
            this.cboGTIN.Location = new System.Drawing.Point(93, 77);
            this.cboGTIN.Name = "cboGTIN";
            this.cboGTIN.Size = new System.Drawing.Size(134, 24);
            this.cboGTIN.TabIndex = 4;
            this.cboGTIN.SelectedIndexChanged += new System.EventHandler(this.cboGTIN_TextChanged);
            this.cboGTIN.TextChanged += new System.EventHandler(this.cboGTIN_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(200, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "No. / Pcs.";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(258, 80);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Batch No :";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(16, 80);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(46, 14);
            this.Label16.TabIndex = 38;
            this.Label16.Text = "GTIN :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstView);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Location = new System.Drawing.Point(3, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1337, 466);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generated JOB(s)";
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.BackColor = System.Drawing.Color.White;
            this.lstView.CheckBoxes = true;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Refno,
            this.Plant_Code,
            this.PackLevel,
            this.Line,
            this.GTIN,
            this.Batch,
            this.PackSize,
            this.columnHeader1});
            this.lstView.Font = new System.Drawing.Font("Calibri", 11F);
            this.lstView.ForeColor = System.Drawing.Color.Black;
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(4, 33);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(1327, 427);
            this.lstView.TabIndex = 53;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // Refno
            // 
            this.Refno.Text = "Request No";
            this.Refno.Width = 95;
            // 
            // Plant_Code
            // 
            this.Plant_Code.Text = "Plant Code";
            this.Plant_Code.Width = 103;
            // 
            // PackLevel
            // 
            this.PackLevel.Text = "Packing Level";
            this.PackLevel.Width = 131;
            // 
            // Line
            // 
            this.Line.Text = "Line Code";
            this.Line.Width = 103;
            // 
            // GTIN
            // 
            this.GTIN.Text = "GTIN";
            this.GTIN.Width = 180;
            // 
            // Batch
            // 
            this.Batch.Text = "Batch";
            this.Batch.Width = 151;
            // 
            // PackSize
            // 
            this.PackSize.Text = "Pack Size";
            this.PackSize.Width = 138;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Expiry";
            this.columnHeader1.Width = 104;
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlBack.Controls.Add(this.lblLabel);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBack.Location = new System.Drawing.Point(0, 735);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1364, 10);
            this.pnlBack.TabIndex = 59;
            this.pnlBack.Visible = false;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.ForeColor = System.Drawing.Color.White;
            this.lblLabel.Location = new System.Drawing.Point(397, 10);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(0, 14);
            this.lblLabel.TabIndex = 62;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(13, 560);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(153, 30);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload To Device";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReject.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(183, 560);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(106, 30);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "Close Job";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnJobCreate
            // 
            this.btnJobCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJobCreate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnJobCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJobCreate.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnJobCreate.ForeColor = System.Drawing.Color.White;
            this.btnJobCreate.Location = new System.Drawing.Point(12, 554);
            this.btnJobCreate.Name = "btnJobCreate";
            this.btnJobCreate.Size = new System.Drawing.Size(144, 41);
            this.btnJobCreate.TabIndex = 7;
            this.btnJobCreate.Text = "Create New Job";
            this.btnJobCreate.UseVisualStyleBackColor = false;
            this.btnJobCreate.Click += new System.EventHandler(this.btnJobCreate_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 7);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1364, 44);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Calibri", 13F);
            this.toolStripButton1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(150, 41);
            this.toolStripButton1.Text = "Existing Records";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Font = new System.Drawing.Font("Calibri", 13F);
            this.toolStripButton2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(150, 41);
            this.toolStripButton2.Text = "Add New Record";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // pnlEntry
            // 
            this.pnlEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEntry.Controls.Add(this.btnJobCreate);
            this.pnlEntry.Controls.Add(this.GroupBox1);
            this.pnlEntry.Controls.Add(this.GroupBox2);
            this.pnlEntry.Location = new System.Drawing.Point(7, 54);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(1345, 654);
            this.pnlEntry.TabIndex = 63;
            this.pnlEntry.Visible = false;
            // 
            // pnlView
            // 
            this.pnlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlView.Controls.Add(this.btnShowAll);
            this.pnlView.Controls.Add(this.btnSearch);
            this.pnlView.Controls.Add(this.label6);
            this.pnlView.Controls.Add(this.txtBatch);
            this.pnlView.Controls.Add(this.lblRecord);
            this.pnlView.Controls.Add(this.btnUpload);
            this.pnlView.Controls.Add(this.groupBox3);
            this.pnlView.Controls.Add(this.btnReject);
            this.pnlView.Location = new System.Drawing.Point(3, 58);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1345, 621);
            this.pnlView.TabIndex = 64;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAll.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(365, 10);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(93, 30);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(263, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 65;
            this.label6.Text = "Batch No :";
            // 
            // txtBatch
            // 
            this.txtBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(92, 10);
            this.txtBatch.MaxLength = 14;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(147, 23);
            this.txtBatch.TabIndex = 0;
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(10, 521);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(120, 14);
            this.lblRecord.TabIndex = 64;
            this.lblRecord.Text = "0 record(s) found.";
            // 
            // frmJobCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 745);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlEntry);
            this.Name = "frmJobCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Creation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmJobCreate_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlEntry.ResumeLayout(false);
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
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
        internal System.Windows.Forms.ComboBox cboJobBatch;
        internal System.Windows.Forms.ComboBox cboGTIN;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ListView lstView;
        internal System.Windows.Forms.ColumnHeader Refno;
        private System.Windows.Forms.Panel pnlBack;
        internal System.Windows.Forms.Button btnUpload;
        internal System.Windows.Forms.Label lblLabel;
        internal System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.ColumnHeader Plant_Code;
        private System.Windows.Forms.ColumnHeader PackLevel;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ColumnHeader GTIN;
        private System.Windows.Forms.ColumnHeader Batch;
        private System.Windows.Forms.ColumnHeader PackSize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Label lblExpiry;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtJobPackSize;
        internal System.Windows.Forms.Button btnJobCreate;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboProduct;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.Panel pnlView;
        internal System.Windows.Forms.Label lblRecord;
        internal System.Windows.Forms.Button btnShowAll;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtBatch;
    }
}