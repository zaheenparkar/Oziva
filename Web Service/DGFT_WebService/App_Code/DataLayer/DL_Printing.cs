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
/// Summary description for DL_Printing
/// </summary>
public class DL_Printing
{
    public DL_Printing()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string DL_GetLoginPlant(string strUserID)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strUserID.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_String(_Sql.strSqlConn, "SELECT PLANTCODE FROM TBLMASTER_USER WHERE USER_ID = @PARAM1 AND ACTIVATE_ST=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetPrintMethod()
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT PRINT_METHOD FROM TBLMASTER_PRINTMETHOD").Tables[0];
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetPrntPackLvl(string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (PACKING_LEVEL) FROM TBLGEN_HDR WHERE PLANT = @PARAM1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DL_GetPrntLineNo(string strPlant, string strPackLevel)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT DISTINCT (NAME) FROM TBLMASTER_LINE WHERE PLANT_ID = @PARAM1 AND LINE_TYPE=@PARAM2 AND STATUS=1; SELECT DISTINCT(LABEL_TYPE) FROM TBLMASTER_LABELTYPE WHERE PACKING_LEVEL=@PARAM2", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DL_GetPrnPortIP(string strPrinterName, string strLabelSize,string strLabelType,string strLine,string strpackLevel)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[5];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);
            objParameters[0].Value = strPrinterName.Trim();
            objParameters[1].Value = strLabelSize.Trim();
            objParameters[2].Value = strLabelType.Trim();
            objParameters[3].Value = strLine.Trim();
            objParameters[4].Value = strpackLevel.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT IPADD,PORTNO FROM TBLMASTER_PRINTER WHERE PRINTER_NAME = @PARAM1 AND STATUS=1; SELECT PRN FROM TBLMASTER_LABEL_DESIGN WHERE LABEL_SIZE=@PARAM2 AND LABEL_TYPE=@PARAM3 AND LINEID=@PARAM4 AND PACKING_LEVEL=@PARAM5 AND STATUS=1;SELECT ISNULL(PRINT_FILE,'') FROM TBLMASTER_LINE WHERE NAME=@PARAM4", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DL_OnlineScanning_Info(string strLine)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strLine.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT dbo.TBLMASTER_LINE.NAME, dbo.TBLMASTER_LINE.SCANNING_IP, dbo.TBLMASTER_LINE.PORT, dbo.TBLMASTER_PRINTER.IPADD, dbo.TBLMASTER_PRINTER.PORTNO " +
                    "FROM dbo.TBLMASTER_LINE INNER JOIN dbo.TBLMASTER_PRINTER ON dbo.TBLMASTER_LINE.NAME = dbo.TBLMASTER_PRINTER.LINE_ID " +
                    "WHERE dbo.TBLMASTER_LINE.NAME = @PARAM1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetPrntProdName(string strPlant, string strPackLevel, string strLineNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (PROD_DESC1) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND STATUS=0", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetPrntBatch(string strPlant, string strPackLevel, string strLineNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH_NO) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND STATUS=0", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetBatch(string strPlant, string strPackLevel, string strLineNo, string strProduct)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();
            objParameters[3].Value = strProduct.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH_NO) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND PROD_DESC1=@PARAM4", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetProduct(string strPlant, string strPackLevel, string strLineNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
           
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();
     

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (PROD_DESC1) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetJobGTIN(string strPlant, string strPackLevel, string strLineNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
           
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();
            

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (GTIN_ID) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetJobBT(string strPlant, string strPackLevel, string strLineNo, string strGTIN)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();
            objParameters[3].Value = strGTIN.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (BATCH_NO) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND GTIN_ID=@PARAM4", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

 
    public DataTable DL_GetJobPkSize(string strPlant, string strPackLevel, string strLineNo, string strGTIN,string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[5];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strLineNo.Trim();
            objParameters[3].Value = strGTIN.Trim();
            objParameters[4].Value = strBatch.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT PACK_SIZE,EXP_DATE FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND GTIN_ID=@PARAM4 AND BATCH_NO=@PARAM5", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetSerial(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch, string strSerialNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strQuery = "";
        string strTable = "";
        try
        {
            if (strPackLevel == "Tertiary")
            {
                strTable = "TBLTER_TRANS";
            }
            else
            {
                strTable = "TBLSEC_TRANS";
            }

            if (strSerialNo == "")
            {

                SqlParameter[] objParameters = new SqlParameter[5];

                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);

                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                objParameters[3].Value = strProdName.Trim();
                objParameters[4].Value = strBatch.Trim();

                strQuery = "SELECT T.BARCODE,H.GTIN_ID,H.PROD_DESC1,H.BATCH_NO,H.MFG_DATE,H.EXP_DATE FROM TBLGEN_HDR H," + strTable + " T" +
                           " WHERE T.BCIL_ID=H.BCIL_ID AND T.STATUS IN (0,1)" +
                           " AND H.PLANT=@PARAM1" +
                           " AND H.PACKING_LEVEL=@PARAM2" +
                           " AND H.LINE_ID=@PARAM3" +
                           " AND H.PROD_DESC1=@PARAM4" +
                           " AND H.BATCH_NO=@PARAM5";
                           

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, strQuery, objParameters);
            }
            else
            {
                SqlParameter[] objParameters = new SqlParameter[6];

                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);
                objParameters[5] = new SqlParameter("@PARAM6", SqlDbType.VarChar);

                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                objParameters[3].Value = strProdName.Trim();
                objParameters[4].Value = strBatch.Trim();
                objParameters[5].Value = "%" + strSerialNo.Trim() + "%";


                strQuery = "SELECT T.BARCODE,H.GTIN_ID,H.PROD_DESC1,H.BATCH_NO,H.MFG_DATE,H.EXP_DATE FROM TBLGEN_HDR H," + strTable + " T" +
                           " WHERE T.BCIL_ID=H.BCIL_ID AND T.STATUS IN (0,1)" +
                           " AND H.PLANT=@PARAM1" +
                           " AND H.PACKING_LEVEL=@PARAM2" +
                           " AND H.LINE_ID=@PARAM3" +
                           " AND H.PROD_DESC1=@PARAM4" +
                           " AND H.BATCH_NO=@PARAM5" +
                           " AND BARCODE LIKE @PARAM6";

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, strQuery, objParameters);

            }

           
         
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   

