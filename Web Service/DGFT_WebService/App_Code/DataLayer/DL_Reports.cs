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
/// Summary description for DL_Reports
/// </summary>
public class DL_Reports
{
    public DataTable DL_GetParentChildRpt(string strVal)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Relation where " + strVal + "").Tables[0];
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
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

    public DataTable DL_GetUnUtilizedRptSec(string Batch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Utilization_Secondary where " + Batch + "").Tables[0];
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
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

    public DataTable DL_GetUnUtilizedRptTer(string Batch)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {

            //objSql = new SqlDataLayer();
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Utilization_Tertiary where " + Batch + "").Tables[0];
            //return objSql.ExecuteDataset(objSql.strSqlConn, "SELECT DISTINCT(BCIL_ID) FROM TBLMASTER_LINE WHERE LINE_TYPE='" + strPackLeve + "'").Tables[0];
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

    public DataTable DL_GetSumHead(string strResult, string strPlant,int ArcFlag)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if (ArcFlag==1)
            {
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM Vw_Summary_Header_ARC WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
            }
            else
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM Vw_Summary_Header WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
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

   public DataTable DL_GetSumNEW(string strResult, string strPlant,int ArcFlag)
   {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if (ArcFlag==1)
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
               //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
            }
            else
            {
                if(strPlant.Contains("All Plant"))
                {
                    //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult ).Tables[0];
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [Product Description],[GTIN ID],[ERP_ITEM_CODE][ERP Code],[BATCH_NO][Batch No],[MFG DATE],[EXP DATE],[Pack Level],[Printed],[Parent Utilized],[Parent Un-Utilized],[Child Utilized],[Child Un-Utilized],[Uploaded to Server],[Pending to Upload] FROM [VW_SummaryRpt_new] where " + strResult + " AND PLANT like '%%'").Tables[0];
                }
                else
                {
                    //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult ).Tables[0];
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [Product Description],[GTIN ID],[ERP_ITEM_CODE][ERP Code],[BATCH_NO][Batch No],[MFG DATE],[EXP DATE],[Pack Level],[Printed],[Parent Utilized],[Parent Un-Utilized],[Child Utilized],[Child Un-Utilized],[Uploaded to Server],[Pending to Upload] FROM [VW_SummaryRpt_new] where " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
                }
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
   public DataTable DL_GetUploadSumNEW(string strResult, string strPlant, int ArcFlag)
     {
       SqlDataLayer _Sql = new SqlDataLayer();

       try
       {
           if (ArcFlag == 1)
           {
               return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryUploadRpt WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
               //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
           }
           else
           {
               if (strPlant.Contains("All Plant"))
               {
                   //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult ).Tables[0];
                   return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [Product Description],[GTIN ID],[ERP_ITEM_CODE][ERP Code],[BATCH_NO][Batch No],[Packing Level],[MFG DATE],[EXP DATE],[Pack Size],[Printed],[Uploaded to Server],[Pending to Upload] FROM [VW_SummaryUploadRpt] where " + strResult + " AND PLANT like '%%'").Tables[0];
               }
               else
               {
                   //return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_SummaryRpt_new WHERE " + strResult ).Tables[0];
                   return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT [Product Description],[GTIN ID],[ERP_ITEM_CODE][ERP Code],[BATCH_NO][Batch No],[Packing Level],[MFG DATE],[EXP DATE],[Pack Size],[Printed],[Uploaded to Server],[Pending to Upload] FROM [VW_SummaryUploadRpt] where " + strResult + " AND PLANT='" + strPlant + "'").Tables[0];
               }
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

    public DataTable DL_GetSummRpt(string strGTIN, string strERP, string strPakcing, string strData, int ArcFlag)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        string strQuery = string.Empty;
        try
        {

            if (strPakcing == "Tertiary")
            {
                if (ArcFlag == 1)
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Summary_tertiary_ARC WHERE GTIN_ID='" + strGTIN + "' AND " + strData + "").Tables[0];
                }
                else
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Summary_tertiary WHERE GTIN_ID='" + strGTIN + "' AND " + strData + "").Tables[0];
                }

            }
            else
            {
                if (ArcFlag == 1)
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Summary_sec_ARC WHERE GTIN_ID='" + strGTIN + "' AND " + strData + "").Tables[0];
                }
                else
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_Summary_sec WHERE GTIN_ID='" + strGTIN + "' AND " + strData + "").Tables[0];
                }
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
    public DataTable DL_GetTerRpt(string Batch, string strPlant,string strCriteria)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if (strCriteria == "All")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_TerRpt WHERE " + Batch + " AND PLANT='" + strPlant + "'").Tables[0];
            }
            else if (strCriteria == "Rejected")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_TerRpt WHERE " + Batch + " AND PLANT='" + strPlant + "' AND [REJECTION]='REJECTED' ").Tables[0];
            }
            else if (strCriteria == "Mapped")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_TerRpt WHERE " + Batch + " AND PLANT='" + strPlant + "' AND [MAPPING STATUS]='MAPPED'").Tables[0];
            }
            else
            {
                return new DataTable("TEMP");
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

    public DataTable DL_GetSecRpt(string Batch, string strPlant,string strCriteria)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if (strCriteria == "All")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_SecRpt WHERE " + Batch + " AND PLANT='" + strPlant + "'").Tables[0];
            }
            else if (strCriteria == "Rejected")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_SecRpt WHERE " + Batch + " AND PLANT='" + strPlant + "' AND [REJECTION]='REJECTED'").Tables[0];
            }
            else if (strCriteria == "Mapped")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_SecRpt WHERE " + Batch + " AND PLANT='" + strPlant + "' AND ([PARENT MAPPING STATUS]='MAPPED' OR [CHILD MAPPING STATUS]='MAPPED')").Tables[0];
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

    public DataTable DL_GetWrongPackRpt(string Batch, string dFromDate, string dToDate, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();

        try
        {
            if (Batch != "")
            {
                if (dFromDate != "")
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_wrong_packing WHERE " + Batch + " AND CAST(TRAN_ON AS DATE) BETWEEN CAST('" + dFromDate + "' AS DATE) AND CAST('" + dToDate + "' AS DATE) AND  PLANT='" + strPlant + "'").Tables[0];
                }
                else
                {
                    return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_wrong_packing WHERE " + Batch + " AND PLANT='" + strPlant + "'").Tables[0];
                }
            }
            else if (dFromDate != "")
            {
                return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM vw_wrong_packing WHERE PLANT ='" + strPlant + "' AND CAST(TRAN_ON AS DATE) BETWEEN CAST('" + dFromDate + "' AS DATE) AND CAST('" + dToDate + "' AS DATE)").Tables[0];
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
        finally
        {
            _Sql = null;
        }
    }

    public DataTable DL_GetEventLog(string dFromDate, string dToDate, string strPlant)
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        try
        {
            return _Sql.ExecuteDataset(_Sql.strSqlConn, "SELECT * FROM VW_Audit_Trail WHERE PLANT ='" + strPlant + "' AND CAST([Date] AS DATE) BETWEEN CAST('" + dFromDate + "' AS DATE) AND CAST('" + dToDate + "' AS DATE)").Tables[0];

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

}
