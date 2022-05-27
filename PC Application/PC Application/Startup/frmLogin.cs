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
using BusinessLayer.localhost;
using DataLayer;

namespace PC_Application.Startup
{
    public partial class frmLogin : Form
    {
        int iLoginEntry = 0;
        public frmLogin()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            string strValue = "", strResult = "";
            try
            {


                if (txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter User ID");
                    txtUsername.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Password");
                    txtPassword.Focus();
                    return;
                }
                //if (cboPlantCode.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please Select Plant Code");
                //    cboPlantCode.Focus();
                //    return;
                //}

                PL_Login objPLlog = new PL_Login();
                BL_Login objBL_Log = new BL_Login();

                objPLlog.strUserID = txtUsername.Text;
                objPLlog.strPass = txtPassword.Text;
                objPLlog.strPlantCode = "";
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                PL_File.TerMonth = DataLayer.clsDb.GetGlobleDetails("TERMONTH");
                PL_File.TerSep = DataLayer.clsDb.GetGlobleDetails("TERSEP");

                strValue = objBL_Log.Login(objPLlog, PL_Login.PlantCode);
                if (strValue.Trim().Split('@').GetValue(0).ToString() != "2")
                {
                    if (strValue.Trim().Split('@').GetValue(0).ToString() == "1")
                    {
                        PL_Login.UserID = txtUsername.Text;

                        if (strValue.Trim().Split('@').GetValue(1).ToString() == "First Time Login.")
                        {
                            this.Hide();
                            objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Error", "First Time Login.", "PC Client", txtUsername.Text, PL_Login.PlantCode);
                            frmChangePwd objChnage = new frmChangePwd();
                            objChnage.Show();
                        }
                        else
                        {


                            PL_Login.UType = strValue.Trim().Split('@').GetValue(3).ToString();
                            PL_Login.PlantCode = strValue.Trim().Split('@').GetValue(2).ToString();
                            PL_Login.URights = strValue.Trim().Split('@').GetValue(4).ToString();
                            PL_Login.iExpiry = 180 - Convert.ToInt32(strValue.Trim().Split('@').GetValue(5).ToString());
                            objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Success", "User Logged in Successfully", "PC Client", txtUsername.Text, PL_Login.PlantCode);
                            clsFile.SetGlobleDetails("User", txtUsername.Text.Trim());
                            MDIMain objMain = new MDIMain();
                            objMain.Show();

                            //PL_Login.PlantCode = cboPlantCode.Text.Trim();
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (strValue.Split('@').GetValue(1).ToString() == "Invalid login credentials entered.")
                        {
                            //objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Error", "Invalid login credentials entered.", "PC Client", txtUsername.Text);
                            iLoginEntry += 1;
                        }
                        if (iLoginEntry >= 3)
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Error", "User Account has been Deactivated", "PC Client", txtUsername.Text, PL_Login.PlantCode);
                            strResult = objBL_Log.UpdateStatus(objPLlog, "DEACTIVE");
                            MessageBox.Show(strResult.ToString());
                            lnkActiveUser.Visible = true;
                            //txtUsername.Text = "";
                            txtUsername.Enabled = false;
                            txtPassword.Text = "";
                            //txtUsername.Focus();
                        }
                        else
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Error", strValue.Split('@').GetValue(1).ToString(), "PC Client", txtUsername.Text, PL_Login.PlantCode);
                            MessageBox.Show(strValue.Split('@').GetValue(1).ToString());

                            if (strValue.Split('@').GetValue(1).ToString() == "Your account is locked.")
                            {
                                lnkActiveUser.Visible = true;
                                //txtUsername.Text = "";
                                txtUsername.Enabled = false;
                                txtPassword.Text = "";
                            }
                            else
                            {
                                txtPassword.Text = "";
                                txtPassword.Focus();
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show(strValue.Split('@').GetValue(1).ToString(),"Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unable to connect to the remote server")
                {
                    MessageBox.Show(ex.Message, "Message");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                    objLog.WriteErrorLog(this.Name.ToString(), "btnLogin_Click", "Error", ex.Message, "PC Client", txtUsername.Text, PL_Login.PlantCode);
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            BL_Login objLog = new BL_Login();
            string strReturn = "";
            try
            {
                this.Size = new Size(529, 302);
                
                 pnlLogin.Location = new Point(0, 0);
                 pnlConnection.Visible = false;
                 pnlLogin.Visible = true;

                string version = "V" + System.Reflection.Assembly.GetExecutingAssembly()
                                         .GetName()
                                         .Version
                                         .ToString();
                lblVersion.Text = version;



                pcbImage.Image = Image.FromFile(Application.StartupPath + "\\logo.jpeg");

                try
                {
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    BL_Login.objLocal = new Service();
                    BL_Login.objLocal.Url = PL_File.servicePath;
                    BL_Login.objLocal.Timeout = 60000;

                    BL_Login.objLocal.HelloWorld();
                    strReturn = objLog.GetSetting();

                    if (strReturn.Split('~').Count()!= 6)
                    {
                        lnkConnection.Text = "Build ID Mismatch";
                        lnkConnection.LinkColor = Color.DarkRed;

                        lblServer.Text = strReturn.Split('~').GetValue(1).ToString();
                        lblDb.Text = strReturn.Split('~').GetValue(2).ToString();
                        txtWeb.Text = PL_File.servicePath;
                        return;
                    }



                    if (strReturn.Split('~').GetValue(0).ToString() == "1")
                    {
                        lnkConnection.Text = "Server Connected";
                        lnkConnection.LinkColor = Color.DarkGreen;
                        lblServer.Text = strReturn.Split('~').GetValue(1).ToString();
                        lblDb.Text = strReturn.Split('~').GetValue(2).ToString();
                        txtBuildID.Text=strReturn.Split('~').GetValue(5).ToString();
                        txtWeb.Text = PL_File.servicePath; 


                    }
                    else
                    {
                        lnkConnection.Text = "Server Disconnected";
                        lnkConnection.LinkColor = Color.DarkRed;
                        lblServer.Text = strReturn.Split('~').GetValue(1).ToString();
                        lblDb.Text = strReturn.Split('~').GetValue(2).ToString();
                        txtBuildID.Text = strReturn.Split('~').GetValue(5).ToString();
                        txtWeb.Text = PL_File.servicePath;
                    }
                }
                catch (Exception ex)
                {
                    lnkConnection.Text = "Server Disconnected";
                    lnkConnection.LinkColor = Color.DarkRed;

                    lblServer.Text = "";
                    lblDb.Text = "";

                    txtBuildID.Text = "";

                    txtWeb.Text = PL_File.servicePath; ;
                }
               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BL_Login.objLocal = null;
            }

            
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePwd objChnage = new frmChangePwd();
            objChnage.Show();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void lnkConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = false;
            pnlConnection.Visible = true;
            pnlConnection.Location = new Point(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlConnection.Visible = false;
            pnlLogin.Location = new Point(0, 0);
        }

        private void pcbImage_Click(object sender, EventArgs e)
        {


        }

        private void lnkActiveUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter User ID");
                    txtUsername.Focus();
                    return;
                }
              
                BL_LogWriter objLog = new BL_LogWriter();
                PL_Login objPLlog = new PL_Login();
                BL_Login objBL_Log = new BL_Login();
                string strResult = "";
                objPLlog.strUserID = txtUsername.Text;

                objLog.WriteErrorLog(this.Name.ToString(), "lnkActiveUser_LinkClicked", "Success", "User Account has been Activated", "PC Client", txtUsername.Text, "-");
                strResult = objBL_Log.UpdateStatus(objPLlog, "ACTIVE");

                if (strResult == "")
                {
                    MessageBox.Show("User id does not exists");
                }
                else
                {
                    MessageBox.Show(strResult.ToString());
                    txtUsername.Enabled = true;
                    lnkActiveUser.Visible = false;
                }
                //txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
           
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBuild_Click(object sender, EventArgs e)
        {

        }


    }
}
