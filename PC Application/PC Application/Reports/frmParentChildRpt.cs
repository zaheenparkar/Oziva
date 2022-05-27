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
    public partial class frmParentChildRpt : Form
    {
        public frmParentChildRpt()
        {
            InitializeComponent();
        }

        private void frmParentChildRpt_Load(object sender, EventArgs e)
        {
            cboBatchCond.SelectedIndex = 0;

            // BL_Generator objGen = new BL_Generator();
            //BL_LogWriter objLog = new BL_LogWriter();
            //try
            //{
            //    clsStandards.FillListView(listView1, objGen.GetBatch_Details(textBox1.Text));
            //}
            //catch (Exception ex)
            //{
            //    objLog.WriteErrorLog(this.Name.ToString(), "fillCombo", "Error", ex.Message, "PC Clinet", PL_Login.UserID.ToString());
            //}
            //finally
            //{
            //    label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
            //    objLog = null;
            //    objGen = null;
            //}
        }

        public string GetSelectedString()
        {
            string strCond = "";
            string strBatch= "";

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

                    strCond = " ERP_ITEM_Code = '" + txtERPCode.Text + "' AND [Batch No] " + strBatch + "";
                }
                else
                {
                    strCond = " ERP_ITEM_Code = '" + txtERPCode.Text + "'";
                }
            }
            else if(txtBatch.Text!="")
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
            lblRecord.Text = "0 record(s) found.";
            string strResult = GetSelectedString();

            try
            {
                if (strResult != "")
                {
                    //clsStandards.FillListView(lstView, objGen.BLGet_GetParentChild(txtBatch.Text));
                    clsStandards.FillListView(lstView, objGen.BLGet_GetParentChild(strResult));
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
                // label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                // objLog = null;
                // objGen = null;
            }
        }
        //"C:\\Barcode Report\\ReportParentChild.csv"
        private void button1_Click(object sender, EventArgs e)
        {
            BL_Reports objRep = new BL_Reports();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (lstView.Items.Count > 0)
                {
                    //objRep.ExportPCToExcel(lstView);
                    //objRep.KillProcess();


                    using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                    {

                        exportSaveFileDialog.InitialDirectory = "C:\\";
                        exportSaveFileDialog.Title = "Select File";
                        exportSaveFileDialog.Filter = "CSV (.csv)|*.csv;";

                        if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
                        {
                            string fullFileName = exportSaveFileDialog.FileName;
                            objRep.ExportToCsvPC(fullFileName, lstView);
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
    }
}
