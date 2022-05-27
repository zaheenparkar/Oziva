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
using DataLayer;

namespace PC_Application.Startup
{
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            frmLogin objLog = new frmLogin();
            objLog.Show();
        }

        private void frmChangePwd_Load(object sender, EventArgs e)
        {
            try
            {
                if (PL_Login.UserID != "")
                {
                    txtUsername.Text = PL_Login.UserID;
                    txtUsername.Enabled = false;
                    txtNewPass.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PL_Login objPLlog = new PL_Login();
            BL_Login objBL_Log = new BL_Login();
            BL_LogWriter objLog = new BL_LogWriter();
            string strValue = "";
            errorProvider1.Dispose();
            try
            {
                if (txtUsername.Text == "")
                {
                    errorProvider1.SetError(txtUsername, "User Id Can't be left blank");
                    txtUsername.Focus();
                    return;
                }
                if (txtOldPass.Text == "")
                {
                    errorProvider1.SetError(txtNewPass, "Old Password Can't be left blank");
                    txtOldPass.Focus();
                    return;
                }
                if (txtNewPass.Text == "")
                {
                    errorProvider1.SetError(txtNewPass, "New Password Can't be left blank");
                    txtNewPass.Focus();
                    return;
                }
                if (txtNewPass.Text.Length < 8)
                {
                    errorProvider1.SetError(txtNewPass, "Password should be greater than 8 character");
                    txtNewPass.Focus();
                    return;
                }

                if (txtConfirm.Text == "")
                {
                    errorProvider1.SetError(txtConfirm, "Confirm Password Can't be left blank");
                    txtConfirm.Focus();
                    return;
                }
                if (txtNewPass.Text.ToLower().CompareTo(txtConfirm.Text.ToLower())!=0)
                {
                    errorProvider1.SetError(txtConfirm, "New Password and Confirm password does not match.");
                    txtConfirm.Text = "";
                    txtConfirm.Focus();
                    return;
                }
                if(txtUsername.Text.ToUpper()==txtNewPass.Text.ToUpper())
                {
                    errorProvider1.SetError(txtNewPass, "Username And Password Should not be same.");
                    txtNewPass.Text = "";
                    txtConfirm.Text = "";
                    txtNewPass.Focus();
                    return;
                }

                objPLlog.strUserID = txtUsername.Text;
                objPLlog.strNewPass = txtNewPass.Text;
                objPLlog.strPass = txtOldPass.Text;

                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                strValue = objBL_Log.ForgotPassword(objPLlog);
                if (strValue.Contains("@") == true)
                {
                    objLog.WriteErrorLog(this.Name.ToString(), "btnUpdate_Click", "Error", strValue.Split('@').GetValue(1).ToString(), "PC Client", txtUsername.Text, PL_Login.PlantCode);

                    if (strValue.Trim().Split('@').GetValue(0).ToString() == "0")
                    {
                        MessageBox.Show(strValue.Trim().Split('@').GetValue(1).ToString(), "e-Track App.- Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtOldPass.Text = "";
                        txtOldPass.Focus();
                        return;
                    }
                    else if (strValue.Trim().Split('@').GetValue(0).ToString() == "1")
                    {
                        MessageBox.Show(strValue.Trim().Split('@').GetValue(1).ToString(), "e-Track App.- Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNewPass.Text = "";
                        txtConfirm.Text = "";
                        txtNewPass.Focus();
                        return;
                    }
                }
                else
                {
                    objLog.WriteErrorLog(this.Name.ToString(), "btnUpdate_Click", "Success", strValue, "PC Client", txtUsername.Text, PL_Login.PlantCode);
                    MessageBox.Show(strValue.Trim(), "e-Track App.- Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    frmLogin objLogin = new frmLogin();
                    objLogin.Show();
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnUpdate_Click", "Error", ex.Message, "PC Client", txtUsername.Text, PL_Login.PlantCode);
                MessageBox.Show(ex.Message, "e-Track App.- Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objBL_Log = null; objPLlog = null;objLog=null;
            }
        }
    }
}
