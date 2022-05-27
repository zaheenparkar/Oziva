using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using PC_Application.Cantral;
using BusinessLayer;
using PropertyLayer;
using System.IO;

namespace PC_Application.Sync
{
    public partial class frmTransSync : Form
    {
        public frmTransSync()
        {
            InitializeComponent();
        }

        string strWebService = "";
        string strPlant = "";

        private void frmTransSync_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblLocal.Visible = false;
            lblCentral.Visible = false;
        }

        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            lblLocal.Visible = true;
            lblCentral.Visible = true;

            bool local = false;
            bool Central = false;

            clsDb objData = new clsDb();
            try
            {
                objData.connect();
                lblLocal.Text = "Local Server : Connected";
                lblLocal.BackColor = Color.DarkGreen;
                local = true;
            }
            catch (Exception ex)
            {
                lblLocal.Text = "Local Server : Not Connected";
                lblLocal.BackColor = Color.Red;
                local = false;
            }
            finally
            {
                objData = null;
            }

            try
            {
                Service objLocal = new Service();
                objLocal.Url = clsGlobal.gstWebService;
                objLocal.Timeout = 60000;

                objLocal.HelloWorld();

                lblCentral.Text = "Central Server : Connected";
                lblCentral.BackColor = Color.DarkGreen;
                Central = true;
            }
            catch (Exception ex)
            {
                lblCentral.Text = "Central Server : Not Connected";
                lblCentral.BackColor = Color.Red;
                Central = false;
            }
            if (local == true && Central == true)
            {
                lstView.Visible = true;
                btnSync.Visible = true;
            }
            else
            {
                lstView.Visible = true;
                btnSync.Visible = true;
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            
            
            foreach (ListViewItem lst in lstView.Items)
            {
                if (lst.Checked == true)
                {
                    Service objService = new Service();
                    BL_LogWriter objLog = new BL_LogWriter();
                    DataTable dt_Temp = new DataTable();
                    BL_Scheduler objSchedule = new BL_Scheduler();
                    string Res = "";
                    bool Flg = false; 

                    try
                    {
                        objService.Url = clsGlobal.gstWebService;
                        objService.Timeout = 60000;
                        switch (lst.SubItems[0].Text)
                        {
                            case "Batch Details":
                                Res = LinkBatchDtl();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true; 
                                }
                                //objSchedule.Sync_BatchData(clsGlobal.gstrPlantID.Trim());   
                                break;
                            case "Request Generation":
                                Res = LinkReqGenHdr();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                                //objSchedule.Sync_ReqGenData(clsGlobal.gstrPlantID.Trim());  
                                break;
                            case "Secondary Data":
                                Res = LinkSecDtls();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                               // objSchedule.Sync_SecData(clsGlobal.gstrPlantID.Trim(),clsGlobal.gstrUserID.Trim());
                                break;
                            case "Tertiary Data":
                                Res = LinkTertDtls();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                               // objSchedule.Sync_TertData(clsGlobal.gstrPlantID.Trim(), clsGlobal.gstrUserID.Trim());
                                break;
                            case "Relation Data":
                                Res = LinkMappingDtl();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                               // objSchedule.Sync_MapplingData();
                                break;
                            case "Tertiary Rejection":
                                Res = LinkTertRejDtl();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                               // objSchedule.Sync_Tert_RejData(clsGlobal.gstrPlantID.Trim());
                                break;
                            case "Secondary Rejection":
                                Res = LinkSecRejDtl();
                                if (int.Parse(Res) > 0)
                                {
                                    Flg = true;
                                }
                                //objSchedule.Sync_Sec_RejData(clsGlobal.gstrPlantID.Trim());
                                break;
                        }


                        if (Flg == true)
                        {
                            lst.SubItems[0].BackColor = Color.Green;
                            Flg = false; 
                        }
                        else
                        {
                            lst.SubItems[0].BackColor = Color.Red;
                        }
                        Res = "";

                    }
                    catch (Exception ex)
                    {
                        // lst.SubItems[1].Text = "Failed";
                        objLog.WriteErrorLog(this.Name.ToString(), "btnSync_Click", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                    }
                    finally
                    {
                        objLog = null;
                        objService = null;
                    }
                }
            }
        }

