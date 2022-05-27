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
    public partial class frmBatchCreation : Form
    {
        BL_Generator objGen;
        PL_Generator objPLGen;
        BL_Printing objBL_Prnt;


        public frmBatchCreation()
        {
            InitializeComponent();
        }

        private void frmBatchCreation_Load(object sender, EventArgs e)
        {
            pnlView.BringToFront();
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                clsStandards.FillListView(listView1, objGen.GetBatch_Details(textBox1.Text.Trim(), false));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "fillCombo", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objGen = null;
            }
        }

        private void txtPackSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void fillCombo(string strPlant, string strCompany, string strValue, ComboBox SelctCombo, ComboBox fillCombo)
        {
            DataTable dt = new DataTable();
            objGen = new BL_Generator();
            objPLGen = new PL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

            try
            {
                objPLGen.strCompany = strCompany;
                objPLGen.strFieldCriteria = SelctCombo.Name.ToString();
                objPLGen.strFieldValue = strValue;
                objPLGen.strGTIN = cboGTIN.Text;
                fillCombo.Items.Clear();
                fillCombo.Items.Add("Select");

                dt = objGen.BLfillBatchData(objPLGen, fillCombo.Name.ToString(), cboPlant.Text);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        fillCombo.Items.Add(dt.Rows[i][0].ToString());
                    }

                    if (dt.Rows.Count == 1)
                    {
                        fillCombo.SelectedIndex = 1;
                    }
                    else
                    {
                        fillCombo.SelectedIndex = 0;
                    }
                }
                else
                {
                    fillCombo.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "fillCombo", "Error", ex.Message, "PC Clinet", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objGen = null; objPLGen = null; dt = null;
                objLog = null;
            }

        }

        private void cboProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboERP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BL_LogWriter objLog = new BL_LogWriter();
            //objGen = new BL_Generator();
            //DataTable dt_Temp = new DataTable();
            //try
            //{

            //    if (cboERP.Text != "Select")
            //    {
            //        dt_Temp = objGen.GetProductData_Batch(cboCompany.Text, cboERP.Text);

            //        cboGTIN.Items.Clear();
            //        cboProduct.Items.Clear();
            //        cboBCILID.Items.Clear();
            //        foreach (DataRow dt in dt_Temp.Rows)
            //        {
            //            cboGTIN.Items.Add(dt["GTIN_CODE"].ToString());
            //            cboProduct.Items.Add(dt["PROD_DESC1"].ToString());
            //            txtPackSize.Text = dt["PACK_SIZE"].ToString();
            //            cboBCILID.Items.Add(dt["BCIL_ID"].ToString());

            //            cboGTIN.SelectedIndex = 0;
            //            cboProduct.SelectedIndex = 0;
            //            cboBCILID.SelectedIndex = 0;
            //        }
            //        txtBatchno.Focus();
            //    }
            //    else
            //    {
            //        cboGTIN.Items.Clear();
            //        cboProduct.Items.Clear();
            //        cboBCILID.Items.Clear();
            //        txtPackSize.Text = string.Empty;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objLog.WriteErrorLog(this.Name.ToString(), "cboERP_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    objLog = null;
            //    dt_Temp = null;
            //    objGen = null;
            //}
        }

        private void LoadBatch()
        {

            cboExport.SelectedIndex = 0;
            cboExempted.SelectedIndex = 0;
            cboBatchStatus.SelectedIndex = 0;
            txtCountryCode.Text = "";
            txtExemptedInfo.Text = "";
            txtUnitPrice.Text = "";
            txtBatchno.Text = "";

            mfgdate.Text = DateTime.Now.ToShortDateString();
            expiry.Text = DateTime.Now.ToShortDateString();

            txtQty.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
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

                if (cboCompany.Text.Trim() == "" || cboCompany.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboCompany, "Select Company prefix");
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
                //if (cboPackSize.Text.Trim() == "" || cboPackSize.Text.Trim() == "Select")
                //{
                //    errorProvider1.SetError(cboPackSize, "Select Pack Size ");
                //    return;
                //}
                //else
                //{
                //    errorProvider1.Dispose();
                //}

                if (txtPackSize.Text.Trim() == "" || Convert.ToInt32(txtPackSize.Text) <= 0)
                {
                    errorProvider1.SetError(txtPackSize, "Enter Valid Pack Size");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (txtBatchno.Text.Trim() == "")
                {
                    errorProvider1.SetError(txtBatchno, "Enter Batch No");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
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
                //if (txtUnitPrice.Text == "" || Convert.ToDouble(txtUnitPrice.Text) <= 0)
                //{
                //    errorProvider1.SetError(txtQty, "Enter Unit Price");
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

                if (expiry.Value <= mfgdate.Value)
                {
                    MessageBox.Show("Expiry Date Can't be less than Mfg");
                    return;
                }
                errorProvider1.Dispose();

                DialogResult ds = MessageBox.Show("Do you really want to save this Transaction", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ds == DialogResult.Yes)
                {

                    ListViewItem lv = new ListViewItem(cboCompany.Text.Trim());
                    lv.SubItems.Add(cboGTIN.Text.Trim());
                    if (txtUnitPrice.Text != "")
                    {
                        try { lv.SubItems.Add(Convert.ToDouble(txtUnitPrice.Text.Trim()).ToString()); }
                        catch { errorProvider1.SetError(txtUnitPrice, "Enter valid unit price"); }
                    }
                    else
                    {
                        lv.SubItems.Add("");
                    }

                    lv.SubItems.Add(txtBatchno.Text.Trim());
                    lv.SubItems.Add(txtPackSize.Text.Trim());
                    lv.SubItems.Add(expiry.Text);
                    lv.SubItems.Add(mfgdate.Text);
                    lv.SubItems.Add(txtQty.Text.Trim());

                    lv.SubItems.Add(cboExport.Text.Trim());
                    lv.SubItems.Add(cboExempted.Text.Trim());
                    lv.SubItems.Add(txtExemptedInfo.Text.Trim());
                    lv.SubItems.Add(txtCountryCode.Text.Trim());
                    lv.SubItems.Add(cboBatchStatus.Text.Trim());
                    lv.SubItems.Add(cboPlant.Text.Trim());
                    lv.SubItems.Add(cboERP.Text.Trim());

                    lstDetial.Items.Add(lv);

                    LoadBatch();
                    txtBatchno.Focus();


                    btnSave_Click(sender, e);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DisableControl(0);
                //btnSave.PerformClick();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable("TEMP");
            lblLabel.Text = "";
            DataRow dr;
            try
            {
                dt.Columns.Add("REFNO", typeof(int));
                dt.Columns.Add("GS1_PREFIX", typeof(string));
                dt.Columns.Add("GTIN_CODE", typeof(string));
                dt.Columns.Add("MRP", typeof(string));
                dt.Columns.Add("BATCH", typeof(string));
                dt.Columns.Add("PACK_SIZE", typeof(int));
                dt.Columns.Add("EXP_DATE", typeof(string));
                dt.Columns.Add("MFG_DATE", typeof(string));
                dt.Columns.Add("TXN_QTY", typeof(int));
                dt.Columns.Add("BATCH_EXPORT_ST", typeof(char));
                dt.Columns.Add("EXEMPTED_ST", typeof(char));
                dt.Columns.Add("EXEMPTED_NOTIFY_INFO", typeof(string));
                dt.Columns.Add("EXEMPTED_COUNTRY_CODE", typeof(string));
                dt.Columns.Add("BATCH_ST", typeof(char));
                dt.Columns.Add("PLANT_CODE", typeof(string));
                dt.Columns.Add("ERP_ITEM_CODE", typeof(string));

                for (int i = 0; i < lstDetial.Items.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = (i + 1).ToString();
                    dr[1] = lstDetial.Items[i].SubItems[0].Text.ToString();
                    dr[2] = lstDetial.Items[i].SubItems[1].Text.ToString();
                    dr[3] = lstDetial.Items[i].SubItems[2].Text.ToString();  //for mrp (decimal)
                    dr[4] = lstDetial.Items[i].SubItems[3].Text.ToString();
                    dr[5] = Convert.ToInt32(lstDetial.Items[i].SubItems[4].Text.ToString()); //for pack size
                    dr[6] = lstDetial.Items[i].SubItems[5].Text.ToString();
                    dr[7] = lstDetial.Items[i].SubItems[6].Text.ToString();
                    dr[8] = Convert.ToInt32(lstDetial.Items[i].SubItems[7].Text.ToString()); // for Txn Qty
                    dr[9] = lstDetial.Items[i].SubItems[8].Text.ToString();
                    dr[10] = lstDetial.Items[i].SubItems[9].Text.ToString();
                    dr[11] = lstDetial.Items[i].SubItems[10].Text.ToString();
                    dr[12] = lstDetial.Items[i].SubItems[11].Text.ToString();
                    dr[13] = lstDetial.Items[i].SubItems[12].Text.ToString();
                    dr[14] = lstDetial.Items[i].SubItems[13].Text.ToString();
                    dr[15] = lstDetial.Items[i].SubItems[14].Text.ToString();

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }

                if (dt.Rows.Count > 0)
                {
                    string strMessage = objGen.BL_SaveBatchDt(dt, PL_Login.UserID.ToString(), cboPlant.Text);
                    if (strMessage.Contains('|') == true)
                    {

                        if (strMessage.Split('|').GetValue(0).ToString() == "1")
                        {
                            objLog.WriteErrorLog(this.Name.ToString(), "btnSave_Click", "Success", "Batch Created / Updated successfully", "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                            lblLabel.Text = strMessage.ToString();
                            MessageBox.Show("Batch Created / Updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else if (strMessage.Split('|').GetValue(0).ToString() == "-1")
                        {
                            lblLabel.Text = "Batch Updated and Generation Request has been cancelled against ";
                            MessageBox.Show("Batch Updated and Generation Request has been cancelled against same batch\nKindly create new generation request of the same batch", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else if (strMessage.Split('|').GetValue(0).ToString() == "0")
                        {
                            MessageBox.Show(strMessage.Split('|').GetValue(1).ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            toolStripButton2_Click(sender, e);
                        }
                        lstDetial.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnSave_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dt = null; objGen = null;

                cboExport.SelectedIndex = 0;
                cboBatchStatus.SelectedIndex = 0;
                cboExempted.SelectedIndex = 0;

                txtUnitPrice.Text = "0";
            }
        }

        private void mfgdate_ValueChanged(object sender, EventArgs e)
        {
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            DisableControl(0);
            try
            {
                clsStandards.FillListView(listView1, objGen.GetBatch_Details(textBox1.Text.Trim(), false));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "toolStripButton1_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                pnlView.BringToFront();
                objLog = null;
                objGen = null;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            objBL_Prnt = new BL_Printing();
            DataTable dt = new DataTable();

            DateTime Expdate = new DateTime();
            DateTime Mfgdate = new DateTime();

            string[] strPlantCode;
            string str = "";
            objGen = new BL_Generator();
            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
            try
            {
                DisableControl(0);
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
                    if (cboPlant.Items.Count >= 2)
                    {
                        cboPlant.SelectedIndex = 1;
                    }
                    else
                    {
                        cboPlant.SelectedIndex = 0;
                    }
                }

                if (cboPlant.Text != "Select")
                {
                    fillCombo(cboPlant.Text.Trim(), (cboCompany.Text == "Select" ? "" : cboCompany.Text), cboPlant.Text.Trim(), cboPlant, cboCompany);
                }
                else
                {
                    cboCompany.Items.Clear();
                    cboCompany.Items.Add("Select");
                    cboCompany.SelectedIndex = 0;
                }

                mfgdate.Text = DateTime.Now.ToShortDateString();
                expiry.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmBatchCreation_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                pnlEntry.BringToFront();
                objGen = null;
                objLog = null;
                dt = null;
                cboExport.SelectedIndex = 0;
                cboBatchStatus.SelectedIndex = 0;
                cboExempted.SelectedIndex = 0;
            }

            objGen = new BL_Generator();
            try
            {
                clsStandards.fillCombobox(cboERP, objGen.GetERP_Items(cboCompany.Text.Trim()));
                if (cboERP.Items.Count > 0)
                {
                    cboERP.SelectedIndex = 0;
                }
                LoadBatch();
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmBatchCreation_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objGen = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                clsStandards.FillListView(listView1, objGen.GetBatch_Details(textBox1.Text, false));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "fillCombo", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objGen = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                clsStandards.FillListView(listView1, objGen.GetBatch_Details("", false));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "fillCombo", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objGen = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.CheckedIndices.Count > 0)
            {

                if (MessageBox.Show("Selected batch will be no longer use for printing. Do you want to close?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem li in listView1.Items)
                    {
                        if (li.Checked == true)
                        {
                            BL_Generator objGen = new BL_Generator();
                            BL_LogWriter objLog = new BL_LogWriter();
                            try
                            {
                                objGen.CloseBatch(li.SubItems[4].Text, true);
                            }
                            catch (Exception ex)
                            {
                                objLog.WriteErrorLog(this.Name.ToString(), "button2_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                            }
                            finally
                            {
                                objLog = null;
                                objGen = null;
                            }
                        }
                    }

                    BL_Generator objGen1 = new BL_Generator();
                    BL_LogWriter objLog1 = new BL_LogWriter();
                    try
                    {
                        clsStandards.FillListView(listView1, objGen1.GetBatch_Details(textBox1.Text, false));
                    }
                    catch (Exception ex)
                    {
                        objLog1.WriteErrorLog(this.Name.ToString(), "button2_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
                    }
                    finally
                    {
                        label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                        objLog1 = null;
                        objGen1 = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Record from list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboERP_TextChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            objGen = new BL_Generator();
            DataTable dt_Temp = new DataTable();
            DateTime date;
            try
            {

                if (cboERP.Text != "Select")
                {
                    dt_Temp = objGen.GetProductData_Batch(cboCompany.Text, cboERP.Text);

                    cboGTIN.Items.Clear();
                    cboProduct.Items.Clear();
                    cboBCILID.Items.Clear();
                    cboPackSize.Items.Clear();
                    cboPackSize.Items.Add("Select");
                    foreach (DataRow dt in dt_Temp.Rows)
                    {
                        cboGTIN.Items.Add(dt["GTIN_CODE"].ToString());
                        cboProduct.Items.Add(dt["PROD_DESC1"].ToString());
                        txtPackSize.Text = dt["PACK_SIZE"].ToString();
                        txtPackSize.Text = dt["PACK_SIZE"].ToString();
                        //cboPackSize.Items.Add(dt["PACK_SIZE"].ToString());
                        cboBCILID.Items.Add(dt["BCIL_ID"].ToString());
                    }

                    cboGTIN.SelectedIndex = 0;
                    cboProduct.SelectedIndex = 0;
                    cboBCILID.SelectedIndex = 0;
                    cboPackSize.SelectedIndex = 0;
                    if (dt_Temp.Rows.Count > 0)
                    {
                        if (dt_Temp.Rows[0]["DAYS_EXPIRY"].ToString() != "" && Convert.ToInt32(dt_Temp.Rows[0]["DAYS_EXPIRY"].ToString()) > 0)
                        {

                            lblExpiry.Text = dt_Temp.Rows[0]["DAYS_EXPIRY"].ToString() + " Days (Expiry Period)";

                            date = DateTime.ParseExact(mfgdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).AddDays(double.Parse(dt_Temp.Rows[0]["DAYS_EXPIRY"].ToString()) + 1);

                            DateTime endOfMonth = new DateTime(date.Year,
                                           date.Month,
                                           DateTime.DaysInMonth(date.Year,
                                                                date.Month));

                            expiry.Text = endOfMonth.ToString();
                        }
                    }

                    txtBatchno.Focus();


                }
                else
                {
                    cboGTIN.Items.Clear();
                    cboProduct.Items.Clear();
                    cboBCILID.Items.Clear();
                    txtPackSize.Text = string.Empty;
                    cboPackSize.Items.Clear();
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
                dt_Temp = null;
                objGen = null;
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (ListViewItem li in listView1.Items)
            {
                if (e.Index != li.Index)
                {
                    li.Checked = false;
                }

            }
        }

        public void DisableControl(int iEDIT)
        {
            if (iEDIT == 1)
            {
                cboERP.Enabled = false;
                cboGTIN.Enabled = false;
                cboProduct.Enabled = false;
                cboBCILID.Enabled = false;
                txtBatchno.Enabled = false;
            }
            else
            {
                cboERP.Enabled = true;
                cboGTIN.Enabled = true;
                cboProduct.Enabled = true;
                cboBCILID.Enabled = true;
                txtBatchno.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DateTime Expdate = new DateTime();
            DateTime Mfgdate = new DateTime();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (listView1.CheckedIndices.Count > 0)
                {

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Checked == true)
                        {

                            //cboCompany.Items.Add(listView1.Items[i].SubItems[1].Text.ToString()); cboCompany.SelectedIndex = 0;
                            //cboPlant.Items.Add(listView1.Items[i].SubItems[14].Text.ToString()); cboPlant.SelectedIndex = 0;
                            //cboERP.Items.Add(listView1.Items[i].SubItems[15].Text.ToString()); cboERP.SelectedIndex = 0;
                            toolStripButton2_Click(sender, e);

                            try
                            {
                                cboCompany.SelectedItem = listView1.Items[i].SubItems[1].Text.ToString();
                                cboPlant.SelectedItem = listView1.Items[i].SubItems[14].Text.ToString();
                                cboERP.SelectedItem = listView1.Items[i].SubItems[15].Text.ToString();
                            }
                            catch { }



                            txtBatchno.Text = listView1.Items[i].SubItems[4].Text.ToString();
                            txtPackSize.Text = listView1.Items[i].SubItems[5].Text.ToString();

                            Mfgdate = DateTime.ParseExact(listView1.Items[i].SubItems[7].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            mfgdate.Text = Mfgdate.ToString();

                            Expdate = DateTime.ParseExact(listView1.Items[i].SubItems[6].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            expiry.Text = Expdate.ToString();

                            txtUnitPrice.Text = listView1.Items[i].SubItems[3].Text.ToString();
                            txtQty.Text = listView1.Items[i].SubItems[8].Text.ToString();

                            try
                            {
                                cboExport.SelectedItem = listView1.Items[i].SubItems[9].Text.ToString();
                                cboExempted.SelectedItem = listView1.Items[i].SubItems[10].Text.ToString();
                                cboBatchStatus.SelectedItem = listView1.Items[i].SubItems[13].Text.ToString();
                            }
                            catch { }

                            txtCountryCode.Text = listView1.Items[i].SubItems[12].Text.ToString();
                            txtExemptedInfo.Text = listView1.Items[i].SubItems[11].Text.ToString();

                            DisableControl(1);

                            pnlEntry.BringToFront();
                            break;
                        }
                    }





                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnEdit_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void btnViewClose_Click(object sender, EventArgs e)
        {

            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                clsStandards.FillListView(listView1, objGen.GetBatch_Details(textBox1.Text, true));
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnViewClose_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                label33.Text = listView1.Items.Count.ToString() + " record(s) found.";
                objLog = null;
                objGen = null;
            }
        }

        private void btnReOpen_Click(object sender, EventArgs e)
        {
            BL_Generator objGen = new BL_Generator();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (listView1.CheckedIndices.Count > 0)
                {
                    if (MessageBox.Show("Do you want to Re-Open Selected Batch?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (ListViewItem li in listView1.Items)
                        {
                            if (li.Checked == true)
                            {
                                objGen.CloseBatch(li.SubItems[4].Text, false);
                                break;
                            }
                        }
                    }

                    btnViewClose_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Select Record from list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnReOpen_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode.ToString());
            }
            finally
            {
                objGen = null; objLog = null;

            }
        }

        private void cboPlant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlant_TextChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            objGen = new BL_Generator();
            DataTable dt_Temp = new DataTable();
            try
            {

                if (cboPlant.Text != "Select")
                {
                    dt_Temp = objGen.GetCompanyData_Batch(cboPlant.Text);

                    cboCompany.Items.Clear();
                    foreach (DataRow dt in dt_Temp.Rows)
                    {
                        cboCompany.Items.Add(dt["GS1_PREFIX"].ToString());

                        cboCompany.SelectedIndex = 0;
                    } 

                    cboCompany.Focus();
                }
                else
                {
                    cboCompany.Items.Clear();
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
                dt_Temp = null;
                objGen = null;
            }
        }

        private void cboCompany_TextChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            objGen = new BL_Generator();
            DataTable dt_Temp = new DataTable();
            try
            {

                if (cboCompany.Text != "Select")
                {
                    dt_Temp = objGen.GetProductData_ERP(cboCompany.Text);

                    cboERP.Items.Clear();
                    cboERP.Items.Add("Select");
                    foreach (DataRow dt in dt_Temp.Rows)
                    {
                        cboERP.Items.Add(dt["ERP_ITEM_CODE"].ToString());

                    }

                    cboERP.SelectedIndex = 0;
                    cboERP.Focus();
                }
                else
                {
                    cboERP.Items.Clear();
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
                dt_Temp = null;
                objGen = null;
            }
        }

        private void cboPackSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
