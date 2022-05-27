using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.localhost;
using System.Web;
using DataLayer;
using PropertyLayer;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace BusinessLayer
{
    public class BL_Scanning
    {
        public static Service objLocal;

        #region "Access DB"

       
        public int InsertInwardData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (objData.GetDatatable("SELECT BCIL_ID FROM TBLTER_INWORD WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    //{
                    strQuery = "INSERT INTO TBLTER_INWARD (BARCODE,SOURCE,DESTINATION,TRAN_BY,TRAN_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["SOURCE"].ToString() + "','" + dt.Rows[i]["DESTINATION"].ToString() + "','" + strUser + "','" + dtp + "')";
                    objData.ExecuteQuery(strQuery);
                    iCount++;
                    //}
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertOutwardData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (objData.GetDatatable("SELECT BCIL_ID FROM TBLTER_OUTWARD WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    //{
                    strQuery = "INSERT INTO TBLTER_OUTWARD (BARCODE,SOURCE,DESTINATION,CONSIGNEE,DOCUMENT_NO,TRAN_BY,TRAN_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["SOURCE"].ToString() + "','" + dt.Rows[i]["DESTINATION"].ToString() + "','" + dt.Rows[i]["CONSIGNEE"].ToString() + "','" + dt.Rows[i]["DOCUMENT_NO"].ToString() + "','" + strUser + "','" + dtp + "')";
                    objData.ExecuteQuery(strQuery);
                    iCount++;
                    //}
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertSecData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (objData.GetDatatable("SELECT BCIL_ID FROM TBLSEC_TRANS WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    {
                        strQuery = "INSERT INTO TBLSEC_TRANS (BARCODE,VALIDATED_BY,VALIDATED_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + strUser + "','" + dtp + "')";
                        objData.ExecuteQuery(strQuery);
                        iCount++;
                    }
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertSecRejData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (objData.GetDatatable("SELECT BCIL_ID FROM TBLSEC_REJECT WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    {
                        strQuery = "INSERT INTO TBLSEC_REJECT (BARCODE,REJECT_BY,REJECT_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + strUser + "','" + dtp + "')";
                        objData.ExecuteQuery(strQuery);
                        iCount++;
                    }
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertTerRejData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (objData.GetDatatable("SELECT BCIL_ID FROM TBLTER_REJECT WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    {
                        strQuery = "INSERT INTO TBLTER_REJECT (BARCODE,REJECT_BY,REJECT_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + strUser + "','" + dtp + "')";
                        objData.ExecuteQuery(strQuery);
                        iCount++;
                    }
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertTerData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData= new clsOledbDataLayer();
            try
            {
               // objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (objData.GetDatatable("SELECT BCIL_ID FROM TBLTER_TRANS WHERE BARCODE='" + dt.Rows[i]["BARCODE"].ToString() + "'").Rows.Count == 0)
                    {
                        strQuery = "INSERT INTO TBLTER_TRANS (BARCODE,VALIDATED_BY,VALIDATED_ON) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + strUser + "','" + dtp + "')";
                        objData.ExecuteQuery(strQuery);
                        iCount++;
                    }
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int InsertMapData(DataTable dt, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                //objData.BeginTrans();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (objData.GetDatatable("SELECT BCIL_ID FROM TBLRELETION WHERE C_BARCODE='" + dt.Rows[i]["C_BARCODE"].ToString() + "'").Rows.Count == 0)
                    {
                        strQuery = "INSERT INTO TBLRELETION (P_BARCODE,C_BARCODE,PACK_SIZE,P_PREFIX,TRAN_BY,TRAN_ON) VALUES ('" + dt.Rows[i]["P_BARCODE"].ToString() + "','" + dt.Rows[i]["C_BARCODE"].ToString() + "'," + dt.Rows[i]["PACK_SIZE"].ToString() + "," + dt.Rows[i]["P_PREFIX"].ToString() + ",'" + strUser + "','" + dtp + "')";
                        objData.ExecuteQuery(strQuery);
                        iCount++;
                    }
                }
                //objData.CommitTrans();
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        public int DeleteSyncData(DataTable dt, string strInput)
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            int iRec = 0;
            try
            {
                if (strInput == "I")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLTER_INWARD WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }

                }
                else if (strInput == "O")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLTER_OUTWARD WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
                else if (strInput == "S")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLSEC_TRANS WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
                else if (strInput == "T")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLTER_TRANS WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
                else if (strInput == "M")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLRELETION WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
                else if (strInput == "SR")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLSEC_REJECT WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
                else if (strInput == "TR")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objData.ExecuteQuery("DELETE FROM TBLTER_REJECT WHERE BCIL_ID=" + dt.Rows[i]["BCIL_ID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
            finally
            {
                objData = null;
            }
            return iRec;
        }

        public DataTable GetInward()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,SOURCE,DESTINATION,TRAN_BY,TRAN_ON FROM TBLTER_INWARD";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetSecReject()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,REJECT_BY,REJECT_ON FROM TBLSEC_REJECT";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetTerReject()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,REJECT_BY,REJECT_ON FROM TBLTER_REJECT";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetOutward()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,SOURCE,DESTINATION,CONSIGNEE,DOCUMENT_NO,TRAN_BY,TRAN_ON FROM TBLTER_OUTWARD";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetSecScanning()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,VALIDATED_BY,VALIDATED_ON FROM TBLSEC_TRANS";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetTerScanning()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,BARCODE,VALIDATED_BY,VALIDATED_ON FROM TBLTER_TRANS";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public DataTable GetMapping()
        {
            clsOledbDataLayer objData = new clsOledbDataLayer();
            string strQuery = "";
            try
            {
                strQuery = "SELECT BCIL_ID,P_BARCODE,C_BARCODE,PACK_SIZE,P_PREFIX,TRAN_BY,TRAN_ON FROM TBLRELETION";
                return objData.GetDatatable(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objData = null;
            }
        }

        public int InsertSecData_Single(string strBarcode, string strUser)
        {
            string strQuery = "";
            DateTime dtp = DateTime.Now;
            int iCount = 0;
            clsOledbDataLayer objData = new clsOledbDataLayer();
            try
            {
                if (objData.GetDatatable("SELECT BCIL_ID FROM TBLSEC_TRANS WHERE BARCODE='" + strBarcode + "'").Rows.Count == 0)
                {
                    strQuery = "INSERT INTO TBLSEC_TRANS (BARCODE,VALIDATED_BY,VALIDATED_ON) VALUES ('" + strBarcode + "','" + strUser + "','" + dtp + "')";
                    return objData.ExecuteQuery(strQuery);
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception ex)
            {
                //objData.RollBack();
                throw ex;
            }
            finally
            {
                objData = null;
            }
            return iCount;
        }

        #endregion

        #region "Scanning Web"

        public DataTable BL_GetJOBDt(string strGTIN, string strBatch)
        {
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.GetJobDt(strGTIN, strBatch);
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

        public DataTable BL_GetShipperJOBDt(string strBarcode)
        {
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.GetShipperJobDt(strBarcode);
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

    

        public DataTable BL_GetChildBarcode(string strPBarcode)
        {
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.GetChildBarcode(strPBarcode);
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

        public string BL_ManualMapping(int iPrefix, string strPackLevel, string strMode, string strGTIN, string strBatch, int iPackSize, string strP_Barcode, string strC_Barcode, string strUser,string strPartial,string strlabelType)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.ManualMapping(iPrefix, strPackLevel, strMode, strGTIN, strBatch, iPackSize, strP_Barcode, strC_Barcode, strUser,strPartial,strlabelType);
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

        public string BL_ShipperMapping( string strPackLevel, string strMode, string strGTIN,  string strP_Barcode, string strC_Barcode, string strUser)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.ManualShipperMapping(strPackLevel, strMode, strGTIN, strP_Barcode, strC_Barcode, strUser);
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

        public string BL_InOutBarcode(string strMode,string strBarcode,string strSource,string strDest,string strConsign,string strDocNo,string strUser)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.InoutBarcode(strMode,strBarcode,strSource,strDest,strDest,strDocNo,strUser);
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

        public string BL_ValidateStatus(string strBarocde, string strMode)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
               return objLocal.ValidateStatus(strBarocde, strMode);
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

        public int BL_UpdateStatus(string strFromBarocde,string strTo, string strMode,string strUser)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.UpdateBarcodeStatus(strFromBarocde,strTo, strMode,strUser);
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

        public int BL_RejectRequest(string strRefNo)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.RejectRequest(strRefNo);
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

        public string BL_UpdateReject(string Barcode,string strMode, string strUser,string strPlant)
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
                return objLocal.UpdateReject(Barcode, strMode, strUser,strPlant);
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

        //public string BL_UpdatelinkReletion(DataTable dt)
        //{
        //    //PL_Login objPL_Log=new PL_Login();
        //    objLocal = new Service();
        //    objLocal.Url = PL_File.servicePath;
        //    objLocal.Timeout = 60000;
        //    try
        //    {
        //        return objLocal.UpdateReject(Barcode, strMode, strUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objLocal = null;
        //    }
        //}

        public string BL_linkServerMapping()
        {
            //PL_Login objPL_Log=new PL_Login();
            objLocal = new Service();
            objLocal.Url = PL_File.servicePath;
            objLocal.Timeout = 60000;
            try
            {
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


        #endregion


        public void SaveBarcode(string strBarcode, ListView listView1, Label lblPass, Label lblFail)
        {
            BusinessLayer.BL_Scanning objScan = new BusinessLayer.BL_Scanning();
            ListViewItem lstitem = new ListViewItem(strBarcode.Replace("*", ""));
            try
            {
                if (strBarcode.Trim() == "NOREAD")
                {
                    lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                    listView1.Items.Add(lstitem).BackColor = Color.Red;
                }
                else
                {
                    Int32 intStatus = objScan.InsertSecData_Single(strBarcode, PL_Login.UserID.ToString().Trim());
                    switch (intStatus)
                    {
                        case 0:
                            lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                            listView1.Items.Add(lstitem).BackColor = Color.Red;
                            break;
                        case 1:
                            listView1.Items.Add(lstitem).BackColor = Color.Green;
                            lblPass.Text = (Convert.ToInt32(lblPass.Text) + 1).ToString();
                            break;
                        case 2:
                            lblFail.Text = (Convert.ToInt32(lblFail.Text) + 1).ToString();
                            listView1.Items.Add(lstitem).BackColor = Color.Red;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objScan = null;
            }
        }

    }
}
