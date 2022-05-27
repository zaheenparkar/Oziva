using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using PropertyLayer;
using System.IO;

namespace PC_Application.Reports
{
    public partial class frmSecondUnutlized : Form
    {
        public frmSecondUnutlized()
        {
            InitializeComponent();
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

                strCond = " [Batch No] " + strBatch + "";
            }
            return strCond;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_Reports objGen = new BL_Reports();
            BL_LogWriter objLog = new BL_LogWriter();
            string strResult = GetSelectedString();

            lblRecord.Text = "0 record(s) found.";
            try
            {
                if (strResult != "")
                {
                    clsStandards.FillListView(lstView, objGen.BLGet_GetUnutilizedSec(strResult));
                    lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(),PL_Login.PlantCode.ToString());
            }
            finally
            {
                // label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
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
                    //objRep.ExportToExcel(lstView);
                    //objRep.KillProcess();

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
        }

        private void frmSecondUnutlized_Load(object sender, EventArgs e)
        {
            cboBatchCond.SelectedIndex = 0;
        }

        private void lblRecord_Click(object sender, EventArgs e)
        {

        }
    }
}
