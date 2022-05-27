using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PC_Application
{
    public partial class frmReportPre : Form
    {
        public frmReportPre()
        {
            InitializeComponent();
        }

        private void frmReportPre_Load(object sender, EventArgs e)
        {

            try
            {
                if (clsGlobal.dtSum.Rows.Count > 0)
                {
                    rptSummary objSum = new rptSummary();
                    objSum.SetDataSource(clsGlobal.dtSum);
                    crystalReportViewer1.ReportSource = objSum;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
