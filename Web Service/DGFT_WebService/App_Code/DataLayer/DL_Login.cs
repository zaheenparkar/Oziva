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
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_Login
/// </summary>
public class DL_Login
{

    //
    // TODO: Add constructor logic here
    //

    public string Login(string strUsername, string strPassword,string strPlant)
    {
        SqlDataLayer objSql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
            //objParameters[2] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 1000);
          
            objParameters[0].Value = strUsername.Trim();
            objParameters[1].Value = strPassword.Trim();
            //objParameters[2].Value = "P001";
            objParameters[2].Direction = ParameterDirection.Output;

            if (objSql.ExecuteProcedureParam(objSql.strSqlConn, "sp_Login", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[2].Value.ToString();
            }
            else
            {
                throw new Exception("Invalid login details");
            }
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

    public DataTable DL_GetPlant()
    {
        SqlDataLayer _Sql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[0];
        try
        {
            return _Sql.ExecuteProcedure_Table(_Sql.strSqlConn, "SELECT DISTINCT PLANT_ID FROM TBLMASTER_PLANT WHERE STATUS=1", objParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _Sql = null;
            objParameters = null;
        }
    }

    public string ForgotPassword(string strUserID, string strOldPass, string strNewPass)
    {
        SqlDataLayer objSql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[4];
        try
        {
            objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@NEWPASSWORD", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
            //objParameters[2] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
            objParameters[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strUserID.Trim();
            objParameters[1].Value = strNewPass.Trim();
            objParameters[2].Value = strOldPass.Trim();
            //objParameters[2].Value = "P001";
            objParameters[3].Direction = ParameterDirection.Output;

            if (objSql.ExecuteProcedureParam(objSql.strSqlConn, "sp_Forgot_Password", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[3].Value.ToString();
            }
            else
            {
                throw new Exception("Invalid Change Password Detials");
            }
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

    public string UpdateStatus(string strUsername, string strMode)
    {
        SqlDataLayer objSql = new SqlDataLayer();
        SqlParameter[] objParameters = new SqlParameter[3];
        try
        {
            objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            objParameters[1] = new SqlParameter("@MODE", SqlDbType.VarChar);
            //objParameters[2] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
            objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 100);

            objParameters[0].Value = strUsername.Trim();
            objParameters[1].Value = strMode.Trim();
            //objParameters[2].Value = "P001";
            objParameters[2].Direction = ParameterDirection.Output;

            if (objSql.ExecuteProcedureParam(objSql.strSqlConn, "[sp_Activate]", objParameters, "@RESULT", "@RESULT") != "")
            {
                return objParameters[2].Value.ToString();
            }
            else
            {
                return "";
            }
          
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
