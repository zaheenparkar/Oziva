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
/// Summary description for BL_Generator
/// </summary>
public class BL_Generator
{
    DL_Generator objDL_Gen;

	public BL_Generator()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BL_GetPackLevel()
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetPackLevel();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetLabelType(string strPacking)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetLabelType(strPacking);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BL_GetLineInfo(string strPackLevel, string strPlant, string strLabelType)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetLineInfo(strPackLevel, strPlant,strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetGTIN(string strPackLevel,string strLine,string strPlant,string strProduct)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetGTIN(strPackLevel,strLine, strPlant,strProduct);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_BatchfillComboData(string strPackLevel, string strLine, string strFieldNm, string strFillDt, string strValue, string strGTIN)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_BatchGetComboData(strPackLevel, strLine, strFieldNm, strFillDt, strValue,strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Gen = null;
        }
    }

    public DataTable BL_fillComboData(string strPackLevel, string strLine, string strFieldNm, string strFillDt, string strValue)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetComboData(strPackLevel, strLine, strFieldNm, strFillDt, strValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetProduct(string strPackLevel, string strLine, string strPlant)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetProduct(strPackLevel, strLine, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetData(string strPackLevel,string strGTIN)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetData(strPackLevel, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetExpDays(string strPackLevel, string strGTIN)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetExpDays(strPackLevel, strGTIN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string BL_SaveData(string strPackLevel, string strLine, string strGTIN, string strDesc, string strPack, string strBatch, string strMfg, string strExp, string strQty, string strUserID,string strPlant)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_SaveData(strPackLevel, strLine, strGTIN, strDesc, strPack, strBatch, strMfg, strExp, strQty, strUserID, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string BL_ShipperSaveData(string strPlant, string strGTIN, string strPRODDesc, string strSerialNo, string strPackSize, string strCR_DATE, string LabelCount)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_ShipperSaveData(strPlant, strGTIN, strPRODDesc, strSerialNo, strPackSize, strCR_DATE, LabelCount);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public string BL_SaveDataDt(DataTable dt,string strUser,string strPlant)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_SaveDataDt(dt, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Gen = null;
        }
    }

    public string BL_SaveShipperDataDt(DataTable dt, string strUser, string strPlant)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_SaveShipperDataDt(dt, strUser, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Gen = null;
        }
    }

    public DataTable BL_GetBatch_ERP(string strBatch)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetBatch_ERP(strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Gen = null;
        }
    }


    public DataTable BL_GetDataOnERP(string strPackLevel, string strERPCode,string strBatch)
    {
        try
        {
            objDL_Gen = new DL_Generator();
            return objDL_Gen.DL_GetDataOnERP(strPackLevel,strERPCode,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Gen = null;
        }
    }


    
}
