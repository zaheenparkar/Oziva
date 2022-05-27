using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;
using BusinessLayer.localhost;
using System.Web;

namespace BusinessLayer
{
    public class BL_Printing
    {
        public static Service objLocal;

        public string BLGetPlantLogin(string strUserID)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetLoginPlant(strUserID);
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

        public DataTable BL_GetPrintMethod()
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrintMethod();
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

        public DataTable BL_GetLine(PL_Printing objPL_Prnt)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntPackLvl(objPL_Prnt.strPlantCode);
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

        public DataSet BL_GetPrntLineNo(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntLineNo(objField.strPlantCode, objField.strPackLevel);
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

        public DataSet BL_GetPrntConfig(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntConfig(objField.strPlantCode, objField.strPackLevel,objField.strLineNo);
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

        public DataSet BL_GetPrnPortIP(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrnPortIP(objField.strPrinterPk, objField.strLabelSize,objField.strLabelType,objField.strLineNo,objField.strPackLevel);
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

        public DataTable BL_GetPrntProdName(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntProdName(objField.strPlantCode, objField.strPackLevel, objField.strLineNo);
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

        public DataTable BL_GetGTIN(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetJobGTIN(objField.strPlantCode, objField.strPackLevel, objField.strLineNo);
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

        public DataTable BL_GetPrntBatch(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntBatch(objField.strPlantCode, objField.strPackLevel, objField.strLineNo);
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

        public DataTable BL_GetBatch(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetBatch(objField.strPlantCode, objField.strPackLevel, objField.strLineNo,objField.strProdName);
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

        public DataTable BL_GetProduct(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetProductName(objField.strPlantCode, objField.strPackLevel, objField.strLineNo);
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

        public DataTable BL_GetJobBatch(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetJobBT(objField.strPlantCode, objField.strPackLevel, objField.strLineNo, objField.strGTINCode);
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

        public DataTable BL_GetJobs(string strPlant,string strBatch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetAllJob(strPlant,strBatch);
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

        public DataTable BL_GetJobPack(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetJobPack(objField.strPlantCode, objField.strPackLevel, objField.strLineNo, objField.strGTINCode,objField.strBatchNo);
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

        public DataTable BL_GetOnlineScan_Info(string strLine)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.Get_OnlinePrint_Info(strLine.Trim()).Tables[0];
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
        public DataTable BL_GetPrntData(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPrntData(objField.strPlantCode, objField.strPackLevel, objField.strLineNo, objField.strProdName, objField.strBatchNo);
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

        public DataTable BL_GetSerial(PL_Printing objField,string strSerial)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetSerialData(objField.strPlantCode, objField.strPackLevel, objField.strLineNo, objField.strProdName, objField.strBatchNo,strSerial);
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

   

        public DataTable BL_GetLabelSize(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetLabelSize(objField.strPackLevel,objField.strLabelType);
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

        public DataTable BL_GetDataToPrint(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                
                //return objLocal.GetPrintData(objField.iRefNo, objField.iPrintQty, PL_Login.UserID,objField.strPackLevel);
                return objLocal.linkSavePrint(objField.strRefNo, objField.iPrintQty, objField.strBatchNo, objField.strPlantCode, PL_Login.UserID, objField.strPackLevel);
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

        public string BL_PrintData(PL_Printing objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SavePrint(objField.iRefNo, objField.iLabelCount, objField.strLabelType, PL_Login.UserID);
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

        public string BL_SaveJob(PL_Printing objField,int iPackSize,string strMode,int iRefNo,string strExpiry)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveJobEntry(objField.strPlantCode,objField.strPackLevel,objField.strLineNo,objField.strGTINCode,objField.strBatchNo,iPackSize, PL_Login.UserID,strMode,iRefNo,strExpiry);
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
