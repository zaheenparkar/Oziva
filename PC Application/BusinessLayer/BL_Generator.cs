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
    public class BL_Generator
    {
        public static Service objLocal;
        PL_Generator objPL_Gen;

        public DataTable BLGetPackLevel()
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetPackingLevel();
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

        public DataTable BLGetShipperMasterBatch(string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetShipperGen(strPlant);
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

        public DataTable BLGetMasterBatch(string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetBatchGen(strPlant);
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

        public DataTable BLGetMasterGTINProduct(string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetMasterGTINProduct(strPlant);
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

        public DataTable BLGetMasterShipper(string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetShipperGen(strPlant);
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

        public DataTable BLGetBatchERP(string strBatch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetBatch_ERP(strBatch);
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

        public DataTable BLGetDataOnERP(string strPacklevel,string strERPCode,string strBatch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetDataOnERP(strPacklevel,strERPCode,strBatch);
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



        public DataSet BLGetLineInfo(PL_Generator objField,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetLineInfo(objField.strPackLevel, strPlant, objField.strLableType);
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

        public DataTable BLGetLableType(PL_Generator objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetLabelType(objField.strPackLevel);
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

        public DataTable BLOldfillComboData(PL_Generator objField,string strComboName)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.FillBatchComboData(objField.strPackLevel, objField.strLineNo, objField.strFieldCriteria, strComboName, objField.strFieldValue, objField.strGTIN);
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

        public DataTable BLfillComboData(PL_Generator objField, string strComboName)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.FillComboData(objField.strPackLevel, objField.strLineNo, objField.strFieldCriteria, strComboName, objField.strFieldValue);
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

        public DataTable BLfillBatchData(PL_Generator objField, string strComboName,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.FillBatchData(strPlant, objField.strCompany,objField.strGTIN,objField.strFieldCriteria, strComboName, objField.strFieldValue);
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


        public DataTable BLGetGTIN(PL_Generator objField,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetGTIN(objField.strPackLevel,objField.strLineNo, strPlant,objField.strDesc);
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

        public DataTable BLGetProduct(PL_Generator objField, string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetProduct(objField.strPackLevel, objField.strLineNo, strPlant);
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

        public DataTable BL_GetData(PL_Generator objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetData(objField.strPackLevel, objField.strGTIN);
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

        public DataTable BL_GetExpDays(PL_Generator objField)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetExpDays(objField.strPackLevel, objField.strGTIN);
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

        public string BL_SaveData(string strPackLevel, string strLine, string strGTIN, string strDesc, string strPackSize,string strBatch,string strMfg,string strExp,string strQty,string strUserID,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.SaveData(strPackLevel, strLine, strGTIN, strDesc, strPackSize, strBatch, strMfg, strExp, strQty, strUserID, strPlant);
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

        public string BL_SaveDataDt(DataTable dt,string strUser,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.SaveDataDT(dt,strUser,strPlant);
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

        public string BL_ShipperSaveDataDt(DataTable dt, string strUser, string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.SaveShipperDataDT(dt, strUser, strPlant);
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

        public string BL_ShipperSaveData(string strPlant, string strGTIN, string strPRODDesc, string strSerialNo, string strPackSize, string strCR_DATE, string LabelCount)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.ShipperSaveData(strPlant, strGTIN, strPRODDesc, strSerialNo, strPackSize, strCR_DATE, LabelCount);
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

        public string BL_SaveBatchDt(DataTable dt, string strUser,string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.SaveBatchDT(dt, strUser,strPlant);
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

        public DataTable GetERP_Items(string strCompanyPrefix)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetERP_Items(strCompanyPrefix);
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

        public DataTable GetProductData_Batch(string strCompanyPrefix, string strERP_Item)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetProductData_Batch(strCompanyPrefix, strERP_Item);
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
        public DataTable GetProductData_ERP(string strCompanyPrefix)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetProductData_ERP(strCompanyPrefix);
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
        public DataTable GetCompanyData_Batch(string strPlantId)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetCompany_Batch(strPlantId);
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

        public DataTable GetBatch_Details(string strBatch,bool bClose)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                return objLocal.GetBatch_Details(strBatch,bClose);
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

        public void CloseBatch(string strBatch, bool bClose)
        {
            objLocal = new Service();
            try
            {
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;

                objLocal.BL_CloseOpenBatch(strBatch, bClose);
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
