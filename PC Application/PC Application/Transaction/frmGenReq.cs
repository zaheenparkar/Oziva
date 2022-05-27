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

namespace PC_Application.Transaction
{
    public partial class frmGenReq : Form
    {
        BL_Generator objGen;
        PL_Generator objPLGen;
        BL_Printing objBL_Prnt;
        int iHet = 0;
        public frmGenReq()
        {
            InitializeComponent();
        }


        private void frmGenReq_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            string[] strPlantCode;
            string str = "";
            try
            {


                objGen = new BL_Generator();
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                dt = objGen.BLGetPackLevel();
                cboPacking.Items.Clear();
                cboPacking.Items.Add("Select");
                cboPackSize.Items.Add("Select");
                cboPackSize.SelectedIndex = 0;
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboPacking.Items.Add(dt.Rows[i]["PACKING_LEVEL"].ToString());
                    }

                }
                cboPacking.SelectedIndex = 0;
                objBL_Prnt = new BL_Printing();
                str = objBL_Prnt.BLGetPlantLogin(PL_Login.UserID);
                if (str != "")
                {
                    cboPlant.Items.Clear();
                    cboPlant.Items.Add("Select");
                    strPlantCode = str.Split(',');
                    for (int i = 0; i < strPlantCode.Count(); i++)
                    {
                        cboPlant.Items.Add(strPlantCode[i].ToString());
                    }
                    if (cboPlant.Items.Count == 2)
                    {
                        cboPlant.SelectedIndex = 1;
                    }
                    else
                    {
                        cboPlant.SelectedIndex = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmGenReq_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objGen = null;
                objLog = null;
                dt = null;
            }
        }

