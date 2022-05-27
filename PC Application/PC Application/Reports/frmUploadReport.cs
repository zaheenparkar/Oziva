using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PropertyLayer;
using BusinessLayer;

namespace PC_Application.Reports
{
    public partial class frmUploadReport : Form
    {
        public frmUploadReport()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            BL_Reports objRep = new BL_Reports();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (lstView.Items.Count > 0)
                {
                    //objRep.ExportToExcel(lstView);
                    //objRep.KillProcess();

                    using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                    {

                        exportSaveFileDialog.InitialDirectory = "C:\\";
                        exportSaveFileDialog.Title = "Select File";
                        exportSaveFileDialog.Filter = "CSV (.csv)|*.csv;";

                        if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
                        {
                            string fullFileName = exportSaveFileDialog.FileName;
                            objRep.ExportToCsv(fullFileName, lstView);
                            MessageBox.Show("File Saved Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed To Save File");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "button1_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objRep = null; objLog = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_Reports objGen = new BL_Reports();
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dtHead = new DataTable();
            string strResult = GetSelectedString();
            int strArcFlag = 0;

            DataTable dtTer = new DataTable();
            DataTable dtSec = new DataTable();

            lblRecord.Text = "0 record(s) found.";
            if (chkrpt.Checked == true)
            {
                strArcFlag = 1;
            }
            try
            {


                lstView.Items.Clear();
                lstView.Columns.Clear();

                if (strResult != "")
                {

                    dtHead = objGen.BLGet_SumUploadHead(strResult, PL_Login.PlantCode, strArcFlag);
                    clsStandards.FillListView(lstView, dtHead);
                }

                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                if (lstView.Items.Count > 0)
                {
                   // MessageBox.Show("If this Report is not matching with your Physical Scanning then \nKindly check 'Wrong Packing Report' against same batch ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objLog = null;
                objGen = null;
                // label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                // objLog = null;
                // objGen = null;
            }
        }

        private string GetSelectedString()
        {
            string strCond = "";
            string strBatch = "";

            if (txtERPCode.Text != "")
            {
                if (txtBatch.Text != "")
                {
                    if (cboBatchCond.Text == "Like")
                    {
                        strBatch = " Like '%" + txtBatch.Text.Trim() + "%'";
                    }
                    else
                    {
                        strBatch = " ='" + txtBatch.Text.Trim() + "'";
                    }

                    strCond = " ERP_ITEM_Code = '" + txtERPCode.Text + "' AND Batch_No " + strBatch + "";
                }
                else
                {
                    strCond = " ERP_ITEM_Code = '" + txtERPCode.Text + "'";
                }
            }
            else if (txtBatch.Text != "")
            {
                if (cboBatchCond.Text == "Like")
                {
                    strBatch = " Like '%" + txtBatch.Text.Trim() + "%'";
                }
                else
                {
                    strBatch = " ='" + txtBatch.Text.Trim() + "'";
                }

                strCond = " Batch_No " + strBatch + "";
            }
            return strCond;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsGlobal.dtSum = null;
            this.Close();
            this.Dispose();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
