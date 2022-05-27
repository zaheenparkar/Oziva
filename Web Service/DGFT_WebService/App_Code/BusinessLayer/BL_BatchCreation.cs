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
/// Summary description for BL_Rejection
/// </summary>
public class BL_BatchCreation
{
    DL_BatchCreation objDL_Batch;

    public BL_BatchCreation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BL_fillBatchData(string strPlant, string strCompany,string strGTIN, string strSelectCombo, string strFillDt, string strValue)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_BatchCombo(strPlant,strCompany,strGTIN,strSelectCombo,strFillDt,strValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_MasterBatch(string strPlant,string strERP)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_MasterGetBatch(strPlant,strERP);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string BL_SaveBatchDt(DataTable dt, string strUser,string strPlant)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_SaveBatchDt(dt, strUser,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable BL_GetERP_Items(string strCompanyPrefix)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            return objDL_Batch.DL_GetERP_Items(strCompanyPrefix);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_GetProductData_Batch(string strCompanyPrefix, string strERPItem)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            return objDL_Batch.DL_GetProductData_Batch(strCompanyPrefix, strERPItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }
    public DataTable BL_GetProductData_ERP(string strCompanyPrefix)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            return objDL_Batch.DL_GetProductData_ERP(strCompanyPrefix);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_GetCompany_Batch(string strPlantcode)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            return objDL_Batch.DL_GetCompany_batch(strPlantcode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_GetBatch_Details(string strBatch,bool bClose)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            return objDL_Batch.DL_GetBatch_Details(strBatch,bClose);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public void BL_CloseOpenBatch(string strBatch,bool bClose)
    {
        objDL_Batch = new DL_BatchCreation();
        try
        {
            objDL_Batch.DL_CloseOpenBatch(strBatch, bClose);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_GetBatch(string strPlant)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_GetBatch(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_ShipperGen(string strPlant)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_ShipperGen(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }
    public DataTable BL_GTINProduct(string strPlant)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_GTINProduct(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }
    
    public DataTable BL_GetJobBatch(string strPlant)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_GetJobBatch(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }

    public DataTable BL_GetJobData(string strPlant,string strBatch)
    {
        try
        {
            objDL_Batch = new DL_BatchCreation();
            return objDL_Batch.DL_GetJobData(strPlant,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Batch = null;
        }
    }
}
