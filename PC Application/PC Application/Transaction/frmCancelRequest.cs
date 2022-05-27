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

namespace PC_Application.Transaction
{
    public partial class frmCancelRequest : Form
    {
        BL_LogWriter objLog;
        PL_Printing objPL_Prnt;
        BL_Scanning objScan;
        BL_Printing objBL_Prnt;

        public frmCancelRequest()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmCancelRequest_Load(sender, e);
        }

        private void frmCancelRequest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BL_LogWriter objLog = new BL_LogWriter();
            BL_Generator objGen = new BL_Generator();
            DataTable dt = new DataTable();
            chkSelectAll.Checked = false;
            string str = "";
            string[] strPlantCode;
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



                dt = objGen.BLGetPackLevel();
                cboPacking.Items.Clear();
                cboPacking.Items.Add("Select");
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboPacking.Items.Add(dt.Rows[i]["PACKING_LEVEL"].ToString());
                    }

                }
                cboPacking.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                objLog.WriteErrorLog(this.Name.ToString(), "frmCancelRequest_Load", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objBL_Prnt = null;
                objLog = null;
                objGen = null;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            objLog = new BL_LogWriter();
            int iCheck = 0;
            objScan = new BL_Scanning();
            objBL_Prnt = new BL_Printing();
            try
            {
                if (lstView.Items.Count > 0)
                {
                    if (lstView.CheckedIndices.Count > 0)
                    {

                        DialogResult ds = MessageBox.Show("Do you really want to Reject selected Requests ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (ds == DialogResult.Yes)
                        {
                            for (int i = 0; i < lstView.Items.Count; i++)
                            {
                                if (lstView.Items[i].Checked == true)
                                {
                                    if (objScan.BL_RejectRequest(lstView.Items[i].SubItems[0].Text.ToString()) > 0)
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Success", "Request is Rejected against Refno - " + lstView.Items[i].SubItems[0].Text.ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                        iCheck++;
                                    }
                                    else
                                    {
                                        objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", "Request is not Rejected against Refno - " + lstView.Items[i].SubItems[0].Text.ToString(), "PC Client", PL_Login.UserID.ToString(), PL_Login.PlantCode);
                                    }
                                }
                            }
                            btnGetData_Click(sender, e);
                            lblLabel.Text = iCheck + " No Of Request has been Rejected.";
                            lblLabel.Visible = true;
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
                MessageBox.Show(ex.ToString());
                objLog.WriteErrorLog(this.Name.ToString(), "btnReject_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
            finally
            {
                objLog = null;
                objBL_Prnt = null;
                objScan = null;
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

        public void Clear()
        {

            cboPacking.Items.Clear();
            cboLine.Items.Clear();
            cboProduct.Items.Clear();
            txtBatchno.Text = "";
            lstView.Items.Clear();

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


            DataSet ds = new DataSet();
            try
            {
                if (cboLine.Text != "Select")
                {

                    objPL_Prnt.strPlantCode = cboPlant.Text;
                    objPL_Prnt.strPackLevel = cboPacking.Text;
                    objPL_Prnt.strLineNo = cboLine.Text;
                    PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");
                    ds = objBL_Prnt.BL_GetPrntConfig(objPL_Prnt);

                    cboProduct.Items.Clear();
                    cboProduct.Items.Add("Select");


                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            cboProduct.Items.Add(ds.Tables[2].Rows[i][0].ToString());
                        }
                    }



                }
                else
                {
                    cboProduct.Items.Clear();
                    cboProduct.Items.Add("Select");
                }

                cboProduct.SelectedIndex = 0;
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
                ds = null;

            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            objPL_Prnt = new PL_Printing();
            objBL_Prnt = new BL_Printing();
            chkSelectAll.Checked = false;
            DataTable dt = new DataTable();
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
                //if (cboProduct.Text.Trim() == "" || cboProduct.Text.Trim() == "Select")
                //{
                //    errorProvider1.SetError(cboProduct, "Select Product Name");
                //    return;
                //}
                //else
                //{
                //    errorProvider1.Dispose();
                //}
                //if (txtBatchno.Text.Trim() == "")
                //{
                //    errorProvider1.SetError(txtBatchno, "Enter Batch No.");
                //    return;
                //}
                //else
                //{
                //    errorProvider1.Dispose();
                //}

                PL_File.servicePath = DataLayer.clsDb.GetGlobleDetails("SERVICE");

                objPL_Prnt.strPlantCode = cboPlant.Text;
                objPL_Prnt.strPackLevel = cboPacking.Text;
                objPL_Prnt.strLineNo = cboLine.Text;
                objPL_Prnt.strProdName = cboProduct.Text;
                objPL_Prnt.strBatchNo = txtBatchno.Text;

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

                        Litem.SubItems.Add(dt.Rows[i][6].ToString());

                        Litem.SubItems.Add(dt.Rows[i][8].ToString());
                        Litem.SubItems.Add(dt.Rows[i][9].ToString());
                        lstView.Items.Add(Litem);
                    }


                }
                lblLabel.Text = dt.Rows.Count + " No Of Records Found";
                lblLabel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                objLog.WriteErrorLog(this.Name.ToString(), "btnGetData_Click", "Error", ex.Message, "PC Client", PL_Login.UserID, PL_Login.PlantCode);
            }
            finally
            {
                objPL_Prnt = null;
                objBL_Prnt = null;
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

    }
}
