using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using PropertyLayer;
using BusinessLayer;
using System.Globalization;
using System.IO;

namespace PC_Application.Reports
{
    public partial class frmSecRpt : Form
    {
        public frmSecRpt()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_Reports objGen = new BL_Reports();
            BL_LogWriter objLog = new BL_LogWriter();
            lblRecord.Text = "0 record(s) found.";
            string strResult = GetSelectedString();
            try
            {
                if (strResult != "")
                {
                    lstView.Items.Clear();
                    if (rdbAll.Checked == true)
                    {
                        clsStandards.FillListView(lstView, objGen.BLGet_SecRpt(strResult, PL_Login.PlantCode.ToString(), rdbAll.Text));
                    }
                    else if (rdbRejected.Checked == true)
                    {
                        clsStandards.FillListView(lstView, objGen.BLGet_SecRpt(strResult, PL_Login.PlantCode.ToString(), rdbRejected.Text));
                    }
                    else if (rdbMapped.Checked == true)
                    {
                        clsStandards.FillListView(lstView, objGen.BLGet_SecRpt(strResult, PL_Login.PlantCode.ToString(), rdbMapped.Text));
                    }
                    lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
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
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        public string GetSelectedString()
        {
            string strCond = "";
            string strBatch = "";

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

                strCond = " Batch " + strBatch + "";
            }
            return strCond;
        }

        private void frmSecRpt_Load(object sender, EventArgs e)
        {
            rdbAll.Checked = true;
            cboBatchCond.SelectedIndex = 0;
        }
    }
}
