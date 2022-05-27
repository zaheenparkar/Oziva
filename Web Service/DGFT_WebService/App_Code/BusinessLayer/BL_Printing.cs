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

/// <summary>
/// Summary description for BL_Printing
/// </summary>
public class BL_Printing
{
	public BL_Printing()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    DL_Printing objDL_Prnt;

    public string BL_GetLoginPlant(string strUserID)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetLoginPlant(strUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetPrintMethod()
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrintMethod();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable BL_GetPrntPackLvl(string strPlant)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrntPackLvl(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BL_GetPrnPortIP(string strprinter, string strlabelsize, string strLabelType,string strLine,string strPacking)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrnPortIP(strprinter, strlabelsize,strLabelType,strLine,strPacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BL_OnlineScanning_Info(string strLine)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_OnlineScanning_Info(strLine);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BL_GetPrntLineNo(string strPlant,string strPackLevel)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrntLineNo(strPlant, strPackLevel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BL_GetPrintConfig(string strPlant, string strPackLevel,string strline)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetprintConfig(strPlant, strPackLevel,strline);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetPrntProdName(string strPlant, string strPackLevel, string strLineNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrntProdName(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetPrntBatch(string strPlant, string strPackLevel, string strLineNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrntBatch(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable BL_GetBatch(string strPlant, string strPackLevel, string strLineNo,string strProduct)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetBatch(strPlant, strPackLevel, strLineNo,strProduct);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetProduct(string strPlant, string strPackLevel, string strLineNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetProduct(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetJobGTIN(string strPlant, string strPackLevel, string strLineNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetJobGTIN(strPlant, strPackLevel, strLineNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable BL_GetJobBatch(string strPlant, string strPackLevel, string strLineNo, string strGTIN)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetJobBT(strPlant, strPackLevel, strLineNo, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetJobPkSize(string strPlant, string strPackLevel, string strLineNo, string strGTIN,string strBatch)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetJobPkSize(strPlant, strPackLevel, strLineNo, strGTIN,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetLabelSize(string strPacking, string strLabelType)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetLabelSize(strPacking, strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable BL_GetPrntData(string strPlant, string strPackLevel, string strLineNo,string strProdName,string strBatch)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrntData(strPlant, strPackLevel, strLineNo, strProdName, strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetSerial(string strPlant, string strPackLevel, string strLineNo, string strProdName, string strBatch, string strSerialNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetSerial(strPlant, strPackLevel, strLineNo, strProdName, strBatch,strSerialNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetPrintdata(int iRefNo, int iGenQty, string strUsername,string strPacking)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_GetPrintdata(iRefNo, iGenQty, strUsername, strPacking);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Prnt = null;
        }
    }

    public DataTable BL_GetLinkPrintdata(string strRefNo, int iGenQty,string strBatch,string strPlant, string strUsername, string strPacking)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_LinkGetPrintdata(strRefNo, iGenQty, strBatch, strPlant, strUsername, strPacking);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Prnt = null;
        }
    }


    public string BL_SavePrint(int iRefNo,int iCount, string strLabelType, string strUsername)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_SavePrint(iRefNo, iCount, strLabelType, strUsername);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int BL_Scan2D(string strBarcode, string strLine, string strUser)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_Scan2D(strBarcode, strLine, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int BL_Sync(DataTable dt)
    {
        objDL_Prnt = new DL_Printing();
        try
        {
            return objDL_Prnt.DL_Sync(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Prnt = null;
        }
    }

    public DataSet BL_DupliScanCheck(string strSrNo)
    {
        try
        {
            objDL_Prnt = new DL_Printing();
            return objDL_Prnt.DL_DupliScanCheck(strSrNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
