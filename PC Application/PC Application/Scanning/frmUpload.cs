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
using OpenNETCF.Desktop.Communication;

namespace PC_Application.Scanning
{
    public partial class frmUpload : Form
    {
        BL_Upload objUpload;
        clsFile objFile;
        BL_Printing objBL_Prnt;
        OpenNETCF.Desktop.Communication.RAPI mri;
        
        public frmUpload()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            mri = new OpenNETCF.Desktop.Communication.RAPI();
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
                lblDevice.Text = "Device is not connected";
                lblDevice.BackColor = Color.Red;
                lblDevice.Visible = true;
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            objUpload = new BL_Upload();
            BL_LogWriter objLog = new BL_LogWriter();
            mri = new OpenNETCF.Desktop.Communication.RAPI();
            objFile = new clsFile();
            DataSet ds = new DataSet();
            objBL_Prnt = new BL_Printing();
            int iCons=0, iUser=0, iplant = 0;
            StreamWriter sw;
            string strMaster = "";
            string strPlant = "", strarrPlant = "";
            string[] str;
            try
            {
                strPlant = objBL_Prnt.BLGetPlantLogin(PL_Login.UserID);
                if (strPlant != "")
                {

                    if (!mri.DevicePresent == true)
                    {

                        lblDevice.Text = "Device is not connected";
                        lblDevice.BackColor = Color.Red;
                        lblDevice.Visible = true;
                        return;
                    }

                    mri.Connect();
                    if (mri.Connected == false)
                    {
                        lblDevice.Text = "Device is not connected";
                        lblDevice.BackColor = Color.Red;
                        lblDevice.Visible = true;
                        return;
                    }

                    str = strPlant.Split(',');
                    for (int i = 0; i < str.Count(); i++)
                    {
                        if (i == 0)
                        {
                            strarrPlant = str[i].ToString();
                        }
                        else
                        {
                            strarrPlant = strarrPlant + "','" + str[i].ToString();
                        }
                    }

                    ds = objUpload.BLGetMasterDt(strarrPlant);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iUser++;

                        sw = new StreamWriter(Application.StartupPath + "\\Upload\\Users.txt", true);
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            sw.WriteLine(ds.Tables[0].Rows[i][0].ToString() + "#" + ds.Tables[0].Rows[i][1].ToString());
                        }
                        sw.Close();
                        sw.Dispose();
                        objFile.UploadDataToDevice("User", Application.StartupPath + "\\Upload\\Users.txt");
                        

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        iplant++;

                        sw = new StreamWriter(Application.StartupPath + "\\Plant.txt");
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            sw.WriteLine(ds.Tables[1].Rows[i][0].ToString());
                        }
                        sw.Close();
                        sw.Dispose();
                        objFile.UploadDataToDevice("Plant", Application.StartupPath + "\\Plant.txt");
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        iCons++;
                        sw = new StreamWriter(Application.StartupPath + "\\Consignee.txt");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            sw.WriteLine(ds.Tables[2].Rows[i][0].ToString());
                        }
                        sw.Close();
                        sw.Dispose();
                        objFile.UploadDataToDevice("Consignee", Application.StartupPath + "\\Consignee.txt");
                    }
                    if (iplant > 0 && iCons > 0 && iUser > 0)
                    {
                        lblMessage.Text = "Master Details Uploaded Successfully.";
                        objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click", "Success", "Master Details Uploaded Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode); 
                    }


                }
                else
                {
                    lblMessage.Text = "Plant Code Not found";
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objFile = null; objUpload = null; objBL_Prnt = null; ds = null;
                mri.Disconnect();
                objLog = null;
                mri.Dispose();
                mri = null;
            }
        }

        private void frmUpload_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\Upload"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Upload");
            }
        }
    }
}
