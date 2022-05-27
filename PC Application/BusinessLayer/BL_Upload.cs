using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.localhost;
using System.Web;
using System.Data;
using PropertyLayer;

namespace BusinessLayer
{
    public class BL_Upload
    {
        public static Service objLocal;

        public DataSet BLGetMasterDt(string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetMasterDt(strPlant);
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
