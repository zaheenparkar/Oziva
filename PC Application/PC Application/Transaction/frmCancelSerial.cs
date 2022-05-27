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
using PC_Application.Startup;


namespace PC_Application.Transaction
{
    public partial class frmCancelSerial : Form
    {
        BL_LogWriter objLog;
        PL_Printing objPL_Prnt;
        BL_Scanning objScan;
        BL_Printing objBL_Prnt;

        public frmCancelSerial()
        {
            InitializeComponent();
        }

        private void frmCancelSerial_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BL_LogWriter objLog = new BL_LogWriter();
            string str = "";
            string[] strPlantCode;
            chkSelectAll.Checked = false;
            lstView.Items.Clear();
            lblLabel.Text = "";
            try
            {
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

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmCancelSerial_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objBL_Prnt = null;
                objLog = null;
            }
        }

        public void Clear()
        {

            cboPacking.Items.Clear();
            cboLine.Items.Clear();
            cboProduct.Items.Clear();
            cboBatch.Items.Clear();

            lstView.Items.Clear();

        }


        private void cboPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            try
            {
                if (cboPlant.Text != "Select")
                {
                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    Clear();
                    dt = objBL_Prnt.BL_GetLine(objPL_Prnt);
                    cboPacking.Items.Clear();
                    cboPacking.Items.Add("Select");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboPacking.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                }
                else
                {
                    cboPacking.Items.Clear();
                    cboPacking.Items.Add("Select");
                }

                cboPacking.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "cboPlant_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objLog = null;
                objPL_Prnt = null;
                objBL_Prnt = null;
                dt = null;
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
                    lstView.Items.Clear();
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
                objLog.WriteErrorLog(this.Name.ToString(), "cboPacking_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);

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

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPacking.Text;
                    objPL_Prnt.strLineNo = cboLine.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    dt = objBL_Prnt.BL_GetProduct(objPL_Prnt);

                    cboProduct.Items.Clear();
                    cboProduct.Items.Add("Select");

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboProduct.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                }
                else
                {
                    cboProduct.Items.Clear();
                    cboProduct.Items.Add("Select");
                }

                cboProduct.SelectedIndex = 0;



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
            //objPL_Prnt = new PL_Printing();
            //objBL_Prnt = new BL_Printing();
            //BL_LogWriter objLog = new BL_LogWriter();


            //DataTable dt = new DataTable();
            //try
            //{
            //    if (cboLine.Text != "Select")
            //    {

            //        objPL_Prnt.strPlantCode = cboPlant.Text;
            //        objPL_Prnt.strPackLevel = cboPacking.Text;
            //        objPL_Prnt.strLineNo = cboLine.Text;
            //        objPL_Prnt.strProdName = cboProduct.Text;


            //        PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
            //        dt = objBL_Prnt.BL_GetBatch(objPL_Prnt);

            //        cboBatch.Items.Clear();
            //        cboBatch.Items.Add("Select");

            //        if (dt.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                cboBatch.Items.Add(dt.Rows[i][0].ToString());
            //            }
            //        }
            //    }
            //    else
            //    {
            //        cboBatch.Items.Clear();
            //        cboBatch.Items.Add("Select");
            //    }

            //    cboBatch.SelectedIndex = 0;



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    objLog.WriteErrorLog(this.Name.ToString(), "cboProduct_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID);
            //}
            //finally
            //{
            //    objBL_Prnt = null;
            //    objPL_Prnt = null;
            //    objLog = null;
            //    dt = null;

            //}
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            objLog = new BL_LogWriter();
            objScan = new BL_Scanning();
            string strMode = "", strStatus = "";
            int iCheck = 0;
            try
            {
                if (lstView.Items.Count > 0)
                {
                    if (lstView.CheckedIndices.Count > 0)
                    {

                        if (cboPacking.Text == "Tertiary")
                        {
                            strMode = "T";
                        }
                        else
                        {
                            strMode = "S";
                        }

                        DialogResult ds = MessageBox.Show("Do you really want to Reject selected Records ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (ds == DialogResult.Yes)
                        {


                            for (int i = 0; i < lstView.Items.Count; i++)
                            {

                                if (lstView.Items[i].Checked == true)
                                {
                                    strStatus = objScan.BL_UpdateReject(lstView.Items[i].SubItems[0].Text.ToString(), strMode, PL_Login.UserID, PL_Login.PlantCode);

                                    if (strStatus.Contains("|") == true)
                                    {
                                        if (strStatus.Split('|').GetValue(0).ToString() == "0")
                                        {
                                            iCheck++;
                                            objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Success", strStatus.Split('|').GetValue(1).ToString() + "-" + lstView.Items[i].SubItems[0].Text.ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        }
                                        else
                                        {
                                            objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", strStatus.Split('|').GetValue(1).ToString() + "-" + lstView.Items[i].SubItems[0].Text.ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        }
                                    }
                                }
                            }

                            lblLabel.Text = iCheck + " No Of Barcode Rejected";
                            lblLabel.Visible = true;
                            btnGetData_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Record from list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmCancelSerial_Load(sender, e);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            objLog = new BL_LogWriter();
            objBL_Prnt = new BL_Printing();
            objScan = new BL_Scanning();
            objPL_Prnt = new PL_Printing();
            DataTable dt = new DataTable();
            chkSelectAll.Checked = false;
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
                    errorProvider1.SetError(cboLine, "Select Line No");
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
                if (cboBatch.Text.Trim() == "" || cboBatch.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboBatch, "Enter Batch No.");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                objPL_Prnt.strPlantCode = cboPlant.Text;
                objPL_Prnt.strPackLevel = cboPacking.Text;
                objPL_Prnt.strLineNo = cboLine.Text;
                objPL_Prnt.strProdName = cboProduct.Text;
                objPL_Prnt.strBatchNo = cboBatch.Text;


                dt = objBL_Prnt.BL_GetSerial(objPL_Prnt, txtSerial.Text.Trim());
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
                        lstView.Items.Add(Litem);
                    }
                }

                lblLabel.Text = dt.Rows.Count + " No Of Records Found";
                lblLabel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objScan = null; objLog = null; objPL_Prnt = null; objBL_Prnt = null;
            }
        }

        private void cboProduct_TextChanged(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            BL_LogWriter objLog = new BL_LogWriter();


            DataTable dt = new DataTable();
            try
            {
                if (cboLine.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPacking.Text;
                    objPL_Prnt.strLineNo = cboLine.Text;
                    objPL_Prnt.strProdName = cboProduct.Text;


                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    dt = objBL_Prnt.BL_GetBatch(objPL_Prnt);

                    cboBatch.Items.Clear();
                    cboBatch.Items.Add("Select");

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cboBatch.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                }
                else
                {
                    cboBatch.Items.Clear();
                    cboBatch.Items.Add("Select");
                }

                cboBatch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "cboProduct_SelectedIndexChanged", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
            finally
            {
                objBL_Prnt = null;
                objPL_Prnt = null;
                objLog = null;
                dt = null;

            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int i = 0; i < lstView.Items.Count; i++)
                {
                    lstView.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lstView.Items.Count; i++)
                {
                    lstView.Items[i].Checked = false;
                }
            }
        }

        public string GetSelectedString()
        {
            string strCond = "";
            string strBatch = "";

            if (cboBatch.Text != "")
            {

                strBatch = " ='" + cboBatch.Text.Trim() + "'";


                strCond = " [Batch No] " + strBatch + "";
            }
            return strCond;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL_Reports objGen = new BL_Reports();
            DataTable dt = new DataTable();
            chkSelectAll.Checked = false;
            
            string strResult = GetSelectedString();
            try
            {
                if (cboPacking.Text.Trim() == "" || cboPacking.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboPacking, "Select Packing Level");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }

                if (cboBatch.Text.Trim() == "" || cboBatch.Text.Trim() == "Select")
                {
                    errorProvider1.SetError(cboBatch, "Enter Batch No.");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (cboPacking.Text == "Tertiary")
                {
                    dt = objGen.BLGet_GetUnutilizedTer(strResult);
                }
                else
                {
                    dt = objGen.BLGet_GetUnutilizedSec(strResult);
                }
                lstView.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem Litem = new ListViewItem(dt.Rows[i][0].ToString());
                        Litem.SubItems.Add(dt.Rows[i][4].ToString());
                        Litem.SubItems.Add(dt.Rows[i][2].ToString());
                        Litem.SubItems.Add(dt.Rows[i][1].ToString());
                        Litem.SubItems.Add(dt.Rows[i][6].ToString());
                        Litem.SubItems.Add(dt.Rows[i][7].ToString());
                        lstView.Items.Add(Litem);
                    }
                }

                lblLabel.Text = dt.Rows.Count + " No Of Records Found";
                lblLabel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                objLog.WriteErrorLog(this.Name.ToString(), "button1_Click", "Error", ex.Message, "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
            }
            finally
            {
                objGen = null;
            }
        }
    }
}
