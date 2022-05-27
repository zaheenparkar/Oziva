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
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_Rejection
/// </summary>
public class DL_BatchCreation
{
    public DL_BatchCreation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable DL_BatchCombo(string strPlant, string strCompany, string strGTIN, string strSelectCombo, string strFillDt, string strValue)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strQuery = "";
        string strFieldNm = "";
        try
        {

            if (strSelectCombo == "cboPlant")
            {
                strFieldNm = "COMPANY";
            }
            if (strSelectCombo == "cboProduct")
            {
                strFieldNm = "PROD_DESC1";
            }
            else if (strSelectCombo == "cboGTIN")
            {
                strFieldNm = "GTIN_CODE";
            }
            else if (strSelectCombo == "cboERP")
            {
                strFieldNm = "ERP_ITEM_CODE";
            }
            else if (strSelectCombo == "cboBCILID")
            {
                strFieldNm = "BCIL_ID";
            }

            if (strFillDt == "cboCompany")
            {
                if (strSelectCombo == "cboPlant")
                {
                    strQuery = "SELECT DISTINCT GS1_PREFIX FROM TBLMASTER_COMPANY WHERE PLANT='" + strPlant + "' AND STATUS=1";
                }
            }
            else if (strFillDt == "cboProduct")
            {
                if (strSelectCombo == "cboCompany")
                {
                    strQuery = "SELECT DISTINCT PROD_DESC1 FROM TBLMASTER_GTIN WHERE COMP_PRIFIX='" + strCompany + "' AND STATUS=1";
                }
            }
            else if (strFillDt == "cboGTIN")
            {
                if (strSelectCombo == "cboProduct")
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND COMP_PRIFIX='" + strCompany + "'";
                }
            }
            else if (strFillDt == "cboERP")
            {
                if (strSelectCombo == "cboGTIN")
                {
                    strQuery = "SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND COMP_PRIFIX='" + strCompany + "'";
                }
            }
            else if (strFillDt == "cboBCILID")
            {
                if (strSelectCombo == "cboERP")
                {
                    strQuery = "SELECT DISTINCT BCIL_ID FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND GTIN_CODE='" + strGTIN + "' AND COMP_PRIFIX='" + strCompany + "'";
                }
            }
            else if (strFillDt == "txtPackSize")
            {
                strQuery = "SELECT DISTINCT PACK_SIZE,DAYS_EXPIRY FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND COMP_PRIFIX='" + strCompany + "'";
            }

            return _Sql.ExecuteDataset(_Sql.strSqlConn, strQuery).Tables[0];

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string DL_SaveBatchDt(DataTable dt, string strUser, string strPlantCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 1000);

            objParameters[0].Value = dt;
            objParameters[1].Value = strUser.ToString();
            objParameters[2].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Batch_Creation", objParameters, "@RESULT", "@RESULT") != "")
            {
                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT REFNO,GS1_PREFIX,GTIN_CODE,MRP,BATCH,PACK_SIZE,EXP_DATE,MFG_DATE,TXN_QTY,BATCH_EXPORT_ST,EXEMPTED_ST,EXEMPTED_NOTIFY_INFO,EXEMPTED_COUNTRY_CODE,BATCH_ST,PLANT_CODE,ERP_ITEM_CODE,CREATED_BY,FLAG,BCIL_ID from dbo.TBLMASTER_BATCH WHERE FLAG = 0").Tables[0];
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;
                            if (objService.CTSLinkSaveBatchDT(DT_temp, strPlantCode) != string.Empty)
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLMASTER_BATCH SET FLAG = 1 WHERE FLAG = 0");
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
                return objParameters[2].Value.ToString();
            }
            else
            {
                throw new Exception("FAIL");
            }
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(PROD_DESC1) AS 'DESC',PACK_SIZE FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable DL_MasterGetBatch(string strPlant, string strERP)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strERP.Trim();

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND SUBSTRING(GTIN_CODE,2,12)=@PARAM2 AND BATCH_ST='A' AND BATCH_STATUS=0", objParameters);

