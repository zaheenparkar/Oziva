using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PC_Application.Transaction
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            frmLineNo Line = new frmLineNo();
            Line.ShowDialog();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            //this.Close();
            frmPrinterConf Line = new frmPrinterConf();
            Line.ShowDialog();
        }

    }
}
