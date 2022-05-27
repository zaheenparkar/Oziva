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
/// Summary description for BL_Login
/// </summary>
public class BL_Login
{
	public BL_Login()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string BL_LoginUser(string strUser,string strPass,string strPlant)
    {
        DL_Login objDL_log = new DL_Login();
        try
        {

            return objDL_log.Login(strUser, strPass, strPlant);
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

    public string BL_UpdateStatus(string strUser, string strMode)
    {
        DL_Login objDL_log = new DL_Login();
        try
        {

            return objDL_log.UpdateStatus(strUser, strMode);
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

    public string BL_ForgotPass(string strUserID, string strOldPass, string strNewPass)
    {
        DL_Login objDL_log = new DL_Login();
        try
        {

            return objDL_log.ForgotPassword(strUserID, strOldPass, strNewPass);
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

    public DataTable BL_GetPlant()
    {
        DL_Login objDL_log = new DL_Login();
        try
        {
            return objDL_log.DL_GetPlant();
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
