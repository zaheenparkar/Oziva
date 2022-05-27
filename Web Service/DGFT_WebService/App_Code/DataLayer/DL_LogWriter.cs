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
/// Summary description for DL_LogWriter
/// </summary>
public class DL_LogWriter
{
	public DL_LogWriter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void DL_WriteErrorLog(string strModule, string strMethod, string strType,string strDetials,string strProgram,string strUser,string strPlant)
    {
        SqlDataLayer objSql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[7];
        try
        {
            objParameters[0] = new SqlParameter("@MODULE", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@METHOD", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@DETAILS", SqlDbType.VarChar);
            objParameters[4] = new SqlParameter("@PROGRAM", SqlDbType.VarChar);
            objParameters[5] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[6] = new SqlParameter("@PLANT", SqlDbType.VarChar);



            objParameters[0].Value = strModule.Trim();
            objParameters[1].Value = strMethod.Trim();
            objParameters[2].Value = strType.Trim();
            objParameters[3].Value = strDetials.Trim();
            objParameters[4].Value = strProgram.Trim();
            objParameters[5].Value = strUser.Trim();
            objParameters[6].Value =strPlant.Trim();

            objSql.ExecuteProcedureParam(objSql.strSqlConn, "sp_Insert_log", objParameters);
           
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

}