        public void fillCombo(string strPackLevel, string strLine, string strValue, ComboBox SelctCombo, ComboBox fillCombo)
        {
            DataTable dt = new DataTable();
            objGen = new BL_Generator();
            objPLGen = new PL_Generator();
            bool iCount = false;
            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

            try
            {
                objPLGen.strPackLevel = strPackLevel;
                objPLGen.strLableType = cboLabelType.Text.Trim();
                objPLGen.strLineNo = strLine;
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
                    else if (fillCombo.Name == cboLabelType.Name.ToString())
                    {
                        dt = objGen.BLGetLableType(objPLGen);
                        if (dt.Rows.Count > 0)
                        {
                            iCount = true;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            fillCombo.Items.Add(dt.Rows[i][0].ToString());
                        }
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

            BL_LogWriter objLog = new BL_LogWriter();

            try
            {
                if (cboPacking.Text != "Select")
                {

                    cboERP_SelectedIndexChanged(sender, e);
                    if (cboPacking.Text != "Tertiary")
                    {
                        VisibleBatch("");



                        fillCombo(cboPacking.Text.Trim(), (cboLine.Text == "Select" ? "" : cboLine.Text), cboPacking.Text.Trim(), cboPacking, cboLine);
                        cboLabelType.Items.Clear();
                        cboLabelType.Enabled = false;
                    }
                    else if (cboPacking.Text == "Tertiary")
                    {

                        fillCombo(cboPacking.Text.Trim(), (cboLine.Text == "Select" ? "" : cboLine.Text), cboPacking.Text.Trim(), cboPacking, cboLabelType);
                        if (cboLabelType.Items.Count > 1)
                        {
                            cboLabelType.SelectedIndex = 2;
                        }
                        else
                        {
                            cboLabelType.SelectedIndex = 0;
                        }

                        cboLabelType.Enabled = true;
                    }
                    else
                    {
                        cboLabelType.Enabled = false;
                    }


                }
                else
                {
                    cboLabelType.Enabled = false;
                    cboLabelType.Items.Clear();
                    cboLabelType.Items.Add("Select");
                    cboLabelType.SelectedIndex = 0;
                    cboLine.Items.Clear();
                    cboLine.Items.Add("Select");
                    cboLine.SelectedIndex = 0;

                    cboGTIN.Items.Clear();
                    cboProduct.Items.Clear();
                    cboGTIN.Items.Add("Select");
                    cboProduct.Items.Add("Select");
                    cboGTIN.SelectedIndex = 0;
                    cboProduct.SelectedIndex = 0;

                    mfgdate.Text = DateTime.Now.ToShortDateString();
                    expiry.Text = DateTime.Now.ToShortDateString();
                    txtPackSize.Text = "";

                }


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboPacking_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;

            }
        }

        private void cboGTIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BL_LogWriter objLog = new BL_LogWriter();
            //DataTable dt = new DataTable();

            //try
            //{
            //    if (cboGTIN.Text != "Select")
            //    {


            //        objGen = new BL_Generator();
            //        dt = objGen.BLGetMasterBatch(cboPlant.Text.Trim(), cboGTIN.Text.Substring(1, 12).ToString());

            //        cboBatch.Items.Clear();
            //        cboBatch.Items.Add("Select");
            //        if (dt.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                cboBatch.Items.Add(dt.Rows[i][0].ToString());
            //            }
            //        }
            //        cboBatch.SelectedIndex = 0;

            //    }
            //    else if (cboPacking.Text != "Select")
            //    {
            //        //cboERP.Items.Clear();
            //        //cboERP.Items.Add("Select");
            //        cboBatch.SelectedIndex = 0;
            //        cboERP.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        cboERP.Items.Clear();
            //        cboERP.Items.Add("Select");
            //        cboERP.SelectedIndex = 0;

            //        cboBatch.Items.Clear();
            //        cboBatch.Items.Add("Select");
            //        cboBatch.SelectedIndex = 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objLog.WriteErrorLog(this.Name.ToString(), "cboGTIN_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    objLog = null; objGen = null; dt = null;
            //}
        }

        private void mfgdate_ValueChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            DateTime date = new DateTime();
            double iDays = 0;
            BL_LogWriter objLog = new BL_LogWriter();

            try
            {

                if (lblExpiry.Text != "")
                {
                    iDays = Convert.ToDouble(lblExpiry.Text.Split(' ').GetValue(0).ToString());

                    date = DateTime.ParseExact(mfgdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).AddDays(iDays + 1);

                    DateTime endOfMonth = new DateTime(date.Year,
                                   date.Month,
                                   DateTime.DaysInMonth(date.Year,
                                                        date.Month));

                    expiry.Text = endOfMonth.ToString();
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "mfgdate_ValueChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
                //objGen = null;
                //objPLGen = null;
                //dt = null;
            }
        }

        public void Clear(bool iFlag)
        {
            if (iFlag == true)
            {
                txtPackSize.Text = "";
                //mfgdate.Text = DateTime.Today.Date;
                //expiry.Text = DateTime.Today.Date.ToString();
                cboGTIN.SelectedIndex = 0;
                txtBatch.Text = "";
                cboProduct.SelectedIndex = 0;
            }
            else
            {
                txtPackSize.Text = "";
                cboBatch.SelectedIndex = 0;
                txtBatch.Text = "";
                //mfgdate.Text = DateTime.Today.Date.ToString();
                //expiry.Text = DateTime.Today.Date.ToString();
                txtQty.Text = "";
                cboLine.Items.Clear();
                cboLabelType.Items.Clear();
                cboGTIN.Items.Clear();
                cboProduct.Items.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowindex = 0;
            string strBatch = "";
            try
            {
                if (cboPlant.Text.Trim() == "" || cboPlant.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPlant, "Select Plant Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                if (cboPacking.Text.Trim() == "" || cboPacking.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPacking, "Select Packing Level");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboLine.Text.Trim() == "" || cboLine.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboLine, "Select Line Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                if (cboProduct.Text.Trim() == "" || cboProduct.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboProduct, "Select Product Name");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                if (cboGTIN.Text.Trim() == "" || cboGTIN.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboGTIN, "Select GTIN Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                if (cboLabelType.Text != "Heterogeneous")
                {
                    if (txtPackSize.Text.Trim() == "" || Convert.ToInt32(txtPackSize.Text) <= 0)
                    {
                        errorProvider1.SetError(txtPackSize, "Enter Valid Pack Size");
                        return;
                    }
                    else
                    {
                        errorProvider1.Dispose();
                    }
                }
                
                if (mfgdate.Text.Trim() == "")
                {
                    errorProvider1.SetError(mfgdate, "Select Manufacturing Date");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (expiry.Text.Trim() == "")
                {
                    errorProvider1.SetError(expiry, "Select Expiry Date");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                //if (cboPackSize.Text.Trim() == "" || cboPackSize.Text.Trim() == "Select")
                //{
                //    errorProvider1.SetError(cboPackSize, "Select Pack Size ");
                //    return;
                //}
                //else
                //{
                //    errorProvider1.Dispose();
                //}
                if (txtQty.Text.Trim() == "" || Convert.ToInt32(txtQty.Text) <= 0)
                {
                    errorProvider1.SetError(txtQty, "Enter Valid Quantity");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPacking.Text == "Tertiary")
                {
                    if (cboLabelType.Text.Trim() == "" || cboLabelType.Text.Trim() == "Select")
                    {
                        errorProvider1.SetError(cboLabelType, "Select Lable Type");
                        return;
                    }
                    else
                    {
                        errorProvider1.Dispose();
                    }

                    if (cboLabelType.Text == "Heterogeneous")
                    {
                        cboPacking.Enabled = false;
                        cboLabelType.Enabled = false;
                        iHet++;

                    }
                }

                if (iHet > 0)
                {
                    if (txtBatch.Text == "")
                    {
                        errorProvider1.SetError(txtBatch, "Enter Batch No");
                        return;
                    }
                    else
                    {
                        strBatch = txtBatch.Text.Trim();
                        errorProvider1.Dispose();
                    }
                }
                else
                {
                    if (cboBatch.Text == "Select")
                    {
                        errorProvider1.SetError(cboBatch, "Select Batch No");
                        return;
                    }
                    else
                    {
                        strBatch = cboBatch.Text.Trim();
                        errorProvider1.Dispose();
                    }
                }
                if (cboLabelType.Text != "Heterogeneous")
                {
                    if (expiry.Value <= mfgdate.Value)
                    {
                        MessageBox.Show("Expiry Date Can't be less than Mfg");
                        return;
                    }
                }


                //objPLGen.strPackLevel = cboPacking.Text;
                //objPLGen.strLineNo = cboLine.Text;
                //objPLGen.strGTIN = cboGTIN.Text;
                //objPLGen.strDesc = txtDesc.Text;
                //objPLGen.strPackSize = txtPackSize.Text;
                //objPLGen.strBatch = txtBatchno.Text;
                //objPLGen.strMfg = mfgdate.Text;
                //objPLGen.strExp = expiry.Text;
                //objPLGen.strQty = txtQty.Text;


                DialogResult ds = MessageBox.Show("Do you really want to save this Transaction", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ds == DialogResult.Yes)
                {

                    dtgDtl.Rows.Add();
                    rowindex = dtgDtl.Rows.Count;
                    dtgDtl.Rows[rowindex - 1].Cells[0].Value = cboPacking.Text;
                    dtgDtl.Rows[rowindex - 1].Cells[1].Value = cboLine.Text;
                    if (cboPacking.Text == "Tertiary")
                    {
                        dtgDtl.Rows[rowindex - 1].Cells[2].Value = cboLabelType.Text;
                    }
                    else
                    {
                        dtgDtl.Rows[rowindex - 1].Cells[2].Value = "";
                    }
                    dtgDtl.Rows[rowindex - 1].Cells[3].Value = cboGTIN.Text;
                    dtgDtl.Rows[rowindex - 1].Cells[4].Value = cboProduct.Text.Trim();
                    dtgDtl.Rows[rowindex - 1].Cells[5].Value = txtPackSize.Text.Trim();
                    dtgDtl.Rows[rowindex - 1].Cells[6].Value = strBatch;
                    dtgDtl.Rows[rowindex - 1].Cells[7].Value = mfgdate.Text;
                    dtgDtl.Rows[rowindex - 1].Cells[8].Value = expiry.Text;
                    dtgDtl.Rows[rowindex - 1].Cells[9].Value = txtQty.Text;
                    dtgDtl.Rows[rowindex - 1].Cells[10].Value = cboPlant.Text.Trim();
                    if (iHet > 1)
                    {
                        dtgDtl.Rows[rowindex - 1].Cells[11].Value = "2";
                    }
                    else
                    {
                        dtgDtl.Rows[rowindex - 1].Cells[11].Value = "1";
                    }
                    dtgDtl.Rows[rowindex - 1].Cells[12].Value = (dtgDtl.Rows.Count + 1).ToString();
                    dtgDtl.Rows[rowindex - 1].Cells[13].Value = cboERP.Text.Trim();

                    //if (cboLabelType.Text == "Heterogeneous")
                    //{
                    //    txtQty.Enabled = true;
                    //}
                    //else
                    //{
                    txtQty.Text = "";
                    txtQty.Enabled = true;
                    //}
                    //if (cboPacking.Enabled == false)
                    //{
                    //    //Clear(true);
                    //}
                    //else
                    //{
                    //    //Clear(false);
                    //}
                    Clear(true);

                    btnRefresh_Click(sender, e);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //btnRefresh.PerformClick();


            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string strMessgae = "";
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable("TEMP");
            try
            {
                objGen = new BL_Generator();
                objPLGen = new PL_Generator();
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                if (dtgDtl.Rows.Count > 0)
                {
                    dt.Columns.Add("PACKING_LEVEL", typeof(string));
                    dt.Columns.Add("LINE_ID", typeof(string));
                    dt.Columns.Add("LABEL_TYPE", typeof(string));
                    dt.Columns.Add("GTIN_ID", typeof(string));
                    dt.Columns.Add("PROD_DESC1", typeof(string));
                    dt.Columns.Add("PACK_SIZE", typeof(int));
                    dt.Columns.Add("BATCH_NO", typeof(string));
                    dt.Columns.Add("MFG_DATE", typeof(string));
                    dt.Columns.Add("EXP_DATE", typeof(string));
                    dt.Columns.Add("QTY", typeof(int));
                    dt.Columns.Add("PLANT", typeof(string));
                    dt.Columns.Add("FLAG", typeof(string));
                    dt.Columns.Add("ROWCNT", typeof(int));
                    dt.Columns.Add("ERP_ITEM_CODE", typeof(string));

                    DataRow dr;

                    foreach (DataGridViewRow dr1 in dtgDtl.Rows)
                    {
                        dr = dt.NewRow();
                        dr[0] = dr1.Cells[0].Value.ToString();
                        dr[1] = dr1.Cells[1].Value.ToString();
                        dr[2] = dr1.Cells[2].Value.ToString();
                        dr[3] = dr1.Cells[3].Value.ToString();
                        dr[4] = dr1.Cells[4].Value.ToString();
                        dr[5] = Convert.ToInt32(dr1.Cells[5].Value.ToString());
                        dr[6] = dr1.Cells[6].Value.ToString();
                        dr[7] = dr1.Cells[7].Value.ToString();
                        dr[8] = dr1.Cells[8].Value.ToString();
                        dr[9] = Convert.ToInt32(dr1.Cells[9].Value.ToString());
                        dr[10] = dr1.Cells[10].Value.ToString();
                        dr[11] = dr1.Cells[11].Value.ToString();
                        dr[12] = dr1.Cells[12].Value.ToString();
                        dr[13] = dr1.Cells[13].Value.ToString();

                        dt.Rows.Add(dr);
                        dt.AcceptChanges();



                    }
                    strMessgae = objGen.BL_SaveDataDt(dt, PL_Login.UserID, cboPlant.Text);
                    objLog.WriteErrorLog(this.Name.ToString(), "btnRefresh_Click", "Success", strMessgae, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    if (strMessgae != "")
                    {
                        iHet = 0;
                        dtgDtl.Rows.Clear();
                        MessageBox.Show(strMessgae.ToString());
                        frmGenReq_Load(sender, e);
                        cboPacking.Enabled = true;
                        cboLabelType.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("No Data Found to Generate Request");
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnRefresh_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
                dt = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPackSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void VisibleBatch(string strLabelType)
        {
            if (strLabelType == "Heterogeneous")
            {
                cboBatch.Visible = false;
                txtBatch.Visible = true;
                txtBatch.Text = "";
                expiry.Enabled = true;  

            }
            else
            {
                cboBatch.Visible = true;
                txtBatch.Visible = false;
                txtBatch.Text = "";
                expiry.Enabled = false;  
            }
        }

        private void cboLabelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsLine = new DataSet();
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (cboLabelType.Text != "Select")
                {
                    objGen = new BL_Generator();
                    objPLGen = new PL_Generator();
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    objPLGen.strPackLevel = cboPacking.Text;
                    objPLGen.strLableType = cboLabelType.Text;

                    cboLine.Items.Clear();
                    cboLine.Items.Add("Select");


                    dsLine = objGen.BLGetLineInfo(objPLGen, cboPlant.Text);

                    if (dsLine.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                        {
                            cboLine.Items.Add(dsLine.Tables[0].Rows[i][0].ToString());
                        }
                        cboLine.SelectedIndex = 0;
                    }
                    else
                    {
                        cboLine.SelectedIndex = 0;
                    }

                    if (cboLabelType.Text == "Heterogeneous")
                    {
                        cboERP.Items.Clear();
                        cboERP.Items.Add("Select");
                        dt = objGen.BLGetBatchERP("");
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                cboERP.Items.Add(dt.Rows[i][0].ToString());
                            }
                        }
                        if (cboERP.Items.Count > 1)
                        {
                            cboERP.SelectedIndex = 1;
                        }
                        else
                        {
                            cboERP.SelectedIndex = 0;
                        }
                    }
                   

                }
                else
                {
                    cboLine.Items.Clear();
                    cboLine.Items.Add("Select");
                    cboLine.SelectedIndex = 0;
                }

                VisibleBatch(cboLabelType.Text);



            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboLabelType_SelectedValueChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objPLGen = null;
                objGen = null;
                dt = null;
            }
        }

        private void cboERP_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            objGen = new BL_Generator();

            DateTime Expdate = new DateTime();
            DateTime Mfgdate = new DateTime();

            try
            {
                if (cboERP.Text != "Select" && cboPacking.Text != "Select")
                {

                    if (cboLabelType.Text != "Heterogeneous")
                    {
                       
                        cboGTIN.Items.Clear();
                        cboProduct.Items.Clear();
                        cboPackSize.Items.Clear();
                        cboGTIN.Items.Add("Select");
                        cboProduct.Items.Add("Select");
                        cboPackSize.Items.Add("Select");

                        dt = objGen.BLGetDataOnERP(cboPacking.Text.Trim(), cboERP.Text.Trim(), cboBatch.Text.Trim());

                        if (dt.Rows.Count > 0)
                        {
                            cboGTIN.Items.Add(dt.Rows[0]["GTIN_CODE"].ToString());
                            cboProduct.Items.Add(dt.Rows[0]["PROD_DESC1"].ToString());
                           // cboPackSize.Items.Add(dt.Rows[0]["PACK_SIZE"].ToString());
                            txtPackSize.Text = dt.Rows[0]["PACK_SIZE"].ToString();

                            foreach (DataRow dt1 in dt.Rows)
                            {
                                cboPackSize.Items.Add(dt1["PACK_SIZE"].ToString());
                            }

                            Mfgdate = DateTime.ParseExact(dt.Rows[0]["MFG_DATE"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            mfgdate.Text = Mfgdate.ToString();

                            Expdate = DateTime.ParseExact(dt.Rows[0]["EXP_DATE"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            expiry.Text = Expdate.ToString();

                            cboGTIN.SelectedIndex = 1;
                            cboProduct.SelectedIndex = 1;
                            cboPackSize.SelectedIndex = 0;
                            txtBatch.Focus();
                        }
                        else
                        {
                            cboGTIN.SelectedIndex = 0;
                            cboProduct.SelectedIndex = 0;
                           // cboPackSize.SelectedIndex = 0;
                            mfgdate.Text = DateTime.Now.ToShortDateString();
                            expiry.Text = DateTime.Now.ToShortDateString();
                            txtPackSize.Text = "";
                        }
                    }
                    else
                    {
                        cboGTIN.Items.Clear();
                        cboProduct.Items.Clear();
                        cboPackSize.Items.Clear();
                        cboGTIN.Items.Add("Select");
                        cboProduct.Items.Add("Select");

                        dt = objGen.BLGetDataOnERP(cboPacking.Text.Trim(), cboERP.Text.Trim(), "");

                        if (dt.Rows.Count > 0)
                        {
                            cboGTIN.Items.Add(dt.Rows[0]["GTIN_CODE"].ToString());
                            cboProduct.Items.Add(dt.Rows[0]["PROD_DESC1"].ToString());
                            foreach (DataRow dt1 in dt.Rows)
                            {
                                cboPackSize.Items.Add(dt1["PACK_SIZE"].ToString());
                            }

                            //txtPackSize.Text = dt.Rows[0]["PACK_SIZE"].ToString();
                            mfgdate.Text = DateTime.Now.ToShortDateString();
                            expiry.Text = DateTime.Now.ToShortDateString();
                            cboGTIN.SelectedIndex = 1;
                            cboProduct.SelectedIndex = 1;
                            cboPackSize.SelectedIndex = 0;
                            txtQty.Focus();
                        }
                        else
                        {
                            cboGTIN.SelectedIndex = 0;
                            cboProduct.SelectedIndex = 0;
                            cboPackSize.SelectedIndex = 0;
                            mfgdate.Text = DateTime.Now.ToShortDateString();
                            expiry.Text = DateTime.Now.ToShortDateString();
                            txtPackSize.Text = "";
                        }
                    }
                  

                }
                else
                {
                    cboGTIN.Items.Clear();
                    cboProduct.Items.Clear();
                    cboGTIN.Items.Add("Select");
                    cboProduct.Items.Add("Select");
                    cboGTIN.SelectedIndex = 0;
                    cboProduct.SelectedIndex = 0;

                    mfgdate.Text = DateTime.Now.ToShortDateString();
                    expiry.Text = DateTime.Now.ToShortDateString();
                    txtPackSize.Text = "";
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboERP_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
            }
        }


        private void cboPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            objGen = new BL_Generator();
            try
            {
                if (cboPlant.Text != "Select")
                {

                    dt = objGen.BLGetMasterBatch(cboPlant.Text.Trim());

                    cboBatch.Items.Clear();
                    cboBatch.Items.Add("Select");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboBatch.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                    cboBatch.SelectedIndex = 0;
                }
                else
                {
                    cboBatch.Items.Clear();
                    cboBatch.Items.Add("Select");
                    cboBatch.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboPlant_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objLog = null;
            }

        }

        private void cboBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            objGen = new BL_Generator();
            try
            {
                if (cboBatch.Text != "Select")
                {
                    cboERP.Items.Clear();
                    cboERP.Items.Add("Select");
                    dt = objGen.BLGetBatchERP(cboBatch.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboERP.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                    if (cboERP.Items.Count > 1)
                    {
                        cboERP.SelectedIndex = 1;
                    }
                    else
                    {
                        cboERP.SelectedIndex = 0;
                    }

                    
                }
                else
                {
                    cboERP.Items.Clear();
                    cboERP.Items.Add("Select");
                    cboERP.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboBatch_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objLog = null;
                dt = null;
            }


        }




    }
}
