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
using DataLayer;
using System.IO;

namespace PC_Application.Transaction
{
    public partial class frmJobCreate : Form
    {
        BL_LogWriter objLog;
        PL_Printing objPL_Prnt;
        BL_Printing objBL_Prnt;
        public frmJobCreate()
        {
            InitializeComponent();
        }

        private void frmJobCreate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            DataTable dtPack = new DataTable();
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            string str = "";
            string strPlant = "";
            string[] strPlantCode;
            lstView.Items.Clear();
            lblLabel.Text = "";
            try
            {


                if (!Directory.Exists(Application.StartupPath + "\\Upload"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Upload");
                }

                objBL_Prnt = new BL_Printing();

                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");



                str = objBL_Prnt.BLGetPlantLogin(PL_Login.UserID);

                cboPlant.Items.Clear();
                cboPlant.Items.Add("Select");
                if (str != "")
                {

                    strPlantCode = str.Split(',');
                    for (int i = 0; i < strPlantCode.Count(); i++)
                    {
                        cboPlant.Items.Add(strPlantCode[i].ToString());
                        if (i == 0)
                        {
                            strPlant = strPlantCode[i].ToString();
                        }
                        else
                        {
                            strPlant = strPlant + "','" + strPlantCode[i].ToString();
                        }

                    }

                    //if (PL_Login.PlantCode == "MultiPlant" || PL_Login.PlantCode == "All Plant")
                    //{
                    //    cboPlant.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    cboPlant.SelectedIndex = 1;
                    //}

                    if (cboPlant.Items.Count == 2)
                    {
                        cboPlant.SelectedIndex = 1;
                    }
                    else
                    {
                        cboPlant.SelectedIndex = 0;
                    }
                }


                dtPack = objGen.BLGetPackLevel();
                cboPacking.Items.Clear();
                cboPacking.Items.Add("Select");
                if (dtPack.Rows.Count > 0)
                {

                    for (int i = 0; i < dtPack.Rows.Count; i++)
                    {
                        cboPacking.Items.Add(dtPack.Rows[i]["PACKING_LEVEL"].ToString());
                    }

                }
                cboPacking.SelectedIndex = 0;

                if (strPlant != "")
                {
                    objBL_Prnt = new BL_Printing();
                    dt = objBL_Prnt.BL_GetJobs(strPlant, "");
                }


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i][0].ToString());
                        lv.SubItems.Add(dt.Rows[i][1].ToString());
                        lv.SubItems.Add(dt.Rows[i][2].ToString());
                        lv.SubItems.Add(dt.Rows[i][3].ToString());
                        lv.SubItems.Add(dt.Rows[i][4].ToString());
                        lv.SubItems.Add(dt.Rows[i][5].ToString());
                        lv.SubItems.Add(dt.Rows[i][6].ToString());
                        lv.SubItems.Add(dt.Rows[i][7].ToString());
                        lstView.Items.Add(lv);
                    }
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmJobCreate_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dtPack = null;
                objBL_Prnt = null;
                objLog = null;
            }
        }

        //private void cboPlant_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    objPL_Prnt = new PL_Printing();
        //    objBL_Prnt = new BL_Printing();
        //    DataTable dt = new DataTable();
        //    BL_LogWriter objLog = new BL_LogWriter();
        //    try
        //    {
        //        if (cboPlant.Text != "Select")
        //        {
        //            objPL_Prnt.strPlantCode = cboPlant.Text;
        //            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
        //            Clear();
        //            dt = objBL_Prnt.BL_GetLine(objPL_Prnt);
        //            cboPacking.Items.Clear();
        //            cboPacking.Items.Add("Select");
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    cboPacking.Items.Add(dt.Rows[i][0].ToString());
        //                }
        //            }
        //        }
        //        else
        //        {
        //            cboPacking.Items.Clear();
        //            cboPacking.Items.Add("Select");
        //        }

        //        cboPacking.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        objLog.WriteErrorLog(this.Name.ToString(), "cboPlant_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID);
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        objLog = null;
        //        objPL_Prnt = null;
        //        objBL_Prnt = null;
        //        dt = null;
        //    }
        //}

        public void fillCombo(string strPackLevel, string strLine, string strValue, ComboBox SelctCombo, ComboBox fillCombo, string strGTIN)
        {
            DataTable dt = new DataTable();
            BL_Generator objGen = new BL_Generator();
            PL_Generator objPLGen = new PL_Generator();
            bool iCount = false;
            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

            try
            {
                objPLGen.strPackLevel = strPackLevel;
                objPLGen.strLableType = "";
                objPLGen.strLineNo = strLine;
                objPLGen.strGTIN = strGTIN;
                objPLGen.strFieldCriteria = SelctCombo.Name.ToString();
                objPLGen.strFieldValue = strValue;

                if (SelctCombo.Name == cboPacking.Name.ToString())
                {

                    fillCombo.Items.Clear();
                    fillCombo.Items.Add("Select");


                    if (fillCombo.Name == cboLine.Name.ToString())
                    {
                        DataSet dsLine = new DataSet();

                        dsLine = objGen.BLGetLineInfo(objPLGen, cboPlant.Text.Trim());
                        for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                        {
                            fillCombo.Items.Add(dsLine.Tables[0].Rows[i][0].ToString());
                        }
                        dsLine = null;
                        fillCombo.SelectedIndex = 0;

                    }
                    else
                    {
                        dt = objGen.BLfillComboData(objPLGen, fillCombo.Name.ToString());

                        if (dt.Rows.Count > 0)
                        {
                            iCount = true;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            fillCombo.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                }
                else if (SelctCombo.Name == cboLine.Name.ToString())
                {
                    dt = objGen.BLfillComboData(objPLGen, fillCombo.Name.ToString());

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            fillCombo.SelectedItem = dt.Rows[0][0].ToString();
                        }
                        catch { }
                    }
                    else
                    {
                        fillCombo.SelectedIndex = 0;
                    }

                }
                else
                {
                    dt = objGen.BLfillComboData(objPLGen, fillCombo.Name.ToString());

                    fillCombo.Items.Clear();
                    fillCombo.Items.Add("Select");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            fillCombo.Items.Add(dt.Rows[i][0].ToString());
                        }
                        fillCombo.SelectedIndex = 1;
                    }
                    else
                    {
                        fillCombo.SelectedIndex = 0;
                    }


                }




            }
            catch (Exception ex)
            {

            }
            finally
            {
                objGen = null; objPLGen = null; dt = null;
            }

        }

        private void cboPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
            DataSet ds = new DataSet();
            try
            {
                if (cboPacking.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPacking.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                    ds = objBL_Prnt.BL_GetPrntLineNo(objPL_Prnt);
                    cboLine.Items.Clear();
                    cboLine.Items.Add("Select");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            cboLine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                    }

                    fillCombo(cboPacking.Text.Trim(), (cboLine.Text == "Select" ? "" : cboLine.Text), cboPacking.Text.Trim(), cboPacking, cboProduct, (cboGTIN.Text == "Select" ? "" : cboGTIN.Text));
                }
                else
                {
                    cboLine.Items.Clear();
                    cboLine.Items.Add("Select");

                }
                cboLine.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "cboPacking_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());

            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                ds = null;
                objLog = null;
            }
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();


            DataTable dt = new DataTable();
            try
            {


                if (cboLine.Text != "Select")
                {
                    fillCombo(cboPacking.Text.Trim(), cboLine.Text.Trim(), cboLine.Text.Trim(), cboLine, cboProduct, (cboGTIN.Text == "Select" ? "" : cboGTIN.Text));
                }
                else
                {
                    //cboProduct.Items.Clear();
                    //cboProduct.Items.Add("Select");
                    if (cboProduct.Items.Count > 1)
                    {
                        cboProduct.SelectedIndex = 1;
                    }
                    else if (cboProduct.Items.Count == 0)
                    {
                        cboProduct.Items.Add("Select");
                        cboProduct.SelectedIndex = 0;
                    }
                    else
                    {
                        cboProduct.SelectedIndex = 0;
                    }
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "cboLine_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                objLog = null;
                dt = null;

            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            objBL_Prnt = new BL_Printing();
            objPL_Prnt = new PL_Printing();
            objLog = new BL_LogWriter();
            int iSave = 0;
            try
            {
                if (lstView.Items.Count > 0)
                {
                    for (int i = 0; i < lstView.Items.Count; i++)
                    {
                        if (lstView.Items[i].Checked == true)
                        {
                            objPL_Prnt.strPlantCode = "";
                            objPL_Prnt.strPackLevel = "";
                            objPL_Prnt.strLineNo = "";
                            objPL_Prnt.strGTINCode = "";
                            objPL_Prnt.strBatchNo = "";

                            string strStatus = objBL_Prnt.BL_SaveJob(objPL_Prnt, 0, "REJECT", Convert.ToInt32(lstView.Items[i].SubItems[0].Text.ToString()), lblExpiry.Text);


                            if (strStatus.Contains("|") == true)
                            {
                                if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Success", strStatus.Split('|').GetValue(1).ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    iSave++;
                                    //DisplayMessage(false, strStatus.Split('|').GetValue(1).ToString());

                                }
                                else
                                {
                                    objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", strStatus.Split('|').GetValue(1).ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    //DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString());

                                }
                            }

                        }

                    }
                    if (iSave > 0)
                    {
                        frmJobCreate_Load(sender, e);
                        pnlEntry.Visible = false;
                        pnlView.Visible = true;
                        DisplayMessage(false, iSave + " No. Of Jobs Closed Succesfully");
                    }
                    else
                    {
                        DisplayMessage(true, iSave + " No. Of Jobs Closed Succesfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
            finally
            {
                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                objPL_Prnt = null; objBL_Prnt = null; objLog = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmJobCreate_Load(sender, e);
        }

        public void DisplayMessage(bool isError, string strMessage)
        {

            if (isError == true)
            {
                pnlBack.BackColor = Color.Red;
                lblLabel.Text = strMessage;
            }
            else
            {
                pnlBack.BackColor = Color.CornflowerBlue;
                lblLabel.Text = strMessage;
            }


        }

        private void btnJobCreate_Click(object sender, EventArgs e)
        {
            objBL_Prnt = new BL_Printing();
            objPL_Prnt = new PL_Printing();
            objLog = new BL_LogWriter();
            try
            {
                if (cboPlant.Text == "" || cboPlant.Text == "Select")
                {
                    errorProvider1.SetError(cboPlant, "Select Plant Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPacking.Text == "" || cboPacking.Text == "Select")
                {
                    errorProvider1.SetError(cboPacking, "Select Packing Level");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboLine.Text == "" || cboLine.Text == "Select")
                {
                    errorProvider1.SetError(cboLine, "Select Line Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboGTIN.Text == "" || cboGTIN.Text == "Select")
                {
                    errorProvider1.SetError(cboGTIN, "Select GTIN Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboJobBatch.Text == "" || cboJobBatch.Text == "Select")
                {
                    errorProvider1.SetError(cboJobBatch, "Select Batch No.");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (txtJobPackSize.Text == "" || Convert.ToInt32(txtJobPackSize.Text) <= 0)
                {
                    errorProvider1.SetError(txtJobPackSize, "Pack Size Can't be left Blank");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                objPL_Prnt.strPlantCode = cboPlant.Text;
                objPL_Prnt.strPackLevel = cboPacking.Text;
                objPL_Prnt.strLineNo = cboLine.Text;
                objPL_Prnt.strGTINCode = cboGTIN.Text;
                objPL_Prnt.strBatchNo = cboJobBatch.Text;

                DialogResult ds = MessageBox.Show("Do you really want to create this Job", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ds == DialogResult.Yes)
                {
                    string strStatus = objBL_Prnt.BL_SaveJob(objPL_Prnt, Convert.ToInt32(txtJobPackSize.Text), "ADD", 0, lblExpiry.Text);

                    if (strStatus.Contains("|") == true)
                    {
                        if (strStatus.Split('|').GetValue(0).ToString() == "0")
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "btnJobCreate_Click", "Success", strStatus.Split('|').GetValue(1).ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                            frmJobCreate_Load(sender, e);
                            pnlEntry.Visible = true;
                            pnlView.Visible = false;
                            MessageBox.Show(strStatus.Split('|').GetValue(1).ToString(), "Message");
                            //DisplayMessage(false, strStatus.Split('|').GetValue(1).ToString());

                        }
                        else
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "btnJobCreate_Click", "Error", strStatus.Split('|').GetValue(1).ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                            //DisplayMessage(true, strStatus.Split('|').GetValue(1).ToString());
                            MessageBox.Show(strStatus.Split('|').GetValue(1).ToString(), "Message");
                            //lblLabel.Text = strStatus.Split('|').GetValue(1).ToString();

                        }
                    }
                    else
                    {
                        //lblLabel.Text = "Failed to save transaction";
                        //DisplayMessage(false, "Failed to save transaction");
                        MessageBox.Show("Failed to save transaction", "Message");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "btnJobCreate_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
            }
            finally
            {
                objPL_Prnt = null; objBL_Prnt = null; objLog = null;
            }
        }

        private void cboBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            BL_Generator objGen = new BL_Generator();
            PL_Generator objPLGen = new PL_Generator();

            try
            {
                if (cboJobBatch.Text != "Select")
                {

                    objPLGen.strPackLevel = cboPacking.Text.Trim();
                    objPLGen.strLableType = "";
                    objPLGen.strLineNo = (cboLine.Text == "Select" ? "" : cboLine.Text);
                    objPLGen.strGTIN = (cboGTIN.Text == "Select" ? "" : cboGTIN.Text);
                    objPLGen.strFieldCriteria = cboJobBatch.Name.ToString();
                    objPLGen.strFieldValue = cboJobBatch.Text.Trim();

                    dt = objGen.BLfillComboData(objPLGen, txtJobPackSize.Name.ToString());


                    if (dt.Rows.Count > 0)
                    {
                        txtJobPackSize.Text = dt.Rows[0]["PACK_SIZE"].ToString();
                        //lblExpiry.Text = dt.Rows[0][1].ToString().Split('/').GetValue(0).ToString() + "/" + dt.Rows[0][1].ToString().Split('/').GetValue(1).ToString() + "/" + dt.Rows[0][1].ToString().Split('/').GetValue(2).ToString();
                        lblExpiry.Text = dt.Rows[0]["EXP_DATE"].ToString();
                    }
                    else
                    {
                        txtJobPackSize.Text = "";
                        lblExpiry.Text = "";
                    }
                }
                else
                {
                    txtJobPackSize.Text = "";
                    lblExpiry.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "cboBatch_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
            }
            finally
            {
                objGen = null;
                objPLGen = null;
                objLog = null;
                dt = null;

            }
        }

        public void Clear()
        {

            cboPacking.Items.Clear();
            cboLine.Items.Clear();
            cboGTIN.Items.Clear();
            cboJobBatch.Items.Clear();
            txtJobPackSize.Text = "";

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            objLog = new BL_LogWriter();
            clsFile objFile = new clsFile();
            OpenNETCF.Desktop.Communication.RAPI mri = new OpenNETCF.Desktop.Communication.RAPI();
            StreamWriter sw;
            try
            {

                if (lstView.Items.Count > 0)
                {
                    if (mri.DevicePresent == false)
                    {
                        lblRecord.Text = "Device is not connected";
                        return;
                    }

                    mri.Connect();
                    if (mri.Connected == true)
                    {
                        sw = new StreamWriter(Application.StartupPath + "\\JOB.txt", true);
                        for (int i = 0; i < lstView.Items.Count; i++)
                        {
                            sw.WriteLine(lstView.Items[i].SubItems[4].Text.ToString() + "#" + lstView.Items[i].SubItems[5].Text.ToString() + "#" + lstView.Items[i].SubItems[7].Text.ToString() + "#" + lstView.Items[i].SubItems[6].Text.ToString());
                        }
                        sw.Close();
                        sw.Dispose();
                        objFile.UploadDataToDevice("JOB", Application.StartupPath + "\\JOB.txt");
                        lblRecord.Text = "Job File Uploaded Successfully";
                        //DisplayMessage(false, "Job File Uploaded Successfully");

                    }
                    else
                    {
                        lblRecord.Text = "Device is not connected";
                        //DisplayMessage(true, "Device is not connected");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "btnUpload_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                objLog = null; objFile = null;
                mri.Disconnect(); mri.Dispose();
                mri = null;
            }
        }

        private void txtPackSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboGTIN_TextChanged(object sender, EventArgs e)
        {

            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();


            DataTable dt = new DataTable();
            try
            {
                if (cboGTIN.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPacking.Text;
                    objPL_Prnt.strLineNo = cboLine.Text;
                    objPL_Prnt.strGTINCode = cboGTIN.Text;


                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    dt = objBL_Prnt.BL_GetJobBatch(objPL_Prnt);

                    cboJobBatch.Items.Clear();
                    cboJobBatch.Items.Add("Select");

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboJobBatch.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                }
                else
                {
                    cboJobBatch.Items.Clear();
                    cboJobBatch.Items.Add("Select");
                }
                cboJobBatch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "cboGTIN_TextChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                objLog = null;
                dt = null;

            }
        }

        private void cboProduct_TextChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {

                if (cboProduct.Text != "Select")
                {
                    fillCombo(cboPacking.Text.Trim(), (cboLine.Text == "Select" ? "" : cboLine.Text), cboProduct.Text.Trim(), cboProduct, cboGTIN, cboGTIN.Text);
                }
                else if (cboPacking.Text != "Select")
                {
                    //cboGTIN.Items.Clear();
                    //cboGTIN.Items.Add("Select");
                    cboGTIN.SelectedIndex = 0;
                }
                else
                {
                    cboGTIN.Items.Clear();
                    cboGTIN.Items.Add("Select");
                    cboGTIN.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboProduct_TextChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objLog = null;
            }
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";

            pnlEntry.Visible = false;
            pnlView.Visible = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnlEntry.Visible = true;
            pnlView.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BL_Printing objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (txtBatch.Text == "")
                {
                    errorProvider1.SetError(txtBatch, "Enter Batch No.");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                clsStandards.FillListView(lstView, objBL_Prnt.BL_GetJobs(cboPlant.Text, txtBatch.Text.Trim()));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objBL_Prnt = null;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            BL_Printing objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                clsStandards.FillListView(lstView, objBL_Prnt.BL_GetJobs(cboPlant.Text, ""));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSearch_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                lblRecord.Text = lstView.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objBL_Prnt = null;
            }
        }







    }
}