            // return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND BATCH_ST='A' AND BATCH_STATUS=0", objParameters);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetERP_Items(string strCompanyPrefix)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strCompanyPrefix.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(ERP_ITEM_CODE) FROM TBLMASTER_GTIN WHERE COMP_PRIFIX = @PARAM1  ORDER BY ERP_ITEM_CODE", objParameters);
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

    public DataTable DL_GetProductData_Batch(string strCompanyPrefix, string strERP_Item)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strCompanyPrefix.Trim();
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[1].Value = strERP_Item.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT [GTIN_CODE], [PROD_DESC1], [PACK_SIZE], [BCIL_ID],[DAYS_EXPIRY] FROM TBLMASTER_GTIN WHERE [GTIN_CODE] LIKE '0%' AND COMP_PRIFIX = @PARAM1 AND [ERP_ITEM_CODE] = @PARAM2", objParameters);
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

    public DataTable DL_GetProductData_ERP(string strCompanyPrefix)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strCompanyPrefix.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT [GTIN_CODE], [ERP_ITEM_CODE], [PACK_SIZE], [BCIL_ID],[DAYS_EXPIRY] FROM TBLMASTER_GTIN WHERE [GTIN_CODE] LIKE '0%' AND COMP_PRIFIX = @PARAM1 ", objParameters);
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
    public DataTable DL_GetCompany_batch(string strProdCode)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strProdCode.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT [GS1_PREFIX] FROM [dbo].[TBLMASTER_COMPANY] WHERE PLANT = @PARAM1", objParameters);
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
    public DataTable DL_GetBatch_Details(string strBatch,bool bClose)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strBatch.Trim();


