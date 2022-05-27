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
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_Generator
/// </summary>
public class DL_Generator
{
    public DL_Generator()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable DL_GetPackLevel()
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[0];
        try
        {
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(PACKING_LEVEL) FROM TBLMASTER_PACKINGLEVEL", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DL_GetLineInfo(string strPackLevel, string strPlant, string strLabelType)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strPlant.Trim();
            objParameters[2].Value = strLabelType.Trim();

            //objSql = new SqlDataLayer();
            if (strPackLevel == "Tertiary")
            {
                return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT DISTINCT(NAME) FROM TBLMASTER_LINE WHERE LINE_TYPE = @PARAM1 AND PLANT_ID=@PARAM2 AND LABEL_TYPE=@PARAM3 AND STATUS=1;", objParameters);
            }
            else
            {
                return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT DISTINCT(NAME) FROM TBLMASTER_LINE WHERE LINE_TYPE = @PARAM1 AND PLANT_ID=@PARAM2 AND STATUS=1;", objParameters);
            }

            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetComboData(string strPackLevel, string strLine, string strSelectCombo, string strFillDt, string strValue)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strQuery = "";
        string strFieldNm = "";
        try
        {

            if (strSelectCombo == "cboProduct")
            {
                strFieldNm = "PROD_DESC1";
            }
            else if (strSelectCombo == "cboGTIN")
            {
                strFieldNm = "GTIN_CODE";
            }
            else if (strSelectCombo == "cboJobGTIN")
            {
                strFieldNm = "GTIN_ID";
            }
            else if (strSelectCombo == "cboLine")
            {
                strFieldNm = "LINE_ID";
            }
            else if (strSelectCombo == "cboERP")
            {
                strFieldNm = "ERP_ITEM_CODE";
            }
            else if (strSelectCombo == "cboBCILID")
            {
                strFieldNm = "BCIL_ID";
            }
            else if (strSelectCombo == "cboJobBatch")
            {
                strFieldNm = "BATCH_NO";
            }

            if (strFillDt == "cboProduct")
            {
                if (strPackLevel != "" && strSelectCombo == "cboLine")
                {
                    //strQuery = "SELECT DISTINCT(PROD_DESC1) FROM TBLMASTER_GTIN WHERE GTIN_CODE = (SELECT DISTINCT(PRODUCT_CODE) FROM TBLMASTER_LINE WHERE NAME='" + strLine + "' AND STATUS=1) AND STATUS=1";

                    strQuery = "SELECT DISTINCT(PROD_DESC1) FROM TBLMASTER_GTIN WHERE ERP_ITEM_CODE IN (SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_BATCH WHERE BATCH_STATUS=0) AND GTIN_CODE = (SELECT DISTINCT(PRODUCT_CODE) FROM TBLMASTER_LINE WHERE NAME='" + strLine + "' AND STATUS=1) AND STATUS=1";

                }
                else if (strPackLevel != "" && strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT PROD_DESC1 FROM TBLMASTER_GTIN WHERE ERP_ITEM_CODE IN (SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_BATCH WHERE BATCH_STATUS=0) AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";

                    //strQuery = "SELECT DISTINCT PROD_DESC1 FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }

            }
            else if (strFillDt == "cboGTIN")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "cboJobGTIN")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT (GTIN_ID) FROM TBLGEN_HDR WHERE " + strFieldNm + "='" + strValue + "' AND PACKING_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "cboJobBatch")
            {
                strQuery = "SELECT DISTINCT (BATCH_NO) FROM TBLGEN_HDR WHERE " + strFieldNm + "='" + strValue + "' AND PACKING_LEVEL='" + strPackLevel + "'";
            }
            else if (strFillDt == "cboERP")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "cboBCILID")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT BCIL_ID FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT BCIL_ID FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "txtPackSize")
            {
                strQuery = "SELECT DISTINCT PACK_SIZE,DAYS_EXPIRY FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
            }
            else if (strFillDt == "txtJobPackSize")
            {
                strQuery = "SELECT DISTINCT PACK_SIZE,EXP_DATE FROM TBLGEN_HDR WHERE " + strFieldNm + "='" + strValue + "' AND PACKING_LEVEL='" + strPackLevel + "'";
            }


            return _Sql.ExecuteDataset(_Sql.strSqlConn, strQuery).Tables[0];

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_BatchGetComboData(string strPackLevel, string strLine, string strSelectCombo, string strFillDt, string strValue, string strGTIN)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strQuery = "";
        string strFieldNm = "";
        try
        {

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
            else if (strSelectCombo == "cboBatch" || strSelectCombo == "cboJobBatch")
            {
                strFieldNm = "BATCH";
            }

            if (strFillDt == "cboProduct")
            {
                if (strPackLevel != "" && strSelectCombo == "cboLine")
                {
                    strQuery = "SELECT DISTINCT(PROD_DESC1) FROM TBLMASTER_GTIN WHERE GTIN_CODE = (SELECT DISTINCT(PRODUCT_CODE) FROM TBLMASTER_LINE WHERE NAME='" + strLine + "' AND STATUS=1) AND STATUS=1";
                }
                else if (strPackLevel != "" && strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT PROD_DESC1 FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }

            }
            else if (strFillDt == "cboBatch")
            {
                if (strSelectCombo == "cboGTIN")
                {
                    strQuery = "SELECT DISTINCT BATCH,SUM(TXN_QTY) AS TXN_QTY,USED_QTY FROM TBLMASTER_BATCH WHERE BATCH_ST='A' AND " + strFieldNm + "='" + strValue + "' GROUP BY BATCH,USED_QTY HAVING (SUM(TXN_QTY)-USED_QTY)>0";
                }
            }
            else if (strFillDt == "cboJobBatch")
            {
                if (strSelectCombo == "cboGTIN")
                {
                    strQuery = "SELECT DISTINCT BATCH FROM TBLMASTER_BATCH WHERE BATCH_ST='A' AND " + strFieldNm + "='" + strValue + "'";
                }
            }
            else if (strFillDt == "cboGTIN")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT GTIN_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "cboERP")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT ERP_ITEM_CODE FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "cboBCILID")
            {
                if (strSelectCombo == "cboPacking")
                {
                    strQuery = "SELECT DISTINCT BCIL_ID FROM TBLMASTER_GTIN WHERE STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
                else
                {
                    strQuery = "SELECT DISTINCT BCIL_ID FROM TBLMASTER_GTIN WHERE " + strFieldNm + "='" + strValue + "' AND STATUS=1 AND PACK_LEVEL='" + strPackLevel + "'";
                }
            }
            else if (strFillDt == "txtPackSize")
            {
                strQuery = "SELECT (SUM(TXN_QTY) - USED_QTY) AS REM_QTY,PACK_SIZE,ERP_ITEM_CODE,MFG_DATE,EXP_DATE FROM TBLMASTER_BATCH WHERE " + strFieldNm + "='" + strValue + "' AND BATCH_ST='A' AND  GTIN_CODE='" + strGTIN + "' GROUP BY BATCH,USED_QTY,PACK_SIZE,ERP_ITEM_CODE,MFG_DATE,EXP_DATE HAVING (SUM(TXN_QTY)-USED_QTY)>0";
            }
            else if (strFillDt == "txtJobPackSize")
            {
                strQuery = "SELECT DISTINCT PACK_SIZE,EXP_DATE FROM TBLMASTER_BATCH WHERE " + strFieldNm + "='" + strValue + "' AND BATCH_ST='A' AND GTIN_CODE='" + strGTIN + "'";
            }


            return _Sql.ExecuteDataset(_Sql.strSqlConn, strQuery).Tables[0];

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetGTIN(string strPackLevel, string strLine, string strPlant, string strProduct)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strPlant.Trim();
            objParameters[2].Value = strLine.Trim();
            objParameters[3].Value = strProduct.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(GTIN_CODE) FROM TBLMASTER_GTIN WHERE COMP_PRIFIX = (SELECT DISTINCT(COMPANY_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE = @PARAM1 AND PLANT_ID=@PARAM2 AND NAME=@PARAM3 AND STATUS=1) AND PACK_LEVEL=@PARAM1 AND PROD_DESC1=@PARAM4 AND STATUS=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(GTIN_CODE) FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetLabelType(string strPackLevel)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strPackLevel.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(LABEL_TYPE) FROM TBLMASTER_LABELTYPE WHERE PACKING_LEVEL=@PARAM1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(GTIN_CODE) FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetProduct(string strPackLevel, string strLine, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);

            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strPlant.Trim();
            objParameters[2].Value = strLine.Trim();

            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(PROD_DESC1) FROM TBLMASTER_GTIN WHERE COMP_PRIFIX = (SELECT DISTINCT(COMPANY_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE = @PARAM1 AND PLANT_ID=@PARAM2 AND NAME=@PARAM3 AND STATUS=1) AND PACK_LEVEL=@PARAM1 AND STATUS=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(GTIN_CODE) FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetData(string strPackLevel, string strGTIN)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strGTIN.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT(PROD_DESC1) AS 'DESC',PACK_SIZE FROM TBLMASTER_GTIN WHERE PACK_LEVEL = @PARAM1 AND GTIN_CODE= @PARAM2 AND STATUS=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(PROD_DESC1) AS 'DESC',PACK_SIZE FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetExpDays(string strPackLeve, string strGTIN)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strPackLeve.Trim();
            objParameters[1].Value = strGTIN.Trim();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DAYS_EXPIRY FROM TBLMASTER_GTIN WHERE PACK_LEVEL = @PARAM1 AND GTIN_CODE= @PARAM2 AND STATUS=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(PROD_DESC1) AS 'DESC',PACK_SIZE FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string DL_SaveData(string strPackLevel, string strLine, string strGTIN, string strDesc, string strPack, string strBatch, string strMfg, string strExp, string strQty, string strUserID, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[12];
        try
        {
            objParameters[0] = new SqlParameter("@PACKLEVEL", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@LINENO", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@GTINCODE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@DESC", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@PACKSIZE", SqlDbType.Int);
            objParameters[5] = new SqlParameter("@BATCH", SqlDbType.VarChar);
            objParameters[6] = new SqlParameter("@MFG", SqlDbType.Date);
            objParameters[7] = new SqlParameter("@EXP", SqlDbType.Date);
            objParameters[8] = new SqlParameter("@QTY", SqlDbType.Int);
            objParameters[9] = new SqlParameter("@USERID", SqlDbType.VarChar);
            objParameters[10] = new SqlParameter("@PLANT", SqlDbType.VarChar);
            objParameters[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strLine.Trim();
            objParameters[2].Value = strGTIN.Trim();
            objParameters[3].Value = strDesc.Trim();
            objParameters[4].Value = int.Parse(strPack.Trim());
            objParameters[5].Value = strBatch.Trim();
            objParameters[6].Value = Convert.ToDateTime(strMfg.Trim());
            objParameters[7].Value = Convert.ToDateTime(strExp.Trim());
            objParameters[8].Value = int.Parse(strQty.Trim());
            objParameters[9].Value = strUserID.Trim();
            objParameters[10].Value = strPlant.Trim();
            objParameters[11].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Generate_Req", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[10].Value.ToString();
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

    

    public string DL_ShipperSaveData(string strPlant, string strGTIN, string strPRODDesc, string strSerialNo, string strPackSize, string strCR_DATE, string LabelCount)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[8];
        try
        {
            objParameters[0] = new SqlParameter("@PLANT", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@GTINCODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@DESC", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@SerialNo", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@PACKSIZE", SqlDbType.Int);
            objParameters[5] = new SqlParameter("@DATE", SqlDbType.Date);
            objParameters[6] = new SqlParameter("@LABELCOUNT", SqlDbType.Int);
            objParameters[7] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);


            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strGTIN.Trim();
            objParameters[2].Value = strPRODDesc.Trim();
            objParameters[3].Value = strSerialNo.Trim();
            objParameters[4].Value = int.Parse(strPackSize.Trim());
            objParameters[5].Value = Convert.ToDateTime(strCR_DATE.Trim());
            objParameters[6].Value = int.Parse(LabelCount.Trim());
            objParameters[7].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Generate_Shipper", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[7].Value.ToString();
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

    public string DL_SaveDataDt(DataTable dt, string strUser, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Value = strUser.ToString();
            objParameters[2].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Generate", objParameters, "@RESULT", "@RESULT") != "")
            {
                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[PACKING_LEVEL],[LINE_ID],[LABEL_TYPE],[GTIN_ID],[PROD_DESC1],[PROD_DESC2],[PACK_SIZE],[BATCH_NO],[MFG_DATE],[EXP_DATE],[TXN_QTY],[PRINT_QTY],[STATUS],[GENERATE_ON],[GENERATED_BY],[PLANT],[FLAG],[ERP_ITEM_CODE] FROM [TBLGEN_HDR] WHERE FLAG = 0").Tables[0];
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;
                            if (objService.LinkGenHdrDt(DT_temp, strPlant) != string.Empty)
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLGEN_HDR SET FLAG = 1 WHERE FLAG = 0");
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



    public string DL_SaveShipperDataDt(DataTable dt, string strUser, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = dt;
            objParameters[1].Value = strUser.ToString();
            objParameters[2].Direction = ParameterDirection.Output;

            if (_Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Generate", objParameters, "@RESULT", "@RESULT") != "")
            {
                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        DataTable DT_temp = new DataTable();
                        Central_Service.Service objService = new Central_Service.Service();
                        try
                        {
                            DT_temp = _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [BCIL_ID],[PACKING_LEVEL],[LINE_ID],[LABEL_TYPE],[GTIN_ID],[PROD_DESC1],[PROD_DESC2],[PACK_SIZE],[BATCH_NO],[MFG_DATE],[EXP_DATE],[TXN_QTY],[PRINT_QTY],[STATUS],[GENERATE_ON],[GENERATED_BY],[PLANT],[FLAG],[ERP_ITEM_CODE] FROM [TBLGEN_HDR] WHERE FLAG = 0").Tables[0];
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;
                            if (objService.LinkGenHdrDt(DT_temp, strPlant) != string.Empty)
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE TBLGEN_HDR SET FLAG = 1 WHERE FLAG = 0");
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

    public DataTable DL_GetBatch_ERP(string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strBatch.Trim();

            if (strBatch == string.Empty)
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT G.[ERP_ITEM_CODE] FROM TBLMASTER_BATCH B,TBLMASTER_GTIN G WHERE B.BATCH_STATUS=0 AND CAST(SUBSTRING(B.GTIN_CODE,2,13) AS VARCHAR(12))=CAST(SUBSTRING(G.GTIN_CODE,2,13) AS VARCHAR(12))", objParameters);
            }
            else
            {
                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT G.[ERP_ITEM_CODE] FROM TBLMASTER_BATCH B,TBLMASTER_GTIN G WHERE B.BATCH_STATUS=0 AND CAST(SUBSTRING(B.GTIN_CODE,2,13) AS VARCHAR(12))=CAST(SUBSTRING(G.GTIN_CODE,2,13) AS VARCHAR(12)) AND B.BATCH = @PARAM1", objParameters);
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

    public DataTable DL_GetDataOnERP(string strPackLevel, string strERPCode, string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        string strQuery = "";
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);

            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strERPCode.Trim();
            objParameters[2].Value = strBatch.Trim();

            if (strBatch == string.Empty)
            {
                strQuery = "SELECT DISTINCT [GTIN_CODE],[PROD_DESC1],"
                  + " PACK_SIZE FROM TBLMASTER_GTIN WHERE ERP_ITEM_CODE=@PARAM2 AND PACK_LEVEL=@PARAM1";

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, strQuery, objParameters);
            }
            else
            {
                strQuery = "SELECT DISTINCT M.[GTIN_CODE],M.[PROD_DESC1],"
                   + " (SELECT TOP(1) B.MFG_DATE FROM TBLMASTER_BATCH B WHERE CAST(SUBSTRING(B.GTIN_CODE,2,12) AS VARCHAR(12))=CAST(SUBSTRING(M.GTIN_CODE,2,12) AS VARCHAR(12)) AND BATCH=@PARAM3 AND BATCH_STATUS=0)  AS 'MFG_DATE',"
                   + " (SELECT TOP(1) B1.EXP_DATE FROM TBLMASTER_BATCH B1 WHERE CAST(SUBSTRING(B1.GTIN_CODE,2,12) AS VARCHAR(12))=CAST(SUBSTRING(M.GTIN_CODE,2,12) AS VARCHAR(12)) AND BATCH=@PARAM3 AND BATCH_STATUS=0)  AS 'EXP_DATE',"
                   + " M.PACK_SIZE FROM TBLMASTER_GTIN M WHERE ERP_ITEM_CODE=@PARAM2 AND PACK_LEVEL=@PARAM1";

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, strQuery, objParameters);
            }


            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(GTIN_CODE) FROM TBLMASTER_GTIN WHERE PACK_LEVEL='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
