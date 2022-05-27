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
    public partial class frmEventRpt : Form
    {
        public frmEventRpt()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            BL_Reports objRpt = new BL_Reports();
            DataTable dtOrg = new DataTable();
            DataTable dtList = new DataTable();
            try
            {
                dtOrg = objRpt.BLGet_AuditRpt(dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy"), PL_Login.PlantCode);

                if (rdbSuccess.Checked == true)
                {
                    dtList = dtOrg.Select("Type='Success'").CopyToDataTable();
                    clsStandards.FillListView(lstView, dtList);
                }
                else if (rdbError.Checked == true)
                {
                    dtList = dtOrg.Select("Type='Error'").CopyToDataTable();
                    clsStandards.FillListView(lstView, dtList);
                }
                else
                {
                    clsStandards.FillListView(lstView, dtOrg);
                }
                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objLog = null; objRpt = null;
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

        private void frmEventRpt_Load(object sender, EventArgs e)
        {
            rdbAll.Checked = true;
        }
    }
}
