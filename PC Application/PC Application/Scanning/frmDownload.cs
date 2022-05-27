using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;
using PropertyLayer;

namespace PC_Application.Scanning
{
    public partial class frmDownload : Form
    {
        OpenNETCF.Desktop.Communication.RAPI mri;

        BL_Scanning objScan;
        BL_Scheduler objSchedule;
        clsFile objFile;
        string strLocal = Application.StartupPath + "\\Download";
        string strUpload = Application.StartupPath + "\\Upload";
        string strBackup = Application.StartupPath + "\\BackupFile";

        public frmDownload()
        {
            InitializeComponent();
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            cboPackLvl.SelectedIndex = 0;
            if (!Directory.Exists(Application.StartupPath + "\\Download"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Download");
            }
            if (!Directory.Exists(Application.StartupPath + "\\BackupFile"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\BackupFile");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            mri = new OpenNETCF.Desktop.Communication.RAPI();

            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (!mri.DevicePresent == true)
                {
                    lblDevice.Text = "Device is not connected";
                    lblDevice.BackColor = Color.Red;
                    lblDevice.Visible = true;
                    return;
                }
                mri.Connect();
                if (mri.Connected == true)
                {
                    lblDevice.Text = "Device is connected";
                    lblDevice.BackColor = Color.Green;
                    lblDevice.Visible = true;
                }
                else
                {
                    lblDevice.Text = "Device is not connected";
                    lblDevice.BackColor = Color.Red;
                    lblDevice.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnConnect_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                lblDevice.Text = "Device is not connected";
                lblDevice.BackColor = Color.Red;
                lblDevice.Visible = true;
            }
            finally
            {
                objLog = null;
                mri.Dispose();
                mri = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            objScan = new BL_Scanning();
            int iMap = 0;
            DateTime dtp = DateTime.Now;
            objSchedule = new BL_Scheduler();
            BL_LogWriter objLog = new BL_LogWriter();
            mri = new OpenNETCF.Desktop.Communication.RAPI();
            objFile = new clsFile();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable("temp");
            try
            {


                if (cboPackLvl.Text != "Select")
                {

                    //if (!mri.DevicePresent == true)
                    //{

                    //    lblDevice.Text = "Device is not connected";
                    //    lblDevice.BackColor = Color.Red;
                    //    lblDevice.Visible = true;
                    //    return;
                    //}

                    //mri.Connect();
                    //if (mri.Connected == false)
                    //{
                    //    lblDevice.Text = "Device is not connected";
                    //    lblDevice.BackColor = Color.Red;
                    //    lblDevice.Visible = true;
                    //    return;
                    //}


                    if (cboPackLvl.SelectedIndex == 1)
                    {
                        //inward
                        if (objFile.DownloadDataFromDevice("Inward", strLocal + "\\Inward.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("Inward", strLocal + "\\Inward.txt");
                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertInwardData(dt, PL_Login.UserID);

                                objSchedule.BLUpdateInward(dt);
                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);
                                File.Delete(strLocal + "\\Inward.txt");
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Inward", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                mri.DeleteDeviceFile(objFile.defaultInwardPath());


                            }
                            else
                            {
                                lblMessage.Text = "Inward Scan Data Not Found";
                            }
                        }
                        else
                        {

                            lblMessage.Text = "Inward Scan Data Not Found";
                            //download data not found
                        }


                    }
                    else if (cboPackLvl.SelectedIndex == 2)
                    {
                        //outward

                        if (objFile.DownloadDataFromDevice("Outward", strLocal + "\\Outward.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("Outward", strLocal + "\\Outward.txt");
                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertOutwardData(dt, PL_Login.UserID);
                                objSchedule.BLUpdateOutward(dt);
                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);
                                File.Delete(strLocal + "\\Outward.txt");
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Outward", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                mri.DeleteDeviceFile(objFile.defaultOutwardPath());


                            }
                            else
                            {
                                lblMessage.Text = "Outward Scan Data Not Found";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Outward Scan Data Not Found";
                            //download data not found
                        }
                    }
                    else if (cboPackLvl.SelectedIndex == 3)
                    {
                        //secondary

                        if (objFile.DownloadDataFromDevice("Secondary", strLocal + "\\Secondary.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("Secondary", strLocal + "\\Secondary.txt");
                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertSecData(dt, PL_Login.UserID);
                                objSchedule.BLUpdateValidation(dt, "S");
                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);
                                File.Delete(strLocal + "\\Secondary.txt");
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Secondary", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                mri.DeleteDeviceFile(objFile.defaultSecScanningPath());
                            }
                            else
                            {
                                lblMessage.Text = "Secondary Scan Data Not Found";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Secondary Scan Data Not Found";
                            //download data not found
                        }
                    }
                    else if (cboPackLvl.SelectedIndex == 4)
                    {
                        //Tertiary
                        if (objFile.DownloadDataFromDevice("Tertiary", strLocal + "\\Tertiary.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("Tertiary", strLocal + "\\Tertiary.txt");

                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertTerData(dt, PL_Login.UserID);
                                objSchedule.BLUpdateValidation(dt, "T");
                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);
                                File.Delete(strLocal + "\\Tertiary.txt");
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Tertiary", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                mri.DeleteDeviceFile(objFile.defaultTerScanningPath());



                            }
                            else
                            {
                                lblMessage.Text = "Tertiary Scan Data Not Found";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Tertiary Scan Data Not Found";
                            //download data not found
                        }
                    }
                    else if (cboPackLvl.SelectedIndex == 5)
                    {

                        DataTable dtParent = new DataTable();
                        DataTable dtComPack = new DataTable();
                        DataRow[] drParent;

                        DataTable dtHetro = new DataTable();
                        DataTable dtCompHetro = new DataTable();
                        DataRow[] drHetro;
                        iMap++;
                        //if (objFile.DownloadDataFromDevice("Mapping", strLocal + "\\Mapping.txt") == 1)
                        //{
                        //    iMap++;
                        //    dt = objFile.CreateDataTable("Mapping", strLocal + "\\Mapping.txt");
                        //}
                        //if (objFile.DownloadDataFromDevice("Hetro", strLocal + "\\Hetro.txt") == 1)
                        //{
                        //    iMap++;
                        //    dt1 = objFile.CreateDataTable("Mapping", strLocal + "\\Hetro.txt");

                        //}
                        if (iMap > 0)
                        {
                            string strResult = "";

                            //if (dt1.Rows.Count > 0 && dt.Rows.Count > 0)
                            //{
                               // dt.Merge(dt1);
                               // dt.AcceptChanges();


                               // strResult=objSchedule.BLUpdateMappingWrng(dt);

                               // lstView.Items.Clear();
                               // lstView.Columns.Clear();
                               //// objFile.BindListMapping(dt, lstView);

                               // File.Copy(strLocal + "\\Hetro.txt", strBackup + "\\Hetro_" + dtp.Day.ToString() + dtp.Month.ToString() + dtp.Year.ToString() + dtp.Hour.ToString() + dtp.Minute.ToString() + dtp.Second.ToString() + ".txt");
                               // File.Copy(strLocal + "\\Mapping.txt", strBackup + "\\Packing_" + dtp.Day.ToString() + dtp.Month.ToString() + dtp.Year.ToString() + dtp.Hour.ToString() + dtp.Minute.ToString() + dtp.Second.ToString() + ".txt");

                                dtComPack = objFile.CreateDataTable("MappingFull", strLocal + "\\Mapping.txt");
                                dtParent = dtComPack.DefaultView.ToTable(true, "P_BARCODE", "PARTIAL_ST");
                                drParent = dtParent.Select("PARTIAL_ST=1");

                                //dtCompHetro = objFile.CreateDataTable("MappingFull", strLocal + "\\Hetro.txt");
                                //dtHetro = dtCompHetro.DefaultView.ToTable(true, "P_BARCODE", "PARTIAL_ST");
                                //drHetro = dtHetro.Select("PARTIAL_ST=1");


                               // File.Delete(strLocal + "\\Hetro.txt");
                                //File.Delete(strLocal + "\\Mapping.txt");

                             

                                //for packing
                                string strIncomp = "";
                                foreach (DataRow rowParent in drParent)
                                {
                                    if (strIncomp == "")
                                    {
                                        strIncomp = rowParent[0].ToString();
                                    }
                                    else
                                    {
                                        strIncomp = strIncomp + "','" + rowParent[0].ToString();
                                    }
                                }

                                
                                if (strIncomp != "")
                                {
                                    mri.DeleteDeviceFile(objFile.defaultMappingpath());
                                    mri.DeleteDeviceFile(objFile.defaultJobPath());

                                    DataRow[] drIncomp = dtComPack.Select("P_BARCODE NOT IN ('" + strIncomp + "')");
                                    if (drIncomp.Length > 0)
                                    {
                                        StreamWriter sw = new StreamWriter(strUpload + "\\Packing.txt");
                                        foreach (DataRow drPen in drIncomp)
                                        {
                                            sw.WriteLine(drPen[0].ToString() + "#" + drPen[1].ToString() + "#" + drPen[2].ToString() + "#" + drPen[3].ToString() + "#" + drPen[4].ToString() + "#" + drPen[5].ToString() + "#" + drPen[6].ToString());
                                        }
                                        sw.Close();
                                        sw.Dispose();
                                        mri.CopyFileToDevice(strUpload + "\\Packing.txt", objFile.defaultMappingpath());
                                        File.Delete(strUpload + "\\Packing.txt");
                                    }
                                    
                                }

                                //FOR HETRO

                                //string strHetroIncomp = "";
                                //foreach (DataRow rowHetro in drHetro)
                                //{
                                //    if (strHetroIncomp == "")
                                //    {
                                //        strHetroIncomp = rowHetro[0].ToString();
                                //    }
                                //    else
                                //    {
                                //        strHetroIncomp = strHetroIncomp + "','" + rowHetro[0].ToString();
                                //    }
                                //}

                                //if (strHetroIncomp != "")
                                //{
                                //    mri.DeleteDeviceFile(objFile.defaultHetroMappingpath());

                                //    DataRow[] drHetroIncomp = dtCompHetro.Select("P_BARCODE NOT IN ('" + strHetroIncomp + "')");
                                //    if (drHetroIncomp.Length > 0)
                                //    {
                                //        StreamWriter sw = new StreamWriter(strUpload + "\\Hetro.txt");
                                //        foreach (DataRow drPenHetro in drHetroIncomp)
                                //        {
                                //            sw.WriteLine(drPenHetro[0].ToString() + "#" + drPenHetro[1].ToString() + "#" + drPenHetro[2].ToString() + "#" + drPenHetro[3].ToString() + "#" + drPenHetro[4].ToString() + "#" + drPenHetro[5].ToString() + "#" + drPenHetro[6].ToString());
                                //        }
                                //        sw.Close();
                                //        sw.Dispose();
                                //        mri.CopyFileToDevice(strUpload + "\\Hetro.txt", objFile.defaultHetroMappingpath());
                                //        File.Delete(strUpload + "\\Hetro.txt");
                                //    }
                                //}
                                
                               
                                lblMessage.Text = strResult;
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Mapping", "Success", strResult, "PC Client", PL_Login.UserID,PL_Login.PlantCode);

                            //}
                            //else if (dt1.Rows.Count > 0)
                            //{
                                strResult=objSchedule.BLUpdateMappingWrng(dt1);

                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                //objFile.BindListMapping(dt1, lstView);

                                File.Copy(strLocal + "\\Hetro.txt", strBackup + "\\Hetro_" + dtp.Day.ToString() + dtp.Month.ToString() + dtp.Year.ToString() + dtp.Hour.ToString() + dtp.Minute.ToString() + dtp.Second.ToString() + ".txt");

                                dtHetro = objFile.CreateDataTable("MappingFull", strLocal + "\\Hetro.txt");
                                dtCompHetro = dtHetro.DefaultView.ToTable(true, "P_BARCODE", "PARTIAL_ST");
                                drHetro = dtCompHetro.Select("PARTIAL_ST=1");

                                File.Delete(strLocal + "\\Hetro.txt");
                                
                                //string strHetroIncomp = "";
                                //foreach (DataRow rowHetro in drHetro)
                                //{
                                //    if (strHetroIncomp == "")
                                //    {
                                //        strHetroIncomp = rowHetro[0].ToString();
                                //    }
                                //    else
                                //    {
                                //        strHetroIncomp = strHetroIncomp + "','" + rowHetro[0].ToString();
                                //    }
                                //}
                                //if (strHetroIncomp != "")
                                //{
                                //    mri.DeleteDeviceFile(objFile.defaultHetroMappingpath());
                                //    DataRow[] drHetroIncomp = dtCompHetro.Select("P_BARCODE NOT IN ('" + strHetroIncomp + "')");
                                //    if (drHetroIncomp.Length > 0)
                                //    {
                                //        StreamWriter sw = new StreamWriter(strUpload + "\\Hetro.txt");
                                //        foreach (DataRow drPenHetro in drHetroIncomp)
                                //        {
                                //            sw.WriteLine(drPenHetro[0].ToString() + "#" + drPenHetro[1].ToString() + "#" + drPenHetro[2].ToString() + "#" + drPenHetro[3].ToString() + "#" + drPenHetro[4].ToString() + "#" + drPenHetro[5].ToString() + "#" + drPenHetro[6].ToString());
                                //        }
                                //        sw.Close();
                                //        sw.Dispose();

                                //        mri.CopyFileToDevice(strUpload + "\\Hetro.txt", objFile.defaultHetroMappingpath());
                                //        File.Delete(strUpload + "\\Hetro.txt");
                                //    }
                                //}

                                lblMessage.Text = strResult;
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Mapping", "Success", strResult, "PC Client", PL_Login.UserID,PL_Login.PlantCode);


                           // }
                            //else if (dt.Rows.Count > 0)
                            //{

                               strResult= objSchedule.BLUpdateMappingWrng(dt);

                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                               // objFile.BindListMapping(dt, lstView);

                                File.Copy(strLocal + "\\Mapping.txt", strBackup + "\\Packing_" + dtp.Day.ToString() + dtp.Month.ToString() + dtp.Year.ToString() + dtp.Hour.ToString() + dtp.Minute.ToString() + dtp.Second.ToString() + ".txt");

                                dtComPack = objFile.CreateDataTable("MappingFull", strLocal + "\\Mapping.txt");
                                dtParent = dtComPack.DefaultView.ToTable(true, "P_BARCODE", "PARTIAL_ST");
                                drParent = dtParent.Select("PARTIAL_ST=1");

                               // string strIncomp = "";
                                foreach (DataRow rowParent in drParent)
                                {
                                    if (strIncomp == "")
                                    {
                                        strIncomp = rowParent[0].ToString();
                                    }
                                    else
                                    {
                                       strIncomp= strIncomp + "','" + rowParent[0].ToString();
                                    }
                                }
                                File.Delete(strLocal + "\\Mapping.txt");
                                
                                if (strIncomp != "")
                                {
                                    mri.DeleteDeviceFile(objFile.defaultMappingpath());
                                    mri.DeleteDeviceFile(objFile.defaultJobPath());

                                    DataRow[] drIncomp = dtComPack.Select("P_BARCODE NOT IN ('" + strIncomp + "')");

                                    if (drIncomp.Length > 0)
                                    {
                                        StreamWriter sw = new StreamWriter(strUpload + "\\Packing.txt");
                                        foreach (DataRow drPen in drIncomp)
                                        {
                                            sw.WriteLine(drPen[0].ToString() + "#" + drPen[1].ToString() + "#" + drPen[2].ToString() + "#" + drPen[3].ToString() + "#" + drPen[4].ToString() + "#" + drPen[5].ToString() + "#" + drPen[6].ToString());
                                        }
                                        sw.Close();
                                        sw.Dispose();

                                        mri.CopyFileToDevice(strUpload + "\\Packing.txt", objFile.defaultMappingpath());
                                        File.Delete(strUpload + "\\Packing.txt");
                                    }
                                    
                                }

                                lblMessage.Text = strResult;
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Mapping", "Success", strResult, "PC Client", PL_Login.UserID,PL_Login.PlantCode);
                            //}
                           // else
                            //{
                            //    lblMessage.Text = "Mapping Scan Data Not Found";
                            //}
                        }
                        else
                        {
                            lblMessage.Text = "Mapping Scan Data Not Found";
                        }
                    }
                    else if (cboPackLvl.SelectedIndex == 6)
                    {
                        if (objFile.DownloadDataFromDevice("SReject", strLocal + "\\SReject.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("SReject", strLocal + "\\SReject.txt");
                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertSecRejData(dt, PL_Login.UserID);

                                objSchedule.BLUpdateRejection(dt, "S", PL_Login.PlantCode);

                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);

                                File.Delete(strLocal + "\\SReject.txt");
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Secondary Reject", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID,PL_Login.PlantCode);
                                mri.DeleteDeviceFile(objFile.defaultSecRejectionpath());


                            }
                            else
                            {
                                lblMessage.Text = "Secondary Rejection Data Not Found";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Secondary Rejection Data Not Found";
                            //download data not found
                        }
                    }
                    else if (cboPackLvl.SelectedIndex == 7)
                    {
                        if (objFile.DownloadDataFromDevice("TReject", strLocal + "\\TReject.txt") == 1)
                        {
                            dt = objFile.CreateDataTable("TReject", strLocal + "\\TReject.txt");
                            if (dt.Rows.Count > 0)
                            {
                                //objScan.InsertTerRejData(dt, PL_Login.UserID);

                                objSchedule.BLUpdateRejection(dt, "T", PL_Login.PlantCode);

                                lstView.Items.Clear();
                                lstView.Columns.Clear();
                                objFile.BindListMapping(dt, lstView);

                                File.Delete(strLocal + "\\TReject.txt");
                                lblMessage.Text = dt.Rows.Count + " Records Downloaded..";
                                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click-Tertiary Reject", "Success", dt.Rows.Count + " Records Downloaded", "PC Client", PL_Login.UserID,PL_Login.PlantCode);

                                mri.DeleteDeviceFile(objFile.defaultTerRejectionpath());


                            }
                            else
                            {
                                lblMessage.Text = "Tertiary Rejection Data Not Found";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Tertiary Rejection Data Not Found";
                            //download data not found
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click", "Error", ex.Message, "PC Client", PL_Login.UserID,PL_Login.PlantCode);
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                mri.Disconnect();
                mri.Dispose();
                mri = null;
                objLog = null;
                objScan = null;
            }
        }

        //public void displayCount(DataTable dtWrong, DataTable dtTotal)
        //{
        //    //DataRow [] drSecSucc = new DataRow();
        //    //DataRow[] drSecFail = new DataRow();
        //    //DataRow[] drTerSucc = new DataRow();
        //    //DataRow[] drTerFail = new DataRow();



        //    DataRow drComp = dtTotal.Select("PARTIAL_ST=1 AND C_BARCODE!=''");
        //    DataRow drIncomp = dtTotal.Select("PARTIAL_ST=0");

        //    DataTable dtCompParent = drComp.Table.DefaultView.ToTable(true, "P_BARCODE");
        //    DataTable dtInComParent = drIncomp.Table.DefaultView.ToTable(true, "P_BARCODE");




        //    try
        //    {


        //        string strFinal = "Total Download " + drcomp.Count().ToString();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
