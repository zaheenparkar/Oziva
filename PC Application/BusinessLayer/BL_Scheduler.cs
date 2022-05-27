using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;
using BusinessLayer.localhost;
using PropertyLayer;
using System.Web;
using System.IO;

namespace BusinessLayer
{
    public class BL_Scheduler
    {

        public static Service objLocal;

        #region "Transactions"

        public string BLUpdateValidation(DataTable dt, string strMode)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveValidationDT(dt, strMode);
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

        public string BLUpdateRejection(DataTable dt, string strMode,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveRejectionDT(dt, strMode,strPlant);
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

        public string BLUpdateInward(DataTable dt)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveInwardDT(dt);
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

        public string BLUpdateOutward(DataTable dt)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveOutwardDT(dt);
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

        public string BLUpdateMapping(DataTable dt)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveMappingDT(dt);
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

        public string BLUpdateMappingWrng(DataTable dt)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 600000;

                return objLocal.SaveMappWrngDT(dt,PL_Login.PlantCode.ToString());
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

        #endregion

        #region "Masters"

        public int Sync_Company_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_Company_Master(dt);
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

        public int Sync_Plant_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_Plant_Master(dt);
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

        public int Sync_Line_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_Line_Master(dt);
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

        public int Sync_LabelDesign_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_LabelDesign_Master(dt);
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

        public int Sync_GTIN_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_GTIN_Master(dt);
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

        public int Sync_Printer_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_Printer_Master(dt);
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

        public int Sync_Consignee_master(DataTable dt)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.BL_Sync_Consignee_Master(dt);
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


        public bool Sync_BatchData(string PlantID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Sync_Batch_Data(PlantID);
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


        public bool Sync_ReqGenData(string PlantID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Sync_ReqGen_Data(PlantID);
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


        public bool Sync_SecData(string PlantID, string UserID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Sync_Sec_Data(PlantID, UserID);
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


        public bool Sync_TertData(string PlantID, string UserID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Sync_Tert_Data(PlantID, UserID);
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


        public string Sync_MapplingData()
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveLinkMappingDT();
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


        public bool Sync_Sec_RejData(string PlantID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Sync_Sec_Rej_Data(PlantID);
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


        public bool Sync_Tert_RejData(string PlantID)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Tert_Rej_Data(PlantID);
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


        #endregion

        public string ConvertDataTableToXML(DataTable dtdata)
        {
            DataSet dsData = new DataSet();
            StringBuilder sbSQL = default(StringBuilder);
            StringWriter swSQL = default(StringWriter);
            string XMLformat = null;
            try
            {
                sbSQL = new StringBuilder();
                swSQL = new StringWriter(sbSQL);
                dsData.Merge(dtdata, true, MissingSchemaAction.AddWithKey);
                dsData.Tables[0].TableName = "SampleDataTable";
                foreach (DataColumn col in dsData.Tables[0].Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }
                dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
                XMLformat = sbSQL.ToString();
                return XMLformat;
            }
            catch (Exception sysException)
            {
                throw sysException;
            }
        }


    }
}