            if (strBatch.Trim() == string.Empty && bClose==false)
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT [REFNO], [GS1_PREFIX], [GTIN_CODE], [MRP], [BATCH], [PACK_SIZE], [EXP_DATE], [MFG_DATE], [TXN_QTY], [BATCH_EXPORT_ST], [EXEMPTED_ST], [EXEMPTED_NOTIFY_INFO], [EXEMPTED_COUNTRY_CODE], [BATCH_ST], [PLANT_CODE], [ERP_ITEM_CODE] FROM [TBLMASTER_BATCH] WHERE BATCH_STATUS = 0", objParameters);
            }
            else if(strBatch!=string.Empty && bClose==false)
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT [REFNO], [GS1_PREFIX], [GTIN_CODE], [MRP], [BATCH], [PACK_SIZE], [EXP_DATE], [MFG_DATE], [TXN_QTY], [BATCH_EXPORT_ST], [EXEMPTED_ST], [EXEMPTED_NOTIFY_INFO], [EXEMPTED_COUNTRY_CODE], [BATCH_ST], [PLANT_CODE], [ERP_ITEM_CODE] FROM [TBLMASTER_BATCH] WHERE BATCH_STATUS = 0 AND [BATCH] = @PARAM1", objParameters);
            }
            else if (strBatch != string.Empty && bClose == true)
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT [REFNO], [GS1_PREFIX], [GTIN_CODE], [MRP], [BATCH], [PACK_SIZE], [EXP_DATE], [MFG_DATE], [TXN_QTY], [BATCH_EXPORT_ST], [EXEMPTED_ST], [EXEMPTED_NOTIFY_INFO], [EXEMPTED_COUNTRY_CODE], [BATCH_ST], [PLANT_CODE], [ERP_ITEM_CODE] FROM [TBLMASTER_BATCH] WHERE [BATCH] = @PARAM1 AND BATCH_STATUS=1", objParameters);
            }
            else if (strBatch == string.Empty && bClose == true)
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT [REFNO], [GS1_PREFIX], [GTIN_CODE], [MRP], [BATCH], [PACK_SIZE], [EXP_DATE], [MFG_DATE], [TXN_QTY], [BATCH_EXPORT_ST], [EXEMPTED_ST], [EXEMPTED_NOTIFY_INFO], [EXEMPTED_COUNTRY_CODE], [BATCH_ST], [PLANT_CODE], [ERP_ITEM_CODE] FROM [TBLMASTER_BATCH] WHERE BATCH_STATUS=1", objParameters);
            }
            else
            {
                return new DataTable("temp");
            }
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

    public DataTable DL_GetBatch_Select(string strBatch, string strGTIN)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strBatch.Trim();
            objParameters[1].Value = strGTIN.Trim();

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT [REFNO], [GS1_PREFIX], [GTIN_CODE], [MRP], [BATCH], [PACK_SIZE], [EXP_DATE], [MFG_DATE], [TXN_QTY], [BATCH_EXPORT_ST], [EXEMPTED_ST], [EXEMPTED_NOTIFY_INFO], [EXEMPTED_COUNTRY_CODE], [BATCH_ST], [PLANT_CODE], [ERP_ITEM_CODE] FROM [TBLMASTER_BATCH] WHERE BATCH_STATUS = 0", objParameters);


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

    public void DL_CloseOpenBatch(string strBatch, bool bClose)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strBatch.Trim();

     
            if (bClose == true)
            {
                _Sql.ExecuteQueryParam(_Sql.strSqlConn, "UPDATE [TBLMASTER_BATCH] SET BATCH_STATUS = 1 WHERE [BATCH] = @PARAM1", objParameters);
            }
            else
            {
                _Sql.ExecuteQueryParam(_Sql.strSqlConn, "UPDATE [TBLMASTER_BATCH] SET BATCH_STATUS = 0 WHERE [BATCH] = @PARAM1", objParameters);
            }
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

    public DataTable DL_GetBatch(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            
            objParameters[0].Value = strPlant.Trim();

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND BATCH_ST='A' AND BATCH_STATUS=0 ORDER BY BATCH", objParameters);

            // return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND BATCH_ST='A' AND BATCH_STATUS=0", objParameters);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_ShipperGen(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);

            objParameters[0].Value = strPlant.Trim();

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (GTIN_CODE) FROM TBLMASTER_GTIN  where PACK_LEVEL = 'Tertiary'", objParameters);

            // return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND BATCH_ST='A' AND BATCH_STATUS=0", objParameters);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GTINProduct(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);

            objParameters[0].Value = strPlant.Trim();


            string strQuery = "SELECT DISTINCT M.[GTIN_CODE] AS GTIN_CODE,M.[PROD_DESC1] AS PROD_DESC1,"
                     + " (SELECT TOP(1) B.MFG_DATE FROM TBLMASTER_BATCH B WHERE CAST(SUBSTRING(B.GTIN_CODE,2,12) AS VARCHAR(12))=CAST(SUBSTRING(M.GTIN_CODE,2,12) AS VARCHAR(12)))  AS 'MFG_DATE',"
                     + " (SELECT TOP(1) B1.EXP_DATE FROM TBLMASTER_BATCH B1 WHERE CAST(SUBSTRING(B1.GTIN_CODE,2,12) AS VARCHAR(12))=CAST(SUBSTRING(M.GTIN_CODE,2,12) AS VARCHAR(12)))  AS 'EXP_DATE',"
                     + " M.PACK_SIZE as PACK_SIZE FROM TBLMASTER_GTIN M WHERE GTIN_CODE = @PARAM1";

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, strQuery, objParameters);

            // return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH) FROM TBLMASTER_BATCH WHERE PLANT_CODE = @PARAM1 AND BATCH_ST='A' AND BATCH_STATUS=0", objParameters);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetJobBatch(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);

            objParameters[0].Value = strPlant.Trim();


            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH_NO) FROM TBLMASTER_JOB WHERE STATUS=0 AND PLANT = @PARAM1", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetJobData(string strPlant,string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strBatch.Trim();


            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT GTIN_CODE,PACK_SIZE FROM TBLMASTER_JOB WHERE STATUS=0 AND PLANT = @PARAM1", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
