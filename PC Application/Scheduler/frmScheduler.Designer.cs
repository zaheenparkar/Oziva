namespace Scheduler
{
    partial class frmScheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduler));
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtdbpath = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fopen = new System.Windows.Forms.OpenFileDialog();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblate = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.ContextMenuStrip1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox1
            // 
            this.ListBox1.BackColor = System.Drawing.Color.White;
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox1.ForeColor = System.Drawing.Color.Blue;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 16;
            this.ListBox1.Location = new System.Drawing.Point(0, 56);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(764, 436);
            this.ListBox1.TabIndex = 15;
            this.ListBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDoubleClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel1.Controls.Add(this.txtdbpath);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(764, 56);
            this.Panel1.TabIndex = 14;
            // 
            // txtdbpath
            // 
            this.txtdbpath.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtdbpath.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdbpath.Location = new System.Drawing.Point(5, 31);
            this.txtdbpath.Name = "txtdbpath";
            this.txtdbpath.ReadOnly = true;
            this.txtdbpath.Size = new System.Drawing.Size(756, 21);
            this.txtdbpath.TabIndex = 11;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.Location = new System.Drawing.Point(9, 4);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(263, 23);
            this.Label8.TabIndex = 10;
            this.Label8.Text = "Track And Trace Scheduler";
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.HideToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ShowToolStripMenuItem.Text = "Show";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            this.HideToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.HideToolStripMenuItem.Text = "Hide";
            this.HideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // Fopen
            // 
            this.Fopen.DefaultExt = "mdb";
            this.Fopen.Filter = "Database Files (*.mdb)|*.mdb";
            this.Fopen.Title = "Open Database File...";
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon1.BalloonTipTitle = "Scheduler";
            this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Visible = true;
            // 
            // Timer2
            // 
            this.Timer2.Enabled = true;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 6000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel2.Controls.Add(this.lblTime);
            this.Panel2.Controls.Add(this.lblate);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 466);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(764, 40);
            this.Panel2.TabIndex = 17;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(764, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 23);
            this.lblTime.TabIndex = 12;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblate
            // 
            this.lblate.AutoSize = true;
            this.lblate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblate.ForeColor = System.Drawing.Color.White;
            this.lblate.Location = new System.Drawing.Point(0, 0);
            this.lblate.Name = "lblate";
            this.lblate.Size = new System.Drawing.Size(0, 23);
            this.lblate.TabIndex = 11;
            // 
            // frmScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 506);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmScheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.frmScheduler_Load);
            this.Resize += new System.EventHandler(this.frmScheduler_Resize);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtdbpath;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem HideToolStripMenuItem;
        internal System.Windows.Forms.OpenFileDialog Fopen;
        private System.Windows.Forms.NotifyIcon NotifyIcon1;
        internal System.Windows.Forms.Timer Timer2;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.Label lblate;
    }
}

