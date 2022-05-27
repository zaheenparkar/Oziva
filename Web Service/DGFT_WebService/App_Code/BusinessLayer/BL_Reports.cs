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
/// Summary description for BL_Reports
/// </summary>
public class BL_Reports
{
    DL_Reports objDL_Rpt;
    public DataTable BL_GetParentChild(string Batch)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetParentChildRpt(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //BL_GetUnutilized

    public DataTable BL_GetUnutilizedSec(string Batch)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetUnUtilizedRptSec(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BL_GetUnutilizedTer(string Batch)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetUnUtilizedRptTer(Batch);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }
    public DataTable BL_GetSumHed(string strData, string strPlant, int ArcFlag)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetSumHead(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }
    public DataTable BL_GetSumNEW(string strData, string strPlant, int ArcFlag)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetSumNEW(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }
    public DataTable BL_GetUploadSumNEW(string strData, string strPlant, int ArcFlag)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetUploadSumNEW(strData, strPlant, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }


    public DataTable BL_GetSummaryRpt(string strGTIN, string strERP, string strPacking, string strData, int ArcFlag)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetSummRpt(strGTIN, strERP, strPacking, strData, ArcFlag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }

    public DataTable BL_GetTerRpt(string Batch,string strPlant,string strCriteria)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetTerRpt(Batch,strPlant,strCriteria);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }

    public DataTable BL_GetSecRpt(string Batch,string strPlant,string strCriteria)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetSecRpt(Batch,strPlant,strCriteria);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }

    public DataTable BL_GetWrongPackRpt(string Batch, string dFromDate, string dToDate, string strPlant)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetWrongPackRpt(Batch, dFromDate,dToDate,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }

    public DataTable BL_GetAuditRpt(string dFromDate, string dToDate, string strPlant)
    {
        try
        {
            objDL_Rpt = new DL_Reports();
            return objDL_Rpt.DL_GetEventLog(dFromDate, dToDate, strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_Rpt = null;
        }
    }
}
