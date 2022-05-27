using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for DL_Scheduler
/// </summary>
public class DL_Scheduler
{
    public DL_Scheduler()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet DL_GetMasterDt(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strPlant1 = "'%," + strPlant.Replace("'", "") + ",%'";
        try
        {

            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT USER_ID,CAST(PASS_WORD AS VARCHAR(50)) AS PASS FROM TBLMASTER_USER WHERE (',' + RTRIM(PLANTCODE) + ',') LIKE " + strPlant1.Trim() + " OR PLANTCODE IN ('" + strPlant + "')  AND ACTIVATE_ST=1;SELECT PLANT_ID FROM TBLMASTER_PLANT WHERE STATUS=1;SELECT NAME FROM TBLMASTER_CONSIGNEE WHERE STATUS=1");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            _Sql = null;
        }
    }

    public DataTable DL_GetReletionDt()
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        //string strPlant1 = "'%," + strPlant.Replace("'", "") + ",%'";
        try
        {

            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            _Sql = null;
        }
    }

    public DataTable DL_GetAllJOB(string strPlant, string strSearch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            //objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);

            //objParameters[0].Value =  "'" + strUser + "'";

            if (strSearch != "")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT REFNO,PLANT,PACKING_LEVEL,LINE_ID,GTIN_CODE,BATCH_NO,PACK_SIZE,EXPIRY_DATE FROM TBLMASTER_JOB WHERE PLANT IN ('" + strPlant + "') AND STATUS=0 AND BATCH_NO='" + strSearch.Trim() + "'").Tables[0];
            }
            else
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT REFNO,PLANT,PACKING_LEVEL,LINE_ID,GTIN_CODE,BATCH_NO,PACK_SIZE,EXPIRY_DATE FROM TBLMASTER_JOB WHERE PLANT IN ('" + strPlant + "') AND STATUS=0").Tables[0];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public DataTable DL_GetJobDT(string strGTIN, string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);

            objParameters[0].Value = strGTIN;
            objParameters[1].Value = strBatch;

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT PACK_SIZE,EXPIRY_DATE FROM TBLMASTER_JOB WHERE GTIN_CODE=@PARAM AND BATCH_NO=@PARAM1 AND STATUS=0", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }


    public DataTable DL_GetShipperJobDT(string strBarcode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
            //objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);

            objParameters[0].Value = strBarcode;
           // objParameters[1].Value = strBatch;

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT PACK_SIZE,GTIN_ID FROM [TBLShipperLevel] WHERE BarcodeNo =@PARAM", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    
    public DataTable DL_GetChildDt(string strPBarcode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);


            objParameters[0].Value = strPBarcode;


            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT P_BARCODE,C_BARCODE,P_PREFIX FROM TBLRELETION WHERE P_BARCODE=@PARAM", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public string DL_ValidateStatus(string strBarcode, string strMode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strRes = "-1";
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {

            objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);

            objParameters[0].Value = strBarcode;

            if (strMode == "S")
            {
                strRes = _Sql.ExecuteProc_String(_Sql.strSqlConn, "SELECT CAST(T.STATUS AS VARCHAR(50)) + '|' + (SELECT DISTINCT M.BATCH_NO FROM TBLGEN_HDR M WHERE M.BCIL_ID=T.BCIL_ID) AS 'REC' FROM TBLSEC_TRANS T WHERE T.BARCODE=@PARAM", objParameters);
            }
            else if (strMode == "T")
            {
                strRes = _Sql.ExecuteProc_String(_Sql.strSqlConn, "SELECT CAST(T.STATUS AS VARCHAR(50)) + '|' + (SELECT DISTINCT M.BATCH_NO FROM TBLGEN_HDR M WHERE M.BCIL_ID=T.BCIL_ID) AS 'REC' FROM TBLTER_TRANS T WHERE T.BARCODE=@PARAM", objParameters);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
        return strRes;
    }

    public int DL_UpdateStatus(string strFromBarcode, string strToBarcode, string strMode, string strUser)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        int iRes = 0;
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {

            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[0].Value = strFromBarcode;
            objParameters[1].Value = strToBarcode;
            objParameters[2].Value = strUser;


            if (strMode == "S")
            {
                iRes = _Sql.ExecuteQueryParam(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET STATUS=1,VALIDATED_ON=GETDATE(),VALIDATED_BY=@PARAM3 WHERE REFNO>=(SELECT REFNO FROM TBLSEC_TRANS WHERE BARCODE=@PARAM1 AND STATUS=0) AND REFNO<=(SELECT REFNO FROM TBLSEC_TRANS where BARCODE=@PARAM2 AND STATUS=0)", objParameters);
            }
            else if (strMode == "T")
            {
                iRes = _Sql.ExecuteQueryParam(_Sql.strSqlConn, "UPDATE TBLTER_TRANS SET STATUS=1,VALIDATED_ON=GETDATE(),VALIDATED_BY=@PARAM3 WHERE REFNO>=(SELECT REFNO FROM TBLTER_TRANS WHERE BARCODE=@PARAM1 AND STATUS=0) AND REFNO<=(SELECT REFNO FROM TBLTER_TRANS where BARCODE=@PARAM2 AND STATUS=0)", objParameters);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
        return iRes;
    }

    public int DL_RejectRequest(string strRefNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        int iRes = 0;
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {

            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strRefNo;

            iRes = _Sql.ExecuteQueryParam(_Sql.strSqlConn, "UPDATE TBLGEN_HDR SET STATUS=9 WHERE BCIL_ID=@PARAM1", objParameters);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
        return iRes;
    }

    public string DL_UpdateReject(string strBarcode, string strMode, string strUser, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@BARCODE", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strBarcode;
            objParameters[1].Value = strMode;
            objParameters[2].Value = strUser;
            objParameters[3].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Reject_Barcode", objParameters, "@RESULT", "@RESULT") != "")
            {

                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            if (strMode == "S")
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [TBLSEC_TRANS] WHERE FLAG = 0 AND STATUS=9 AND PLANT='" + strPlant + "' ").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;

                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.LinkSecRejDt(DT_temp) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET FLAG = 1 WHERE FLAG = 0 AND STATUS=9 AND PLANT='" + strPlant + "'");
                                }
                            }
                            else if (strMode == "T")
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [dbo].[TBLTER_TRANS] WHERE FLAG = 0 AND STATUS=9 AND PLANT='" + strPlant + "'").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;

                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.LinkTerRejDt(DT_temp) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLTER_TRANS SET FLAG = 1 WHERE FLAG = 0 AND STATUS=9 AND PLANT='" + strPlant + "'");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return objParameters[3].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }

    public string DL_ManualMapping(int iPrefix, string strPackLevel, string strMode, string strGTIN, string strBatch, int iPackSize, string strP_Barcode, string strC_Barcode, string strUser, string strPartial, string strLabelType)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[12];
        try
        {
            objParameters[0] = new SqlParameter("@PARENT_PREFIX", SqlDbType.Int);
            objParameters[1] = new SqlParameter("@PACKING_LEVEL", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@GTIN", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@BATCH", SqlDbType.VarChar);
            objParameters[5] = new SqlParameter("@PACK_SIZE", SqlDbType.Int);
            objParameters[6] = new SqlParameter("@P_BARCODE", SqlDbType.VarChar);
            objParameters[7] = new SqlParameter("@C_BARCODE", SqlDbType.VarChar);

            objParameters[8] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[9] = new SqlParameter("@ISPARTIAL", SqlDbType.VarChar);
            objParameters[10] = new SqlParameter("@LABELTYPE", SqlDbType.VarChar);
            objParameters[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

            objParameters[0].Value = iPrefix;
            objParameters[1].Value = strPackLevel;
            objParameters[2].Value = strMode;
            objParameters[3].Value = strGTIN;
            objParameters[4].Value = strBatch;
            objParameters[5].Value = iPackSize;
            objParameters[6].Value = strP_Barcode;
            objParameters[7].Value = strC_Barcode;

            objParameters[8].Value = strUser;
            objParameters[9].Value = strPartial;
            objParameters[10].Value = strLabelType;
            objParameters[11].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Mapping_Barcode", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[11].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }

    public string DL_ManualShipperMapping(string strPackLevel, string strMode, string strGTIN, string strP_Barcode, string strC_Barcode, string strUser)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[7];
        try
        {
            
            objParameters[0] = new SqlParameter("@PACKING_LEVEL", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@GTIN", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@P_BARCODE", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@C_BARCODE", SqlDbType.VarChar);
            objParameters[5] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[6] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

            
            objParameters[0].Value = strPackLevel;
            objParameters[1].Value = strMode;
            objParameters[2].Value = strGTIN;
           
            objParameters[3].Value = strP_Barcode;
            objParameters[4].Value = strC_Barcode;

            objParameters[5].Value = strUser;
           
            objParameters[6].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_ShipperMapping_Barcode", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[6].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }

    
    public string DL_UpdateValidation(DataTable dt, string strMode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Value = strMode;
            objParameters[2].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Update_Validation", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[2].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_JobEntry(string strPlant, string strPack, string strLine, string strGTIN, string strBatch, int iPackSize, string strUser, string strMode, int irefNo, string strExpiry)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[11];
        try
        {
            objParameters[0] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PACKLEVEL", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@LINECODE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@GTINCODE", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@BATCH", SqlDbType.VarChar);
            objParameters[5] = new SqlParameter("@PACKSIZE", SqlDbType.Int);
            objParameters[6] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[7] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[8] = new SqlParameter("@REFNO", SqlDbType.Int);
            objParameters[9] = new SqlParameter("@EXPIRY", SqlDbType.VarChar);
            objParameters[10] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strPlant;
            objParameters[1].Value = strPack;
            objParameters[2].Value = strLine;
            objParameters[3].Value = strGTIN;
            objParameters[4].Value = strBatch;
            objParameters[5].Value = iPackSize;
            objParameters[6].Value = strUser;
            objParameters[7].Value = strMode;
            objParameters[8].Value = irefNo;
            objParameters[9].Value = strExpiry;

            objParameters[10].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Job_Entry", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[10].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_UpdateRejection(DataTable dt, string strMode, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Value = strMode;
            objParameters[2].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Update_Rejection", objParameters, "@RESULT", "@RESULT") != "")
            {


                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            if (strMode == "S")
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [TBLSEC_TRANS] WHERE FLAG = 0").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;

                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.LinkSecTransDt(DT_temp, strPlant) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET FLAG = 1 WHERE FLAG = 0");
                                }
                            }
                            else if (strMode == "T")
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [dbo].[TBLTER_TRANS] WHERE FLAG = 0").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;

                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.LinkTerTransDt(DT_temp, strPlant) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLTER_TRANS SET FLAG = 1 WHERE FLAG = 0");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return objParameters[2].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_UpdateInward(DataTable dt)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Update_Inward", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[1].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_UpdateOutward(DataTable dt)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Update_Outward", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[1].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_UpdateMapping(DataTable dt)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Update_Mapping", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[1].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string DL_UpdateMappNew(DataTable dt)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        dt.DefaultView.Sort = "P_BARCODE";
        int iCheck = 0, iRes = 0;
        bool isSame = false;
        dt = dt.DefaultView.ToTable();
        string strTable = "", strPBarcode = "";
        int iPack = 0;
        DataTable dtWrong = new DataTable();
        try
        {

            dtWrong.Columns.Add("BCIL_ID", typeof(string));
            dtWrong.Columns.Add("BARCODE", typeof(string));
            dtWrong.Columns.Add("TXN_TYPE", typeof(string));
            dtWrong.Columns.Add("TRAN_BY", typeof(string));
            DataRow dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                iRes = 1;
                string strPStatus = "", strCStatus = "";

                if (i == 0)
                {
                    strPBarcode = dt.Rows[0]["P_BARCODE"].ToString();
                    isSame = false;
                }
                else
                {
                    if (strPBarcode != dt.Rows[i]["P_BARCODE"].ToString())
                    {
                        isSame = false;
                        strPBarcode = dt.Rows[i]["P_BARCODE"].ToString();
                    }
                    else
                    {
                        isSame = true;
                    }
                }


                if (iCheck == 0 && isSame == false)
                {
                    if (dt.Rows[i]["P_PREFIX"].ToString() == "5")
                    {
                        strTable = "TBLTER_TRANS";
                    }
                    else
                    {
                        strTable = "TBLSEC_TRANS";
                    }
                    if (dt.Rows[i]["PACK_SIZE"].ToString() == "0")
                    {
                        //strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  CAST([STATUS] AS VARCHAR(50)) + '|' + CAST(RELATION_ST AS VARCHAR(50)) + '|' + CAST(BCIL_ID AS VARCHAR(50)) FROM " + strTable + " WHERE BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "'");

                        strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(T.RELATION_ST AS VARCHAR(50)) + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM TBLTER_TRANS T,TBLGEN_HDR H WHERE T.BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "' AND H.BCIL_ID=T.BCIL_ID AND H.LABEL_TYPE='Heterogeneous'");
                    }
                    else
                    {
                        //strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  CAST([STATUS] AS VARCHAR(50)) + '|' + CAST(RELATION_ST AS VARCHAR(50)) + '|' + CAST(BCIL_ID AS VARCHAR(50)) FROM " + strTable + " WHERE BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "'");

                        strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(T.RELATION_ST AS VARCHAR(50)) + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM TBLTER_TRANS T,TBLGEN_HDR H WHERE T.BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "' AND H.BCIL_ID=T.BCIL_ID AND H.LABEL_TYPE='Homogeneous'");
                    }
                    if (strPStatus != "")
                    {
                        if (strPStatus.Split('|').GetValue(0).ToString() == "9")
                        {
                            dr = dtWrong.NewRow();
                            dr[0] = strPStatus.Split('|').GetValue(2).ToString();
                            dr[1] = dt.Rows[i]["P_BARCODE"].ToString();
                            dr[2] = "MAPPING|TERTIARY BARCODE IS REJECTED";
                            dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                            dtWrong.Rows.Add(dr);
                            dtWrong.AcceptChanges();

                        }
                        else if (strPStatus.Split('|').GetValue(1).ToString() == "1")
                        {
                            dr = dtWrong.NewRow();
                            dr[0] = strPStatus.Split('|').GetValue(2).ToString();
                            dr[1] = dt.Rows[i]["P_BARCODE"].ToString();
                            dr[2] = "MAPPING|TERTIARY BARCODE IS ALREADY MAPPED";
                            dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                            dtWrong.Rows.Add(dr);
                            dtWrong.AcceptChanges();

                        }
                        else
                        {
                            iCheck++;
                        }
                    }
                    else
                    {
                        dr = dtWrong.NewRow();
                        dr[0] = "0";
                        dr[1] = dt.Rows[i]["P_BARCODE"].ToString();
                        if (dt.Rows[i]["PACK_SIZE"].ToString() == "0")
                        {
                            dr[2] = "MAPPING|HETEROGENEOUS TERTIARY BARCODE IS NOT EXIST";
                        }
                        else
                        {
                            dr[2] = "MAPPING|HOMOGENEOUS TERTIARY BARCODE IS NOT EXIST";
                        }
                        dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                        dtWrong.Rows.Add(dr);
                        dtWrong.AcceptChanges();

                    }

                }
                if (iCheck > 0)
                {

                    if (dt.Rows[i]["PARTIAL_ST"].ToString() == "1")
                    {
                        if (iPack > 0)
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE " + strTable + " SET RELATION_ST=1,FLAG=0 WHERE BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "'");
                            iCheck = 0;
                            iPack = 0;
                        }
                    }
                    else
                    {
                        strCStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(ISNULL(T.C_RELATION_ST,0) AS VARCHAR(50))  + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM TBLSEC_TRANS T,TBLGEN_HDR H WHERE BARCODE='" + dt.Rows[i]["C_BARCODE"].ToString() + "' AND H.BCIL_ID=T.BCIL_ID");
                        if (strCStatus != "")
                        {
                            if (strCStatus.Split('|').GetValue(0).ToString() == "9")
                            {
                                dr = dtWrong.NewRow();
                                dr[0] = strCStatus.Split('|').GetValue(2).ToString();
                                dr[1] = dt.Rows[i]["C_BARCODE"].ToString();
                                dr[2] = "MAPPING|SECONDARY BARCODE IS REJECTED";
                                dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                                dtWrong.Rows.Add(dr);
                                dtWrong.AcceptChanges();

                            }
                            else if (strCStatus.Split('|').GetValue(1).ToString() == "1")
                            {
                                dr = dtWrong.NewRow();
                                dr[0] = strCStatus.Split('|').GetValue(2).ToString();
                                dr[1] = dt.Rows[i]["C_BARCODE"].ToString();
                                dr[2] = "MAPPING|SECONDARY BARCODE IS ALREADY MAPPED";
                                dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                                dtWrong.Rows.Add(dr);
                                dtWrong.AcceptChanges();

                            }
                            else
                            {
                                iPack++;
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET C_RELATION_ST=1,FLAG=0 WHERE BARCODE='" + dt.Rows[i]["C_BARCODE"].ToString() + "';INSERT INTO TBLRELETION (P_BARCODE,C_BARCODE,P_PREFIX,BATCH,PLANT,TRAN_BY,TRAN_ON) VALUES ('" + dt.Rows[i]["P_BARCODE"].ToString() + "','" + dt.Rows[i]["C_BARCODE"].ToString() + "'," + Convert.ToInt32(dt.Rows[i]["P_PREFIX"].ToString()) + ",'" + strCStatus.Split('|').GetValue(3).ToString() + "','" + strCStatus.Split('|').GetValue(4).ToString() + "','" + dt.Rows[i]["TRAN_BY"].ToString() + "',GETDATE())");
                                if (iPack == Convert.ToInt32(dt.Rows[i]["PACK_SIZE"].ToString()))
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE " + strTable + " SET RELATION_ST=1,FLAG=0 WHERE BARCODE='" + dt.Rows[i]["P_BARCODE"].ToString() + "'");
                                    iCheck = 0;
                                    iPack = 0;
                                }
                            }
                        }
                        else
                        {
                            dr = dtWrong.NewRow();
                            dr[0] = "0";
                            dr[1] = dt.Rows[i]["C_BARCODE"].ToString();
                            dr[2] = "MAPPING|SECONDARY BARCODE IS NOT EXIST";
                            dr[3] = dt.Rows[i]["TRAN_BY"].ToString();
                            dtWrong.Rows.Add(dr);
                            dtWrong.AcceptChanges();

                        }
                    }
                }
            }
            if (dtWrong.Rows.Count > 0)
            {
                SqlParameter[] objParameters = new SqlParameter[2];
                objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objParameters[1] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

                objParameters[0].Value = dtWrong;
                objParameters[1].Direction = ParameterDirection.Output;

                if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Wrong_dt", objParameters, "@RESULT", "@RESULT") != "")
                {

                    if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                    {
                        if (SqlDataLayer.checkConnectivity() == true)
                        {
                            DataTable DT_temp = new DataTable();
                            Central_Service.Service objService = new Central_Service.Service();
                            try
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.UploadMapping(DT_temp) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLRELETION SET FLAG = 1 WHERE FLAG = 0");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                DT_temp = null;
                                objService = null;
                            }
                        }
                    }

                    return objParameters[1].Value.ToString();
                }
                else
                {
                    throw new Exception("FAIL");
                }
            }
            else
            {

                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;
                            if (objService.UploadMapping(DT_temp) == "1")
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLRELETION SET FLAG = 1 WHERE FLAG = 0");
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            DT_temp = null;
                            objService = null;
                        }
                    }
                }

                return "Transaction Saved Successfully";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public string  DL_UpdateMappWrng(DataTable dt, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        DataTable dtParent = new DataTable();
        string strPStatus = "", strCStatus = "";

        string strFinalResult = "";

        //0,1,2,3,4
        dtParent = dt.DefaultView.ToTable(true, "P_BARCODE", "PACK_SIZE", "PARTIAL_ST", "TRAN_BY", "P_PREFIX","BATCH");
        DataRow[] drParent = dtParent.Select("PARTIAL_ST=1");
        dt = dt.DefaultView.ToTable();

        string strTable = "";
        int iTotalParent = 0, iTotalChild = 0, iSuccesParent = 0, iSuccesChild = 0, iFailParent = 0, iFailChild = 0;
        DataTable dtWrong = new DataTable();
        DataTable dtSecWrng = new DataTable();



        dtWrong.Columns.Add("P_BARCODE", typeof(string));
        dtWrong.Columns.Add("C_BARCODE", typeof(string));
        dtWrong.Columns.Add("PLANT", typeof(string));
        dtWrong.Columns.Add("BATCH", typeof(string));
        dtWrong.Columns.Add("PACK_SIZE", typeof(string));
        dtWrong.Columns.Add("TXN_TYPE", typeof(string));
        dtWrong.Columns.Add("TRAN_BY", typeof(string));


        DataRow dr;


        try
        {
            foreach (DataRow rowParent in drParent)
            {
                //
                bool bTerNot=false;

                iTotalParent++;
                string PError = "";
                int iChildWrng = 0;

                if (rowParent["P_PREFIX"].ToString() == "5")
                {
                    strTable = "TBLTER_TRANS";
                }
                else
                {
                    strTable = "TBLSEC_TRANS";
                }

                if (rowParent[1].ToString() == "0")
                {
                    strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(T.RELATION_ST AS VARCHAR(50)) + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM TBLTER_TRANS T,TBLGEN_HDR H WHERE T.BARCODE='" + rowParent[0].ToString() + "' AND H.BCIL_ID=T.BCIL_ID AND H.LABEL_TYPE='Heterogeneous'");
                }
                else
                {
                    strPStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(T.RELATION_ST AS VARCHAR(50)) + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM " + strTable + " T,TBLGEN_HDR H WHERE T.BARCODE='" + rowParent[0].ToString() + "' AND H.BCIL_ID=T.BCIL_ID AND H.LABEL_TYPE!='Heterogeneous'");
                }

                if (strPStatus != "")
                {
                    if (strPStatus.Split('|').GetValue(0).ToString() == "9")
                    {
                        PError = "MAPPING|TERTIARY BARCODE IS REJECTED";
                        iFailParent++;
                    }
                    else if (strPStatus.Split('|').GetValue(1).ToString() == "1")
                    {
                        PError = "MAPPING|TERTIARY BARCODE IS ALREADY MAPPED";
                        iFailParent++;

                    }
                    else 
                    {
                        if (rowParent[1].ToString() == "0")
                        {
                            iSuccesParent++;
                            PError = "";
                        }
                        else
                        {
                            if (strPStatus.Split('|').GetValue(3).ToString() == rowParent[5].ToString())
                            {
                                iSuccesParent++;
                                PError = "";
                            }
                            else
                            {
                                PError = "MAPPING|TERTIARY BARCODE SCANNED AGAINST WRONG BATCH";
                                iFailParent++;
                            }
                        }

                    }
                }
                else
                {
                    if (rowParent[1].ToString() == "0")
                    {
                        bTerNot=true;
                        iFailParent++;
                        PError = "MAPPING|TERTIARY HETEROGENIOUS BARCODE IS NOT EXIST";
                    }
                    else
                    {
                        bTerNot=true;
                        iFailParent++;
                        PError = "MAPPING|TERTIARY HOMOGENIOUS BARCODE IS NOT EXIST";
                    }

                }

                DataRow[] drChild = dt.Select("P_BARCODE=" + rowParent[0].ToString());

                foreach (DataRow rowChild in drChild)
                {
                    bool bNotSec = false;

                    if (rowChild[2].ToString() != "")
                    {

                        iTotalChild++;
                        string CError = "";

                        if (PError != "")
                        {
                            dr = dtWrong.NewRow();

                            dr[0] = rowParent[0].ToString();
                            dr[1] = rowChild[2].ToString();
                            dr[2] = strPlant.ToString();

                            if (bTerNot == true)
                            {
                                dr[3] = "NA";
                            }
                            else
                            {
                                dr[3] = strPStatus.Split('|').GetValue(3).ToString();
                            }
                            dr[4] = rowParent[1].ToString();
                            dr[5] = PError.ToString();
                            dr[6] = rowParent[3].ToString();

                            dtWrong.Rows.Add(dr);
                            dtWrong.AcceptChanges();


                            iFailChild++;
                        }
                        else
                        {

                            strCStatus = _Sql.Execute_String(_Sql.strSqlConn, "SELECT  DISTINCT CAST(T.[STATUS] AS VARCHAR(50)) + '|' + CAST(ISNULL(T.C_RELATION_ST,0) AS VARCHAR(50))  + '|' + CAST(T.BCIL_ID AS VARCHAR(50)) + '|' + CAST(H.BATCH_NO AS VARCHAR(50)) + '|' + CAST(H.PLANT AS VARCHAR(50)) FROM TBLSEC_TRANS T,TBLGEN_HDR H WHERE BARCODE='" + rowChild[2].ToString() + "' AND H.BCIL_ID=T.BCIL_ID");
                            if (strCStatus != "")
                            {
                                if (strCStatus.Split('|').GetValue(0).ToString() == "9")
                                {
                                    CError = "MAPPING|SECONDARY BARCODE IS REJECTED";
                                    iChildWrng++;

                                }
                                else if (strCStatus.Split('|').GetValue(1).ToString() == "1")
                                {
                                    CError = "MAPPING|SECONDARY BARCODE IS ALREADY MAPPED";
                                    iChildWrng++;

                                }
                                else
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET C_RELATION_ST=1,FLAG=0 WHERE BARCODE='" + rowChild["C_BARCODE"].ToString() + "';INSERT INTO TBLRELETION (P_BARCODE,C_BARCODE,P_PREFIX,BATCH,PLANT,TRAN_BY,TRAN_ON) VALUES ('" + rowChild["P_BARCODE"].ToString() + "','" + rowChild["C_BARCODE"].ToString() + "'," + Convert.ToInt32(rowChild["P_PREFIX"].ToString()) + ",'" + strCStatus.Split('|').GetValue(3).ToString() + "','" + strCStatus.Split('|').GetValue(4).ToString() + "','" + rowChild["TRAN_BY"].ToString() + "',GETDATE())" + ";UPDATE TBLGEN_HDR SET CHILDUTILIZED= CHILDUTILIZED+1 WHERE BCIL_ID=(SELECT BCIL_ID FROM TBLSEC_TRANS WHERE BARCODE= '"+ rowChild["C_BARCODE"].ToString()+ "')");
                                    iSuccesChild++;
                                }
                            }
                            else
                            {
                                bNotSec = true;
                                CError = "MAPPING|SECONDARY BARCODE IS NOT EXIST";
                                iChildWrng++;
                            }

                            if (CError != "")
                            {
                                iFailChild++;
                                dr = dtWrong.NewRow();

                                dr[0] = rowChild[1].ToString();
                                dr[1] = rowChild[2].ToString();
                                dr[2] = strPlant.ToString();

                                if (bNotSec == true)
                                {
                                    dr[3] = "NA";
                                }
                                else
                                {
                                    dr[3] = strCStatus.Split('|').GetValue(3).ToString();
                                }
                                dr[4] = rowParent[1].ToString();
                                dr[5] = CError.ToString();
                                dr[6] = rowParent[3].ToString();


                                dtWrong.Rows.Add(dr);
                                dtWrong.AcceptChanges();
                            }
                        }
                        //
                    }

                }

                if (PError == "")
                {
                    if (iChildWrng > 0)
                    {
                        iSuccesParent--;
                        iFailParent++;

                        dtSecWrng = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT P_BARCODE,C_BARCODE,PLANT,BATCH,'" + rowParent[1].ToString() + "' AS PACK_SIZE,'MAPPING|PACKING CANCELLED' AS TXN_TYPE,TRAN_BY FROM TBLRELETION WHERE P_BARCODE='" + rowParent[0].ToString() + "'").Tables[0];

                        iFailChild = iFailChild + dtSecWrng.Rows.Count;
                        iSuccesChild = iSuccesChild - dtSecWrng.Rows.Count;

                        if (dtSecWrng.Rows.Count > 0)
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET C_RELATION_ST=0,FLAG=0 WHERE BARCODE IN (SELECT DISTINCT C_BARCODE FROM TBLRELETION WHERE P_BARCODE='" + rowParent[0].ToString() + "');DELETE FROM TBLRELETION WHERE P_BARCODE='" + rowParent[0].ToString() + "'");

                            dtWrong.Merge(dtSecWrng);
                            dtWrong.AcceptChanges();

                        }
                    }
                    else if (iChildWrng == 0)
                    {
                        _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE " + strTable + " SET RELATION_ST=1,FLAG=0 WHERE BARCODE='" + rowParent["P_BARCODE"].ToString() + "'" + ";UPDATE TBLGEN_HDR SET PARENTUTILIZE=PARENTUTILIZE+1 where BCIL_ID=(SELECT BCIL_ID FROM TBLTER_TRANS WHERE BARCODE='" + rowParent["P_BARCODE"].ToString() + "')");
                    }
                }

            }
            strFinalResult = "Total Parent : " + iTotalParent.ToString() + " Parent Success : " + iSuccesParent.ToString() + " Parent Failed : " + iFailParent.ToString() + " Total Child : " + iTotalChild.ToString() + " Child Success : " + iSuccesChild.ToString() + " Child Failed : " + iFailChild.ToString();
            if (dtWrong.Rows.Count > 0)
            {
                SqlParameter[] objParameters = new SqlParameter[2];
                objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objParameters[1] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

                objParameters[0].Value = dtWrong;
                objParameters[1].Direction = ParameterDirection.Output;

                if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Packing_Wrong_dt", objParameters, "@RESULT", "@RESULT") != "")
                {

                    if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                    {
                        if (SqlDataLayer.checkConnectivity() == true)
                        {
                            DataTable DT_temp = new DataTable();
                            Central_Service.Service objService = new Central_Service.Service();
                            try
                            {
                                DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
                                objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                objService.Timeout = 60000;
                                if (objService.UploadMapping(DT_temp) == "1")
                                {
                                    _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLRELETION SET FLAG = 1 WHERE FLAG = 0");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                DT_temp = null;
                                objService = null;
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception("FAIL");
                }
            }
            else
            {

                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;
                            if (objService.UploadMapping(DT_temp) == "1")
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLRELETION SET FLAG = 1 WHERE FLAG = 0");
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            DT_temp = null;
                            objService = null;
                        }
                    }
                }

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return strFinalResult;


    }

    public string DL_InoutBarcode(string strMode, string strBarcode, string strSource, string strDest, string strConignee, string strDoc, string strUser)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[8];
        try
        {
            objParameters[0] = new SqlParameter("@MODE", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@BARCODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@SOURCE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@DESTINATION", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@CONSIGNEE", SqlDbType.VarChar);
            objParameters[5] = new SqlParameter("@DOC_NO", SqlDbType.VarChar);
            objParameters[6] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[7] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strMode;
            objParameters[1].Value = strBarcode;
            objParameters[2].Value = strSource;
            objParameters[3].Value = strDest;
            objParameters[4].Value = strConignee;
            objParameters[5].Value = strDoc;


            objParameters[6].Value = strUser;
            objParameters[7].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_INOUT_BARCODE", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[7].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }

    public string DL_LinkMapping()
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strResult = "0";
        if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
        {
            if (SqlDataLayer.checkConnectivity() == true)
            {
                DataTable DT_temp = new DataTable();
                Central_Service.Service objService = new Central_Service.Service();
                try
                {
                    DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[P_BARCODE],[C_BARCODE],[P_PREFIX],[TRAN_BY],[TRAN_ON],[FLAG],[BATCH],[PLANT],[DOWNLOAD_ST] FROM [dbo].[TBLRELETION] WHERE FLAG = 0").Tables[0];
                    objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                    objService.Timeout = 60000;
                    if (objService.UploadMapping(DT_temp) == "1")
                    {
                        _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLRELETION SET FLAG = 1 WHERE FLAG = 0");
                        strResult = "1";
                    }
                }
                catch (Exception ex)
                {
                    strResult = "0";
                }
                finally
                {
                    DT_temp = null;
                    objService = null;
                }
            }
        }
        return strResult;

    }

    public int DL_Sync_Company_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            //   objParameters[0].SqlDbType = SqlDbType.Structured;
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "SP_SYNC_COMPANY", objParameters, "@RESULT", "@RESULT"));
            // return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKTBLMASTER_COMPANYDATA", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_Plant_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            //return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKMASTER_PLANT", objParameters);

            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKMASTER_PLANT", objParameters, "@RESULT", "@RESULT"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_Line_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            //return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKMASTER_LINE", objParameters);
            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKMASTER_LINE", objParameters, "@RESULT", "@RESULT"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_LabelDesign_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            //return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKMASTER_LABEL_DESIGN", objParameters);
            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKMASTER_LABEL_DESIGN", objParameters, "@RESULT", "@RESULT"));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_GTIN_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            //  return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKGTIN", objParameters);
            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKGTIN", objParameters, "@RESULT", "@RESULT"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_Consignee_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            // return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKMASTER_CONSIGNEE", objParameters);
            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKMASTER_CONSIGNEE", objParameters, "@RESULT", "@RESULT"));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public int DL_Sync_Printer_Master(DataTable dt)
    {
        SqlDataLayer11 _Sql = new SqlDataLayer11();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            // return _Sql.ExecuteQueryParam(_Sql.strSqlConn, "sp_STCLINKMASTER_PRINTER", objParameters);
            return int.Parse(_Sql.ExecuteProcedureParam(_Sql.strLocal, "sp_STCLINKMASTER_PRINTER", objParameters, "@RESULT", "@RESULT"));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParameters = null;
            _Sql = null;
        }
    }

    public bool DL_Sync_Batch_Data(string strPlantCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;
        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_temp = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();

                    try
                    {
                        DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT REFNO,GS1_PREFIX,GTIN_CODE,MRP,BATCH,PACK_SIZE,EXP_DATE,MFG_DATE,TXN_QTY,BATCH_EXPORT_ST,EXEMPTED_ST,EXEMPTED_NOTIFY_INFO,EXEMPTED_COUNTRY_CODE,BATCH_ST,PLANT_CODE,ERP_ITEM_CODE,CREATED_BY,FLAG from dbo.TBLMASTER_BATCH WHERE FLAG = 0").Tables[0];
                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;
                        if (objService.CTSLinkSaveBatchDT(DT_temp, strPlantCode) != string.Empty)
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLMASTER_BATCH SET FLAG = 1 WHERE FLAG = 0");
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        DT_temp = null;
                        objService = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }

    public bool DL_Sync_ReqGen_Data(string strPlantCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;
        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_temp = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();

                    try
                    {
                        DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[PACKING_LEVEL],[LINE_ID],[LABEL_TYPE],[GTIN_ID],[PROD_DESC1],[PROD_DESC2],[PACK_SIZE],[BATCH_NO],[MFG_DATE],[EXP_DATE],[TXN_QTY],[PRINT_QTY],[STATUS],[GENERATE_ON],[GENERATED_BY],[PLANT],[FLAG] FROM [TBLGEN_HDR] WHERE FLAG = 0").Tables[0];
                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;
                        if (objService.LinkGenHdrDt(DT_temp, strPlantCode) != string.Empty)
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLGEN_HDR SET FLAG = 1 WHERE FLAG = 0");
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        DT_temp = null;
                        objService = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
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

    public bool DL_Sync_Sec_Data(string strPlantCode, string strUserName)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;

        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_REFNO = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();
                    DT_REFNO = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT DISTINCT BCIL_ID FROM TBLSEC_TRANS WHERE FLAG = 0").Tables[0];

                    if (DT_REFNO.Rows.Count > 0)
                    {
                        DataTable DT_BATCHDTLS = new DataTable();
                        DataTable DT_Temp = new DataTable();
                        for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                        {
                            DT_BATCHDTLS = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0").Tables[0];
                            if (DT_BATCHDTLS.Rows.Count > 0)
                            {
                                DT_Temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM TBLSEC_TRANS WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0").Tables[0];
                                if (DT_Temp.Rows.Count > 0)
                                {

                                    objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                    objService.Timeout = 60000;

                                    if (objService.LinkTransBytesDt(System.Text.Encoding.UTF8.GetBytes(dataTableToString(DT_Temp)), DT_BATCHDTLS.Rows[0]["BATCH_NO"].ToString().Trim(), strPlantCode, strUserName, DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim(), DT_BATCHDTLS.Rows[0]["PACKING_LEVEL"].ToString().Trim()) != string.Empty)
                                    {
                                        _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND FLAG = 0");

                                    }
                                }

                            }

                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }



    public bool DL_Sync_Tert_Data(string strPlantCode, string strUserName)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;

        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_REFNO = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();
                    DT_REFNO = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT DISTINCT BCIL_ID FROM TBLTER_TRANS WHERE FLAG = 0").Tables[0];

                    if (DT_REFNO.Rows.Count > 0)
                    {
                        DataTable DT_BATCHDTLS = new DataTable();
                        DataTable DT_Temp = new DataTable();
                        for (int i = 0; i < DT_REFNO.Rows.Count; i++)
                        {
                            DT_BATCHDTLS = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT DISTINCT BATCH_NO,PACKING_LEVEL,BCIL_ID FROM TBLGEN_HDR WHERE BCIL_ID ='" + DT_REFNO.Rows[i]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0").Tables[0];
                            if (DT_BATCHDTLS.Rows.Count > 0)
                            {
                                DT_Temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM TBLTER_TRANS WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND  FLAG = 0").Tables[0];
                                if (DT_Temp.Rows.Count > 0)
                                {

                                    objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                                    objService.Timeout = 60000;

                                    if (objService.LinkTransBytesDt(System.Text.Encoding.UTF8.GetBytes(dataTableToString(DT_Temp)), DT_BATCHDTLS.Rows[0]["BATCH_NO"].ToString().Trim(), strPlantCode, strUserName, DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim(), DT_BATCHDTLS.Rows[0]["PACKING_LEVEL"].ToString().Trim()) != string.Empty)
                                    {
                                        _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLTER_TRANS SET FLAG = 1 WHERE BCIL_ID ='" + DT_BATCHDTLS.Rows[0]["BCIL_ID"].ToString().Trim() + "' AND FLAG = 0");

                                    }
                                }

                            }

                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }


    public bool DL_Sync_Sec_Rej_Data(string strPlantCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;
        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_temp = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();

                    try
                    {
                        DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[C_RELATION_ST],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [TBLSEC_TRANS] WHERE FLAG = 0").Tables[0];
                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;

                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;
                        if (objService.LinkSecTransDt(DT_temp, strPlantCode) == "1")
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLSEC_TRANS SET FLAG = 1 WHERE FLAG = 0");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        DT_temp = null;
                        objService = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }



    public bool DL_Sync_Tert_Rej_Data(string strPlantCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        bool result = false;
        try
        {
            if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
            {
                if (SqlDataLayer.checkConnectivity() == true)
                {
                    DataTable DT_temp = new DataTable();
                    Central_Service.Service objService = new Central_Service.Service();

                    try
                    {
                        DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[BARCODE],[STATUS],[PRINTED_BY],[PRINTED_ON],[REPRINT_COUNT],[REPRINTED_BY],[REPRINTED_ON],[VALIDATED_BY],[VALIDATED_ON],[RELATION_ST],[REJECTED_BY],[REJECTED_ON],[FLAG],[PLANT],[BATCH] FROM [dbo].[TBLTER_TRANS] WHERE FLAG = 0").Tables[0];
                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;

                        objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                        objService.Timeout = 60000;
                        if (objService.LinkTerTransDt(DT_temp, strPlantCode) == "1")
                        {
                            _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLTER_TRANS SET FLAG = 1 WHERE FLAG = 0");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        DT_temp = null;
                        objService = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }

    public string DL_Child_Mapping(string strBatch,string strC_Barcode, string strUser, string strLabelType)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[5];
        try
        {
           
            objParameters[0] = new SqlParameter("@BATCH", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@C_BARCODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@LABELTYPE", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

            objParameters[0].Value = strBatch;
            objParameters[1].Value = strC_Barcode;
            objParameters[2].Value = strUser;
            objParameters[3].Value = strLabelType;
            objParameters[4].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Child_Barcode", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[4].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }



}

