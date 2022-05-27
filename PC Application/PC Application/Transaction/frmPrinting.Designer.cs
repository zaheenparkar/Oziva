namespace PC_Application.Transaction
{
    partial class frmPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinting));
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboLinecode = new System.Windows.Forms.ComboBox();
            this.cboBatchno = new System.Windows.Forms.ComboBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cboBrandname = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPackLvl = new System.Windows.Forms.ComboBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboPrintMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.cboLabelSize = new System.Windows.Forms.ComboBox();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboLabeltype = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNoOfLbl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.Refno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ean_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brandname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Printqty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manufacturing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Expiry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bw_Print = new System.ComponentModel.BackgroundWorker();
            this.tmPrint = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Panel3.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label4.Location = new System.Drawing.Point(8, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(104, 14);
            this.Label4.TabIndex = 40;
            this.Label4.Text = "Product Name :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label2.Location = new System.Drawing.Point(505, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 14);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Line No :";
            // 
            // cboLinecode
            // 
            this.cboLinecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinecode.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLinecode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboLinecode.FormattingEnabled = true;
            this.cboLinecode.Location = new System.Drawing.Point(577, 27);
            this.cboLinecode.Name = "cboLinecode";
            this.cboLinecode.Size = new System.Drawing.Size(113, 24);
            this.cboLinecode.TabIndex = 2;
            this.cboLinecode.SelectedIndexChanged += new System.EventHandler(this.cboLinecode_SelectedIndexChanged);
            // 
            // cboBatchno
            // 
            this.cboBatchno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBatchno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBatchno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchno.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboBatchno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBatchno.FormattingEnabled = true;
            this.cboBatchno.Location = new System.Drawing.Point(494, 30);
            this.cboBatchno.Name = "cboBatchno";
            this.cboBatchno.Size = new System.Drawing.Size(140, 24);
            this.cboBatchno.TabIndex = 8;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel3.Controls.Add(this.Label8);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(981, 7);
            this.Panel3.TabIndex = 37;
            this.Panel3.Visible = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.Location = new System.Drawing.Point(12, 4);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(168, 23);
            this.Label8.TabIndex = 9;
            this.Label8.Text = "Barcode Printing";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label3.Location = new System.Drawing.Point(418, 35);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 14);
            this.Label3.TabIndex = 38;
            this.Label3.Text = "Batch No :";
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetData.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnGetData.ForeColor = System.Drawing.Color.White;
            this.btnGetData.Location = new System.Drawing.Point(15, 30);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(196, 30);
            this.btnGetData.TabIndex = 9;
            this.btnGetData.Text = "View Printing Requests";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cboBrandname
            // 
            this.cboBrandname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBrandname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBrandname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrandname.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboBrandname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBrandname.FormattingEnabled = true;
            this.cboBrandname.Location = new System.Drawing.Point(113, 32);
            this.cboBrandname.Name = "cboBrandname";
            this.cboBrandname.Size = new System.Drawing.Size(293, 24);
            this.cboBrandname.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(15, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 47;
            this.label9.Text = "Plant Code :";
            // 
            // cboPlant
            // 
            this.cboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlant.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPlant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Location = new System.Drawing.Point(114, 27);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(121, 24);
            this.cboPlant.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(255, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 14);
            this.label10.TabIndex = 49;
            this.label10.Text = "Packing Level :";
            // 
            // cboPackLvl
            // 
            this.cboPackLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackLvl.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPackLvl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboPackLvl.FormattingEnabled = true;
            this.cboPackLvl.Location = new System.Drawing.Point(365, 27);
            this.cboPackLvl.Name = "cboPackLvl";
            this.cboPackLvl.Size = new System.Drawing.Size(125, 24);
            this.cboPackLvl.TabIndex = 1;
            this.cboPackLvl.SelectedIndexChanged += new System.EventHandler(this.cboPackLvl_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.groupBox4);
            this.Panel1.Controls.Add(this.groupBox3);
            this.Panel1.Controls.Add(this.groupBox2);
            this.Panel1.Controls.Add(this.groupBox1);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Font = new System.Drawing.Font("Calibri", 13F);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(981, 706);
            this.Panel1.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cboPrintMethod);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblAvailable);
            this.groupBox4.Controls.Add(this.cboLabelSize);
            this.groupBox4.Controls.Add(this.cboPrinter);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.Label7);
            this.groupBox4.Controls.Add(this.cboLabeltype);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox4.Location = new System.Drawing.Point(7, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(971, 117);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Print Configuration";
            // 
            // cboPrintMethod
            // 
            this.cboPrintMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrintMethod.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPrintMethod.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboPrintMethod.FormattingEnabled = true;
            this.cboPrintMethod.Items.AddRange(new object[] {
            "Print",
            "Export"});
            this.cboPrintMethod.Location = new System.Drawing.Point(434, 33);
            this.cboPrintMethod.Name = "cboPrintMethod";
            this.cboPrintMethod.Size = new System.Drawing.Size(197, 24);
            this.cboPrintMethod.TabIndex = 4;
            this.cboPrintMethod.SelectedIndexChanged += new System.EventHandler(this.cboPrintMethod_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(334, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 14);
            this.label5.TabIndex = 54;
            this.label5.Text = "Print Method :";
            // 
            // lblAvailable
            // 
            this.lblAvailable.BackColor = System.Drawing.Color.Green;
            this.lblAvailable.ForeColor = System.Drawing.Color.White;
            this.lblAvailable.Location = new System.Drawing.Point(664, 75);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(193, 23);
            this.lblAvailable.TabIndex = 53;
            this.lblAvailable.Text = "Availibility - Online";
            this.lblAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboLabelSize
            // 
            this.cboLabelSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabelSize.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLabelSize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboLabelSize.FormattingEnabled = true;
            this.cboLabelSize.Items.AddRange(new object[] {
            "Heterogeneous",
            "Homogeneous"});
            this.cboLabelSize.Location = new System.Drawing.Point(744, 33);
            this.cboLabelSize.Name = "cboLabelSize";
            this.cboLabelSize.Size = new System.Drawing.Size(113, 24);
            this.cboLabelSize.TabIndex = 5;
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboPrinter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(113, 76);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(518, 24);
            this.cboPrinter.TabIndex = 6;
            this.cboPrinter.SelectedValueChanged += new System.EventHandler(this.cboPrinter_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(664, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "Label Size :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(14, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 40;
            this.label12.Text = "Printer Name :";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label7.Location = new System.Drawing.Point(25, 39);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(83, 14);
            this.Label7.TabIndex = 44;
            this.Label7.Text = "Label Type :";
            // 
            // cboLabeltype
            // 
            this.cboLabeltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabeltype.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cboLabeltype.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboLabeltype.FormattingEnabled = true;
            this.cboLabeltype.Location = new System.Drawing.Point(113, 35);
            this.cboLabeltype.Name = "cboLabeltype";
            this.cboLabeltype.Size = new System.Drawing.Size(168, 24);
            this.cboLabeltype.TabIndex = 3;
            this.cboLabeltype.SelectedIndexChanged += new System.EventHandler(this.cboLabeltype_SelectedIndexChanged);
            this.cboLabeltype.SelectedValueChanged += new System.EventHandler(this.cboLabeltype_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtNoOfLbl);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lstView);
            this.groupBox3.Controls.Add(this.btnGetData);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Location = new System.Drawing.Point(7, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(971, 328);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Printing Request(s)";
            // 
            // txtNoOfLbl
            // 
            this.txtNoOfLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfLbl.Font = new System.Drawing.Font("Calibri", 10F);
            this.txtNoOfLbl.ForeColor = System.Drawing.Color.Black;
            this.txtNoOfLbl.Location = new System.Drawing.Point(108, 235);
            this.txtNoOfLbl.Name = "txtNoOfLbl";
            this.txtNoOfLbl.Size = new System.Drawing.Size(100, 24);
            this.txtNoOfLbl.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 14);
            this.label11.TabIndex = 53;
            this.label11.Text = "No of Labels :";
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.CheckBoxes = true;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Refno,
            this.Ean_code,
            this.Brandname,
            this.batch,
            this.Qty,
            this.Printqty,
            this.Balance,
            this.packsize,
            this.Manufacturing,
            this.Expiry});
            this.lstView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(4, 76);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(961, 150);
            this.lstView.TabIndex = 53;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstView_ItemCheck);
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
            // Printqty
            // 
            this.Printqty.Text = "Printed  Qty";
            this.Printqty.Width = 94;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance Qty";
            this.Balance.Width = 96;
            // 
            // packsize
            // 
            this.packsize.Text = "Pack Size";
            this.packsize.Width = 82;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboBrandname);
            this.groupBox2.Controls.Add(this.Label4);
            this.groupBox2.Controls.Add(this.Label3);
            this.groupBox2.Controls.Add(this.cboBatchno);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(7, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(971, 66);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Selection ( Optional )";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboPlant);
            this.groupBox1.Controls.Add(this.cboPackLvl);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboLinecode);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 13F);
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Line Selection";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bw_Print
            // 
            this.bw_Print.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_Print_DoWork);
            this.bw_Print.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_Print_RunWorkerCompleted);
            // 
            // tmPrint
            // 
            this.tmPrint.Interval = 2000;
            this.tmPrint.Tick += new System.EventHandler(this.tmPrint_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnExportCSV);
            this.panel2.Controls.Add(this.lblLabel);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 629);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 33);
            this.panel2.TabIndex = 4;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.BackColor = System.Drawing.Color.White;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportCSV.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnExportCSV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExportCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCSV.Image")));
            this.btnExportCSV.Location = new System.Drawing.Point(247, 1);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(113, 30);
            this.btnExportCSV.TabIndex = 63;
            this.btnExportCSV.Text = "Export CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Visible = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.ForeColor = System.Drawing.Color.White;
            this.lblLabel.Location = new System.Drawing.Point(367, 10);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(247, 14);
            this.lblLabel.TabIndex = 62;
            this.lblLabel.Text = "0 No. Of Labels Printed Successfully";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnClear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(123, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnPrint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(4, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 30);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 662);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Name = "frmPrinting";
            this.Text = "Printing";
            this.Load += new System.EventHandler(this.frmPrinting_Load);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboLinecode;
        internal System.Windows.Forms.ComboBox cboBatchno;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.ComboBox cboBrandname;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cboPlant;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox cboPackLvl;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ListView lstView;
        internal System.Windows.Forms.ColumnHeader Refno;
        internal System.Windows.Forms.ColumnHeader Ean_code;
        internal System.Windows.Forms.ColumnHeader batch;
        internal System.Windows.Forms.ColumnHeader Qty;
        internal System.Windows.Forms.ColumnHeader Printqty;
        internal System.Windows.Forms.ColumnHeader packsize;
        internal System.Windows.Forms.ColumnHeader Expiry;
        internal System.Windows.Forms.ColumnHeader Manufacturing;
        internal System.Windows.Forms.ColumnHeader Brandname;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNoOfLbl;
        private System.Windows.Forms.ColumnHeader Balance;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker bw_Print;
        private System.Windows.Forms.Timer tmPrint;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lblLabel;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cboPrintMethod;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAvailable;
        internal System.Windows.Forms.ComboBox cboLabelSize;
        internal System.Windows.Forms.ComboBox cboPrinter;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cboLabeltype;
    }
}