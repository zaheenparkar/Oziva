using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{


    string strBuildID = "24032017";

    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public DataTable GetPlant()
    {
        BL_Login objBL_Log = new BL_Login();
        try
        {

            return objBL_Log.BL_GetPlant();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    //BL_GetParentChild

    [WebMethod]
    public DataTable GetParentChildRpt(string Batch)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetParentChild(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }
    [WebMethod]
    public DataTable GetUnutilizedRptSec(string Batch)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetUnutilizedSec(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }
    [WebMethod]
    public DataTable GetUnutilizedRptTer(string Batch)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetUnutilizedTer(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetSumHead(string strData, string strPlant,int ArcFlag)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetSumHed(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetSumNEW(string strData, string strPlant, int ArcFlag)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetSumNEW(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }
    [WebMethod]
    public DataTable GetUploadSumNEW(string strData, string strPlant, int ArcFlag)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetUploadSumNEW(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }
    [WebMethod]
    public DataTable GetSummaryRpt(string strGTIN, string strERP, string strPakcing, string strData,int ArcFlag)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetSummaryRpt(strGTIN, strERP, strPakcing, strData, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetTerRpt(string Batch, string strPlant,string strCriteria)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetTerRpt(Batch, strPlant,strCriteria);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetSecRpt(string Batch, string strPlant,string strCriteria)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetSecRpt(Batch, strPlant,strCriteria);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetWrongPackRpt(string Batch, string dFromDate, string dToDate, string strPlant)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetWrongPackRpt(Batch,dFromDate,dToDate,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetAuditRpt(string dFromDate, string dToDate, string strPlant)
    {
        BL_Reports objBL_Log = new BL_Reports();
        try
        {
            return objBL_Log.BL_GetAuditRpt(dFromDate, dToDate, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }


    [WebMethod]
    public string GetSettings()
    {
        SqlDataLayer objSql = new SqlDataLayer();
        string connectionString = "";
        string strServer="";
        string strDatabase="";
        string strUser="";
        string strPassword="";
        string strReturn = "";
        try
        {
            connectionString = objSql.strSqlConn;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);


            strServer = builder.DataSource;
            strDatabase = builder.InitialCatalog;
            strUser = builder.UserID;
            strPassword = builder.Password;

            
            objSql.Connect(connectionString);
            strReturn = "1~" + strServer + "~" + strDatabase + "~" + strUser + "~" + strPassword + "~" + strBuildID;
            
        }
        catch (Exception ex)
        {
            objSql = null;
            strReturn = "0~" + strServer + "~" + strDatabase + "~" + strUser + "~" + strPassword + "~" + strBuildID;
        }
        finally
        {
            objSql = null;
        }
        return strReturn;

    }
    

    [WebMethod]
    public string Login(string strUserID, string strPassword, string strPlant)
    {
        BL_Login objBL_Log = new BL_Login();
        try
        {

            return objBL_Log.BL_LoginUser(strUserID, strPassword, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public string ForgotPassword(string strUserID, string strOldPass, string strNewPass)
    {
        BL_Login objBL_Log = new BL_Login();
        try
        {

            return objBL_Log.BL_ForgotPass(strUserID, strOldPass, strNewPass);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }
    [WebMethod]
    public string SaveMappWrngDT(DataTable dt, string strPlant)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveMapWrng(dt, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }
    [WebMethod]
    public string UpdateStatus(string strUserID, string strMode)
    {
        BL_Login objBL_Log = new BL_Login();
        try
        {

            return objBL_Log.BL_UpdateStatus(strUserID, strMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataTable GetPackingLevel()
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetPackLevel();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetLabelType(string strPacking)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetLabelType(strPacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetBatch_ERP(string strBatch)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetBatch_ERP(strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetDataOnERP(string strPackLevel, string strERPCode,string strBatch)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetDataOnERP(strPackLevel,strERPCode,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataSet GetLineInfo(string strPackLevel, string strPlant, string strLabelType)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetLineInfo(strPackLevel, strPlant, strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetGTIN(string strPackLevel, string strLine, string strPlant, string strProduct)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetGTIN(strPackLevel, strLine, strPlant, strProduct);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable FillBatchComboData(string strPackLevel, string strLine, string strFieldNm, string strFillDt, string strValue, string strGTIN)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_BatchfillComboData(strPackLevel, strLine, strFieldNm, strFillDt, strValue, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable FillComboData(string strPackLevel, string strLine, string strFieldNm, string strFillDt, string strValue)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_fillComboData(strPackLevel, strLine, strFieldNm, strFillDt, strValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable FillBatchData(string strPlant, string strCompany, string strGTIN, string strSelectCombo, string strFillDt, string strValue)
    {
        BL_BatchCreation objBL_Bat = new BL_BatchCreation();
        try
        {
            return objBL_Bat.BL_fillBatchData(strPlant, strCompany, strGTIN, strSelectCombo, strFillDt, strValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Bat = null;
        }
    }

    [WebMethod]
    public DataTable GetProduct(string strPackLevel, string strLine, string strPlant)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetProduct(strPackLevel, strLine, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetData(string strPackLevel, string strGTIN)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetData(strPackLevel, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetExpDays(string strPackLevel, string strGTIN)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_GetExpDays(strPackLevel, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public string SaveData(string strPackLevel, string strLine, string strGTIN, string strDesc, string strPack, string strBatch, string strMfg, string strExp, string strQty, string strUserID, string strPlant)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_SaveData(strPackLevel, strLine, strGTIN, strDesc, strPack, strBatch, strMfg, strExp, strQty, strUserID, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public string ShipperSaveData(string strPlant, string strGTIN, string strPRODDesc, string strSerialNo, string strPackSize, string strCR_DATE, string LabelCount)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_ShipperSaveData(strPlant, strGTIN, strPRODDesc, strSerialNo, strPackSize, strCR_DATE, LabelCount);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }


    [WebMethod]
    public string SaveDataDT(DataTable dt, string strUser, string strPlant)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_SaveDataDt(dt, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public string SaveShipperDataDT(DataTable dt, string strUser, string strPlant)
    {
        BL_Generator objBL_Gen = new BL_Generator();
        try
        {
            return objBL_Gen.BL_SaveShipperDataDt(dt, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public string SaveBatchDT(DataTable dt, string strUser, string strPlant)
    {
        BL_BatchCreation objBL_Batch = new BL_BatchCreation();
        try
        {
            return objBL_Batch.BL_SaveBatchDt(dt, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Batch = null;
        }
    }



    [WebMethod]
    public string GetLoginPlant(string strUserID)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetLoginPlant(strUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetPrntPackLvl(string strPlant)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrntPackLvl(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetPrintMethod()
    {
        BL_Printing objBL_Print = new BL_Printing();
        try
        {

            return objBL_Print.BL_GetPrintMethod();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Print = null;
        }
    }

    [WebMethod]
    public DataSet GetPrntLineNo(string strPlant, string strPackLevel)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrntLineNo(strPlant, strPackLevel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetLabelSize(string strPackLevel, string strLabelType)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetLabelSize(strPackLevel, strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }


    [WebMethod]
    public string InoutBarcode(string strMode, string strBarcode, string strSource, string strDest, string strConignee, string strDoc, string strUser)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_InoutBarcode(strMode, strBarcode, strSource, strDest, strConignee, strDoc, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public DataTable GetPrintData(int iRefNo, int iGenQty, string strUsername, string strpacking)
    {
        BL_Printing objBL_print = new BL_Printing();
        try
        {
            return objBL_print.BL_GetPrintdata(iRefNo, iGenQty, strUsername, strpacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_print = null;
        }
    }

    [WebMethod]
    public DataTable GetDataToPrint(int iRefNo, int iGenQty, string strUsername, string strpacking)
    {
        BL_Printing objBL_Print = new BL_Printing();
        try
        {
            return objBL_Print.BL_GetPrintdata(iRefNo, iGenQty, strUsername, strpacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Print = null;
        }
    }


    [WebMethod]
    public DataSet GetPrnPortIP(string strPrinter, string strLabelSize, string strLabelType, string strLine, string strPacking)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrnPortIP(strPrinter, strLabelSize, strLabelType, strLine, strPacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataSet Get_OnlinePrint_Info(string strLine)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_OnlineScanning_Info(strLine);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataSet GetPrntConfig(string strPlant, string strPackLevel, string strline)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrintConfig(strPlant, strPackLevel, strline);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetPrntProdName(string strPlant, string strPackLevel, string strLineNo)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrntProdName(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetPrntBatch(string strPlant, string strPackLevel, string strLineNo)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrntBatch(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetJobGTIN(string strPlant, string strPackLevel, string strLineNo)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetJobGTIN(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetBatch(string strPlant, string strPackLevel, string strLineNo, string strProduct)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetBatch(strPlant, strPackLevel, strLineNo, strProduct);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetMasterBatch(string strPlant,string strERP)
    {
        BL_BatchCreation objBL_Batch = new BL_BatchCreation();
        try
        {
            return objBL_Batch.BL_MasterBatch(strPlant,strERP);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Batch = null;
        }
    }

    [WebMethod]
    public DataTable GetProductName(string strPlant, string strPackLevel, string strLineNo)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetProduct(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetJobBT(string strPlant, string strPackLevel, string strLineNo, string strGTIN)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetJobBatch(strPlant, strPackLevel, strLineNo, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetJobPack(string strPlant, string strPackLevel, string strLineNo, string strGTIN, string strBatch)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetJobPkSize(strPlant, strPackLevel, strLineNo, strGTIN, strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetPrntData(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetPrntData(strPlant, strPackLevel, strLineNo, strProdName, strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable GetSerialData(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch, string strSerial)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetSerial(strPlant, strPackLevel, strLineNo, strProdName, strBatch, strSerial);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public string SavePrint(int iRefNo, int iCount, string strLabelType, string strUsername)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_SavePrint(iRefNo, iCount, strLabelType, strUsername);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public DataTable linkSavePrint(string strRefNo, int iCount, string strBatch, string strPlant, string strLabelType, string strUsername)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_GetLinkPrintdata(strRefNo, iCount, strBatch, strPlant, strLabelType, strUsername);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }
    }

    [WebMethod]
    public void WriteErrorLog(string strModule, string strMethod, string strType, string strDetials, string strProgram, string strUser,string strPlant)
    {
        BL_LogWriter objBL_Log = new BL_LogWriter();
        try
        {
            objBL_Log.BL_WriteErrorLog(strModule, strMethod, strType, strDetials, strProgram, strUser,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public int ScanBarcode_2D(string strBarcode, string strLine, string strUser)
    {
        BL_Printing objBL_Log = new BL_Printing();
        try
        {
            return objBL_Log.BL_Scan2D(strBarcode, strLine, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }


    [WebMethod]
    public DataTable GetERP_Items(string strCompanyPrefix)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetERP_Items(strCompanyPrefix);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }
    [WebMethod]
    public DataTable GetProductData_Batch(string strCompanyPrefix, string strERPItem)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetProductData_Batch(strCompanyPrefix, strERPItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }
    [WebMethod]
    public DataTable GetProductData_ERP(string strCompanyPrefix)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetProductData_ERP(strCompanyPrefix);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }
    [WebMethod]
    public DataTable GetCompany_Batch(string strPlant)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetCompany_Batch(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }
    [WebMethod]
    public DataTable GetBatch_Details(string strBatch,bool bClose)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetBatch_Details(strBatch,bClose);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }


    [WebMethod]
    public DataTable GetBatchGen(string strPlant)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetBatch(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }

    }

    [WebMethod]
    public DataTable GetShipperGen(string strPlant)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_ShipperGen(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }

    }

    [WebMethod]
    public DataTable GetMasterGTINProduct(string strPlant)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GTINProduct(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }

    }

    [WebMethod]
    public DataTable GetJobBatch(string strPlant)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetJobBatch(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public DataTable GetJobData(string strPlant,string strBatch)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            return objBL_Gen.BL_GetJobData(strPlant,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }


    [WebMethod]
    public void BL_CloseOpenBatch(string strBatch,bool bClose)
    {
        BL_BatchCreation objBL_Gen = new BL_BatchCreation();
        try
        {
            objBL_Gen.BL_CloseOpenBatch(strBatch,bClose);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    #region "Scheduler"

    [WebMethod]
    public DataSet GetMasterDt(string strPlant)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetMasterDt(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public DataTable GetReletionDt()
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetReletionDt();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    [WebMethod]
    public DataTable GetAllJob(string strPlant, string strBatch)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetAllJOB(strPlant, strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public DataTable GetJobDt(string strGTIN, string strBatch)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetJOBDt(strGTIN, strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

     [WebMethod]
    public DataTable GetShipperJobDt(string strBarcode)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetShipperJOBDt(strBarcode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    
    [WebMethod]
    public DataTable GetChildBarcode(string strPBarcode)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {

            return objBL_Sch.BL_GetChildDt(strPBarcode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string ManualMapping(int iPrefix, string strPackLevel, string strMode, string strGTIN, string strBatch, int iPackSize, string strP_Barcode, string strC_Barcode, string strUser, string strPartial, string strLabelType)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_ManualMapping(iPrefix, strPackLevel, strMode, strGTIN, strBatch, iPackSize, strP_Barcode, strC_Barcode, strUser, strPartial, strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    [WebMethod]
    public string ManualShipperMapping(string strPackLevel, string strMode, string strGTIN, string strP_Barcode, string strC_Barcode, string strUser)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_ManualShipperMapping(strPackLevel, strMode, strGTIN, strP_Barcode, strC_Barcode, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    [WebMethod]
    public string Child_Mapping(string strBatch, string strC_Barcode, string strUser, string strLabelType)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_Child_Mapping(strBatch,strC_Barcode, strUser,strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string ValidateStatus(string strBarcode, string strMode)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_ValidateStatus(strBarcode, strMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveJobEntry(string strPlant, string strPack, string strLine, string strGTIN, string strBatch, int iPackSize, string strUser, string strMode, int irefNo, string strExpiry)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_JobEntry(strPlant, strPack, strLine, strGTIN, strBatch, iPackSize, strUser, strMode, irefNo, strExpiry);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string UpdateReject(string strBarcode, string strMode, string strUser, string strPlant)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_UpdateReject(strBarcode, strMode, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public int RejectRequest(string strRefNo)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_RejectRequest(strRefNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    [WebMethod]
    public int UpdateBarcodeStatus(string strFromBarcode, string strToBarcode, string strMode, string strUser)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_UpdateStatus(strFromBarcode, strToBarcode, strMode, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveValidationDT(DataTable dt, string strMode)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveValidateDt(dt, strMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveRejectionDT(DataTable dt, string strMode, string strPlant)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveRejectionDt(dt, strMode, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveInwardDT(DataTable dt)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveInward(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveOutwardDT(DataTable dt)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveOutward(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveMappingDT(DataTable dt)
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveMapping(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }

    [WebMethod]
    public string SaveLinkMappingDT()
    {
        BL_Scheduler objBL_Sch = new BL_Scheduler();
        try
        {
            return objBL_Sch.BL_SaveLinkMapping();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Sch = null;
        }
    }


    #endregion

    [WebMethod]
    public int BL_Sync_Company_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncCompany_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_Plant_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncPlant_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_Line_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncLine_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_LabelDesign_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncLabelDesign_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_GTIN_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncGTIN_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_Printer_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncPrinter_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public int BL_Sync_Consignee_Master(DataTable dt)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_SyncConsignee_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public bool Sync_Batch_Data(string strPlant)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_Batch_Data(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }
    
    [WebMethod]
    public bool Sync_ReqGen_Data(string strPlant)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_ReqGen_Data(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public bool Sync_Sec_Data(string strPlant, string strUser)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_Sec_Data(strPlant, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public bool Sync_Tert_Data(string strPlant, string strUser)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_Tert_Data(strPlant, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }


    [WebMethod]
    public bool Sync_Sec_Rej_Data(string strPlant)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_Sec_Rej_Data(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }


    [WebMethod]
    public bool Tert_Rej_Data(string strPlant)
    {
        BL_Scheduler objBL_Gen = new BL_Scheduler();
        try
        {
            return objBL_Gen.BL_Sync_Tert_Rej_Data(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Gen = null;
        }
    }

    [WebMethod]
    public string Sync(DataTable strBarcode)
    {
        BL_Printing objBL_Log = new BL_Printing();
        try
        {
            return objBL_Log.BL_Sync(strBarcode).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Log = null;
        }
    }

    [WebMethod]
    public DataSet Get_DupliScanCheck(string strSrNo)
    {
        BL_Printing objBL_Prnt = new BL_Printing();
        try
        {
            return objBL_Prnt.BL_DupliScanCheck(strSrNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBL_Prnt = null;
        }

    }
}
