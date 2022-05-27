using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using System.Management;
using System.Threading;
using PropertyLayer;
using System.Net;
using System.Net.Sockets;
using PC_Application.Scanning;
using System.IO;
using System.Globalization;

namespace PC_Application.Transaction
{
    public partial class frmPrinting : Form
    {
        BL_Printing objBL_Prnt;
        BL_Generator objGen;
        PL_Printing objPL_Prnt;
        string strPrinterName = "", strLabelType = "", strprintMethod = "", strLabelSize = "", strPrintN = "";
        string strPRN = "", strIP = "", strprintFile = "";
        int iPort = 0;

        public frmPrinting()
        {
            InitializeComponent();
        }

        #region "Functions"

        public void Clear()
        {
            //cboPlant.Items.Clear();
            cboPackLvl.Items.Clear();
            cboLinecode.Items.Clear();
            cboLabeltype.Items.Clear();
            cboLabelSize.Items.Clear();
            lstView.Items.Clear();
            cboBrandname.Items.Clear();
            cboBatchno.Items.Clear();
            txtNoOfLbl.Text = "";
        }

        #endregion

        private void frmPrinting_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            BL_LogWriter objLog = new BL_LogWriter();
            string str = "";
            string[] strPlantCode;
            lstView.Items.Clear();
            DataTable dt = new DataTable();
            DataTable dtPack = new DataTable();
            try
            {
                objBL_Prnt = new BL_Printing();
                objGen = new BL_Generator();
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                dt = objBL_Prnt.BL_GetPrintMethod();
                str = objBL_Prnt.BLGetPlantLogin(PL_Login.UserID);


                cboPlant.Items.Clear();
                cboPlant.Items.Add("Select");
                if (str != "")
                {

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

                    //if (PL_Login.PlantCode == "MultiPlant" || PL_Login.PlantCode == "All Plant")
                    //{
                    //    cboPlant.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    cboPlant.SelectedIndex = 1;
                    //}
                }

                dtPack = objGen.BLGetPackLevel();
                cboPackLvl.Items.Clear();
                cboPackLvl.Items.Add("Select");
                if (dtPack.Rows.Count > 0)
                {

                    for (int i = 0; i < dtPack.Rows.Count; i++)
                    {
                        cboPackLvl.Items.Add(dtPack.Rows[i]["PACKING_LEVEL"].ToString());
                    }

                }
                cboPackLvl.SelectedIndex = 0;

                cboPrintMethod.Items.Clear();
                cboPrintMethod.Items.Add("Select");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboPrintMethod.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
                cboPrintMethod.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmPrinting_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
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
        //            cboPackLvl.Items.Clear();
        //            cboPackLvl.Items.Add("Select");
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    cboPackLvl.Items.Add(dt.Rows[i][0].ToString());
        //                }
        //            }
        //        }
        //        else
        //        {
        //            cboPackLvl.Items.Clear();
        //            cboPackLvl.Items.Add("Select");
        //        }

        //        cboPackLvl.SelectedIndex = 0;
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

        private void cboPackLvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
            DataSet ds = new DataSet();
            try
            {
                if (cboPackLvl.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPackLvl.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                    ds = objBL_Prnt.BL_GetPrntLineNo(objPL_Prnt);
                    cboLinecode.Items.Clear();
                    cboLinecode.Items.Add("Select");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            cboLinecode.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                    }


                    cboLabeltype.Items.Clear();
                    cboLabeltype.Items.Add("Select");

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            cboLabeltype.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                        }
                    }
                }
                else
                {
                    cboLinecode.Items.Clear();
                    cboLinecode.Items.Add("Select");
                    cboLabeltype.Items.Clear();
                    cboLabeltype.Items.Add("Select");
                }
                cboLinecode.SelectedIndex = 0;
                cboLabeltype.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboPackLvl_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                ds = null;
                objLog = null;
            }
        }

        private void cboLinecode_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();
            DataTable dt_Prod = new DataTable();
            DataTable dt_Batch = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                if (cboLinecode.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPackLvl.Text;
                    objPL_Prnt.strLineNo = cboLinecode.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    ds = objBL_Prnt.BL_GetPrntConfig(objPL_Prnt);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cboLabeltype.SelectedItem = ds.Tables[0].Rows[0][0].ToString();
                        cboPrintMethod.SelectedItem = ds.Tables[0].Rows[0][1].ToString();
                    }
                    else
                    {
                        cboLabeltype.SelectedIndex = 0;
                        cboPrintMethod.SelectedIndex = 0;
                    }

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



                    cboBrandname.Items.Clear();
                    cboBrandname.Items.Add("Select");


                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            cboBrandname.Items.Add(ds.Tables[2].Rows[i][0].ToString());
                        }
                    }

                    cboBatchno.Items.Clear();
                    cboBatchno.Items.Add("Select");

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            cboBatchno.Items.Add(ds.Tables[3].Rows[i][0].ToString());
                        }
                    }

                }
                else
                {
                    cboBrandname.Items.Clear();
                    cboBrandname.Items.Add("Select");
                    cboBatchno.Items.Clear();
                    cboBatchno.Items.Add("Select");
                    lstView.Items.Clear();
                    cboPrinter.Items.Clear();
                    cboPrinter.Items.Add("Select");
                    cboPrinter.SelectedIndex = 0;
                    if (cboPrintMethod.Items.Count > 0)
                    {
                        cboPrintMethod.SelectedIndex = 0;
                    }

                }

                cboBrandname.SelectedIndex = 0;
                cboBatchno.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboLinecode_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                objLog = null;
                dt_Batch = null;
                dt_Prod = null;
            }

        }

        public bool ValidatePrint(string strPrintmethd, string strprinter, string strType, string strLabelSize)
        {
            DataSet dtPrintConfig = new DataSet();
            BL_LogWriter objLog = new BL_LogWriter();
            bool bFlag = true;
            try
            {

                if (strPrintmethd == "")
                {
                    errorProvider1.SetError(cboPrintMethod, "Printer Method is not Selected");
                    bFlag = false;
                }
                if (strPrintmethd == "Direct Thermal")
                {
                    if (strprinter == "")
                    {
                        errorProvider1.SetError(cboPrinter, "Printer Name is not Selected");
                        bFlag = false;
                    }
                    if (strType == "")
                    {
                        errorProvider1.SetError(cboLabeltype, "Label Type is not selected");
                        bFlag = false;
                    }
                    if (strLabelSize == "")
                    {
                        errorProvider1.SetError(cboLabelSize, "Label Size is not selected");
                        bFlag = false;
                    }

                }
                else if (strPrintmethd == "Offline")
                {
                    if (strType == "")
                    {
                        errorProvider1.SetError(cboLabeltype, "Label Type is not selected");
                        bFlag = false;
                    }
                }


                objBL_Prnt = new BL_Printing();
                objPL_Prnt = new PL_Printing();
                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                objPL_Prnt.strPrinterPk = (cboPrinter.Text.Contains("|") ? cboPrinter.Text.Split('|').GetValue(0).ToString() : cboPrinter.Text.Trim());
                objPL_Prnt.strLabelSize = cboLabelSize.Text;
                objPL_Prnt.strLabelType = cboLabeltype.Text;
                objPL_Prnt.strPackLevel = (cboPackLvl.Text == "Select" ? "" : cboPackLvl.Text);
                objPL_Prnt.strLineNo = (cboLinecode.Text == "Select" ? "" : cboLinecode.Text);

                dtPrintConfig = objBL_Prnt.BL_GetPrnPortIP(objPL_Prnt);

                if (dtPrintConfig.Tables[0].Rows.Count > 0)
                {
                    strIP = dtPrintConfig.Tables[0].Rows[0][0].ToString();

                    if (dtPrintConfig.Tables[0].Rows[0][1].ToString() == "")
                    {
                        iPort = 0;
                    }
                    else
                    {
                        iPort = Convert.ToInt32(dtPrintConfig.Tables[0].Rows[0][1].ToString());
                    }
                }


                if (strPrintmethd == "Online")
                {
                    if (strIP.ToString() == "" || iPort == 0)
                    {
                        errorProvider1.SetError(cboPrinter, "Printer's IP or Port is not Configured");
                        bFlag = false;
                    }

                    if (dtPrintConfig.Tables[2].Rows.Count > 0)
                    {
                        strprintFile = dtPrintConfig.Tables[2].Rows[0][0].ToString();

                        if (strprintFile == "")
                        {
                            strprintFile = "Common.00I";
                        }
                    }
                    else
                    {
                        strprintFile = "Common.00I";
                    }
                }
                else if (strPrintmethd == "Direct Thermal")
                {

                    if (dtPrintConfig.Tables[1].Rows.Count > 0)
                    {
                        strPRN = dtPrintConfig.Tables[1].Rows[0][0].ToString();

                        if (strPRN == "")
                        {
                            errorProvider1.SetError(cboLabelSize, "PRN File is not Configured for Selected Label Size and Type");
                            bFlag = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(cboLabelSize, "PRN File is not Configured for Selected Label Size and Type");
                        bFlag = false;
                    }
                    //errorProvider1.SetError(cboPrinter, "Selected Printer is not Online");
                    //bFlag = false;
                }


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "ValidatePrint", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objBL_Prnt = null; objLog = null;
            }
            return bFlag;

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (cboPlant.Text.Trim() == "" || cboPlant.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPlant, "Please Select Plant Code");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPackLvl.Text.Trim() == "" || cboPackLvl.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPackLvl, "Please Select Packing Level");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboLinecode.Text.Trim() == "" || cboLinecode.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboLinecode, "Please Select Line No");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPrintMethod.Text.Trim() == "" || cboPrintMethod.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPrintMethod, "Please Select Print Method");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPrintMethod.Text == "Direct Thermal")
                {
                    if (cboLabelSize.Text.Trim() == "" || cboLabelSize.Text.Trim() == "Select")
                    {
                        errorProvider1.SetError(cboLabelSize, "Please Select Label Size");
                        return;
                    }
                    else
                    {
                        errorProvider1.Dispose();
                    }

                    if (cboLabeltype.Text.Trim() == "" || cboLabeltype.Text.Trim() == "Select")
                    {
                        errorProvider1.SetError(cboLabeltype, "Please Select Label Type");
                        return;
                    }
                    else
                    {
                        errorProvider1.Dispose();
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
                }

                strprintMethod = (cboPrintMethod.Text.Trim() == "Select" ? "" : cboPrintMethod.Text);
                strPrinterName = (cboPrinter.Text.Trim() == "Select" ? "" : cboPrinter.Text);

                strLabelType = (cboLabeltype.Text.Trim() == "Select" ? "" : cboLabeltype.Text);
                strLabelSize = (cboLabelSize.Text.Trim() == "Select" ? "" : cboLabelSize.Text);


                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                objPL_Prnt.strPlantCode = cboPlant.Text;
                objPL_Prnt.strPackLevel = cboPackLvl.Text;
                objPL_Prnt.strLineNo = cboLinecode.Text;
                objPL_Prnt.strProdName = cboBrandname.Text;
                objPL_Prnt.strBatchNo = cboBatchno.Text;

                dt = objBL_Prnt.BL_GetPrntData(objPL_Prnt);
                lstView.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem Litem = new ListViewItem(dt.Rows[i][0].ToString());
                        Litem.SubItems.Add(dt.Rows[i][1].ToString());
                        Litem.SubItems.Add(dt.Rows[i][2].ToString());
                        Litem.SubItems.Add(dt.Rows[i][3].ToString());
                        Litem.SubItems.Add(dt.Rows[i][4].ToString());
                        Litem.SubItems.Add(dt.Rows[i][5].ToString());
                        Litem.SubItems.Add(dt.Rows[i][6].ToString());
                        Litem.SubItems.Add(dt.Rows[i][7].ToString());
                        Litem.SubItems.Add(dt.Rows[i][8].ToString());
                        Litem.SubItems.Add(dt.Rows[i][9].ToString());
                        lstView.Items.Add(Litem);
                    }
                }
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnGetData_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
                objPL_Prnt = null;
                //objBL_Prnt = null;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            int iList = 0;
            int iRem = 0;
            Cursor.Current = Cursors.WaitCursor;
            ListViewItem li = new ListViewItem();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (lstView.Items.Count > 0)
                {
                    if (txtNoOfLbl.Text == "" || Convert.ToInt32(txtNoOfLbl.Text) <= 0)
                    {
                        MessageBox.Show("Enter Valid Print Qty");
                        return;
                    }

                    if (ValidatePrint(cboPrintMethod.Text, strPrinterName, strLabelType, strLabelSize) == true)
                    {
                        if (strPrinterName.Contains('|') == true)
                        {
                            strPrintN = strPrinterName.Split('|').GetValue(1).ToString();
                        }
                        else
                        {
                            strPrintN = strPrinterName;
                        }

                        for (int i = 0; i < lstView.Items.Count; i++)
                        {
                            if (lstView.Items[i].Checked == true)
                            {

                                if (Convert.ToInt32(txtNoOfLbl.Text) <= Convert.ToInt32(lstView.Items[i].SubItems[6].Text.ToString()))
                                {
                                    if (cboPackLvl.Text == "Tertiary")
                                    {
                                        if (Convert.ToInt32(txtNoOfLbl.Text) > 2)
                                        {
                                            iRem = Convert.ToInt32(txtNoOfLbl.Text) - 2;
                                        }
                                    }
                                    else if (cboPackLvl.Text == "Secondary 1" || cboPackLvl.Text == "Secondary 2" || cboPackLvl.Text == "Secondary 3" || cboPackLvl.Text == "Secondary 4")
                                    {
                                        if (Convert.ToInt32(txtNoOfLbl.Text) > 3)
                                        {
                                            iRem = Convert.ToInt32(txtNoOfLbl.Text) - 3;
                                        }

                                    }
                                    li = lstView.Items[i];
                                    iList++;
                                    break;

                                }
                                else
                                {
                                    MessageBox.Show("Print Qty is greater than balance qty");
                                    txtNoOfLbl.Focus();
                                    return;
                                }


                            }
                        }
                        if (li.SubItems.Count > 0 && iList > 0)
                        {
                            objBL_Prnt = new BL_Printing();
                            objPL_Prnt = new PL_Printing();
                            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                            if (iRem > 0 && cboPrintMethod.Text == "Direct Thermal")
                            {
                                objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();

                                if (cboPackLvl.Text == "Tertiary")
                                {
                                    objPL_Prnt.iPrintQty = 2;
                                }
                                else if (cboPackLvl.Text == "Secondary 1" || cboPackLvl.Text == "Secondary 2" || cboPackLvl.Text == "Secondary 3" || cboPackLvl.Text == "Secondary 4")
                                {
                                    objPL_Prnt.iPrintQty = 3;
                                }
                                objPL_Prnt.strPackLevel = cboPackLvl.Text;
                                objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                                objPL_Prnt.strPlantCode = cboPlant.Text;

                                dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                                objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo + "/going for verfication", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                PrintData(cboPrintMethod.Text, strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);

                                DialogResult ds= MessageBox.Show("Packing Level : " + cboPackLvl.Text.Trim() + "\nGTIN : " + li.SubItems[1].Text.ToString() + "\nBatch : "+ li.SubItems[3].Text.ToString() + "\nStart SR No. : " + dtPrint.Rows[0][0].ToString(),"Verify Printing",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);

                                if (DialogResult.OK == ds)
                                {
                                    dtPrint = new DataTable();
                                    objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();
                                    objPL_Prnt.iPrintQty = iRem;
                                    objPL_Prnt.strPackLevel = cboPackLvl.Text;
                                    objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                                    objPL_Prnt.strPlantCode = cboPlant.Text;

                                    dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                                    objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click/OK", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo + "/priting verification done", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                    PrintData(cboPrintMethod.Text, strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);

                                    lblLabel.Text = txtNoOfLbl.Text + " No Of Labels Printed Successfully";
                                }
                                else
                                {
                                    BL_Scanning objScan = new BL_Scanning();
                                   
                                    if (cboPackLvl.Text == "Tertiary")
                                    {
                                        for (int k = 0; k < dtPrint.Rows.Count; k++)
                                        {
                                            objScan.BL_UpdateReject(dtPrint.Rows[k][0].ToString(), "T", PL_Login.UserID, PL_Login.PlantCode);
                                        }
                                    }
                                    else if(cboPackLvl.Text=="Secondary 1" || cboPackLvl.Text== "Secondary 2" || cboPackLvl.Text== "Secondary 3" || cboPackLvl.Text== "Secondary 4")
                                    {
                                        for (int k = 0; k < dtPrint.Rows.Count; k++)
                                        {
                                            objScan.BL_UpdateReject(dtPrint.Rows[k][0].ToString(), "S", PL_Login.UserID, PL_Login.PlantCode);
                                        }
                                    }

                                    objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click/Cancel", "Success", "Barcode Rejected Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                    lblLabel.Text = dtPrint.Rows.Count.ToString() + " No Of Labels Cancelled Successfully";
                                    dtPrint = null; objScan = null;
                                }

                            }
                            else
                            {
                                objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();
                                objPL_Prnt.iPrintQty = Convert.ToInt32(txtNoOfLbl.Text);
                                objPL_Prnt.strPackLevel = cboPackLvl.Text;
                                objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                                objPL_Prnt.strPlantCode = cboPlant.Text;

                                dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                                objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                PrintData(cboPrintMethod.Text, strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);
                            }

                            //if (cboPrintMethod.Text == "Online")
                            //{
                            //    MessageBox.Show("Database Created Successfully. \nStart Online Scanning screen using below step \n\n\nStep: \nScanning Menu -> Online Scanning");
                            //    //frmOnlineScanning1 objos = new frmOnlineScanning1();
                            //    //objos.lblLine.Text = cboLinecode.Text.Trim();
                            //    //objos.ShowDialog();
                            //    System.Diagnostics.Process.Start("Barcode Printing.exe");
                            //    this.Close();
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Select Record for printing");
                            return;
                        }
                        btnGetData_Click(sender, e);
                        txtNoOfLbl.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                li = null;
                objBL_Prnt = null;
                Cursor.Current = Cursors.Default;
                objLog = null;
                objPL_Prnt = null;
            }

        }

        private void cboPrinter_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPrinter.Text == "Select")
                {
                    ChangeAvailble(0);
                }
                else
                {
                    if (cboPrintMethod.Text == "Select")
                    {
                        errorProvider1.SetError(cboPrintMethod, "Select Printer Name");
                        cboPrintMethod.Focus();
                        return;
                    }
                    if (cboPrintMethod.Text == "Direct Thermal")
                    {
                        if (cboPrinter.Text.Contains("|") == true)
                        {
                            if (CheckConnectivity(cboPrinter.Text.Split('|').GetValue(1).ToString()) == true)
                            {
                                ChangeAvailble(1);
                            }
                            else
                            {
                                ChangeAvailble(2);
                            }
                        }
                        else
                        {
                            if (CheckConnectivity(cboPrinter.Text) == true)
                            {
                                ChangeAvailble(1);
                            }
                            else
                            {
                                ChangeAvailble(2);
                            }
                        }
                    }
                    else if (cboPrintMethod.Text == "Offline")
                    {
                        ChangeAvailble(2);
                    }
                    else
                    {
                        ChangeAvailble(0);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ChangeAvailble(int bFlag)
        {
            if (bFlag == 0)
            {
                lblAvailable.Text = "Availibility - No Status";
                lblAvailable.BackColor = Color.Blue;
            }
            else if (bFlag == 1)
            {
                lblAvailable.Text = "Availibility - Online";
                lblAvailable.BackColor = Color.Green;
            }
            else if (bFlag == 2)
            {
                lblAvailable.Text = "Availibility - Offline";
                lblAvailable.BackColor = Color.Red;
            }
        }

        private bool CheckConnectivity(string strPrinter)
        {
            bool bFlag = false;
            try
            {
                ManagementScope scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();

                // Select Printers from WMI Object Collections
                ManagementObjectSearcher searcher = new
                 ManagementObjectSearcher("SELECT * FROM Win32_Printer");

                string printerName = "";
                foreach (ManagementObject printer in searcher.Get())
                {
                    printerName = printer["Name"].ToString().ToLower();
                    if (printerName.Equals(strPrinter.ToLower()))
                    {
                        Console.WriteLine("Printer = " + printer["Name"]);
                        if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                        {
                            // printer is offline by user
                            //Console.WriteLine("Your Plug-N-Play printer is not connected.");
                            bFlag = false;
                        }
                        else
                        {
                            bFlag = true;
                            // printer is not offline
                            //Console.WriteLine("Your Plug-N-Play printer is connected.");
                        }
                        break;

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return bFlag;
        }

        private void bw_Print_DoWork(object sender, DoWorkEventArgs e)
        {
            tmPrint.Enabled = false;
            Thread.Sleep(1000);
            lblLabel.Text = "Print Label Processing..";
            DataTable dt_Temp = new DataTable();
            try
            {

            }
            catch (Exception ex)
            {

            }

        }

        private void bw_Print_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else if (e.Error != null)
            {

            }
            else
            {
                lblLabel.Text = "Label Printed Successfully";
            }
            tmPrint.Enabled = true;
        }

        private void tmPrint_Tick(object sender, EventArgs e)
        {
            bw_Print.RunWorkerAsync(1000);
        }

        private void cboLabeltype_SelectedValueChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (cboLabeltype.Text != "Select" && cboPackLvl.Text != "Select")
                {
                    objPL_Prnt.strLabelType = cboLabeltype.Text;
                    objPL_Prnt.strPackLevel = cboPackLvl.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                    dt = objBL_Prnt.BL_GetLabelSize(objPL_Prnt);
                    cboLabelSize.Items.Clear();
                    cboLabelSize.Items.Add("Select");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboLabelSize.Items.Add(dt.Rows[i][0].ToString());
                        }
                        cboLabelSize.SelectedIndex = 1;
                    }
                    else
                    {
                        cboLabelSize.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboLabelSize.Items.Clear();
                    cboLabelSize.Items.Add("Select");
                    cboLabelSize.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboLabeltype_SelectedValueChanged", "Error", ex.Message, "PC Client", PL_Login.UserID,PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objBL_Prnt = null; objPL_Prnt = null; objLog = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmPrinting_Load(sender, e);
        }

        private void lstView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (ListViewItem li in lstView.Items)
            {
                if (e.Index != li.Index)
                {
                    li.Checked = false;
                }

            }

        }

        private void PrintData(string strMethod, string strLbType, string strIP, string strPRN, int iPORT, string strPrntFileName, string strPrinter, DataTable dt, ListViewItem li)
        {
            int iPrint = 0;
            BL_LogWriter objLog = new BL_LogWriter();
            string strOnlineExp = "";
            try
            {

                string strGTIN = li.SubItems[1].Text.ToString();
                string strBatch = li.SubItems[3].Text.ToString();
                string strProduct = li.SubItems[2].Text.ToString();
                string strpacksize = li.SubItems[7].Text.ToString();



                //DateTime tempExp = DateTime.ParseExact(li.SubItems[9].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //string strExp = Convert.ToDateTime(li.SubItems[9].Text.ToString()).ToString("MMM/dd/yyyy");

                //string strExp = DateTime.ParseExact(li.SubItems[9].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();

                string strExp = li.SubItems[9].Text.ToString();

                string strMfg = li.SubItems[8].Text.ToString();

                //string strMfg = Convert.ToDateTime(li.SubItems[8].Text.ToString()).ToString("MMM/dd/yyyy");

                //string strMfg= DateTime.ParseExact(li.SubItems[8].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();

                if (strMethod == "Online")
                {
                    if (!System.IO.Directory.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT")))
                    {
                        System.IO.Directory.CreateDirectory(DataLayer.clsDb.GetGlobleDetails("DBPRINT"));
                    }

                    if (System.IO.File.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml") == true)
                    {
                        try
                        {
                            System.IO.File.Delete(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml");
                        }
                        catch { }
                    }

                    System.IO.StreamWriter sw = new System.IO.StreamWriter(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\"+"Database.csv", false);
                   // System.IO.StreamWriter sw = new System.IO.StreamWriter(PC_Application.Properties.Settings.Default.filepath.ToString(), false);

                    DataTable dt_Database = new DataTable(); dt_Database.TableName = "MetaData";
                    dt_Database.Columns.Add("GTIN", typeof(string));
                    dt_Database.Columns.Add("BATCH", typeof(string));
                    dt_Database.Columns.Add("EXPIRY", typeof(string));
                    dt_Database.Columns.Add("SERIAL", typeof(string));
                    //dt_Database.Columns.Add("EXPIN2D", typeof(string));
                    dt_Database.Columns.Add("EXPINBARCD", typeof(string));
                    dt_Database.Columns.Add("MFGD", typeof(string));

                    string strMonth = strExp.Split('/').GetValue(0).ToString();
                    string strDay = strExp.Split('/').GetValue(1).ToString();
                    string strYear = strExp.Split('/').GetValue(2).ToString();

                    string strMMonth = strMfg.Split('/').GetValue(0).ToString();
                    string strMDay = strMfg.Split('/').GetValue(1).ToString();
                    string strMYear = strMfg.Split('/').GetValue(2).ToString();

                    //strOnlineExp = strDay+"/"+strMonth + "/" + strYear;  //old 07/22
                    strOnlineExp = strMonth + "/" + strYear;

                    clsFile.SetGlobleDetails_Scan("IPADD", strIP.Trim());
                    clsFile.SetGlobleDetails_Scan("LABEL", strPrntFileName.Trim());

                    //IPAddress address = System.Net.IPAddress.Parse(strIP);

                    //byte[] data = new byte[1024];
                    //IPEndPoint ipep = new IPEndPoint(address, iPORT);
                    //Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //newsock.Connect(ipep);
                    //Socket client = newsock;
                    //IPEndPoint clienttep = (IPEndPoint)client.RemoteEndPoint;
                    //List<byte> result = new List<byte>();
                    sw.WriteLine("gtin,expiry,expiry,serial,MFGD");

                    foreach (DataRow dr in dt.Rows) //change 
                    {
                        DataRow dr_Line = dt_Database.NewRow();
                        dr_Line["GTIN"] = strGTIN.Trim();
                        dr_Line["BATCH"] = strBatch;
                        dr_Line["EXPIRY"] = strOnlineExp;
                        dr_Line["SERIAL"] = dr[0].ToString();
                        //dr_Line["EXPIN2D"] = Convert.ToString(strMonth + strYear);
                        dr_Line["EXPINBARCD"] = Convert.ToString(strMonth + strYear);
                      //  dr_Line["MFGD"] = Convert.ToString(strMDay+"/"+strMMonth + "/" + strMYear);
                        dr_Line["MFGD"] = Convert.ToString( strMMonth + "/" + strMYear);   //07/22

                        dt_Database.Rows.Add(dr_Line);
                        dt_Database.AcceptChanges();
                        sw.WriteLine(strGTIN + "," + strExp + "," + strBatch + "," + dr[0].ToString() + ","+strMfg);
                        //result.Add(0x02);
                        ////result.AddRange(Encoding.ASCII.GetBytes("TZShalina.00I;10").ToList());
                        //result.AddRange(Encoding.ASCII.GetBytes("TZ" + strPrntFileName.Trim() + ";10").ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strGTIN).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strOnlineExp).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strBatch).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(dr[0].ToString()).ToList());
                        //result.Add(0x0D);
                        //result.Add(0x03);
                    }

                    //result.Add(0x1B);
                    //result.AddRange(Encoding.ASCII.GetBytes("*").ToList());
                    //result.Add(0x0D);

                    //client.Send(result.ToArray(), SocketFlags.None);
                    //data = new byte[1024];

                    //int iLen1 = client.Receive(data);
                    ////return iLen1.ToString();

                    sw.Close();
                    sw = null;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt_Database);
                    ds.WriteXml(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml");
                    //WriteToCsvFile(dt_Database,"D:\\Nirav\\Test.csv");
                    ds = null;


                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "\\SysConfig.xml");
                    xmlDoc.SelectSingleNode("NewDataSet/TBLCONFIG/PRINTINDEX").InnerText = "0";
                    xmlDoc.Save(Application.StartupPath + "\\SysConfig.xml");

                    System.Diagnostics.Process.Start("Barcode Printing.exe");
                  

                }
                else if (strMethod == "Direct Thermal")
                {
                    if (strLbType == "Homogeneous")
                    {
                        iPrint = PrintDirect.PrintTertiaryHomo(strPrinter, dt, strGTIN, strProduct, strBatch, strpacksize, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Homogeneous Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    else if (strLbType == "Heterogeneous")
                    {
                        iPrint = PrintDirect.PrintTertiaryHetro(strPrinter, dt, strGTIN, strProduct, strBatch, strpacksize, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Heterogeneous Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    else if (strLbType == "One Up")
                    {
                        iPrint = PrintDirect.PrintSecOneUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (One Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    else if (strLbType == "Two Up")
                    {
                        iPrint = PrintDirect.PrintSecOneUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Two Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    else if (strLbType == "Three Up")
                    {
                        iPrint = PrintDirect.PrintSecThreeUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Three Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    else if (strLbType == "Four Up")
                    {
                        iPrint = PrintDirect.PrintSecFourUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Three Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }

                    //lblLabel.Text = iPrint.ToString() + " No Of Labels Printed Successfully";

                    lblLabel.Text = "Labels Printed Successfully";
                }
                else if (strMethod == "Offline")
                {
                    string strFileName = "";
                    try
                    {

                        if (strLbType == "Homogeneous")
                        {
                            strFileName = strLbType;
                        }
                        else if (strLbType == "Heterogeneous")
                        {
                            strFileName = strLbType;
                        }
                        else if (strLbType == "One Up" || strLbType == "Two Up" || strLbType == "Three Up" || strLbType == "Four Up")
                        {
                            strFileName = "Seclbl";
                        }

                        if (strFileName != "")
                        {
                            if (!System.IO.Directory.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT")))
                            {
                                System.IO.Directory.CreateDirectory(DataLayer.clsDb.GetGlobleDetails("DBPRINT"));
                            }

                            if (System.IO.File.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt") == true)
                            {
                                try
                                {
                                    System.IO.File.Delete(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt");
                                }
                                catch { }
                            }

                            System.IO.StreamWriter sw = new System.IO.StreamWriter(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt", false);

                            string strMonth, strYear, strEXP1 = "";
                            strEXP1 = strExp.Split('/').GetValue(2).ToString().Substring(2, 2).ToString() + strExp.Split('/').GetValue(0).ToString() + strExp.Split('/').GetValue(1).ToString();
                            strMonth = strExp.Split('/').GetValue(0).ToString();
                            strYear = strExp.Split('/').GetValue(2).ToString();


                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                sw.WriteLine(strGTIN.Trim() + "#" + strBatch.Trim() + "#" + strMfg + "#" + strEXP1 + "#" + dt.Rows[i][0].ToString());
                            }
                            sw.Close();

                            objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", "File Created Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                            MessageBox.Show("File Created Successfully", "Success");

                            lblLabel.Text = dt.Rows.Count.ToString() + " No Of Barcode generated Successfully";

                        }
                    }
                    catch (Exception ex)
                    {
                        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                        MessageBox.Show("Could not create file", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLog = null;
            }

        }

        private void PrintDataCSV(string strMethod, string strLbType, string strIP, string strPRN, int iPORT, string strPrntFileName, string strPrinter, DataTable dt, ListViewItem li)
        {
            int iPrint = 0;
            BL_LogWriter objLog = new BL_LogWriter();
            string strOnlineExp = "";
            try
            {

                string strGTIN = li.SubItems[1].Text.ToString();
                string strBatch = li.SubItems[3].Text.ToString();
                string strProduct = li.SubItems[2].Text.ToString();
                string strpacksize = li.SubItems[7].Text.ToString();



                //DateTime tempExp = DateTime.ParseExact(li.SubItems[9].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //string strExp = Convert.ToDateTime(li.SubItems[9].Text.ToString()).ToString("MMM/dd/yyyy");

                //string strExp = DateTime.ParseExact(li.SubItems[9].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();

                string strExp = li.SubItems[9].Text.ToString();

                string strMfg = li.SubItems[8].Text.ToString();

                //string strMfg = Convert.ToDateTime(li.SubItems[8].Text.ToString()).ToString("MMM/dd/yyyy");

                //string strMfg= DateTime.ParseExact(li.SubItems[8].Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();

                if (strMethod == "Online")
                {
                    if (!System.IO.Directory.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT")))
                    {
                        System.IO.Directory.CreateDirectory(DataLayer.clsDb.GetGlobleDetails("DBPRINT"));
                    }

                    if (System.IO.File.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml") == true)
                    {
                        try
                        {
                            System.IO.File.Delete(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml");
                        }
                        catch { }
                    }

                    //System.IO.StreamWriter sw = new System.IO.StreamWriter(clsDb.GetGlobleDetails("DBPRINT") + "Database.csv", false);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(PC_Application.Properties.Settings.Default.filepath.ToString(), false);

                    DataTable dt_Database = new DataTable(); dt_Database.TableName = "MetaData";
                    dt_Database.Columns.Add("GTIN", typeof(string));
                    dt_Database.Columns.Add("BATCH", typeof(string));
                    dt_Database.Columns.Add("EXPIRY", typeof(string));
                    dt_Database.Columns.Add("SERIAL", typeof(string));
                    //dt_Database.Columns.Add("EXPIN2D", typeof(string));
                    dt_Database.Columns.Add("EXPINBARCD", typeof(string));
                    dt_Database.Columns.Add("MFGD", typeof(string));

                    string strMonth = strExp.Split('/').GetValue(0).ToString();
                    string strYear = strExp.Split('/').GetValue(2).ToString();

                    string strMMonth = strMfg.Split('/').GetValue(0).ToString();
                    string strMYear = strMfg.Split('/').GetValue(2).ToString();

                    strOnlineExp = strMonth + "/" + strYear;

                    clsFile.SetGlobleDetails_Scan("IPADD", strIP.Trim());
                    clsFile.SetGlobleDetails_Scan("LABEL", strPrntFileName.Trim());

                    //IPAddress address = System.Net.IPAddress.Parse(strIP);

                    //byte[] data = new byte[1024];
                    //IPEndPoint ipep = new IPEndPoint(address, iPORT);
                    //Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //newsock.Connect(ipep);
                    //Socket client = newsock;
                    //IPEndPoint clienttep = (IPEndPoint)client.RemoteEndPoint;
                    //List<byte> result = new List<byte>();
                    sw.WriteLine("GTIN,EXPIRY,BATCH,SERIAL");

                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow dr_Line = dt_Database.NewRow();
                        dr_Line["GTIN"] = strGTIN.Trim();
                        dr_Line["BATCH"] = strBatch;
                        dr_Line["EXPIRY"] = strOnlineExp;
                        dr_Line["SERIAL"] = dr[0].ToString();
                        //dr_Line["EXPIN2D"] = Convert.ToString(strMonth + strYear);
                        dr_Line["EXPINBARCD"] = Convert.ToString(strMonth + strYear);
                        dr_Line["MFGD"] = Convert.ToString(strMMonth + "/" + strMYear);
                        dt_Database.Rows.Add(dr_Line);
                        dt_Database.AcceptChanges();
                        sw.WriteLine(strGTIN + "," + strExp + "," + strBatch + "," + dr[0].ToString());// + "," + strMfg);
                        //result.Add(0x02);
                        ////result.AddRange(Encoding.ASCII.GetBytes("TZShalina.00I;10").ToList());
                        //result.AddRange(Encoding.ASCII.GetBytes("TZ" + strPrntFileName.Trim() + ";10").ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strGTIN).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strOnlineExp).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(strBatch).ToList());
                        //result.Add(0x0D);
                        //result.AddRange(Encoding.ASCII.GetBytes(dr[0].ToString()).ToList());
                        //result.Add(0x0D);
                        //result.Add(0x03);
                    }

                    //result.Add(0x1B);
                    //result.AddRange(Encoding.ASCII.GetBytes("*").ToList());
                    //result.Add(0x0D);

                    //client.Send(result.ToArray(), SocketFlags.None);
                    //data = new byte[1024];

                    //int iLen1 = client.Receive(data);
                    ////return iLen1.ToString();

                    sw.Close();
                    sw = null;

                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dt_Database);
                    //ds.WriteXml(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + "Database.xml");
                    ////WriteToCsvFile(dt_Database,"D:\\Nirav\\Test.csv");
                    //ds = null;


                    //System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    //xmlDoc.Load(Application.StartupPath + "\\SysConfig.xml");
                    //xmlDoc.SelectSingleNode("NewDataSet/TBLCONFIG/PRINTINDEX").InnerText = "0";
                    //xmlDoc.Save(Application.StartupPath + "\\SysConfig.xml");

                    //System.Diagnostics.Process.Start("Barcode Printing.exe");


                }
                //else if (strMethod == "Direct Thermal")
                //{
                //    if (strLbType == "Homogeneous")
                //    {
                //        iPrint = PrintDirect.PrintTertiaryHomo(strPrinter, dt, strGTIN, strProduct, strBatch, strpacksize, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Homogeneous Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }
                //    else if (strLbType == "Heterogeneous")
                //    {
                //        iPrint = PrintDirect.PrintTertiaryHetro(strPrinter, dt, strGTIN, strProduct, strBatch, strpacksize, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Heterogeneous Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }
                //    else if (strLbType == "One Up")
                //    {
                //        iPrint = PrintDirect.PrintSecOneUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (One Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }
                //    else if (strLbType == "Two Up")
                //    {
                //        iPrint = PrintDirect.PrintSecOneUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Two Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }
                //    else if (strLbType == "Three Up")
                //    {
                //        iPrint = PrintDirect.PrintSecThreeUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Three Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }
                //    else if (strLbType == "Four Up")
                //    {
                //        iPrint = PrintDirect.PrintSecFourUP(strPrinter, dt, strGTIN, strBatch, strMfg, strExp, strPRN);
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", iPrint.ToString() + " No Of Secondary (Three Up) Labels Printed Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //    }

                //    //lblLabel.Text = iPrint.ToString() + " No Of Labels Printed Successfully";

                //    lblLabel.Text = "Labels Printed Successfully";
                //}
                //else if (strMethod == "Offline")
                //{
                //    string strFileName = "";
                //    try
                //    {

                //        if (strLbType == "Homogeneous")
                //        {
                //            strFileName = strLbType;
                //        }
                //        else if (strLbType == "Heterogeneous")
                //        {
                //            strFileName = strLbType;
                //        }
                //        else if (strLbType == "One Up" || strLbType == "Two Up" || strLbType == "Three Up" || strLbType == "Four Up")
                //        {
                //            strFileName = "Seclbl";
                //        }

                //        if (strFileName != "")
                //        {
                //            if (!System.IO.Directory.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT")))
                //            {
                //                System.IO.Directory.CreateDirectory(DataLayer.clsDb.GetGlobleDetails("DBPRINT"));
                //            }

                //            if (System.IO.File.Exists(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt") == true)
                //            {
                //                try
                //                {
                //                    System.IO.File.Delete(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt");
                //                }
                //                catch { }
                //            }

                //            System.IO.StreamWriter sw = new System.IO.StreamWriter(DataLayer.clsDb.GetGlobleDetails("DBPRINT") + "\\" + strFileName + ".txt", false);

                //            string strMonth, strYear, strEXP1 = "";
                //            strEXP1 = strExp.Split('/').GetValue(2).ToString().Substring(2, 2).ToString() + strExp.Split('/').GetValue(0).ToString() + strExp.Split('/').GetValue(1).ToString();
                //            strMonth = strExp.Split('/').GetValue(0).ToString();
                //            strYear = strExp.Split('/').GetValue(2).ToString();


                //            for (int i = 0; i < dt.Rows.Count; i++)
                //            {
                //                sw.WriteLine(strGTIN.Trim() + "#" + strBatch.Trim() + "#" + strMfg + "#" + strEXP1 + "#" + dt.Rows[i][0].ToString());
                //            }
                //            sw.Close();

                //            objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Success", "File Created Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //            MessageBox.Show("File Created Successfully", "Success");

                //            lblLabel.Text = dt.Rows.Count.ToString() + " No Of Barcode generated Successfully";

                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        objLog.WriteErrorLog(this.Name.ToString(), "PrintData", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                //        MessageBox.Show("Could not create file", "Error");
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLog = null;
            }

        }

        private void cboPrintMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLabeltype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PC_Application.Startup.MDIMain objMain = new PC_Application.Startup.MDIMain();
            //foreach (Form childform in objMain.MdiChildren)
            //{
            //    if (childform.Name != "frmOnlineScanning")
            //    {
            //        childform.Close();
            //    }
            //}

            //foreach (Form childform in objMain.MdiChildren)
            //{
            //    if (childform.ShowInTaskbar)
            //    {
            //        childform.Focus();
            //        return;
            //    }
            //}

            //this.Close();
            //frmOnlineScanning1 objos = new frmOnlineScanning1();
            //objos.lblLine.Text = cboLinecode.Text.Trim();
            //objos.MdiParent = objMain;
            //objos.Show();
            objMain.mnuOnline.PerformClick();
        }



        public static void WriteToCsvFile(DataTable dataTable, string filePath) 
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns) {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);



            foreach (DataRow dr in dataTable.Rows) {

                foreach (var column in dr.ItemArray) {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());

        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            int iList = 0;
            int iRem = 0;
            Cursor.Current = Cursors.WaitCursor;
            ListViewItem li = new ListViewItem();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (lstView.Items.Count > 0)
                {
                    if (txtNoOfLbl.Text == "" || Convert.ToInt32(txtNoOfLbl.Text) <= 0)
                    {
                        MessageBox.Show("Enter Valid Print Qty");
                        return;
                    }

                    if (ValidatePrint(cboPrintMethod.Text, strPrinterName, strLabelType, strLabelSize) == true)
                    {
                        if (strPrinterName.Contains('|') == true)
                        {
                            strPrintN = strPrinterName.Split('|').GetValue(1).ToString();
                        }
                        else
                        {
                            strPrintN = strPrinterName;
                        }

                        for (int i = 0; i < lstView.Items.Count; i++)
                        {
                            if (lstView.Items[i].Checked == true)
                            {

                                if (Convert.ToInt32(txtNoOfLbl.Text) <= Convert.ToInt32(lstView.Items[i].SubItems[6].Text.ToString()))
                                {
                                    if (cboPackLvl.Text == "Tertiary")
                                    {
                                        if (Convert.ToInt32(txtNoOfLbl.Text) > 2)
                                        {
                                            iRem = Convert.ToInt32(txtNoOfLbl.Text) - 2;
                                        }
                                    }
                                    else if (cboPackLvl.Text == "Secondary 1" || cboPackLvl.Text == "Secondary 2" || cboPackLvl.Text == "Secondary 3" || cboPackLvl.Text == "Secondary 4")
                                    {
                                        if (Convert.ToInt32(txtNoOfLbl.Text) > 3)
                                        {
                                            iRem = Convert.ToInt32(txtNoOfLbl.Text) - 3;
                                        }

                                    }
                                    li = lstView.Items[i];
                                    iList++;
                                    break;

                                }
                                else
                                {
                                    MessageBox.Show("Print Qty is greater than balance qty");
                                    txtNoOfLbl.Focus();
                                    return;
                                }


                            }
                        }
                        if (li.SubItems.Count > 0 && iList > 0)
                        {
                            objBL_Prnt = new BL_Printing();
                            objPL_Prnt = new PL_Printing();
                            PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                            //if (iRem > 0 && cboPrintMethod.Text == "Direct Thermal")
                            //{
                            //    objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();

                            //    if (cboPackLvl.Text == "Tertiary")
                            //    {
                            //        objPL_Prnt.iPrintQty = 2;
                            //    }
                            //    else if (cboPackLvl.Text == "Secondary 1" || cboPackLvl.Text == "Secondary 2" || cboPackLvl.Text == "Secondary 3" || cboPackLvl.Text == "Secondary 4")
                            //    {
                            //        objPL_Prnt.iPrintQty = 3;
                            //    }
                            //    objPL_Prnt.strPackLevel = cboPackLvl.Text;
                            //    objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                            //    objPL_Prnt.strPlantCode = cboPlant.Text;

                            //    dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                            //    objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo + "/going for verfication", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                            //    PrintDataCSV(cboPrintMethod.Text, strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);

                            //    DialogResult ds = MessageBox.Show("Packing Level : " + cboPackLvl.Text.Trim() + "\nGTIN : " + li.SubItems[1].Text.ToString() + "\nBatch : " + li.SubItems[3].Text.ToString() + "\nStart SR No. : " + dtPrint.Rows[0][0].ToString(), "Verify Printing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            //    if (DialogResult.OK == ds)
                            //    {
                            //        dtPrint = new DataTable();
                            //        objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();
                            //        objPL_Prnt.iPrintQty = iRem;
                            //        objPL_Prnt.strPackLevel = cboPackLvl.Text;
                            //        objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                            //        objPL_Prnt.strPlantCode = cboPlant.Text;

                            //        dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                            //        objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click/OK", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo + "/priting verification done", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                            //        PrintDataCSV(cboPrintMethod.Text, strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);

                            //        lblLabel.Text = txtNoOfLbl.Text + " No Of Labels Printed Successfully";
                            //    }
                            //    else
                            //    {
                            //        BL_Scanning objScan = new BL_Scanning();

                            //        if (cboPackLvl.Text == "Tertiary")
                            //        {
                            //            for (int k = 0; k < dtPrint.Rows.Count; k++)
                            //            {
                            //                objScan.BL_UpdateReject(dtPrint.Rows[k][0].ToString(), "T", PL_Login.UserID, PL_Login.PlantCode);
                            //            }
                            //        }
                            //        else if (cboPackLvl.Text == "Secondary 1" || cboPackLvl.Text == "Secondary 2" || cboPackLvl.Text == "Secondary 3" || cboPackLvl.Text == "Secondary 4")
                            //        {
                            //            for (int k = 0; k < dtPrint.Rows.Count; k++)
                            //            {
                            //                objScan.BL_UpdateReject(dtPrint.Rows[k][0].ToString(), "S", PL_Login.UserID, PL_Login.PlantCode);
                            //            }
                            //        }

                            //        objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click/Cancel", "Success", "Barcode Rejected Successfully", "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                            //        lblLabel.Text = dtPrint.Rows.Count.ToString() + " No Of Labels Cancelled Successfully";
                            //        dtPrint = null; objScan = null;
                            //    }

                            //}
                            //else
                            //{
                                objPL_Prnt.strRefNo = li.SubItems[0].Text.ToString();
                                objPL_Prnt.iPrintQty = Convert.ToInt32(txtNoOfLbl.Text);
                                objPL_Prnt.strPackLevel = cboPackLvl.Text;
                                objPL_Prnt.strBatchNo = li.SubItems[3].Text.ToString();
                                objPL_Prnt.strPlantCode = cboPlant.Text;

                                dtPrint = objBL_Prnt.BL_GetDataToPrint(objPL_Prnt);

                                objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Success", objPL_Prnt.iPrintQty.ToString() + " Barcode generated against Ref No. " + objPL_Prnt.strRefNo, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                                PrintDataCSV("Online", strLabelType, strIP, strPRN, Convert.ToInt32(iPort), strprintFile, strPrintN, dtPrint, li);
                            //}

                            //if (cboPrintMethod.Text == "Online")
                            //{
                            //    MessageBox.Show("Database Created Successfully. \nStart Online Scanning screen using below step \n\n\nStep: \nScanning Menu -> Online Scanning");
                            //    //frmOnlineScanning1 objos = new frmOnlineScanning1();
                            //    //objos.lblLine.Text = cboLinecode.Text.Trim();
                            //    //objos.ShowDialog();
                            //    System.Diagnostics.Process.Start("Barcode Printing.exe");
                            //    this.Close();
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Select Record for printing");
                            return;
                        }
                        btnGetData_Click(sender, e);
                        txtNoOfLbl.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "btnPrint_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                li = null;
                objBL_Prnt = null;
                Cursor.Current = Cursors.Default;
                objLog = null;
                objPL_Prnt = null;
            }

        }
    }

    }

