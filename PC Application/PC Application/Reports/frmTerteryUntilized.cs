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
    public partial class frmTerteryUntilized : Form
    {
        public frmTerteryUntilized()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_Reports objGen = new BL_Reports();
            BL_LogWriter objLog=new BL_LogWriter();
            lblRecord.Text = "0 record(s) found.";
            string strResult = GetSelectedString();
            try
            {
                if (strResult != "")
                {
                    clsStandards.FillListView(lstView, objGen.BLGet_GetUnutilizedTer(strResult));
                    lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(),PL_Login.PlantCode.ToString());
            }
            finally
            {
                objLog = null;
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
            
            //if (lstView.Items.Count > 0)
            //{
            //    //ListViewToCSV(lstView, "C:\\Barcode Report\\Report.csv", true);
            //    SaveFileDialog sfd = new SaveFileDialog
            //    {
            //        Title = "Choose file to save to",
            //        FileName = "example.csv",
            //        Filter = "CSV (*.csv)|*.csv",
            //        FilterIndex = 0,
            //        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            //    };

            //    //show the dialog + display the results in a msgbox unless cancelled

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {

            //        string[] headers = lstView.Columns
            //                   .OfType<ColumnHeader>()
            //                   .Select(header => header.Text.Trim())
            //                   .ToArray();

            //        string[][] items = lstView.Items
            //                    .OfType<ListViewItem>()
            //                    .Select(lvi => lvi.SubItems
            //                        .OfType<ListViewItem.ListViewSubItem>()
            //                        .Select(si => si.Text).ToArray()).ToArray();

            //        string table = string.Join(",", headers) + Environment.NewLine;
            //        foreach (string[] a in items)
            //        {
            //            //a = a_loopVariable;
            //            table += string.Join("','", a) + Environment.NewLine;
            //        }
            //        table = table.TrimEnd('\r', '\n');
            //        System.IO.File.WriteAllText(sfd.FileName, table);
            //    }
            //}


        }
      
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {

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

        private void frmTerteryUntilized_Load(object sender, EventArgs e)
        {
            cboBatchCond.SelectedIndex = 0;
        }
    }



}
