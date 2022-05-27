using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.localhost;
using PropertyLayer;

namespace BusinessLayer
{
    public class BL_LogWriter
    {
        public static Service objLocal;

        public void WriteErrorLog(string strModule, string strMethod, string strType, string strDetials, string strProgram, string strUser,string strPlant)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                objLocal.WriteErrorLog(strModule, strMethod, strType, strDetials, strProgram, strUser,strPlant);
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
