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
    public partial class frmShipperLevel : Form
    {
        BL_Generator objGen;
        PL_Generator objPLGen;
        
        BL_Printing objBL_Prnt;
       // BL_Generator objGen;
        PL_Printing objPL_Prnt;
        int iHet = 0;
        string strPrinterName = "";
        public frmShipperLevel()
        {
            InitializeComponent();
        }


        private void frmSipperLevel_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            string[] strPlantCode;
            string str = "";
            try
            {

                cboGTIN.Items.Clear();
                objGen = new BL_Generator();
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                dt = objGen.BLGetPackLevel();
              //  dt = objGen.BLGetShipperMasterBatch();dateTimePicker1
               
               
              
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
                cboGTIN.Items.Add("Select");
                dt = objGen.BLGetShipperMasterBatch(cboPlant.Text);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboGTIN.Items.Add(dt.Rows[i]["GTIN_CODE"].ToString());
                    }

                }

                dt = objGen.BLGetMasterGTINProduct(cboGTIN.Text.Trim());
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboProduct.Items.Add(dt.Rows[i]["PROD_DESC1"].ToString());
                        txtPackSize.Text = dt.Rows[i]["PACK_SIZE"].ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmSipperLevel_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
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
               // objPLGen.strLableType = cboLabelType.Text.Trim();
                objPLGen.strLineNo = strLine;
                objPLGen.strFieldCriteria = SelctCombo.Name.ToString();
                objPLGen.strFieldValue = strValue;

                //if (SelctCombo.Name == cboPacking.Name.ToString())
                //{

                    fillCombo.Items.Clear();
                    fillCombo.Items.Add("Select");


                  
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
            catch (Exception ex)
            {

            }
            finally
            {
                objGen = null; objPLGen = null; dt = null;
            }

        }


        private void cboGTIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt = new DataTable();
            DateTime Expdate = new DateTime();
            DateTime Mfgdate = new DateTime();
            DataSet ds = new DataSet();
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();

            try
            {
                if (cboGTIN.Text != "Select")
                {


                    objGen = new BL_Generator();
                    dt = objGen.BLGetMasterGTINProduct(cboGTIN.Text.Trim());

                  //  cboProduct.Items.Clear();
                   // cboProduct.Items.Add("Select");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            cboProduct.Items.Add(dt.Rows[i]["PROD_DESC1"].ToString());
                            txtPackSize.Text = dt.Rows[i]["PACK_SIZE"].ToString();

                            Mfgdate = DateTime.ParseExact(dt.Rows[0]["MFG_DATE"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            mfgdate.Text = Mfgdate.ToString();

                            Expdate = DateTime.ParseExact(dt.Rows[0]["EXP_DATE"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            expiry.Text = Expdate.ToString();

                        }
                    }
                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = "Tertiary";
                    objPL_Prnt.strLineNo = "Ter1";
                    ds = objBL_Prnt.BL_GetPrntConfig(objPL_Prnt);
                    cboPrinter.Items.Clear();
                    cboPrinter.Items.Add("Select");
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        cboPrinter.Items.Add(ds.Tables[1].Rows[0][0].ToString());
                        cboPrinter.SelectedItem = ds.Tables[1].Rows[0][0].ToString();
                    }
                    else
                    {
                        if (PC_Application.Properties.Settings.Default.setPrinter != "")
                        {
                            if (cboPrinter.Items.Contains(PC_Application.Properties.Settings.Default.setPrinter) == false)
                            {
                                cboPrinter.Items.Add(PC_Application.Properties.Settings.Default.setPrinter);
                            }
                            cboPrinter.SelectedItem = PC_Application.Properties.Settings.Default.setPrinter;
                        }
                        else
                        {
                            cboPrinter.SelectedIndex = 0;
                        }
                    }
                  
                }
                
                else
                {
                    cboProduct.Items.Clear();
                    cboProduct.Items.Add("Select");
                    cboProduct.SelectedIndex = 0;

                    //cboGTIN.Items.Clear();
                    //cboGTIN.Items.Add("Select");
                    //cboGTIN.SelectedIndex = 0;

                  
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboGTIN_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null; objGen = null; dt = null;
            }
        }

        private void mfgdate_ValueChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            DateTime date = new DateTime();
            double iDays = 0;
            BL_LogWriter objLog = new BL_LogWriter();

            try
            {

                //if (lblExpiry.Text != "")
                //{
                //    iDays = Convert.ToDouble(lblExpiry.Text.Split(' ').GetValue(0).ToString());

                //    date = DateTime.ParseExact(mfgdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).AddDays(iDays + 1);

                //    DateTime endOfMonth = new DateTime(date.Year,
                //                   date.Month,
                //                   DateTime.DaysInMonth(date.Year,
                //                                        date.Month));

                //    expiry.Text = endOfMonth.ToString();
                //}
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
             
                cboProduct.SelectedIndex = 0;
            }
            else
            {
                txtPackSize.Text = "";
               
                //mfgdate.Text = DateTime.Today.Date.ToString();
                //expiry.Text = DateTime.Today.Date.ToString();
                txtQty.Text = "";
              
                //cboLabelType.Items.Clear();
                cboGTIN.Items.Clear();
                cboProduct.Items.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowindex = 0;
            int iPrint = 0;
            string strBatch = "";
            BL_Generator objGeny = new BL_Generator();
            DataTable dtPrint = new DataTable();
            objBL_Prnt = new BL_Printing();
            objPL_Prnt = new PL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
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

                if (mfgdate.Text.Trim() == "")
                {
                    errorProvider1.SetError(mfgdate, "Select Manufacturing Date");
                    return;
                }

                if (expiry.Text.Trim() == "")
                {
                    errorProvider1.SetError(expiry, "Select Manufacturing Date");
                    return;
                }
                if (cboPrinter.Text.Trim() == "" || cboPrinter.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPrinter, "Please Select Printer");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                strPrinterName = (cboPrinter.Text.Trim() == "Select" ? "" : cboPrinter.Text);
                DialogResult ds = MessageBox.Show("Do you really want to save this Transaction", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ds == DialogResult.Yes)
                {
                    string strMessgae = "";
                    int serialcount = 1;
                    int txtQtyvalue  = int.Parse(txtQty.Text);
                    for (int i = 0; i < txtQtyvalue; i++)
                    {

                        string strDate = DateTime.ParseExact(mfgdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                        string serialno = strDate.ToString() + txtPackSize.Text.Trim() + "000" + serialcount++;

                        dtgDtl.Rows.Add();
                        rowindex = dtgDtl.Rows.Count;

                        dtgDtl.Rows[rowindex - 1].Cells[0].Value = cboPlant.Text.Trim();
                        dtgDtl.Rows[rowindex - 1].Cells[1].Value = cboGTIN.Text;
                        dtgDtl.Rows[rowindex - 1].Cells[2].Value = cboProduct.Text.Trim();
                        dtgDtl.Rows[rowindex - 1].Cells[3].Value = serialno;
                        dtgDtl.Rows[rowindex - 1].Cells[4].Value = txtPackSize.Text.Trim();
                        dtgDtl.Rows[rowindex - 1].Cells[5].Value = mfgdate.Text;
                        dtgDtl.Rows[rowindex - 1].Cells[6].Value = txtQty.Text;



                        dtPrint = new DataTable();
                        //objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();
                        //objPL_Prnt.iPrintQty = iRem;
                        //objPL_Prnt.strPackLevel = txtPackSize.Text.Trim();
                        //objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                        //objPL_Prnt.strPlantCode = cboPlant.Text;

                        //dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                        strMessgae = objGeny.BL_ShipperSaveData(dtgDtl.Rows[rowindex - 1].Cells[0].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[1].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[2].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[3].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[4].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[5].Value.ToString(), dtgDtl.Rows[rowindex - 1].Cells[6].Value.ToString());
                        // btnRefresh_Click(sender, e);
                        string strPrinter = cboPrinter.Text.Trim();
                        string strPRN = "ShipperLabel";

                        iPrint = PrintDirect.PrintShipperlabel(strPrinter, cboGTIN.Text, serialno, cboProduct.Text.Trim(), mfgdate.Text, expiry.Text, strPRN);
                       objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Shipper Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                   
                    }
                    txtQty.Text = "";
                    txtQty.Enabled = true;

                    Clear(true);
                    if (strMessgae != "")
                    {
                        iHet = 0;
                        dtgDtl.Rows.Clear();
                        MessageBox.Show(strMessgae.ToString());
                        frmSipperLevel_Load(sender, e);

                    }
                   
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
                    dt.Columns.Add("PLANT", typeof(string));
                    dt.Columns.Add("GTIN_ID", typeof(string));
                    dt.Columns.Add("PROD_DESC1", typeof(string));
                    dt.Columns.Add("SerialNo", typeof(string));
                    dt.Columns.Add("PACK_SIZE", typeof(int));
                    
                    dt.Columns.Add("MFG_DATE", typeof(string));
                                                          
                    dt.Columns.Add("LabelCount", typeof(int));
                    // dt.Columns.Add("SerialNo", typeof(string));
                   

                    DataRow dr;

                    foreach (DataGridViewRow dr1 in dtgDtl.Rows)
                    {
                        dr = dt.NewRow();
                        dr[0] = dr1.Cells[0].Value.ToString();
                        dr[1] = dr1.Cells[1].Value.ToString();
                        dr[2] = dr1.Cells[2].Value.ToString();
                        dr[3] = dr1.Cells[3].Value.ToString();
                        dr[4] = Convert.ToInt32(dr1.Cells[4].Value.ToString());
                        dr[5] = dr1.Cells[5].Value.ToString();
                        dr[6] = Convert.ToInt32(dr1.Cells[6].Value.ToString());
                       

                        dt.Rows.Add(dr);
                        dt.AcceptChanges();



                    }

                  //  strMessgae = objGen.BL_ShipperSaveData(dt[0], PL_Login.UserID, cboPlant.Text);
                   strMessgae = objGen.BL_ShipperSaveDataDt(dt, PL_Login.UserID, cboPlant.Text);
                    objLog.WriteErrorLog(this.Name.ToString(), "btnRefresh_Click", "Success", strMessgae, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    if (strMessgae != "")
                    {
                        iHet = 0;
                        dtgDtl.Rows.Clear();
                        MessageBox.Show(strMessgae.ToString());
                        frmSipperLevel_Load(sender, e);
                      
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

       

        //private void cboLabelType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataSet dsLine = new DataSet();
        //    DataTable dt = new DataTable();
        //    BL_LogWriter objLog = new BL_LogWriter();
        //    try
        //    {
        //        if (cboLabelType.Text != "Select")
        //        {
        //            objGen = new BL_Generator();
        //            objPLGen = new PL_Generator();
        //            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
        //            objPLGen.strPackLevel = cboPacking.Text;
        //            objPLGen.strLableType = cboLabelType.Text;

        //            cboLine.Items.Clear();
        //            cboLine.Items.Add("Select");


        //            dsLine = objGen.BLGetLineInfo(objPLGen, cboPlant.Text);

        //            if (dsLine.Tables[0].Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
        //                {
        //                    cboLine.Items.Add(dsLine.Tables[0].Rows[i][0].ToString());
        //                }
        //                cboLine.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                cboLine.SelectedIndex = 0;
        //            }

        //            if (cboLabelType.Text == "Heterogeneous")
        //            {
        //                cboERP.Items.Clear();
        //                cboERP.Items.Add("Select");
        //                dt = objGen.BLGetBatchERP("");
        //                if (dt.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < dt.Rows.Count; i++)
        //                    {
        //                        cboERP.Items.Add(dt.Rows[i][0].ToString());
        //                    }
        //                }
        //                if (cboERP.Items.Count > 1)
        //                {
        //                    cboERP.SelectedIndex = 1;
        //                }
        //                else
        //                {
        //                    cboERP.SelectedIndex = 0;
        //                }
        //            }
                   

        //        }
        //        else
        //        {
        //            cboLine.Items.Clear();
        //            cboLine.Items.Add("Select");
        //            cboLine.SelectedIndex = 0;
        //        }

        //        VisibleBatch(cboLabelType.Text);



        //    }
        //    catch (Exception ex)
        //    {
        //        objLog.WriteErrorLog(this.Name.ToString(), "cboLabelType_SelectedValueChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        objPLGen = null;
        //        objGen = null;
        //        dt = null;
        //    }
        //}

        


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

                
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                           // cboBatch.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                  //  cboBatch.SelectedIndex = 0;
                }
                else
                {
                    //cboBatch.Items.Clear();
                    //cboBatch.Items.Add("Select");
                    //cboBatch.SelectedIndex = 0;
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

        //private void cboBatch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BL_LogWriter objLog = new BL_LogWriter();
        //    DataTable dt = new DataTable();
        //    objGen = new BL_Generator();
        //    try
        //    {
        //        if (cboBatch.Text != "Select")
        //        {
        //            cboERP.Items.Clear();
        //            cboERP.Items.Add("Select");
        //            dt = objGen.BLGetBatchERP(cboBatch.Text.Trim());
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    cboERP.Items.Add(dt.Rows[i][0].ToString());
        //                }
        //            }
        //            if (cboERP.Items.Count > 1)
        //            {
        //                cboERP.SelectedIndex = 1;
        //            }
        //            else
        //            {
        //                cboERP.SelectedIndex = 0;
        //            }

                    
        //        }
        //        else
        //        {
        //            cboERP.Items.Clear();
        //            cboERP.Items.Add("Select");
        //            cboERP.SelectedIndex = 0;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        objLog.WriteErrorLog(this.Name.ToString(), "cboBatch_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        objLog = null;
        //        dt = null;
        //    }


        //}

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