        public  Boolean ReadSetting()
        {
            FileInfo ServerFile = new FileInfo(Application.StartupPath + "\\Setting.SYS");
            string strLine = "";

            if (ServerFile.Exists == true)
            {
                string[] strArr;
                StreamReader ReadServer = new StreamReader(Application.StartupPath + "\\Setting.SYS");
                do
                {
                    strLine = ReadServer.ReadLine();
                    if (strLine.Trim().ToUpper() == "</LOCAL_SETTING>")
                        break;
                    strArr = strLine.Split('~');

                    
                    if (strArr[0].Trim().ToUpper() == "WEBSERVICE")
                        strWebService = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "PLANT")
                        strPlant = strArr[1].Trim();
                }
                while (strLine != null);
                ReadServer.Close();
                ReadServer = null;
                ServerFile = null;
                return true;
            }
            return false;
        }


        public string LinkBatchDtl()
        {

            clsDb clsBatchDtl = new clsDb();
            clsDb clsBatchDtlUpdt = new clsDb();
            string strSql = "";
            string strSqlUpdt = "";
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strSql = "SELECT REFNO,GS1_PREFIX,GTIN_CODE,MRP,BATCH,PACK_SIZE,EXP_DATE,MFG_DATE,TXN_QTY,BATCH_EXPORT_ST,EXEMPTED_ST,EXEMPTED_NOTIFY_INFO,EXEMPTED_COUNTRY_CODE,BATCH_ST,PLANT_CODE,ERP_ITEM_CODE,CREATED_BY,FLAG,BCIL_ID from TBLMASTER_BATCH WHERE FLAG = 0";
                dt = clsBatchDtl.GetDataset(strSql).Tables[0];
                objService.Url = strWebService.Trim();
                Result = objService.CTSLinkSaveBatchDT(dt, clsGlobal.gstrPlantID);



                if (int.Parse(Result) > 0)
                {
                    strSqlUpdt = "UPDATE TBLMASTER_BATCH SET FLAG = 1 WHERE FLAG = 0";
                    clsBatchDtlUpdt.ExecuteQuery(strSqlUpdt);
                }

                strSql = "";
                strSqlUpdt = "";
                clsBatchDtlUpdt = null;
                clsBatchDtl = null;
                objService = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strSqlUpdt = "";
                clsBatchDtl = null;
                clsBatchDtlUpdt = null;
                objService = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkBatchDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }


        public string LinkReqGenHdr()
        {
            
            clsDb clsGenHdr = new clsDb();
            clsDb clsGenHdrUpdt = new clsDb();
            string strSql = "";
            string strSqlUpdt = "";
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strSql = "SELECT [BCIL_ID],[PACKING_LEVEL],[LINE_ID],[LABEL_TYPE],[GTIN_ID],[PROD_DESC1],[PROD_DESC2],[PACK_SIZE],[BATCH_NO],[MFG_DATE],[EXP_DATE],[TXN_QTY],[PRINT_QTY],[STATUS],[GENERATE_ON],[GENERATED_BY],[PLANT],[FLAG],[ERP_ITEM_CODE] FROM [TBLGEN_HDR] WHERE FLAG = 0";
                dt = clsGenHdr.GetDataset(strSql).Tables[0];
                objService.Url = strWebService.Trim();
                Result = objService.LinkGenHdrDt(dt, strPlant);

                if (int.Parse(Result) > 0)
                {
                    strSqlUpdt = "UPDATE TBLGEN_HDR SET FLAG = 1 WHERE FLAG = 0";
                    clsGenHdrUpdt.ExecuteQuery(strSqlUpdt);
                }
                strSql = "";
                strSqlUpdt = "";
                clsGenHdrUpdt = null;
                clsGenHdr = null;
                objService = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strSqlUpdt = "";
                clsGenHdrUpdt = null;
                clsGenHdr = null;
                objService = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkReqGenHdr", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result; 
        }


        public static string dataTableToString(DataTable dt)
        {
            StringBuilder str = new StringBuilder();

            foreach (DataColumn dc in dt.Columns)
            {
                str.Append(Convert.ToString(dc) + "~");
            }
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("#");
                foreach (DataColumn dc in dt.Columns)
                {
                    str.Append(Convert.ToString(dr[dc]) + "~");
                }
            }
            return str.ToString();
        }


        public string LinkSecDtls()
        {

            clsDb clsSecDtls = new clsDb();
            clsDb clsRefNo = new clsDb();
            clsDb clsBatchDtl = new clsDb();
            clsDb clsSecDtlsUpdt = new clsDb();

            string strSql = "";
            string strRefno = "";
            string strBatchDtl = "";
            string strSqlUpdt = "";

            DataTable DT_REFNO = new DataTable();
            DataTable DT_BATCHDTLS = new DataTable();
            DataTable dt = new DataTable();

            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strRefno = "SELECT DISTINCT BCIL_ID FROM TBLSEC_TRANS WHERE FLAG = 0";
                DT_REFNO = clsRefNo.GetDataset(strRefno).Tables[0] ;
                if (DT_REFNO.Rows.Count > 0)
                {
                   
                    for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                    {
                       

                        strBatchDtl ="SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "'";

                        DT_BATCHDTLS = clsBatchDtl.GetDataset(strBatchDtl).Tables[0];
                        if (DT_BATCHDTLS.Rows.Count > 0)
                        {
                             
                        
                            while(true)
                            {
                                strSql = "SELECT TOP 100 [BCIL_ID] ,[BARCODE] ,[STATUS] ,[PRINTED_BY]  ,[PRINTED_ON] ,[REPRINT_COUNT] ,[REPRINTED_BY] ,[REPRINTED_ON] ,[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY] ,[REJECTED_ON] ,[FLAG],[PLANT] ,[BATCH] FROM TBLSEC_TRANS WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0";
                                dt = clsSecDtls.GetDataset(strSql).Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    break;
                                }
                                objService.Url = strWebService.Trim();
                                Result = objService.LinkSecTransDt(dt, strPlant.Trim());
                                if (int.Parse(Result) > 0)
                                {
                                    strSqlUpdt = "UPDATE TOP (100) TBLSEC_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0";
                                    clsSecDtlsUpdt.ExecuteQuery(strSqlUpdt);
                                }
                                                                
                            }
                            
                        }
                    }
                }

                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsSecDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsSecDtlsUpdt = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsSecDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsSecDtlsUpdt = null;
                objService = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkSecDtls", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }


        public string LinkTertDtls()
        {

            clsDb clsTertDtls = new clsDb();
            clsDb clsRefNo = new clsDb();
            clsDb clsBatchDtl = new clsDb();
            clsDb clsTertUpdt = new clsDb();

            string strSql = "";
            string strRefno = "";
            string strBatchDtl = "";
            string strSqlUpdt = "";

            DataTable DT_REFNO = new DataTable();
            DataTable DT_BATCHDTLS = new DataTable();
            DataTable dt = new DataTable();

            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strRefno = "SELECT DISTINCT BCIL_ID FROM TBLTER_TRANS WHERE FLAG = 0";
                DT_REFNO = clsRefNo.GetDataset(strRefno).Tables[0];
                if (DT_REFNO.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                    {
                        //MessageBox.Show("BCIL ID : " + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim()); 
  
                        strBatchDtl = "SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "'";
                        DT_BATCHDTLS = clsBatchDtl.GetDataset(strBatchDtl).Tables[0];
                        if (DT_BATCHDTLS.Rows.Count > 0)
                        {
                            //MessageBox.Show("BCIL ID : " + DT_BATCHDTLS.Rows[i]["BCIL_ID"].ToString().Trim() + "PACKING_LEVEL :" + DT_BATCHDTLS.Rows[i]["PACKING_LEVEL"].ToString().Trim() + "BATCH_NO :" + DT_BATCHDTLS.Rows[i]["PACKING_LEVEL"].ToString().Trim());


                            while(true)
                            {

                                strSql = "SELECT  [BCIL_ID],[BARCODE] ,[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY] ,[REPRINTED_ON] ,[VALIDATED_BY] ,[VALIDATED_ON] ,[RELATION_ST] ,[REJECTED_BY],[REJECTED_ON] ,[FLAG] ,[PLANT],[BATCH] FROM TBLTER_TRANS WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0";
                                dt = clsTertDtls.GetDataset(strSql).Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    break;
                                }

                                objService.Url = strWebService.Trim();
                                Result = objService.LinkTerTransDt(dt, strPlant.Trim());


                                //MessageBox.Show("Result :" + Result);
                                if (int.Parse(Result) > 0)
                                {
                                    strSqlUpdt = "UPDATE TOP (100) TBLTER_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0";
                                    clsTertUpdt.ExecuteQuery(strSqlUpdt);
                                }

                               
                            }
                            
                           

                           
                        }
                    }
                }

                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkSecDtls", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }


        public string LinkMappingDtl()
        {

            clsDb clsMappingDtl = new clsDb();
            clsDb clsMappingUpdt = new clsDb();
            string strSql = "";
            string strSqlUpdt = "";
            DataTable dt = new DataTable();
            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();

                while (true)
                {
                    strSql = "SELECT TOP 100 [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0";
                    dt = clsMappingDtl.GetDataset(strSql).Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        break;
                    }

                    objService.Url = strWebService.Trim();
                    Result = objService.UploadMapping(dt);

                    if (int.Parse(Result) > 0)
                    {
                        strSqlUpdt = "UPDATE TOP (100) TBLRELETION SET FLAG = 1 WHERE FLAG = 0";
                        clsMappingUpdt.ExecuteQuery(strSqlUpdt);
                    }

                    

                }

                strSql = "";
                strSqlUpdt = "";
                clsMappingUpdt = null;
                clsMappingDtl = null;
                objService = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strSqlUpdt = "";
                clsMappingUpdt = null;
                clsMappingDtl = null;
                objService = null;

                objLog.WriteErrorLog(this.Name.ToString(), "LinkMappingDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }

        public string LinkSecRejDtl()
        {
            clsDb clsTertDtls = new clsDb();
            clsDb clsRefNo = new clsDb();
            clsDb clsBatchDtl = new clsDb();
            clsDb clsTertUpdt = new clsDb();

            string strSql = "";
            string strRefno = "";
            string strBatchDtl = "";
            string strSqlUpdt = "";

            DataTable DT_REFNO = new DataTable();
            DataTable DT_BATCHDTLS = new DataTable();
            DataTable dt = new DataTable();

            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strRefno = "SELECT DISTINCT BCIL_ID FROM TBlSEC_TRANS WHERE FLAG = 0";
                DT_REFNO = clsRefNo.GetDataset(strRefno).Tables[0];
                if (DT_REFNO.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                    {
            

                        strBatchDtl = "SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "'";
                        DT_BATCHDTLS = clsBatchDtl.GetDataset(strBatchDtl).Tables[0];
                        if (DT_BATCHDTLS.Rows.Count > 0)
                        {
            


                            while (true)
                            {

                                strSql = "SELECT TOP 100 [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [TBLSEC_TRANS] WHERE FLAG = 0 AND STATUS = 9 AND BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "'";
                                dt = clsTertDtls.GetDataset(strSql).Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    break;
                                }

                                objService.Url = strWebService.Trim();
                                Result = objService.LinkSecRejDt(dt);


                                //MessageBox.Show("Result :" + Result);
                                if (int.Parse(Result) > 0)
                                {
                                    strSqlUpdt = "UPDATE TOP (100) TBLSEC_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0 AND STATUS = 9";
                                    clsTertUpdt.ExecuteQuery(strSqlUpdt);
                                }

                            }

                        }
                    }
                }

                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkSecRejDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }

        public string LinkTertRejDtl()
        {
            clsDb clsTertDtls = new clsDb();
            clsDb clsRefNo = new clsDb();
            clsDb clsBatchDtl = new clsDb();
            clsDb clsTertUpdt = new clsDb();

            string strSql = "";
            string strRefno = "";
            string strBatchDtl = "";
            string strSqlUpdt = "";

            DataTable DT_REFNO = new DataTable();
            DataTable DT_BATCHDTLS = new DataTable();
            DataTable dt = new DataTable();

            BL_LogWriter objLog = new BL_LogWriter();
            Service objService = new Service();
            string Result = "0";
            try
            {
                ReadSetting();
                strRefno = "SELECT DISTINCT BCIL_ID FROM TBLTER_TRANS WHERE FLAG = 0";
                DT_REFNO = clsRefNo.GetDataset(strRefno).Tables[0];
                if (DT_REFNO.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                    {
                        strBatchDtl = "SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "'";
                        DT_BATCHDTLS = clsBatchDtl.GetDataset(strBatchDtl).Tables[0];
                        if (DT_BATCHDTLS.Rows.Count > 0)
                        {
                            while (true)
                            {

                                strSql = "SELECT TOP 100 [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [dbo].[TBLTER_TRANS] WHERE FLAG = 0 AND STATUS = 9 AND BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "'";
                                dt = clsTertDtls.GetDataset(strSql).Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    break;
                                }

                                objService.Url = strWebService.Trim();
                                Result = objService.LinkTerRejDt(dt);


                                //MessageBox.Show("Result :" + Result);
                                if (int.Parse(Result) > 0)
                                {
                                    strSqlUpdt = "UPDATE TOP (100) TBLTER_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND FLAG = 0 AND STATUS = 9";
                                    clsTertUpdt.ExecuteQuery(strSqlUpdt);
                                }


                            }

                        }
                    }
                }

                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
            }
            catch (Exception ex)
            {
                strSql = "";
                strRefno = "";
                strBatchDtl = "";
                strSqlUpdt = "";
                clsTertDtls = null;
                clsRefNo = null;
                clsBatchDtl = null;
                clsTertUpdt = null;
                objLog.WriteErrorLog(this.Name.ToString(), "LinkTertRejDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID, PL_Login.PlantCode);
                objLog = null;
            }

            return Result;
        }

        //public string LinkSecRejDtl()
        //{

        //    clsDb clsSecRejDtl = new clsDb();
        //    clsDb clsSecRejUpdt = new clsDb();
        //    string strSql = "";
        //    string strSqlUpdt = "";
        //    DataTable dt = new DataTable();
        //    BL_LogWriter objLog = new BL_LogWriter();
        //    Service objService = new Service();
        //    string Result = "0";
        //    try
        //    {
        //        ReadSetting();
        //        strSql = "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [TBLSEC_TRANS] WHERE FLAG = 0 AND STATUS = 9";
        //        dt = clsSecRejDtl.GetDataset(strSql).Tables[0];

        //        objService.Url = strWebService.Trim();
        //        Result = objService.LinkSecTransDt(dt, PL_Login.UserID.Trim());
        //        if (int.Parse(Result) > 0)
        //        {
        //            strSqlUpdt = "UPDATE TBLSEC_TRANS SET FLAG = 1 WHERE FLAG = 0 AND STATUS = 9";
        //            clsSecRejUpdt.ExecuteQuery(strSqlUpdt);
        //        }

        //        strSql = "";
        //        strSqlUpdt = "";
        //        clsSecRejDtl = null;
        //        clsSecRejDtl = null;
        //        objService = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        strSql = "";
        //        strSqlUpdt = "";
        //        clsSecRejDtl = null;
        //        clsSecRejDtl = null;
        //        objService = null;

        //        objLog.WriteErrorLog(this.Name.ToString(), "LinkMappingDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID);
        //        objLog = null;
        //    }

        //    return Result;
        //}


        //public string LinkTertRejDtl()
        //{

        //    clsDb clsTertRejDtl = new clsDb();
        //    clsDb clsTertRejUpdt = new clsDb();
        //    string strSql = "";
        //    string strSqlUpdt = "";
        //    DataTable dt = new DataTable();
        //    BL_LogWriter objLog = new BL_LogWriter();
        //    Service objService = new Service();
        //    string Result = "0";
        //    try
        //    {
        //        ReadSetting();
        //        strSql = "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [dbo].[TBLTER_TRANS] WHERE FLAG = 0 AND STATUS = 9";
        //        dt = clsTertRejDtl.GetDataset(strSql).Tables[0];

        //        objService.Url = strWebService.Trim();
        //        Result = objService.LinkTerRejDt(dt);

        //        if (int.Parse(Result) > 0)
        //        {
        //            strSqlUpdt = "UPDATE TBLTER_TRANS SET FLAG = 1 WHERE FLAG = 0 AND STATUS = 9";
        //            clsTertRejUpdt.ExecuteQuery(strSqlUpdt);
        //        }


        //        strSql = "";
        //        strSqlUpdt = "";
        //        clsTertRejDtl = null;
        //        clsTertRejUpdt = null;
        //        objService = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        strSql = "";
        //        strSqlUpdt = "";
        //        clsTertRejDtl = null;
        //        clsTertRejUpdt = null;
        //        objService = null;
        //        objLog.WriteErrorLog(this.Name.ToString(), "LinkTertRejDtl", "Error", ex.Message.ToString(), "PC Client", PL_Login.UserID);
        //        objLog = null;
        //    }

        //    return Result;
        //}


       
    }
}
