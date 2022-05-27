using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.localhost;
using System.Web;
using PropertyLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Login
    {
        public static Service objLocal;

        public string Login(PL_Login objField,string strPlant)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            
            try
            {
                return objLocal.Login(objField.strUserID, objField.strPass, strPlant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLocal = null;
            }
        }

        public string GetSetting()
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;

            try
            {
                return objLocal.GetSettings();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLocal = null;
            }
        }

        public string ForgotPassword(PL_Login objField)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.ForgotPassword(objField.strUserID,objField.strPass, objField.strNewPass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLocal = null;
            }
        }

        public string UpdateStatus(PL_Login objField,string strMode)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.UpdateStatus(objField.strUserID,strMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLocal = null;
            }
        }

        public DataTable BL_GetPlant()
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPlant();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLocal = null;
            }
        }
    }
}
