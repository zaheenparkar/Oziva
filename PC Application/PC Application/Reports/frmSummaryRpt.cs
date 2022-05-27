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
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace PC_Application
{
    public partial class frmSummaryRpt : Form
    {
       
        public frmSummaryRpt()
        {
            InitializeComponent();
        }

        public string GetSelectedString()
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

                    dtHead = objGen.BLGet_SumHead(strResult, PL_Login.PlantCode, strArcFlag);
                    clsStandards.FillListView(lstView, dtHead);
                //    if (dtHead.Rows.Count > 0)
                //    {
                //        for (int c = 0; c < dtHead.Columns.Count; c++)
                //        {
                //            lstView.Columns.Add(dtHead.Columns[c].ToString());
                //            lstView.Columns[c].Width = 120;
                //        }

                //        lstView.Columns.Add("PRINTED");
                //        lstView.Columns.Add("PARENT UTILIZED");
                //        lstView.Columns.Add("PARENT UN-UTILIZED");
                //        lstView.Columns.Add("CHILD UTILIZED");
                //        lstView.Columns.Add("CHILD UNUTILIZED");
                //        lstView.Columns.Add("UPLOADED TO SERVER");
                //        lstView.Columns.Add("PENDING TO UPLOAD");

                //        lstView.Columns[8].Width = 120;
                //        lstView.Columns[9].Width = 120;
                //        lstView.Columns[10].Width = 120;
                //        lstView.Columns[11].Width = 120;
                //        lstView.Columns[12].Width = 120;
                //        lstView.Columns[13].Width = 120;
                //        lstView.Columns[14].Width = 120;

                //        for (int i = 0; i < dtHead.Rows.Count; i++)
                //        {
                //            if (dtHead.Rows[i]["PACKING_LEVEL"].ToString() == "Tertiary")
                //            {
                //                dtTer = new DataTable();
                //                dtTer = objGen.BLGet_SumRpt(dtHead.Rows[i]["GTIN_ID"].ToString(), dtHead.Rows[i]["ERP_ITEM_CODE"].ToString(), dtHead.Rows[i]["PACKING_LEVEL"].ToString(), "BATCH_NO= '" + dtHead.Rows[i]["BATCH_NO"].ToString() + "'",strArcFlag);

                //                for (int t = 0; t < dtTer.Rows.Count; t++)
                //                {
                //                    ListViewItem lv = new ListViewItem(dtHead.Rows[i][0].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][1].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][2].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][3].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][4].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][5].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][6].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][7].ToString());
                //                    lv.SubItems.Add(dtTer.Rows[t][3].ToString());
                //                    lv.SubItems.Add(dtTer.Rows[t][4].ToString());
                //                    lv.SubItems.Add(dtTer.Rows[t][5].ToString());
                //                    lv.SubItems.Add("0");
                //                    lv.SubItems.Add("0");
                //                    lv.SubItems.Add(dtTer.Rows[t][6].ToString());
                //                    lv.SubItems.Add(dtTer.Rows[t][7].ToString());

                //                    lstView.Items.Add(lv);

                //                }
                //                dtTer = null;

                //            }
                //            else
                //            {
                //                dtSec = new DataTable();
                //                dtSec = objGen.BLGet_SumRpt(dtHead.Rows[i]["GTIN_ID"].ToString(), dtHead.Rows[i]["ERP_ITEM_CODE"].ToString(), dtHead.Rows[i]["PACKING_LEVEL"].ToString(), "BATCH_NO= '" + dtHead.Rows[i]["BATCH_NO"].ToString() + "'",strArcFlag);

                //                for (int s = 0; s < dtSec.Rows.Count; s++)
                //                {
                //                    ListViewItem lv = new ListViewItem(dtHead.Rows[i][0].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][1].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][2].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][3].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][4].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][5].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][6].ToString());
                //                    lv.SubItems.Add(dtHead.Rows[i][7].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][3].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][4].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][5].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][6].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][7].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][8].ToString());
                //                    lv.SubItems.Add(dtSec.Rows[s][9].ToString());

                //                    lstView.Items.Add(lv);

                //                }
                //                dtSec = null;
                //            }
                //        }
                //    }
                }

                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                if(lstView.Items.Count>0)
                {
                    MessageBox.Show("If this Report is not matching with your Physical Scanning then \nKindly check 'Wrong Packing Report' against same batch ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            clsGlobal.dtSum = null;
            this.Close();
            this.Dispose();
        }

        private void frmSummaryRpt_Load(object sender, EventArgs e)
        {
            cboBatchCond.SelectedIndex = 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            clsGlobal.dtSum = new DataTable();

            try
            {
                foreach (ColumnHeader header in lstView.Columns)
                {
                    clsGlobal.dtSum.Columns.Add(header.Text);
                }

                for (int i = 0; i < lstView.Items.Count; i++)
                {
                    DataRow dr;
                    dr = clsGlobal.dtSum.NewRow();
                    for (int j = 0; j < lstView.Columns.Count; j++)
                    {
                        dr[j] = lstView.Items[i].SubItems[j].Text.ToString();
                    }
                    clsGlobal.dtSum.Rows.Add(dr);
                    clsGlobal.dtSum.AcceptChanges();
                }

                if (clsGlobal.dtSum.Rows.Count > 0)
                {
                    frmReportPre objRe = new frmReportPre();
                    objRe.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
