using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PC_Application.Transaction;
using PC_Application.Scanning;
using PropertyLayer;
using BusinessLayer;
using System.Diagnostics;
using PC_Application.Sync;
using PC_Application.Reports;


namespace PC_Application.Startup
{
    public partial class MDIMain : Form
    {

        PL_Login objPLlog;
        public MDIMain()
        {
            InitializeComponent();
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            string[] strRights;
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {

                string version = "e-Track Application - V" + System.Reflection.Assembly.GetExecutingAssembly()
                                     .GetName()
                                     .Version
                                     .ToString();
                this.Text = version;

                mnuBatchCreat.Enabled = false;
                mnuGeneration.Enabled = false;
                mnuSipper.Enabled = false;
                mnuDownload.Enabled = false;
                mnuJobCreate.Enabled = false;
                mnuManual.Enabled = false;
                mnuShipper.Enabled = false;
                mnuPrinting.Enabled = false;
                mnuRejectReq.Enabled = false;
                mnuRejectSerial.Enabled = false;
                mnuOnline.Enabled = false;
                mnuUpload.Enabled = false;
                Menu_Report.Enabled = false;

                MdiClient ctlMDI;

                // Loop through all of the form's controls looking
                // for the control of type MdiClient.
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        // Attempt to cast the control to type MdiClient.
                        ctlMDI = (MdiClient)ctl;

                        // Set the BackColor of the MdiClient control.
                        ctlMDI.BackColor = Color.White;
                    }
                    catch (InvalidCastException exc)
                    {
                        // Catch and ignore the error if casting failed.
                    }
                }
                toolStatus.Text = "Loged in as : " + PL_Login.UserID.ToString() + "  |  Plant : " + PL_Login.PlantCode + "  ";
                lblExpiry.Text = "Your login will expire in " + PL_Login.iExpiry.ToString() + " Days.";

                if (PL_Login.UType == "Administrator")
                {
                    mnuBatchCreat.Enabled = true;
                    mnuGeneration.Enabled = true;
                    mnuSipper.Enabled = true;
                    mnuDownload.Enabled = true;
                    mnuJobCreate.Enabled = true;
                    mnuManual.Enabled = true;
                    mnuShipper.Enabled = true;
                    mnuPrinting.Enabled = true;
                    mnuRejectReq.Enabled = true;
                    mnuRejectSerial.Enabled = true;
                    mnuOnline.Enabled = true;
                    mnuMasterSync.Enabled = true;
                    mnuTransSync.Enabled = true;
                    mnuUpload.Enabled = true;
                    Menu_Report.Enabled = true;
                    uploadSummeryReportToolStripMenuItem.Enabled = true;
                }
                else
                {
                    if (PL_Login.URights != "")
                    {
                        strRights = PL_Login.URights.Split(',');
                        for (int i = 0; i < strRights.Count(); i++)
                        {
                            switch (strRights[i])
                            {
                                case "201":
                                    mnuGeneration.Enabled = true;
                                    break;

                                case "207":
                                    mnuSipper.Enabled = true;
                                    break;

                                case "202":
                                    mnuPrinting.Enabled = true;
                                    break;

                                case "203":
                                    mnuRejectReq.Enabled = true;
                                    break;

                                case "204":
                                    mnuRejectSerial.Enabled = true;
                                    break;

                                case "205":
                                    mnuJobCreate.Enabled = true;
                                    break;

                                case "206":
                                    mnuBatchCreat.Enabled = true;
                                    break;

                                case "301":
                                    mnuUpload.Enabled = true;
                                    break;

                                case "302":
                                    mnuDownload.Enabled = true;
                                    break;

                                case "303":
                                    mnuManual.Enabled = true;
                                    break;

                                case "304":
                                    mnuOnline.Enabled = true;
                                    break;

                                case "307":
                                    mnuShipper.Enabled = true;
                                    
                                    break;

                                case "402":
                                    Menu_Report.Enabled = true;
                                    break;

                                case "305":
                                    mnuMasterSync.Enabled = true;
                                    break;

                                case "306":
                                    mnuTransSync.Enabled = true;
                                    break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "MDIMain_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
            }

            //if (printDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Abort)
            //{
            //    PC_Application.Properties.Settings.Default["setPrinter"] = printDialog1.PrinterSettings.PrinterName.ToString();
            //    PC_Application.Properties.Settings.Default.Save();
            //}

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmPrinting")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmPrinting objPrnt = new frmPrinting();
            objPrnt.MdiParent = this;
            objPrnt.Show();
        }

        private void generationRequestRejectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmCancelRequest")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmCancelRequest objCan = new frmCancelRequest();
            objCan.MdiParent = this;
            objCan.Show();
        }

        private void serialNoRejectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmCancelSerial")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmCancelSerial objCanSr = new frmCancelSerial();
            objCanSr.MdiParent = this;
            objCanSr.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmJobCreate")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmJobCreate objob = new frmJobCreate();
            objob.MdiParent = this;
            objob.Show();
        }

        private void uploadMastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmUpload")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            PC_Application.Reports.frmUploadReport objUp = new PC_Application.Reports.frmUploadReport();
            objUp.MdiParent = this;
            objUp.Show();
        }

