using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PropertyLayer;
using BusinessLayer;
using System.Windows.Forms;

namespace PC_Application.Scanning
{
    public partial class ManualScanning : Form
    {
        string strFlag = "";
        string strProcess = "";
        string strFromBatch = "", strToBatch = "";
        BL_LogWriter objLog;
        int ParPackLvl = 0;
        int ChildPackLvl = 0;
        BL_Scanning objScan;

        public ManualScanning()
        {
            InitializeComponent();
        }

        private void cboPackLvl_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPackLvl.Text == "(Select)")
            {
                grpBarcode.Text = "Scan Barcode";
                strFlag = "N";
            }
            else if (cboPackLvl.Text == "Secondary Scanning")
            {
                grpBarcode.Text = "Scan Secondary Barcode";
                txtFrom.Focus();
                strFlag = "S";
            }
            else if (cboPackLvl.Text == "Tertiary Scanning")
            {
                grpBarcode.Text = "Scan Tertiary Barcode";
                txtFrom.Focus();
                strFlag = "T";
            }
        }

        private void ManualScanning_Load(object sender, EventArgs e)
        {
            pnlValidation.Visible = false;
            pnlMain.Visible = true;
        }

        public void DisplayMessage(bool isError, string strMessage, string strType)
        {
            if (strType == "VALID")
            {

                if (isError == true)
                {
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Text = strMessage;
                }
                else
                {
                    lblMessage.BackColor = Color.CornflowerBlue;
                    lblMessage.Text = strMessage;
                }
            }
            else if (strType == "REJECT")
            {
                if (isError == true)
                {
                    lblReject.BackColor = Color.Red;
                    lblReject.Text = strMessage;
                }
                else
                {
                    lblReject.BackColor = Color.CornflowerBlue;
                    lblReject.Text = strMessage;
                }
            }
            else if (strType == "INOUT")
            {
                if (isError == true)
                {
                    lblInOut.BackColor = Color.Red;
                    lblInOut.Text = strMessage;
                }
                else
                {
                    lblInOut.BackColor = Color.CornflowerBlue;
                    lblInOut.Text = strMessage;
                }
            }
            else if (strType == "MAPPING")
            {
                if (isError == true)
                {
                    pnlMap.BackColor = Color.Red;
                    lblMapping.BackColor = Color.Red;
                    lblMapping.Text = strMessage;
                }
                else
                {
                    lblMapping.BackColor = Color.CornflowerBlue;
                    pnlMap.BackColor = Color.CornflowerBlue;
                    lblMapping.Text = strMessage;
                }
            }
        }

        private void txtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                BL_Scanning objScan = new BL_Scanning();
                objLog = new BL_LogWriter();
                try
                {
                    if (strFlag == "S")
                    {
                        if (txtFrom.Text.Length < 13)
                        {
                            DisplayMessage(true, "Invalid Secondary Barcode Scanned", "VALID");
                            txtFrom.Text = "";
                            txtFrom.Focus();
                            return;
                        }
                        else
                        {
                            string strBarcode = txtFrom.Text.Substring(txtFrom.Text.Trim().Length - 13);
                            string strStatus = objScan.BL_ValidateStatus(strBarcode, "S");

                            if (strStatus.Contains("|") == true)
                            {

                                if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                {
                                    strFromBatch = strStatus.Split('|').GetValue(1).ToString();
                                    DisplayMessage(false, "Secondary Barcode Scanned Successfully", "VALID");
                                    txtTo.Text = "";
                                    txtTo.Focus();
                                    return;
                                }
                                else if (strStatus.Split('|').GetValue(0).ToString() == "9")
                                {
                                    DisplayMessage(true, "Scanned Barcode is rejected", "VALID");
                                    txtFrom.Text = "";
                                    txtFrom.Focus();
                                    return;
                                }
                                else if (strStatus.Split('|').GetValue(0).ToString() == "1")
                                {
                                    DisplayMessage(true, "Scanned Barcode is already validated", "VALID");
                                    txtFrom.Text = "";
                                    txtFrom.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Secondary Barcode Scanned", "VALID");
                                txtFrom.Text = "";
                                txtFrom.Focus();
                                return;
                            }

                        }
                    }
                    else if (strFlag == "T")
                    {
                        if (txtFrom.Text.Length != 20)
                        {
                            DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "VALID");
                            txtFrom.Text = "";
                            txtFrom.Focus();
                            return;
                        }
                        else
                        {
                            string strStatus = objScan.BL_ValidateStatus(txtFrom.Text, "T");

                            if (strStatus.Contains("|") == true)
                            {

                                if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                {
                                    strFromBatch = strStatus.Split('|').GetValue(1).ToString();
                                    DisplayMessage(false, "Tertiary Barcode Scanned Successfully", "VALID");
                                    txtTo.Text = "";
                                    txtTo.Focus();
                                    return;
                                }
                                else if (strStatus.Split('|').GetValue(0).ToString() == "9")
                                {
                                    DisplayMessage(true, "Scanned Barcode is rejected", "VALID");
                                    txtFrom.Text = "";
                                    txtFrom.Focus();
                                    return;
                                }
                                else if (strStatus.Split('|').GetValue(0).ToString() == "1")
                                {
                                    DisplayMessage(true, "Scanned Barcode is already validated", "VALID");
                                    txtFrom.Text = "";
                                    txtFrom.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "VALID");
                                txtFrom.Text = "";
                                txtFrom.Focus();
                                return;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Type", "e-Track App.- Message");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    objLog.WriteErrorLog(this.Name.ToString(), "txtFrom_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(),PL_Login.PlantCode);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    objLog = null;
                    objScan = null;
                }
            }
        }

        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            int iRes = 0;
            if (e.KeyCode == Keys.Enter)
            {

                BL_Scanning objScan = new BL_Scanning();
                objLog = new BL_LogWriter();

                try
                {
                    if (txtFrom.Text != "" || strFromBatch != "")
                    {
                        if (txtFrom.Text == txtTo.Text)
                        {
                            DisplayMessage(true, "Both Barcode Should not be Same", "VALID");
                            txtTo.Text = "";
                            txtTo.Focus();
                            return;
                        }
                        if (strFlag == "S")
                        {
                            if (txtTo.Text.Length < 13)
                            {
                                DisplayMessage(true, "Invalid Secondary Barcode Scanned", "VALID");
                                txtTo.Text = "";
                                txtTo.Focus();
                                return;
                            }
                            else
                            {

                                string strPBarcode = txtFrom.Text.Substring(txtFrom.Text.Trim().Length - 13);
                                string strTBarcode = txtTo.Text.Substring(txtTo.Text.Trim().Length - 13);

                                string strStatus = objScan.BL_ValidateStatus(strTBarcode, "S");

                                if (strStatus.Contains("|") == true)
                                {

                                    if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                    {
                                        if (strStatus.Split('|').GetValue(1).ToString() == strFromBatch)
                                        {

                                            iRes = objScan.BL_UpdateStatus(strPBarcode, strTBarcode, "S", PL_Login.UserID.ToString());
                                            if (iRes > 0)
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtTo_KeyDown", "Success", iRes + " Secondary Barcode Validated against " + txtFrom.Text.Trim() + " - " + txtTo.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                                DisplayMessage(false, iRes + " Barcode Validated Successfully.", "VALID");
                                                ListViewItem lv = new ListViewItem(strPBarcode);
                                                lv.SubItems.Add(strTBarcode);
                                                lstVal.Items.Add(lv);
                                                txtFrom.Text = "";
                                                txtTo.Text = "";
                                                strFromBatch = "";
                                                txtFrom.Focus();
                                                return;
                                            }
                                            else
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtTo_KeyDown", "Error", "Secondary Barcode Validation not done against " + txtFrom.Text.Trim() + " - " + txtTo.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                                DisplayMessage(true, "Validation Not Done.", "VALID");
                                                txtTo.Text = "";
                                                txtTo.Focus();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            DisplayMessage(true, "Batch is not Same", "VALID");
                                            txtTo.Text = "";
                                            txtTo.Focus();
                                            return;
                                        }
                                    }
                                    else if (strStatus.Split('|').GetValue(0).ToString() == "9")
                                    {
                                        DisplayMessage(true, "Scanned Barcode is rejected", "VALID");
                                        txtTo.Text = "";
                                        txtTo.Focus();
                                        return;
                                    }
                                    else if (strStatus.Split('|').GetValue(0).ToString() == "1")
                                    {
                                        DisplayMessage(true, "Scanned Barcode is already validated", "VALID");
                                        txtTo.Text = "";
                                        txtTo.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    DisplayMessage(true, "Invalid Secondary Barcode Scanned", "VALID");
                                    txtTo.Text = "";
                                    txtTo.Focus();
                                    return;
                                }

                            }
                        }
                        else if (strFlag == "T")
                        {
                            if (txtTo.Text.Length != 20)
                            {
                                DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "VALID");
                                txtTo.Text = "";
                                txtTo.Focus();
                                return;
                            }
                            else
                            {
                                string strStatus = objScan.BL_ValidateStatus(txtTo.Text, "T");

                                if (strStatus.Contains("|") == true)
                                {

                                    if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                    {
                                        if (strStatus.Split('|').GetValue(1).ToString() == strFromBatch)
                                        {
                                            iRes = objScan.BL_UpdateStatus(txtFrom.Text.Trim(), txtTo.Text.Trim(), "T", PL_Login.UserID.ToString());
                                            if (iRes > 0)
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtTo_KeyDown", "Success", iRes + " Tertiary Barcode Validated against " + txtFrom.Text.Trim() + " - " + txtTo.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                                DisplayMessage(false, iRes + " Barcode Validated Successfully.", "VALID");
                                                ListViewItem lv = new ListViewItem(txtFrom.Text.Trim());
                                                lv.SubItems.Add(txtTo.Text.Trim());
                                                lstVal.Items.Add(lv);
                                                txtFrom.Text = "";
                                                txtTo.Text = "";
                                                strFromBatch = "";
                                                txtFrom.Focus();
                                                return;
                                            }
                                            else
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtTo_KeyDown", "Error", "Tertiary Barcode Validation not done against " + txtFrom.Text.Trim() + " - " + txtTo.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                                DisplayMessage(true, "Validation Not Done.", "VALID");
                                                txtTo.Text = "";
                                                txtTo.Focus();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            DisplayMessage(true, "Batch is not Same", "VALID");
                                            txtTo.Text = "";
                                            txtTo.Focus();
                                            return;
                                        }
                                    }
                                    else if (strStatus.Split('|').GetValue(0).ToString() == "9")
                                    {
                                        DisplayMessage(true, "Scanned Barcode is rejected", "VALID");
                                        txtTo.Text = "";
                                        txtTo.Focus();
                                        return;
                                    }
                                    else if (strStatus.Split('|').GetValue(0).ToString() == "1")
                                    {
                                        DisplayMessage(true, "Scanned Barcode is already validated", "VALID");
                                        txtTo.Text = "";
                                        txtTo.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "VALID");
                                    txtTo.Text = "";
                                    txtTo.Focus();
                                    return;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Select Type", "e-Track App.- Message");
                            return;
                        }
                    }
                    else
                    {
                        txtFrom.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    objLog.WriteErrorLog(this.Name.ToString(), "txtTo_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(),PL_Login.PlantCode);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    objScan = null;
                    objLog = null;
                }
            }
        }

        private void btnValClose_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlMain, pnlValidation);
        }

        public void SetPanelVisible(Panel pnlShow, Panel pnHide)
        {
            pnlShow.Visible = true;
            pnHide.Visible = false;
        }

        private void btnValidation_Click(object sender, EventArgs e)
        {
            cboPackLvl.SelectedIndex = 0;
            strFlag = "";
            lstVal.Items.Clear();
            txtFrom.Text = "";
            txtTo.Text = "";
            lblMessage.Text = "";
            lblMessage.BackColor = Color.DodgerBlue;
            SetPanelVisible(pnlValidation, pnlMain);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            cboRejectPack.SelectedIndex = 0;
            strFlag = "";
            lstReject.Items.Clear();
            lblReject.BackColor = Color.DodgerBlue;
            txtRejectBarcode.Text = "";
            lblReject.Text = "";
            SetPanelVisible(pnlRejection, pnlMain);
        }

        private void btnRejectClose_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlMain, pnlRejection);
        }

        private void txtRejectBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                BL_Scanning objScan = new BL_Scanning();
                objLog = new BL_LogWriter();

                try
                {

                    if (strFlag == "S")
                    {
                        if (txtRejectBarcode.Text.Length < 13)
                        {
                            DisplayMessage(true, "Invalid Secondary Barcode Scanned", "REJECT");
                            txtRejectBarcode.Text = "";
                            txtRejectBarcode.Focus();
                            return;
                        }
                        else
                        {
                            string strBarcode = txtRejectBarcode.Text.Substring(txtRejectBarcode.Text.Trim().Length - 13);

                            string strStatus = objScan.BL_UpdateReject(strBarcode, "S", PL_Login.UserID,PL_Login.PlantCode);

                            if (strStatus.Contains("|") == true)
                            {

                                if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                {
                                    //iRes = objScan.BL_UpdateStatus(txtFrom.Text.Trim(), txtTo.Text.Trim(), "S", PL_Login.UserID.ToString());

                                    objLog.WriteErrorLog(this.Name.ToString(), "txtRejectBarcode_KeyDown", "Success", strStatus.Split('|').GetValue(1).ToString() + "-" + txtRejectBarcode.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(false, "Barcode Rejected Successfully.", "REJECT");
                                    ListViewItem lv = new ListViewItem(strBarcode);
                                    lstReject.Items.Add(lv);
                                    txtRejectBarcode.Text = "";
                                    txtRejectBarcode.Focus();
                                    return;
                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtRejectBarcode_KeyDown", "Error", strStatus.Split('|').GetValue(1).ToString() + "-" + txtRejectBarcode.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString(), "REJECT");
                                    txtRejectBarcode.Text = "";
                                    txtRejectBarcode.Focus();
                                    return;
                                }



                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Secondary Barcode Scanned", "REJECT");
                                txtRejectBarcode.Text = "";
                                txtRejectBarcode.Focus();
                                return;
                            }

                        }
                    }
                    else if (strFlag == "T")
                    {
                        if (txtRejectBarcode.Text.Length != 20)
                        {
                            DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "REJECT");
                            txtRejectBarcode.Text = "";
                            txtRejectBarcode.Focus();
                            return;
                        }
                        else
                        {
                            string strStatus = objScan.BL_UpdateReject(txtRejectBarcode.Text, "T", PL_Login.UserID, PL_Login.PlantCode);

                            if (strStatus.Contains("|") == true)
                            {

                                if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                {

                                    ////iRes = objScan.BL_UpdateStatus(txtFrom.Text.Trim(), txtTo.Text.Trim(), "T", PL_Login.UserID.ToString());
                                    //if (iRes > 0)
                                    //{
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtRejectBarcode_KeyDown", "Success", strStatus.Split('|').GetValue(1).ToString() + "-" + txtRejectBarcode.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(false, "Barcode Rejected Successfully.", "REJECT");
                                    ListViewItem lv = new ListViewItem(txtRejectBarcode.Text.Trim());
                                    lstReject.Items.Add(lv);
                                    txtRejectBarcode.Text = "";
                                    txtRejectBarcode.Focus();
                                    return;
                                    //}


                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtRejectBarcode_KeyDown", "Error", strStatus.Split('|').GetValue(1).ToString() + "-" + txtRejectBarcode.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString(), "REJECT");
                                    txtRejectBarcode.Text = "";
                                    txtRejectBarcode.Focus();
                                    return;
                                }


                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "REJECT");
                                txtRejectBarcode.Text = "";
                                txtRejectBarcode.Focus();
                                return;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Type", "e-Track App.- Message");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    objLog.WriteErrorLog(this.Name.ToString(), "txtRejectBarcode_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    objScan = null;
                    objLog = null;
                }
            }
        }

        private void cboRejectPack_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboRejectPack.Text == "(Select)")
            {
                grpReject.Text = "Scan Barcode";
                strFlag = "N";
            }
            else if (cboRejectPack.Text == "Secondary Scanning")
            {
                grpReject.Text = "Scan Secondary Barcode";
                txtRejectBarcode.Focus();
                strFlag = "S";
            }
            else if (cboRejectPack.Text == "Tertiary Scanning")
            {
                grpReject.Text = "Scan Tertiary Barcode";
                txtRejectBarcode.Focus();
                strFlag = "T";
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlMapping, pnlMain);
            lblMapping.BackColor = Color.CornflowerBlue;
            ClearTer();
            cboPacking.SelectedIndex = 0;
            cboLabelType.SelectedIndex = 0;

        }

        private void txtGTINBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            objLog = new BL_LogWriter();
            objScan = new BL_Scanning();
            string strGTIN = "", strBatch = "", strExpDt = "";
            DataTable dt = new DataTable();
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGTINBarcode.Text != "")
                    {
                        if (txtGTINBarcode.Text.Trim().Length == 20)
                        {
                            DisplayMessage(true, "Invalid GTIN Barcode Scanned", "MAPPING");
                            txtGTINBarcode.Text = "";
                            txtGTINBarcode.Focus();
                            return;
                        }
                        else if (txtGTINBarcode.Text.Trim().Length < 27)
                        {
                            DisplayMessage(true, "Invalid GTIN Barcode Scanned", "MAPPING");
                            txtGTINBarcode.Text = "";
                            txtGTINBarcode.Focus();
                            return;
                        }
                        else
                        {

                            strGTIN = txtGTINBarcode.Text.Trim().Substring(2, 14).Trim();
                            strBatch = txtGTINBarcode.Text.Trim().Substring(26).Trim();
                            strExpDt = txtGTINBarcode.Text.Trim().Substring(18, 6).Trim();

                            dt = objScan.BL_GetJOBDt(strGTIN, strBatch);

                            if (dt.Rows.Count > 0)
                            {
                                lblTerBatch.Text = strBatch.Trim();
                                lblTerGTIN.Text = strGTIN.Trim();
                                lblTerPack.Text = dt.Rows[0][0].ToString();
                                DisplayMessage(false, "Barcode Scanned Successfully", "MAPPING");
                                txtTerBarcode.Text = "";
                                txtSecBarcode.Text = "";
                                txtTerBarcode.Focus();
                                return;
                            }
                            else
                            {
                                DisplayMessage(true, "Job Not Created against batch - " + strBatch, "MAPPING");
                                txtGTINBarcode.Text = "";
                                txtGTINBarcode.Focus();
                                return;
                            }


                        }
                    }
                    else
                    {
                        DisplayMessage(true, "Scan GTIN Barcode", "MAPPING");
                        txtGTINBarcode.Text = "";
                        txtGTINBarcode.Focus();
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayMessage(true, ex.Message, "MAPPING");
                objLog.WriteErrorLog(this.Name.ToString(), "txtGTINBarcode_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objLog = null; dt = null;
            }
        }

        private void txtTerBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                objLog = new BL_LogWriter();
                objScan = new BL_Scanning();
                lblTertiary.Text = "";
                lblTerCount.Text = "0";
                string strStatus = "";
                ParPackLvl = 0;
                lblTerChildlvl.Text = "";
                DataTable dt = new DataTable();
                try
                {

                    if (txtTerBarcode.Text.Trim() != "")
                    {
                        if (cboLabelType.Text == "Homogeneous")
                        {

                            if (lblTerPack.Text == "" || lblTerGTIN.Text == "" || lblTerBatch.Text == "")
                            {
                                DisplayMessage(true, "Scan GTIN Barcode", "MAPPING");
                                txtGTINBarcode.Text = "";
                                txtGTINBarcode.Focus();
                                return;
                            }
                        }

                        if (txtTerBarcode.Text.Length != 20)
                        {
                            DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "MAPPING");
                            txtTerBarcode.Text = "";
                            txtTerBarcode.Focus();
                            return;
                        }
                        if (cboLabelType.Text == "Homogeneous")
                        {
                            strStatus = objScan.BL_ManualMapping(5, cboPacking.Text, "P", lblTerGTIN.Text, lblTerBatch.Text, Convert.ToInt32(lblTerPack.Text), txtTerBarcode.Text.Trim(), "", PL_Login.UserID.ToString(), "0", cboLabelType.Text);
                        }
                        else
                        {
                            strStatus = objScan.BL_ManualMapping(5, cboPacking.Text, "P", lblTerGTIN.Text, lblTerBatch.Text, 0, txtTerBarcode.Text.Trim(), "", PL_Login.UserID.ToString(), "0", cboLabelType.Text);
                        }
                        if (strStatus.Contains('@') == true)
                        {
                            if (strStatus.Split('@').GetValue(0).ToString() == "0")
                            {
                                ParPackLvl = 5;
                                DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                objLog.WriteErrorLog(this.Name.ToString(), "txtTerBarcode_KeyDown", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                dt = objScan.BL_GetChildBarcode(txtTerBarcode.Text.Trim());
                                lstMapping.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        ListViewItem lv = new ListViewItem(dt.Rows[i][0].ToString());
                                        lv.SubItems.Add(dt.Rows[i][1].ToString());
                                        lstMapping.Items.Add(lv);
                                    }
                                }
                                lblTerCount.Text = dt.Rows.Count.ToString();
                                lblTertiary.Text = "Tertiary";
                                txtSecBarcode.Text = "";
                                txtSecBarcode.Focus();
                                return;
                            }
                            else
                            {
                                objLog.WriteErrorLog(this.Name.ToString(), "txtTerBarcode_KeyDown", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                txtTerBarcode.Text = "";
                                txtTerBarcode.Focus();
                                return;
                            }
                        }
                        else
                        {
                            DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "MAPPING");
                            txtTerBarcode.Text = "";
                            txtTerBarcode.Focus();
                            return;
                        }


                    }
                    else
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtTerBarcode.Text = "";
                        txtTerBarcode.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    DisplayMessage(true, ex.Message, "MAPPING");
                    objLog.WriteErrorLog(this.Name.ToString(), "txtTerBarcode_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                }
                finally
                {
                    objLog = null; dt = null; objScan = null;
                }
            }
        }

        public void SetPackLevel(Label lbl, string strSecBarcode, string strFlag)
        {
            string strpck = "";
            string strlvl = "";



            strpck = strSecBarcode.Substring(strSecBarcode.Trim().Length - 13);
            strlvl = strpck.Substring(0, 1);
            if (strlvl == "C")
            {
                if (strFlag == "P")
                {
                    ParPackLvl = 1;
                }
                else
                {
                    ChildPackLvl = 1;
                }
                lbl.Text = "Secondary 1 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "D")
            {
                if (strFlag == "P")
                {
                    ParPackLvl = 2;
                }
                else
                {
                    ChildPackLvl = 2;
                }
                lbl.Text = "Secondary 2 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "E")
            {
                if (strFlag == "P")
                {
                    ParPackLvl = 3;
                }
                else
                {
                    ChildPackLvl = 3;
                }
                lbl.Text = "Secondary 3 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "F")
            {
                if (strFlag == "P")
                {
                    ParPackLvl = 4;
                }
                else
                {
                    ChildPackLvl = 4;
                }
                lbl.Text = "Secondary 4 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "G")
            {
                if (strFlag == "P")
                {
                    ParPackLvl = 5;
                }
                else
                {
                    ChildPackLvl = 5;
                }
                lbl.Text = "Tertiary Level";
                lbl.Visible = true;
            }

        }

        public void SetPackLevelOld(Label lbl, string strSecBarcode, int iLevel)
        {
            string strpck = "";
            string strlvl = "";

            strpck = strSecBarcode.Substring(strSecBarcode.Trim().Length - 13);
            strlvl = strpck.Substring(0, 1);
            if (strlvl == "C")
            {
                iLevel = 1;
                lbl.Text = "Secondary 1 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "D")
            {
                iLevel = 2;
                lbl.Text = "Secondary 2 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "E")
            {
                iLevel = 3;
                lbl.Text = "Secondary 3 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "F")
            {
                iLevel = 4;
                lbl.Text = "Secondary 4 Level";
                lbl.Visible = true;
            }
            else if (strlvl == "G")
            {
                iLevel = 5;
                lbl.Text = "Tertiary Level";
                lbl.Visible = true;
            }

        }

        private void txtSecBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                objLog = new BL_LogWriter();
                string strStatus = "";
                objScan = new BL_Scanning();
                lblTerChildlvl.Text = "";
                string strBarcode = "";
                //DataTable dt = new DataTable();
                try
                {
                    if (txtTerBarcode.Text != "")
                    {
                        if (txtSecBarcode.Text == "")
                        {
                            DisplayMessage(true, "Scan Child Barcode", "MAPPING");
                            txtTerBarcode.Text = "";
                            txtTerBarcode.Focus();
                            return;
                        }
                        if (txtSecBarcode.Text.StartsWith("00") == true)
                        {
                            lblTerChildlvl.Text = "Tertiary Level";
                            ChildPackLvl = 5;

                            if (ParPackLvl <= ChildPackLvl)
                            {
                                DisplayMessage(true, "Cannot Pack the Material (Parent Child level MisMatch)", "MAPPING");
                                txtSecBarcode.Text = "";
                                txtSecBarcode.Focus();
                                return;
                            }
                        }



                        SetPackLevel(lblTerChildlvl, txtSecBarcode.Text.Trim(), "C");
                        strBarcode = txtSecBarcode.Text.Substring(txtSecBarcode.Text.Trim().Length - 13);


                        if (ParPackLvl < ChildPackLvl)
                        {
                            DisplayMessage(true, "Cannot Pack the Material (Parent Child level MisMatch)", "MAPPING");
                            txtSecBarcode.Text = "";
                            txtSecBarcode.Focus();
                            lblTerChildlvl.Text = "";
                            return;
                        }
                        else
                        {
                            if (cboLabelType.Text == "Homogeneous")
                            {
                                strStatus = objScan.BL_ManualMapping(ParPackLvl, cboPacking.Text, "C", lblTerGTIN.Text, lblTerBatch.Text, Convert.ToInt32(lblTerPack.Text), txtTerBarcode.Text.Trim(), strBarcode, PL_Login.UserID.ToString(), "0", cboLabelType.Text);
                            }
                            else
                            {
                                strStatus = objScan.BL_ManualMapping(ParPackLvl, cboPacking.Text, "C", lblTerGTIN.Text, lblTerBatch.Text, 0, txtTerBarcode.Text.Trim(), strBarcode, PL_Login.UserID.ToString(), "0", cboLabelType.Text);
                            }
                            if (strStatus.Contains('@') == true)
                            {
                                if (strStatus.Split('@').GetValue(0).ToString() == "0")
                                {
                                    if (cboLabelType.SelectedIndex == 0)
                                    {

                                        if (Convert.ToInt32(lblTerPack.Text) == Convert.ToInt32(lblTerCount.Text) + 1)
                                        {

                                            if (objScan.BL_linkServerMapping() == "1")
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Success", "Link-Server Mapping Completed against -" + txtSecBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                            }
                                            else
                                            {
                                                objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Success", "Mapping Completed against -" + txtSecBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                            }

                                            //objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Success", " Mapping Completed against -" + txtSecBarcode.Text, "PC Client", PL_Login.UserID.ToString());
                                            DisplayMessage(false, "Mapping Completed against -" + txtTerBarcode.Text.Trim(), "MAPPING");
                                            lstMapping.Items.Clear();
                                            lblTerCount.Text = "0";
                                            ParPackLvl = 0; ChildPackLvl = 0;
                                            txtSecBarcode.Text = "";
                                            lblTerChildlvl.Text = "";
                                            lblTertiary.Text = "";
                                            txtTerBarcode.Text = "";
                                            txtTerBarcode.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                            DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                            ListViewItem lv = new ListViewItem(txtTerBarcode.Text.Trim());
                                            lv.SubItems.Add(strBarcode);
                                            lstMapping.Items.Add(lv);
                                            lblTerCount.Text = lstMapping.Items.Count.ToString();
                                            txtSecBarcode.Text = "";
                                            txtSecBarcode.Focus();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                        ListViewItem lv = new ListViewItem(txtTerBarcode.Text.Trim());
                                        lv.SubItems.Add(strBarcode);
                                        lstMapping.Items.Add(lv);
                                        lblTerCount.Text = lstMapping.Items.Count.ToString();
                                        txtSecBarcode.Text = "";
                                        txtSecBarcode.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecBarcode.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                    txtSecBarcode.Text = "";
                                    txtSecBarcode.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Child Barcode Scanned", "MAPPING");
                                txtSecBarcode.Text = "";
                                txtSecBarcode.Focus();
                                lblTerChildlvl.Text = "";
                                return;
                            }

                        }

                    }
                    else
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtTerBarcode.Text = "";
                        txtTerBarcode.Focus();
                        return;
                    }

                }
                catch (Exception ex)
                {
                    DisplayMessage(true, ex.Message, "MAPPING");
                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                }
                finally
                {
                    objLog = null;
                }

            }
        }

        public void ClearTer()
        {
            ParPackLvl = 0;
            ChildPackLvl = 0;
            txtTerBarcode.Text = "";
            lblTerChildlvl.Text = "";
            lblTerChildlvl.Text = "";
            lblTerPack.Text = "";
            lblTerCount.Text = "0";
            txtGTINBarcode.Text = "";
            txtSecBarcode.Text = "";
            lblTerGTIN.Text = "";
            lblTerBatch.Text = "";
            lstMapping.Items.Clear();
            pnlMap.BackColor = Color.CornflowerBlue;
            lblMapping.Text = "";
            txtGTINBarcode.Focus();
            return;
        }

        public void ClearSec()
        {
            ParPackLvl = 0;
            ChildPackLvl = 0;
            txtSecParent.Text = "";
            txtSecChild.Text = "";
            lblSecGTIN.Text = "";
            lblSecBatch.Text = "";
            lblSecPack.Text = "";
            lblSecParentLvl.Text = "";
            lblSecChildLvl.Text = "";
            lstMapping.Items.Clear();
            lblMapping.Text = "";
            lblSecCount.Text = "0";
            pnlMap.BackColor = Color.CornflowerBlue;
            txtSecParent.Focus();
            return;
        }

        private void cboPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPacking.SelectedIndex == 0)
            {
                grpTertiary.Visible = true;
                grpSec.Visible = false;
                cboLabelType.SelectedIndex = 0;
                cboLabelType.Enabled = true;
                ClearTer();

            }
            else
            {
                grpTertiary.Visible = false;
                cboLabelType.Enabled = false;
                grpSec.Visible = true;
                ClearSec();
            }
        }

        private void txtSecParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                objLog = new BL_LogWriter();
                objScan = new BL_Scanning();
                lblSecParentLvl.Text = "";
                lblSecCount.Text = "0";
                string strBarcode = "";
                string strGTIN = "", strBatch = "";
                ParPackLvl = 0;
                lblSecChildLvl.Text = "";
                DataTable dt = new DataTable();
                DataTable dtBarcode = new DataTable();
                try
                {
                    if (txtSecParent.Text != "")
                    {
                        if (txtSecParent.Text.Length < 13 || txtSecParent.Text.StartsWith("00") == true)
                        {
                            DisplayMessage(true, "Invalid Parent Barcode Scanned", "MAPPING");
                            txtSecParent.Text = "";
                            txtSecParent.Focus();
                            return;
                        }


                        strBarcode = txtSecParent.Text.Substring(txtSecParent.Text.Trim().Length - 13);
                        strGTIN = txtSecParent.Text.Substring(2, 14);
                        strBatch = txtSecParent.Text.Substring(26);
                        strBatch = strBatch.Substring(0, strBatch.Length - 15);

                        dt = objScan.BL_GetJOBDt(strGTIN, strBatch);
                        if (dt.Rows.Count > 0)
                        {

                            string strStatus = objScan.BL_ManualMapping(ParPackLvl, cboPacking.Text, "P", strGTIN, strBatch, Convert.ToInt32(dt.Rows[0][0].ToString()), strBarcode, "", PL_Login.UserID.ToString(), "0", cboLabelType.Text);

                            if (strStatus.Contains('@') == true)
                            {
                                if (strStatus.Split('@').GetValue(0).ToString() == "0")
                                {
                                    lblSecGTIN.Text = strGTIN;
                                    lblSecBatch.Text = strBatch;
                                    lblSecPack.Text = dt.Rows[0][0].ToString();

                                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecParent_KeyDown", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                    dtBarcode = objScan.BL_GetChildBarcode(strBarcode);
                                    lstMapping.Items.Clear();
                                    if (dtBarcode.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtBarcode.Rows.Count; i++)
                                        {
                                            ListViewItem lv = new ListViewItem(dtBarcode.Rows[i][0].ToString());
                                            lv.SubItems.Add(dtBarcode.Rows[i][1].ToString());
                                            lstMapping.Items.Add(lv);
                                        }
                                    }
                                    lblSecCount.Text = dtBarcode.Rows.Count.ToString();
                                    SetPackLevel(lblSecParentLvl, txtSecParent.Text.Trim(), "P");
                                    txtSecChild.Text = "";
                                    txtSecChild.Focus();
                                    return;

                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecParent_KeyDown", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                    txtSecParent.Text = "";
                                    txtSecParent.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Parent Barcode Scanned", "MAPPING");
                                txtSecParent.Text = "";
                                txtSecParent.Focus();
                                return;
                            }

                        }
                        else
                        {
                            DisplayMessage(true, "Job Not Created against batch - " + strBatch, "MAPPING");
                            txtSecParent.Text = "";
                            txtSecParent.Focus();
                            return;
                        }

                    }
                    else
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtSecParent.Text = "";
                        txtSecParent.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    DisplayMessage(true, ex.Message, "MAPPING");
                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecParent_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                }
                finally
                {
                    objLog = null; dt = null; objScan = null;
                }
            }

        }

        private void txtSecChild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                objLog = new BL_LogWriter();
                objScan = new BL_Scanning();
                lblSecChildLvl.Text = "";


                string strPBarcode = "", strCBarcode = "";
                string strGTIN = "", strBatch = "";
                try
                {
                    if (lblSecBatch.Text == "" || lblSecGTIN.Text == "" || lblSecPack.Text == "")
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtSecParent.Text = "";
                        txtSecParent.Focus();
                        return;
                    }
                    if (txtSecChild.Text.Length < 13 || txtSecChild.Text.StartsWith("00") == true)
                    {
                        DisplayMessage(true, "Invalid Child Barcode Scanned", "MAPPING");
                        txtSecChild.Text = "";
                        txtSecChild.Focus();
                        return;
                    }

                    strPBarcode = txtSecParent.Text.Substring(txtSecParent.Text.Trim().Length - 13);
                    strCBarcode = txtSecChild.Text.Substring(txtSecChild.Text.Trim().Length - 13);

                    SetPackLevel(lblSecChildLvl, txtSecChild.Text, "C");

                    if (ParPackLvl <= ChildPackLvl)
                    {
                        DisplayMessage(true, "Cannot Pack the Material (Parent Child level MisMatch)", "MAPPING");
                        txtSecChild.Text = "";
                        txtSecChild.Focus();
                        return;
                    }

                    string strStatus = objScan.BL_ManualMapping(ParPackLvl, cboPacking.Text, "C", lblSecGTIN.Text, lblSecBatch.Text, Convert.ToInt32(lblSecPack.Text), strPBarcode, strCBarcode, PL_Login.UserID.ToString(), "0", cboLabelType.Text);
                    if (strStatus.Contains('@') == true)
                    {
                        if (strStatus.Split('@').GetValue(0).ToString() == "0")
                        {
                            if (Convert.ToInt32(lblSecPack.Text) == Convert.ToInt32(lblSecCount.Text) + 1)
                            {
                                if (objScan.BL_linkServerMapping() == "1")
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecChild_KeyDown", "Success", "Link-Server Mapping Completed against -" + txtSecChild.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecChild_KeyDown", "Success", "Mapping Completed against -" + txtSecChild.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                }
                                DisplayMessage(false, "Mapping Completed against -" + txtSecParent.Text.Trim(), "MAPPING");
                                lstMapping.Items.Clear();
                                lblTerCount.Text = "0";
                                ParPackLvl = 0; ChildPackLvl = 0;
                                txtSecChild.Text = "";
                                lblSecChildLvl.Text = "";
                                lblSecParentLvl.Text = "";
                                txtSecParent.Text = "";
                                txtSecParent.Focus();
                                return;
                            }
                            else
                            {
                                objLog.WriteErrorLog(this.Name.ToString(), "txtSecChild_KeyDown", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecChild.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                ListViewItem lv = new ListViewItem(strPBarcode);
                                lv.SubItems.Add(strCBarcode);
                                lstMapping.Items.Add(lv);
                                lblTerCount.Text = lstMapping.Items.Count.ToString();
                                txtSecChild.Text = "";
                                txtSecChild.Focus();
                                return;
                            }
                        }
                        else
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "txtSecBarcode_KeyDown", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecChild.Text.Trim(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                            DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                            txtSecChild.Text = "";
                            txtSecChild.Focus();
                            return;
                        }
                    }
                    else
                    {
                        DisplayMessage(true, "Invalid Child Barcode Scanned", "MAPPING");
                        txtSecChild.Text = "";
                        txtSecChild.Focus();
                        lblSecChildLvl.Text = "";
                        return;
                    }

                }
                catch (Exception ex)
                {
                    DisplayMessage(true, ex.Message, "MAPPING");
                    objLog.WriteErrorLog(this.Name.ToString(), "txtSecChild_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                }
                finally
                {
                    objLog = null; objScan = null;
                }
            }
        }

        private void btnPartial_Click(object sender, EventArgs e)
        {
            objLog = new BL_LogWriter();
            objScan = new BL_Scanning();
            lblTerChildlvl.Text = "";
            string strStatus = "";
            DataTable dt = new DataTable();
            string strBarcode = "";
            string strGTIN = "", strBatch = "";
            try
            {


                if (cboPacking.SelectedIndex == 0)
                {
                    if (txtTerBarcode.Text.Trim() != "")
                    {
                        if (cboLabelType.SelectedIndex == 0)
                        {
                            if (lblTerPack.Text == "" || lblTerGTIN.Text == "" || lblTerBatch.Text == "")
                            {
                                DisplayMessage(true, "Scan GTIN Barcode", "MAPPING");
                                txtGTINBarcode.Text = "";
                                txtGTINBarcode.Focus();
                                return;
                            }
                        }

                        if (txtTerBarcode.Text.Length != 20)
                        {
                            DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "MAPPING");
                            txtTerBarcode.Text = "";
                            txtTerBarcode.Focus();
                            return;
                        }

                        //

                        DialogResult ds = MessageBox.Show("Do you really want to Complete the Transaction", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (DialogResult.Yes == ds)
                        {
                            if (cboLabelType.SelectedIndex == 0)
                            {
                                strStatus = objScan.BL_ManualMapping(5, cboPacking.Text, "P", lblTerGTIN.Text, lblTerBatch.Text, Convert.ToInt32(lblTerPack.Text), txtTerBarcode.Text.Trim(), "", PL_Login.UserID.ToString(), "1", cboLabelType.Text);
                            }
                            else
                            {
                                strStatus = objScan.BL_ManualMapping(5, cboPacking.Text, "P", "", "", 0, txtTerBarcode.Text.Trim(), "", PL_Login.UserID.ToString(), "1", cboLabelType.Text);
                            }
                            if (strStatus.Contains('@') == true)
                            {
                                if (strStatus.Split('@').GetValue(0).ToString() == "0")
                                {

                                    if (objScan.BL_linkServerMapping() == "1")
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", "Link-Server/" + strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    }
                                    else
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    }

                                    DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                    //objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString());
                                    ClearTer();
                                    txtTerBarcode.Focus();
                                    return;
                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtTerBarcode.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                    txtTerBarcode.Text = "";
                                    txtTerBarcode.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                DisplayMessage(true, "Invalid Tertiary Barcode Scanned", "MAPPING");
                                txtTerBarcode.Text = "";
                                txtTerBarcode.Focus();
                                return;
                            }
                        }
                        //
                    }
                    else
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtTerBarcode.Text = "";
                        txtTerBarcode.Focus();
                        return;
                    }
                }
                else if (cboPacking.SelectedIndex == 1)
                {
                    if (txtSecParent.Text != "")
                    {
                        if (txtSecParent.Text.Length < 13 || txtSecParent.Text.StartsWith("00") == true)
                        {
                            DisplayMessage(true, "Invalid Parent Barcode Scanned", "MAPPING");
                            txtSecParent.Text = "";
                            txtSecParent.Focus();
                            return;
                        }


                        strBarcode = txtSecParent.Text.Substring(txtSecParent.Text.Trim().Length - 13);
                        strGTIN = txtSecParent.Text.Substring(2, 14);
                        strBatch = txtSecParent.Text.Substring(26);
                        strBatch = strBatch.Substring(0, strBatch.Length - 15);

                        dt = objScan.BL_GetJOBDt(strGTIN, strBatch);
                        if (dt.Rows.Count > 0)
                        {
                            DialogResult ds = MessageBox.Show("Do you really want to Complete the Transaction", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (DialogResult.Yes == ds)
                            {

                                strStatus = objScan.BL_ManualMapping(ParPackLvl, cboPacking.Text, "P", strGTIN, strBatch, Convert.ToInt32(dt.Rows[0][0].ToString()), strBarcode, "", PL_Login.UserID.ToString(), "1", cboLabelType.Text);

                                if (strStatus.Contains('@') == true)
                                {
                                    if (strStatus.Split('@').GetValue(0).ToString() == "0")
                                    {

                                        if (objScan.BL_linkServerMapping() == "1")
                                        {
                                            objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", "Link-Server/" + strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        }
                                        else
                                        {
                                            objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        }

                                        //objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Success", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString());
                                        DisplayMessage(false, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                        ClearSec();
                                        return;

                                    }
                                    else
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Error", strStatus.Split('@').GetValue(1).ToString() + "-" + txtSecParent.Text, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        DisplayMessage(true, strStatus.Split('@').GetValue(1).ToString(), "MAPPING");
                                        txtSecParent.Text = "";
                                        txtSecParent.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    DisplayMessage(true, "Invalid Parent Barcode Scanned", "MAPPING");
                                    txtSecParent.Text = "";
                                    txtSecParent.Focus();
                                    return;
                                }
                            }
                            //
                        }
                        else
                        {
                            DisplayMessage(true, "Job Not Created against batch - " + strBatch, "MAPPING");
                            txtSecParent.Text = "";
                            txtSecParent.Focus();
                            return;
                        }
                    }
                    else
                    {
                        DisplayMessage(true, "Scan Parent Barcode", "MAPPING");
                        txtSecParent.Text = "";
                        txtSecParent.Focus();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                DisplayMessage(true, ex.Message, "MAPPING");
                objLog.WriteErrorLog(this.Name.ToString(), "btnPartial_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objLog = null; objScan = null;
            }

        }

        private void btnMapClose_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlMain, pnlMapping);
        }

        private void cboLabelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLabelType.SelectedIndex == 1)
            {
                grpGTIN.Enabled = false;
                ClearTer();
                txtTerBarcode.Focus();
                btnPartial.Text = "Complete";
            }
            else
            {
                grpGTIN.Enabled = true;
                ClearTer();
                txtGTINBarcode.Focus();
                btnPartial.Text = "Partial Pack";
            }
        }

        public void LoadLocation()
        {
            DataSet ds = new DataSet();
            BL_Upload objUpload = new BL_Upload();
            try
            {
                ds = objUpload.BLGetMasterDt("");
                cboSource.Items.Clear();
                cboConsgne.Items.Clear();
                cboDestination.Items.Clear();
                cboSource.Items.Add("Select");
                cboDestination.Items.Add("Select");
                cboConsgne.Items.Add("Select");

                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        cboSource.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                        cboDestination.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                    }

                    if (cboSource.Items.Contains(PL_Login.PlantCode.ToString()) == true)
                    {
                        cboSource.SelectedText = PL_Login.PlantCode.ToString();
                    }
                    else
                    {
                        cboSource.SelectedIndex = 0;
                    }

                    cboDestination.SelectedIndex = 0;


                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        cboConsgne.Items.Add(ds.Tables[2].Rows[i][0].ToString());
                    }
                    cboConsgne.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "LoadLocation", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                ds = null; objUpload = null;
            }
        }

        private void SetVisible(string sProcess)
        {
            if (sProcess == "IN")
            {
                grpProcess.Text = "Inward Details";
                lblCons.Visible = false;
                lblDoc.Visible = false;
                txtDocNo.Visible = false;
                cboConsgne.Visible = false;
                lblProcess.Text = "Inward Scanning";
                LoadLocation();
                lstInOut.Columns.Clear();
                lstInOut.Items.Clear();

                DisplayMessage(false, "", "INOUT");

                lstInOut.Columns.Add("Source");
                lstInOut.Columns.Add("Destination");
                lstInOut.Columns.Add("Barcode");

                for (int i = 0; i < 3; i++)
                {
                    lstInOut.Columns[i].Width = 200;
                }
            }
            else
            {
                grpProcess.Text = "Outward Details";
                lblCons.Visible = true;
                lblDoc.Visible = true;
                txtDocNo.Visible = true;
                cboConsgne.Visible = true;
                lblProcess.Text = "Outward Scanning";
                LoadLocation();

                DisplayMessage(false, "", "INOUT");

                lstInOut.Columns.Clear();
                lstInOut.Items.Clear();
                lstInOut.Columns.Add("Source");
                lstInOut.Columns.Add("Destination");
                lstInOut.Columns.Add("Barcode");
                lstInOut.Columns.Add("Consignee");
                lstInOut.Columns.Add("Document No.");

                for (int i = 0; i < 5; i++)
                {
                    lstInOut.Columns[i].Width = 200;
                }
            }
        }

        private void txtInOutBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            objLog = new BL_LogWriter();
            string strStatus = "";
            objScan = new BL_Scanning();
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtInOutBarcode.Text == "")
                    {
                        DisplayMessage(true, "Scan Tertiary Barcode", "INOUT");
                        txtInOutBarcode.Text = "";
                        txtInOutBarcode.Focus();
                        return;
                    }

                    if (txtInOutBarcode.Text.Length != 20)
                    {
                        DisplayMessage(true, "Invaild Barcode Scan", "INOUT");
                        txtInOutBarcode.Text = "";
                        txtInOutBarcode.Focus();
                        return;
                    }

                    if (cboSource.Text.Trim() == "Select")
                    {
                        DisplayMessage(true, "Select Source Location", "INOUT");
                        return;
                    }


                    if (cboSource.Text.Trim() == cboDestination.Text.Trim())
                    {
                        DisplayMessage(true, "Source And Destination Location Cannot Be Same", "INOUT");
                        cboDestination.Focus();
                        return;
                    }

                    if (strProcess == "IN")
                    {
                        if (cboDestination.Text.Trim() == "Select")
                        {
                            DisplayMessage(true, "Select Destination Location", "INOUT");
                            return;
                        }

                        strStatus = objScan.BL_InOutBarcode("IN", txtInOutBarcode.Text.Trim(), cboSource.Text.Trim(), cboDestination.Text.Trim(), "", "", PL_Login.UserID.ToString());

                        if (strStatus.Contains("|") == true)
                        {
                            if (strStatus.Split('|').GetValue(0).ToString() == "0")
                            {
                                DisplayMessage(false, strStatus.Split('|').GetValue(1).ToString(), "INOUT");
                                fillList("IN");
                                txtInOutBarcode.Text = "";
                                txtInOutBarcode.Focus();
                            }
                            else
                            {
                                DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString(), "INOUT");
                                txtInOutBarcode.Text = "";
                                txtInOutBarcode.Focus();
                            }
                        }
                        else
                        {
                            DisplayMessage(true, "Transaction Not Done", "INOUT");
                            txtInOutBarcode.Text = "";
                            txtInOutBarcode.Focus();
                        }
                    }
                    else
                    {
                        if (cboDestination.Text == "Select" && cboConsgne.Text.Trim() == "Select")
                        {
                            DisplayMessage(true, "Select Destination /Consignee name for Outward Process", "INOUT");
                            return;
                        }

                        if (cboConsgne.Text != "Select")
                        {
                            if (txtDocNo.Text == "")
                            {
                                DisplayMessage(true, "Document No can't be left blank", "INOUT");
                                txtDocNo.Focus();
                                return;
                            }
                        }

                        strStatus = objScan.BL_InOutBarcode("OUT", txtInOutBarcode.Text.Trim(), cboSource.Text.Trim(), (cboDestination.Text.Trim() == "Select" ? "" : cboDestination.Text), (cboConsgne.Text.Trim() == "Select" ? "" : cboConsgne.Text.Trim()), txtDocNo.Text.Trim(), PL_Login.UserID.ToString());

                        if (strStatus.Contains("|") == true)
                        {
                            if (strStatus.Split('|').GetValue(0).ToString() == "0")
                            {
                                DisplayMessage(false, strStatus.Split('|').GetValue(1).ToString(), "INOUT");
                                fillList("OUT");
                                txtInOutBarcode.Text = "";
                                txtInOutBarcode.Focus();
                            }
                            else
                            {
                                DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString(), "INOUT");
                                txtInOutBarcode.Text = "";
                                txtInOutBarcode.Focus();
                            }
                        }
                        else
                        {
                            DisplayMessage(true, "Transaction Not Done", "INOUT");
                            txtInOutBarcode.Text = "";
                            txtInOutBarcode.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(true, ex.Message, "MAPPING");
                objLog.WriteErrorLog(this.Name.ToString(), "txtInOutBarcode_KeyDown", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objLog = null;
                objScan = null;
            }
        }

        public void fillList(string sProcess)
        {
            if (sProcess == "IN")
            {
                ListViewItem lv = new ListViewItem(cboSource.Text.Trim());
                lv.SubItems.Add(cboDestination.Text.Trim());
                lv.SubItems.Add(txtInOutBarcode.Text.Trim());
                lstInOut.Items.Add(lv);
            }
            else
            {
                ListViewItem lv = new ListViewItem(cboSource.Text.Trim());
                lv.SubItems.Add((cboDestination.Text.Trim() == "Select") ? "" : cboDestination.Text.Trim());
                lv.SubItems.Add(txtInOutBarcode.Text.Trim());
                lv.SubItems.Add((cboConsgne.Text.Trim() == "Select") ? "" : cboConsgne.Text.Trim());
                lv.SubItems.Add(txtDocNo.Text.Trim());
                lstInOut.Items.Add(lv);
            }
        }

        private void btnInOutClose_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlMain, pnlInOut);
        }

        private void btnInward_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlInOut, pnlMain);
            strProcess = "IN";
            SetVisible(strProcess);
        }

        private void btnOutward_Click(object sender, EventArgs e)
        {
            SetPanelVisible(pnlInOut, pnlMain);
            txtDocNo.Text = "";
            strProcess = "OUT";
            SetVisible(strProcess);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cboDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDestination.Text != "Select")
            {
                txtInOutBarcode.Focus();
            }
        }

        private void lstMapping_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTerBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSecBarcode_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
