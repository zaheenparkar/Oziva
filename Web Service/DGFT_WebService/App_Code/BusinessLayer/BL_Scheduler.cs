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
/// Summary description for BL_Scheduler
/// </summary>
public class BL_Scheduler
{
    DL_Scheduler objSch;

	public BL_Scheduler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet BL_GetMasterDt(string strPlant)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetMasterDt(strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public DataTable BL_GetReletionDt()
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetReletionDt();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public DataTable BL_GetAllJOB(string strPlant,string strBatch)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetAllJOB(strPlant,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public DataTable BL_GetJOBDt(string strGTIN,string strBatch)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetJobDT(strGTIN,strBatch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public DataTable BL_GetShipperJOBDt(string strBarcode)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetShipperJobDT(strBarcode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    

    public DataTable BL_GetChildDt(string strPBarcode)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_GetChildDt(strPBarcode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_ValidateStatus(string strBarcode, string strMode)
    {
        objSch = new DL_Scheduler();
        try
        {
            
            return objSch.DL_ValidateStatus(strBarcode, strMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_UpdateReject(string strBarcode, string strMode,string strUser,string strPlant)
    {
        objSch = new DL_Scheduler();
        try
        {

            return objSch.DL_UpdateReject(strBarcode, strMode,strUser,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_UpdateStatus(string strFromBarcode,string strToBarcode, string strMode,string strUser)
    {
        objSch = new DL_Scheduler();
        try
        {

            return objSch.DL_UpdateStatus(strFromBarcode,strToBarcode,strMode,strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_RejectRequest(string strRefNo)
    {
        objSch = new DL_Scheduler();
        try
        {

            return objSch.DL_RejectRequest(strRefNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveValidateDt(DataTable dt, string strMode)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_UpdateValidation(dt, strMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_ManualMapping(int iPrefix, string strPackLevel, string strMode, string strGTIN, string strBatch, int iPackSize, string strP_Barcode, string strC_Barcode, string strUser,string strPartial,string strLabelType)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_ManualMapping(iPrefix,strPackLevel,strMode,strGTIN,strBatch,iPackSize,strP_Barcode,strC_Barcode,strUser,strPartial,strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_ManualShipperMapping(string strPackLevel, string strMode, string strGTIN, string strP_Barcode, string strC_Barcode, string strUser)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_ManualShipperMapping(strPackLevel, strMode, strGTIN, strP_Barcode, strC_Barcode, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_JobEntry(string strPlant, string strPack, string strLine, string strGTIN, string strBatch, int iPackSize, string strUser, string strMode, int irefNo,string strExpiry)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_JobEntry(strPlant,strPack,strLine,strGTIN,strBatch,iPackSize,strUser,strMode,irefNo,strExpiry);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveRejectionDt(DataTable dt, string strMode,string strPlant)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_UpdateRejection(dt, strMode,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveInward(DataTable dt)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_UpdateInward(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveOutward(DataTable dt)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_UpdateOutward(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveMapping(DataTable dt)
    {
        try
        {
            objSch = new DL_Scheduler();
//            return objSch.DL_UpdateMapping(dt);
            return objSch.DL_UpdateMappNew(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveMapWrng(DataTable dt,string strPlant)
    {
        try
        {
            objSch = new DL_Scheduler();
            //            return objSch.DL_UpdateMapping(dt);
            return objSch.DL_UpdateMappWrng(dt,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_SaveLinkMapping()
    {
        try
        {
            objSch = new DL_Scheduler();
            //            return objSch.DL_UpdateMapping(dt);
            return objSch.DL_LinkMapping();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_InoutBarcode(string strMode, string strBarcode, string strSource, string strDest, string strConignee, string strDoc, string strUser)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_InoutBarcode(strMode, strBarcode, strSource, strDest, strConignee, strDoc, strUser);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncCompany_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Company_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncPlant_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Plant_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncLine_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Line_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncLabelDesign_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_LabelDesign_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncGTIN_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_GTIN_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncConsignee_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Consignee_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public int BL_SyncPrinter_Master(DataTable dt)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Printer_Master(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }


    public bool BL_Sync_Batch_Data(string PLANTCD)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Batch_Data(PLANTCD);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }


    public bool BL_Sync_ReqGen_Data(string PLANTCD)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_ReqGen_Data(PLANTCD);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }


    public bool BL_Sync_Sec_Data(string PLANTCD,string USERID)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Sec_Data(PLANTCD, USERID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }


    public bool BL_Sync_Tert_Data(string PLANTCD, string USERID)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Tert_Data(PLANTCD, USERID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }



    public bool BL_Sync_Sec_Rej_Data(string PLANTCD)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Sec_Rej_Data(PLANTCD);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }


    public bool BL_Sync_Tert_Rej_Data(string PLANTCD)
    {
        objSch = new DL_Scheduler();
        try
        {
            return objSch.DL_Sync_Tert_Rej_Data(PLANTCD);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }

    public string BL_Child_Mapping(string strBatch, string strC_Barcode, string strUser, string strLabelType)
    {
        try
        {
            objSch = new DL_Scheduler();
            return objSch.DL_Child_Mapping(strBatch,strC_Barcode, strUser,strLabelType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSch = null;
        }
    }
}