    public DataTable DL_GetLabelSize(string strPackLevel, string strLabelType)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);

            objParameters[0].Value = strPackLevel.Trim();
            objParameters[1].Value = strLabelType.Trim();


            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT (LABEL_SIZE) FROM TBLMASTER_LABEL_DESIGN WHERE LABEL_TYPE = @PARAM2 AND PACKING_LEVEL=@PARAM1 AND STATUS=1", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public DataTable DL_GetPrntData(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch)
    //{
    //    SqlDataLayer _Sql = new SqlDataLayer();

    //    try
    //    {
    //        if ((strProdName.Trim() == "" || strProdName.Trim() == "Select") && (strBatch.Trim() == "" || strBatch.Trim() == "Select"))
    //        {
    //            SqlParameter[] objParameters = new SqlParameter[3];
    //            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
    //            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
    //            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
    //            objParameters[0].Value = strPlant.Trim();
    //            objParameters[1].Value = strPackLevel.Trim();
    //            objParameters[2].Value = strLineNo.Trim();
    //            //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0", objParameters);

    //            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT distinct T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,SUM(T.TXN_QTY) AS TXN_QTY,T.PRINT_QTY,(SUM(T.TXN_QTY)-T.PRINT_QTY) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T  WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0  GROUP BY T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.PRINT_QTY,T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE", objParameters);


    //        }
    //        else if ((strProdName.Trim() != "" && strProdName.Trim() != "Select") && (strBatch.Trim() != "" && strBatch.Trim() != "Select"))
    //        {
    //            SqlParameter[] objParameters = new SqlParameter[5];
    //            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
    //            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
    //            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
    //            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
    //            objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);
    //            objParameters[0].Value = strPlant.Trim();
    //            objParameters[1].Value = strPackLevel.Trim();
    //            objParameters[2].Value = strLineNo.Trim();
    //            objParameters[3].Value = strProdName.Trim();
    //            objParameters[4].Value = strBatch.Trim();

    //            //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND PROD_DESC1=@PARAM4 AND BATCH_NO=@PARAM5 AND T.STATUS=0", objParameters);

    //            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT distinct T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,SUM(T.TXN_QTY) AS TXN_QTY,T.PRINT_QTY,(SUM(T.TXN_QTY)-T.PRINT_QTY) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T  WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0 AND PROD_DESC1=@PARAM4 AND BATCH_NO=@PARAM5 GROUP BY T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.PRINT_QTY,T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE", objParameters);
    //        }
    //        else if (strProdName.Trim() != "" && strProdName.Trim() != "Select")
    //        {
    //            SqlParameter[] objParameters = new SqlParameter[4];
    //            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
    //            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
    //            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
    //            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
    //            objParameters[0].Value = strPlant.Trim();
    //            objParameters[1].Value = strPackLevel.Trim();
    //            objParameters[2].Value = strLineNo.Trim();
    //            objParameters[3].Value = strProdName.Trim();
    //            //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND PROD_DESC1=@PARAM4 AND T.STATUS=0", objParameters);

    //            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT distinct T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,SUM(T.TXN_QTY) AS TXN_QTY,T.PRINT_QTY,(SUM(T.TXN_QTY)-T.PRINT_QTY) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T  WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0 AND PROD_DESC1=@PARAM4 GROUP BY T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.PRINT_QTY,T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE", objParameters);
    //        }
    //        else if (strBatch.Trim() != "" && strBatch.Trim() != "Select")
    //        {
    //            SqlParameter[] objParameters = new SqlParameter[4];
    //            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
    //            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
    //            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
    //            objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
    //            objParameters[0].Value = strPlant.Trim();
    //            objParameters[1].Value = strPackLevel.Trim();
    //            objParameters[2].Value = strLineNo.Trim();
    //            objParameters[3].Value = strBatch.Trim();

    //            //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND BATCH_NO=@PARAM4 AND T.STATUS=0", objParameters);

    //            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT distinct T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,SUM(T.TXN_QTY) AS TXN_QTY,T.PRINT_QTY,(SUM(T.TXN_QTY)-T.PRINT_QTY) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T  WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0 AND BATCH_NO=@PARAM4 GROUP BY T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.PRINT_QTY,T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE", objParameters);
    //        }
    //        else
    //        {
    //            return new DataTable();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public DataSet DL_GetprintConfig(string strPlant, string strPackLevel, string strline)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[0].Value = strPlant.Trim();
            objParameters[1].Value = strPackLevel.Trim();
            objParameters[2].Value = strline.Trim();

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT DISTINCT LABEL_TYPE,PRINTING_METHOD FROM TBLMASTER_LINE WHERE PLANT_ID = @PARAM1 AND LINE_TYPE=@PARAM2 AND NAME=@PARAM3 AND STATUS=1; SELECT DISTINCT PRINTER_NAME + '|' + DRIVER_MODEL  FROM TBLMASTER_PRINTER WHERE LINE_ID=@PARAM3 AND STATUS=1;SELECT DISTINCT (PROD_DESC1) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND STATUS=0;SELECT DISTINCT (BATCH_NO) FROM TBLGEN_HDR WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND STATUS=0", objParameters);
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable DL_GetPrintdata(int iRefNo, int iGenQty, string strUsername, string strPacking)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        DataTable dt = new DataTable();
        try
        {

            objParameters[0] = new SqlParameter("@REFNO", SqlDbType.Int);
            objParameters[1] = new SqlParameter("@TXN_QTY", SqlDbType.Int);
            objParameters[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar);

           
            objParameters[0].Value = iRefNo;
            objParameters[1].Value = iGenQty;
            objParameters[2].Value = strUsername.ToString();


            if (strPacking == "Tertiary")
            {
                dt = _Sql.ExecuteProcedureParamTable(_Sql.strSqlConn, "sp_Gen_Ter", objParameters);

            }
            else if (strPacking == "Secondary 1" || strPacking == "Secondary 2" || strPacking == "Secondary 3" || strPacking == "Secondary 4")
            {
                dt = _Sql.ExecuteProcedureParamTable(_Sql.strSqlConn, "sp_Gen_Ser", objParameters);
                
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }

    public DataTable DL_LinkGetPrintdata(string strRefNo, int iGenQty,string strBatch,string strPlant, string strUsername, string strPacking)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        DataTable dt = new DataTable();
        string strTableName = "";
        try
        {

            objParameters[0] = new SqlParameter("@REFNO", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@TXN_QTY", SqlDbType.Int);
            objParameters[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar);


            objParameters[0].Value = strRefNo;
            objParameters[1].Value = iGenQty;
            objParameters[2].Value = strUsername.ToString();


            if (strPacking == "Tertiary")
            {
                dt = _Sql.ExecuteProcedureParamTable(_Sql.strSqlConn, "sp_Gen_Ter", objParameters);

                strTableName = "TBLTER_TRANS";
            }
            else if (strPacking == "Secondary 1" || strPacking == "Secondary 2" || strPacking == "Secondary 3" || strPacking == "Secondary 4")
            {
                dt = _Sql.ExecuteProcedureParamTable(_Sql.strSqlConn, "sp_Gen_Ser", objParameters);

                strTableName = "TBLSEC_TRANS";
            }

            if (dt.Rows.Count > 0)
            {
                if (ConfigurationSettings.AppSettings["IsCentral"].ToString() == "Yes")
                {
                    if (SqlDataLayer.checkConnectivity() == true)
                    {
                        Central_Service.Service objService = new Central_Service.Service();

                        try
                        {
                            objService.Url = ConfigurationSettings.AppSettings["Central_Service.Service"].ToString();
                            objService.Timeout = 60000;

                            if (objService.LinkTransBytesDt(System.Text.Encoding.UTF8.GetBytes(dataTableToString(dt)), strBatch, strPlant, strUsername, strRefNo.ToString(), strPacking) != string.Empty)
                            {
                                _Sql.ExecuteNonQuery(_Sql.strSqlConn, "UPDATE " + strTableName + " SET FLAG = 1 WHERE FLAG = 0");

                            }

                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
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
        return dt;
    }

    public string DL_SavePrint(int iRefNo, int iCount, string strLabelType, string strUsername)
    {
        SqlDataLayer objSql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[5];
        try
        {
            objParameters[0] = new SqlParameter("@REFNO", SqlDbType.Int);
            objParameters[1] = new SqlParameter("@LABELCOUNT", SqlDbType.Int);
            objParameters[2] = new SqlParameter("@LABEL_TYPE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

            objParameters[0].Value = iRefNo;
            objParameters[1].Value = iCount;
            objParameters[2].Value = strLabelType;
            objParameters[3].Value = strUsername.Trim();
            objParameters[4].Direction = ParameterDirection.Output;


            if (objSql.ExecuteProcedureParam(objSql.strSqlConn, "sp_generatebarcode", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[5].Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objParameters = null;
            objSql = null;
        }
    }

    public DataTable DL_GetPrntData(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if ((strProdName.Trim() == "" || strProdName.Trim() == "Select") && (strBatch.Trim() == "" || strBatch.Trim() == "Select"))
            {
                SqlParameter[] objParameters = new SqlParameter[3];
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND T.STATUS=0", objParameters);

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, " SELECT DISTINCT H.BCIL_ID,(SELECT TOP(1) GTIN_ID FROM TBLGEN_HDR G WHERE G.BCIL_ID=H.BCIL_ID) AS GTIN_ID," +
                         " (SELECT TOP(1) PROD_DESC1 FROM TBLGEN_HDR P WHERE P.BCIL_ID=H.BCIL_ID) AS PROD_DESC1," +
                         " (SELECT TOP(1) BATCH_NO FROM TBLGEN_HDR B WHERE B.BCIL_ID=H.BCIL_ID) AS BATCH_NO," +
                         " (SELECT SUM(T.TXN_QTY) FROM TBLGEN_HDR T WHERE T.BCIL_ID=H.BCIL_ID) AS TXN_QTY," +
                         " (SELECT TOP(1) U.PRINT_QTY FROM TBLGEN_HDR U WHERE U.BCIL_ID=H.BCIL_ID) AS PRINT_QTY," +
                         " (SELECT (SUM(A.TXN_QTY)-A.PRINT_QTY) FROM TBLGEN_HDR A WHERE A.BCIL_ID=H.BCIL_ID GROUP BY A.PRINT_QTY) AS BALANCE_QTY," +
                         " (SELECT TOP(1) S.PACK_SIZE FROM TBLGEN_HDR S WHERE S.BCIL_ID=H.BCIL_ID) AS PACK_SIZE," +
                         " (SELECT TOP(1) MD.MFG_DATE FROM TBLGEN_HDR MD WHERE MD.BCIL_ID=H.BCIL_ID) AS MFG_DATE," +
                         " (SELECT TOP(1) ME.EXP_DATE FROM TBLGEN_HDR ME WHERE ME.BCIL_ID=H.BCIL_ID) AS EXP_DATE" +

                         "   FROM TBLGEN_HDR H WHERE H.PLANT=@PARAM1 AND H.PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND H.STATUS=0", objParameters);


            }
            else if ((strProdName.Trim() != "" && strProdName.Trim() != "Select") && (strBatch.Trim() != "" && strBatch.Trim() != "Select"))
            {
                SqlParameter[] objParameters = new SqlParameter[5];
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@PARAM5", SqlDbType.VarChar);
                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                objParameters[3].Value = strProdName.Trim();
                objParameters[4].Value = strBatch.Trim();

                //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND PROD_DESC1=@PARAM4 AND BATCH_NO=@PARAM5 AND T.STATUS=0", objParameters);

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, " SELECT DISTINCT H.BCIL_ID,(SELECT TOP(1) GTIN_ID FROM TBLGEN_HDR G WHERE G.BCIL_ID=H.BCIL_ID) AS GTIN_ID," +
                    " (SELECT TOP(1) PROD_DESC1 FROM TBLGEN_HDR P WHERE P.BCIL_ID=H.BCIL_ID) AS PROD_DESC1," +
                    " (SELECT TOP(1) BATCH_NO FROM TBLGEN_HDR B WHERE B.BCIL_ID=H.BCIL_ID) AS BATCH_NO," +
                    " (SELECT SUM(T.TXN_QTY) FROM TBLGEN_HDR T WHERE T.BCIL_ID=H.BCIL_ID) AS TXN_QTY," +
                    " (SELECT TOP(1) U.PRINT_QTY FROM TBLGEN_HDR U WHERE U.BCIL_ID=H.BCIL_ID) AS PRINT_QTY," +
                    " (SELECT (SUM(A.TXN_QTY)-A.PRINT_QTY) FROM TBLGEN_HDR A WHERE A.BCIL_ID=H.BCIL_ID GROUP BY A.PRINT_QTY) AS BALANCE_QTY," +
                    " (SELECT TOP(1) S.PACK_SIZE FROM TBLGEN_HDR S WHERE S.BCIL_ID=H.BCIL_ID) AS PACK_SIZE," +
                    " (SELECT TOP(1) MD.MFG_DATE FROM TBLGEN_HDR MD WHERE MD.BCIL_ID=H.BCIL_ID) AS MFG_DATE," +
                    " (SELECT TOP(1) ME.EXP_DATE FROM TBLGEN_HDR ME WHERE ME.BCIL_ID=H.BCIL_ID) AS EXP_DATE" +

                    "   FROM TBLGEN_HDR H WHERE H.PLANT=@PARAM1 AND H.PACKING_LEVEL=@PARAM2 AND H.LINE_ID=@PARAM3 AND H.PROD_DESC1=@PARAM4 AND H.BATCH_NO=@PARAM5 AND H.STATUS=0", objParameters);


            }
            else if (strProdName.Trim() != "" && strProdName.Trim() != "Select")
            {
                SqlParameter[] objParameters = new SqlParameter[4];
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                objParameters[3].Value = strProdName.Trim();
                //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND PROD_DESC1=@PARAM4 AND T.STATUS=0", objParameters);

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, " SELECT DISTINCT H.BCIL_ID,(SELECT TOP(1) GTIN_ID FROM TBLGEN_HDR G WHERE G.BCIL_ID=H.BCIL_ID) AS GTIN_ID," +
                   " (SELECT TOP(1) PROD_DESC1 FROM TBLGEN_HDR P WHERE P.BCIL_ID=H.BCIL_ID) AS PROD_DESC1," +
                   " (SELECT TOP(1) BATCH_NO FROM TBLGEN_HDR B WHERE B.BCIL_ID=H.BCIL_ID) AS BATCH_NO," +
                   " (SELECT SUM(T.TXN_QTY) FROM TBLGEN_HDR T WHERE T.BCIL_ID=H.BCIL_ID) AS TXN_QTY," +
                   " (SELECT TOP(1) U.PRINT_QTY FROM TBLGEN_HDR U WHERE U.BCIL_ID=H.BCIL_ID) AS PRINT_QTY," +
                   " (SELECT (SUM(A.TXN_QTY)-A.PRINT_QTY) FROM TBLGEN_HDR A WHERE A.BCIL_ID=H.BCIL_ID GROUP BY A.PRINT_QTY) AS BALANCE_QTY," +
                   " (SELECT TOP(1) S.PACK_SIZE FROM TBLGEN_HDR S WHERE S.BCIL_ID=H.BCIL_ID) AS PACK_SIZE," +
                   " (SELECT TOP(1) MD.MFG_DATE FROM TBLGEN_HDR MD WHERE MD.BCIL_ID=H.BCIL_ID) AS MFG_DATE," +
                   " (SELECT TOP(1) ME.EXP_DATE FROM TBLGEN_HDR ME WHERE ME.BCIL_ID=H.BCIL_ID) AS EXP_DATE" +

                   "   FROM TBLGEN_HDR H WHERE H.PLANT=@PARAM1 AND H.PACKING_LEVEL=@PARAM2 AND H.LINE_ID=@PARAM3 AND H.PROD_DESC1=@PARAM4 AND H.STATUS=0", objParameters);
            }
            else if (strBatch.Trim() != "" && strBatch.Trim() != "Select")
            {
                SqlParameter[] objParameters = new SqlParameter[4];
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@PARAM4", SqlDbType.VarChar);
                objParameters[0].Value = strPlant.Trim();
                objParameters[1].Value = strPackLevel.Trim();
                objParameters[2].Value = strLineNo.Trim();
                objParameters[3].Value = strBatch.Trim();

                //return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT T.BCIL_ID,T.GTIN_ID,T.PROD_DESC1,T.BATCH_NO,T.TXN_QTY,T.PRINT_QTY,(SELECT P.TXN_QTY-P.PRINT_QTY FROM TBLGEN_HDR P WHERE P.BCIL_ID=T.BCIL_ID) AS 'REM_QTY',T.PACK_SIZE,T.MFG_DATE,T.EXP_DATE FROM TBLGEN_HDR T WHERE PLANT = @PARAM1 AND PACKING_LEVEL=@PARAM2 AND LINE_ID=@PARAM3 AND BATCH_NO=@PARAM4 AND T.STATUS=0", objParameters);

                return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, " SELECT DISTINCT H.BCIL_ID,(SELECT TOP(1) GTIN_ID FROM TBLGEN_HDR G WHERE G.BCIL_ID=H.BCIL_ID) AS GTIN_ID," +
                   " (SELECT TOP(1) PROD_DESC1 FROM TBLGEN_HDR P WHERE P.BCIL_ID=H.BCIL_ID) AS PROD_DESC1," +
                   " (SELECT TOP(1) BATCH_NO FROM TBLGEN_HDR B WHERE B.BCIL_ID=H.BCIL_ID) AS BATCH_NO," +
                   " (SELECT SUM(T.TXN_QTY) FROM TBLGEN_HDR T WHERE T.BCIL_ID=H.BCIL_ID) AS TXN_QTY," +
                   " (SELECT TOP(1) U.PRINT_QTY FROM TBLGEN_HDR U WHERE U.BCIL_ID=H.BCIL_ID) AS PRINT_QTY," +
                   " (SELECT (SUM(A.TXN_QTY)-A.PRINT_QTY) FROM TBLGEN_HDR A WHERE A.BCIL_ID=H.BCIL_ID GROUP BY A.PRINT_QTY) AS BALANCE_QTY," +
                   " (SELECT TOP(1) S.PACK_SIZE FROM TBLGEN_HDR S WHERE S.BCIL_ID=H.BCIL_ID) AS PACK_SIZE," +
                   " (SELECT TOP(1) MD.MFG_DATE FROM TBLGEN_HDR MD WHERE MD.BCIL_ID=H.BCIL_ID) AS MFG_DATE," +
                   " (SELECT TOP(1) ME.EXP_DATE FROM TBLGEN_HDR ME WHERE ME.BCIL_ID=H.BCIL_ID) AS EXP_DATE" +

                   "   FROM TBLGEN_HDR H WHERE H.PLANT=@PARAM1 AND H.PACKING_LEVEL=@PARAM2 AND H.LINE_ID=@PARAM3 AND H.BATCH_NO=@PARAM4 AND H.STATUS=0", objParameters);
            }
            else
            {
                return new DataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DL_Scan2D(string strBarcode, string strLine, string strUser)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PARAM3", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = strBarcode.Trim();
            objParameters[1].Value = strUser.Trim();
            objParameters[2].Value = strLine.Trim();
            objParameters[3].Direction = ParameterDirection.Output;

            _Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Scan2D", objParameters);
            return int.Parse(objParameters[3].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DL_DupliScanCheck(string strSrNo)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[1];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
            objParameters[0].Value = strSrNo.Trim();

            return _Sql.ExecuteProcedure_DataSet(_Sql.strSqlConn, "SELECT C_RELATION_ST FROM TBLSEC_TRANS WHERE BARCODE = @PARAM1", objParameters);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DL_Sync(DataTable dt)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[2];
        try
        {
            objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.Structured);
            objParameters[1] = new SqlParameter("@RESULT", SqlDbType.Int);

            objParameters[0].Value = dt;
            objParameters[1].Direction = ParameterDirection.Output;

            _Sql.ExecuteProcedureParam(_Sql.strSqlConn, "sp_Sync", objParameters);
            return int.Parse(objParameters[1].Value.ToString());
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

    #region "Conversionfun"

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

    public static DataTable StringToDataTable(string str)
    {
        string[] strArr = str.ToString().Split('#');
        DataTable dt = new DataTable();
        DataRow drow;
        if (strArr.Length == 0) { return dt; }
        string[] strArr1 = strArr[0].ToString().Split('~');

        for (int i = 0; i <= strArr1.Length - 1; i++)
        {
            if (strArr1[i] != "")
            {
                dt.Columns.Add(strArr1[i].ToString());
            }
        }

        for (int j = 1; j <= strArr.Length - 1; j++)
        {
            if (strArr[j] != "")
            {
                drow = dt.NewRow();
                strArr1 = strArr[j].ToString().Split('~');
                for (int i = 0; i <= strArr1.Length - 1; i++)
                {
                    drow[i] = strArr1[i];
                }
                dt.Rows.Add(drow);
            }
        }
        dt.AcceptChanges();
        return dt;
    }

    private byte[] ConvertDataSetToByteArray(DataTable dataTable)
    {
        byte[] binaryDataResult = null;
        using (MemoryStream memStream = new MemoryStream())
        {
            BinaryFormatter brFormatter = new BinaryFormatter();
            dataTable.RemotingFormat = SerializationFormat.Binary;
            brFormatter.Serialize(memStream, dataTable);
            binaryDataResult = memStream.ToArray();
        }
        return binaryDataResult;
    }

    #endregion
}
