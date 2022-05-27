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
/// Summary description for BL_LogWriter
/// </summary>
public class BL_LogWriter
{
	public BL_LogWriter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void BL_WriteErrorLog(string strModule, string strMethod, string strType, string strDetials, string strProgram, string strUser,string strPlant)
    {
        DL_LogWriter objDL_log = new DL_LogWriter();
        try
        {

             objDL_log.DL_WriteErrorLog(strModule,strMethod,strType,strDetials,strProgram,strUser,strPlant);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDL_log = null;
        }
    }
}