        private void scanningDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmDownload")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmDownload objDown = new frmDownload();
            objDown.MdiParent = this;
            objDown.Show();
        }

        private void manualScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "ManualScanning")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            ManualScanning objMan = new ManualScanning();
            objMan.MdiParent = this;
            objMan.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                objLog.WriteErrorLog(this.Name.ToString(), "exitToolStripMenuItem_Click", "Success", "User Logged Out Succesfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                this.Close();
                this.Dispose();
                Application.Exit();
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "exitToolStripMenuItem_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
        }

        private void mnuOnline_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("MicroScanTest.exe");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //foreach (Form childform in MdiChildren)
            //{
            //    if (childform.Name != "frmMicroscan")
            //    {
            //        childform.Close();
            //    }
            //}

            //foreach (Form childform in MdiChildren)
            //{
            //    if (childform.ShowInTaskbar)
            //    {
            //        childform.Focus();
            //        return;
            //    }
            //}
            //frmOnlineScanning1 objOn = new frmOnlineScanning1();
            //objOn.MdiParent = this;
            //objOn.Show();
        }


        private void mnuBatchCreat_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmBatchCreation")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmBatchCreation objBatch = new frmBatchCreation();
            objBatch.MdiParent = this;
            objBatch.Show();
        }

        private void mnuGeneration_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmGenReq")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmGenReq objGenreq = new frmGenReq();
            objGenreq.MdiParent = this;
            objGenreq.Show();
        }

        private void mnuSipper_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmSipperLevel")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmShipperLevel objGenreq = new frmShipperLevel();
            objGenreq.MdiParent = this;
            objGenreq.Show();
        }

        private void masterSyncronizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Master_Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            Master_Sync objGenreq = new Master_Sync();
            objGenreq.MdiParent = this;
            objGenreq.Show();
        }

        private void transcationSyncronizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Transcation Data Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmTransSync objTranSync = new frmTransSync();
            objTranSync.MdiParent = this;
            objTranSync.Show();
        }

        private void toolStripButton_Print_Click(object sender, EventArgs e)
        {

        }

        private void parentChildReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Transcation Data Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmParentChildRpt objTranSync = new frmParentChildRpt();
            objTranSync.MdiParent = this;
            objTranSync.Show();

        }

        private void unutilizedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Transcation Data Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmSecondUnutlized objTranSync = new frmSecondUnutlized();
            objTranSync.MdiParent = this;
            objTranSync.Show();

        }

        private void unutilizedReportTertiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Transcation Data Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmTerteryUntilized objTranSync = new frmTerteryUntilized();
            objTranSync.MdiParent = this;
            objTranSync.Show();

        }

        private void mnuMasterSync_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "Master_Sync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            Master_Sync objCan = new Master_Sync();
            objCan.MdiParent = this;
            objCan.Show();
        }

        private void mnuTransSync_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmTransSync")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmTransSync objtrans = new frmTransSync();
            objtrans.MdiParent = this;
            objtrans.Show();
        }

        private void mnuUpload_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmUpload")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmUpload objUpload = new frmUpload();
            objUpload.MdiParent = this;
            objUpload.Show();
        }

        private void mnuDownload_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmDownload")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmDownload objDownload = new frmDownload();
            objDownload.MdiParent = this;
            objDownload.Show();
        }

        private void mnuSummaryRpt_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmSummaryRpt")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmSummaryRpt objSumRpt = new frmSummaryRpt();
            objSumRpt.MdiParent = this;
            objSumRpt.Show();
        }

        private void mnuTertiary_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmTerRpt")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmTerRpt objRpt = new frmTerRpt();
            objRpt.MdiParent = this;
            objRpt.Show();
        }

        private void mnuSecondary_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmSecRpt")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmSecRpt objRpt = new frmSecRpt();
            objRpt.MdiParent = this;
            objRpt.Show();
        }

        private void mnuWrongPacking_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmWrongPack")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmWrongPack objRpt = new frmWrongPack();
            objRpt.MdiParent = this;
            objRpt.Show();
        }

        private void mnuEventLog_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmEventRpt")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmEventRpt objEvent = new frmEventRpt();
            objEvent.MdiParent = this;
            objEvent.Show();
        }

        private void uploadSummeryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uploadSummeryReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmUploadReport")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmUploadReport objEvent = new frmUploadReport();
            objEvent.MdiParent = this;
            objEvent.Show();
        }

        private void Menu_Config_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "frmConfig")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            frmConfig objEvent = new frmConfig();
            //objEvent.MdiParent = this;
            objEvent.ShowDialog();
        }

        private void shipperScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childform in MdiChildren)
            {
                if (childform.Name != "ShipperScanning")
                {
                    childform.Close();
                }
            }

            foreach (Form childform in MdiChildren)
            {
                if (childform.ShowInTaskbar)
                {
                    childform.Focus();
                    return;
                }
            }
            ShipperScanning objMan = new ShipperScanning();
            objMan.MdiParent = this;
            objMan.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

       


    

       








    }
}
