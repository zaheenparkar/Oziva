using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Windows.Forms;
using PropertyLayer;

namespace PC_Application
{
    public class clsFile
    {
        ArrayList dt;

        StreamReader FileReader;

        public static void SetGlobleDetails_Scan(string returnField, string val)
        {
            if (File.Exists(Application.StartupPath + "\\SysConfigIP.xml") == false)
            {
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(Application.StartupPath + "\\SysConfigIP.xml");
            if (ds.Tables["TBLCONFIG"].Rows.Count != 0)
            {
                ds.Tables["TBLCONFIG"].Rows[0][returnField] = val;
                ds.Tables["TBLCONFIG"].AcceptChanges();
                ds.WriteXml(Application.StartupPath + "\\SysConfigIP.xml");
            }
            else
            {
                return;
            }
        }

        public static void SetGlobleDetails(string returnField, string val)
        {
            if (File.Exists(Application.StartupPath + "\\SysConfig.xml") == false)
            {
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(Application.StartupPath + "\\SysConfig.xml");
            if (ds.Tables["TBLCONFIG"].Rows.Count != 0)
            {
                ds.Tables["TBLCONFIG"].Rows[0][returnField] = val;
                ds.Tables["TBLCONFIG"].AcceptChanges();
                ds.WriteXml(Application.StartupPath + "\\SysConfig.xml");
            }
            else
            {
                return;
            }
        }

        public string defaultrootDirectory()
        {
            return "\\Application\\DGFT";
        }

        public string defaultInwardPath()
        {
            return "\\Application\\DGFT\\INWARD.txt";
        }

        public string defaultUserPath()
        {
            return "\\Application\\DGFT\\Users.txt";
        }

        public string defaultJobPath()
        {
            return "\\Application\\DGFT\\JOB.txt";
        }

        public string defaultConsignePath()
        {
            return "\\Application\\DGFT\\CONSIGN.txt";
        }

        public string defaultPlantPath()
        {
            return "\\Application\\DGFT\\LOCATION.txt";
        }

        public string defaultOutwardPath()
        {
            return "\\Application\\DGFT\\OUTWARD.txt";
        }

        public string defaultSecScanningPath()
        {
            return "\\Application\\DGFT\\SecScanning.txt";
        }

        public string defaultTerScanningPath()
        {
            return "\\Application\\DGFT\\TerScanning.txt";
        }

        public string defaultMappingpath()
        {
            return "\\Application\\DGFT\\Packing.txt";
        }

        public string defaultHetroMappingpath()
        {
            return "\\Application\\DGFT\\Hetro.txt";
        }

        public string defaultSecRejectionpath()
        {
            return "\\Application\\DGFT\\SecRejection.txt";
        }

        public string defaultTerRejectionpath()
        {
            return "\\Application\\DGFT\\TerRejection.txt";
        }

        public OleDbConnection connect()
        {
            string sconnstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Application.StartupPath + " \\dbTracknTrace.mdb";
            OleDbConnection str = new OleDbConnection(sconnstr);
            return str;
        }

        public int DownloadDataFromDevice(string strInput, string strLocalPath)
        {
            int bFlag = 0;
            OpenNETCF.Desktop.Communication.RAPI rapi = new OpenNETCF.Desktop.Communication.RAPI();
            try
            {

                try
                {
                    rapi.Connect();
                    if (rapi.Connected == true)
                    {
                        try
                        {
                            if (File.Exists(strLocalPath))
                            {
                                File.Delete(strLocalPath);
                            }
                            if (strInput == "Inward")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultInwardPath());
                                //rapi.DeleteDeviceFile(defaultInwardPath());
                            }
                            else if (strInput == "Outward")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultOutwardPath());
                                //rapi.DeleteDeviceFile(defaultOutwardPath());
                            }
                            else if (strInput == "Secondary")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultSecScanningPath());
                                //rapi.DeleteDeviceFile(defaultSecScanningPath());
                            }
                            else if (strInput == "Tertiary")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultTerScanningPath());
                                //rapi.DeleteDeviceFile(defaultTerScanningPath());
                            }
                            else if (strInput == "Mapping")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultMappingpath());
                                //rapi.DeleteDeviceFile(defaultMappingpath());
                            }
                            else if (strInput == "Hetro")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultHetroMappingpath());
                                //rapi.DeleteDeviceFile(defaultMappingpath());
                            }
                            else if (strInput == "SReject")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultSecRejectionpath());
                                //rapi.DeleteDeviceFile(defaultMappingpath());
                            }
                            else if (strInput == "TReject")
                            {
                                rapi.CopyFileFromDevice(strLocalPath, defaultTerRejectionpath());
                                //rapi.DeleteDeviceFile(defaultMappingpath());
                            }
                            bFlag = 1;
                        }
                        catch { }

                    }
                    else
                    {
                        bFlag = 0;
                    }
                }
                catch (Exception ex)
                {
                    bFlag = 0;//not connected
                }
            }
            catch (Exception ex)
            {
                bFlag = 0;
            }
            finally
            {
                rapi.Disconnect();
                rapi.Dispose();
                rapi = null;
            }
            return bFlag;
        }

        public int UploadDataToDevice(string strInput, string strLocalPath)
        {
            int bFlag = 0;
            OpenNETCF.Desktop.Communication.RAPI rapi = new OpenNETCF.Desktop.Communication.RAPI();
            try
            {

                try
                {
                    rapi.Connect();
                    if (rapi.Connected == true)
                    {
                        try
                        {
                            
                            if(!rapi.DeviceFileExists(defaultrootDirectory()))
                            {
                                rapi.CreateDeviceDirectory(defaultrootDirectory());
                            }

                            if (strInput == "User")
                            {
                                rapi.CopyFileToDevice(strLocalPath, defaultUserPath(), true);
                                File.Delete(strLocalPath);
                                //rapi.DeleteDeviceFile(defaultInwardPath());
                            }
                            else if (strInput == "Plant")
                            {
                                rapi.CopyFileToDevice(strLocalPath, defaultPlantPath(), true);
                                File.Delete(strLocalPath);
                                //rapi.DeleteDeviceFile(defaultOutwardPath());
                            }
                            else if (strInput == "Consignee")
                            {
                                rapi.CopyFileToDevice(strLocalPath, defaultConsignePath(), true);
                                File.Delete(strLocalPath);
                                //rapi.DeleteDeviceFile(defaultSecScanningPath());
                            }

                            if (strInput == "JOB")
                            {
                                rapi.CopyFileToDevice(strLocalPath, defaultJobPath(), true);
                                File.Delete(strLocalPath);
                                //rapi.DeleteDeviceFile(defaultInwardPath());
                            }
                            bFlag = 1;
                        }
                        catch { }

                    }
                    else
                    {
                        bFlag = 0;
                    }
                }
                catch (Exception ex)
                {
                    bFlag = 0;//not connected
                }
            }
            catch (Exception ex)
            {
                bFlag = 0;
            }
            finally
            {
                rapi.Disconnect();
                rapi.Dispose();
                rapi = null;
            }
            return bFlag;
        }

        public DataTable CreateDataTable(string strInput, string strLocalPath)
        {
            DataTable dt = new DataTable("temp");
            DataRow dr;
            int iRow = 0;
            
            StreamReader sr;
            string strData = "";
            try
            {
                if (strInput == "Inward")
                {

                    sr = new StreamReader(strLocalPath);

                    dt.Columns.Add("BCIL", typeof(string));
                    dt.Columns.Add("BARCODE", typeof(string));
                    dt.Columns.Add("SOURCE", typeof(string));
                    dt.Columns.Add("DESTINATION", typeof(string));
                    dt.Columns.Add("TRAN_BY", typeof(string));
                  
                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {
                            dr = dt.NewRow();
                            iRow = iRow + 1;

                            dr[0] = iRow.ToString();
                            dr[1] = strData.Split('#').GetValue(0).ToString();
                            dr[2] = strData.Split('#').GetValue(1).ToString();
                            dr[3] = strData.Split('#').GetValue(2).ToString();
                            dr[4] = PL_Login.UserID.ToString();
                           
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();


                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();
                 
                }
                else if (strInput == "Outward")
                {
                    sr = new StreamReader(strLocalPath);

                    dt.Columns.Add("BCIL", typeof(string));
                    dt.Columns.Add("BARCODE", typeof(string));
                    dt.Columns.Add("SOURCE", typeof(string));
                    dt.Columns.Add("DESTINATION", typeof(string));
                    dt.Columns.Add("CONSIGNEE", typeof(string));
                    dt.Columns.Add("DOCUMENT_NO", typeof(string));
                    dt.Columns.Add("TRAN_BY", typeof(string));

                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {
                            dr = dt.NewRow();
                            iRow = iRow + 1;
                            dr[0] = iRow.ToString();
                            dr[1] = strData.Split('#').GetValue(0).ToString();
                            dr[2] = strData.Split('#').GetValue(1).ToString();
                            dr[3] = strData.Split('#').GetValue(2).ToString();
                            dr[4] = strData.Split('#').GetValue(3).ToString();
                            dr[5] = strData.Split('#').GetValue(4).ToString();
                            dr[6] = PL_Login.UserID.ToString();

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();


                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();
                   
                }
                else if (strInput == "Secondary" || strInput == "Tertiary")
                {
                    sr = new StreamReader(strLocalPath);

                    dt.Columns.Add("BCIL", typeof(string));
                    dt.Columns.Add("FROM_BARCODE", typeof(string));
                    dt.Columns.Add("TO_BARCODE", typeof(string));
                    dt.Columns.Add("VALIDATED_BY", typeof(string));
                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {

                            dr = dt.NewRow();
                            iRow = iRow + 1;
                            dr[0] = iRow.ToString();
                            dr[1] = strData.Split('#').GetValue(0).ToString();
                            dr[2] = strData.Split('#').GetValue(1).ToString();
                            dr[3] = PL_Login.UserID.ToString();

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();

                }
                else if (strInput == "SReject" || strInput == "TReject")
                {
                    sr = new StreamReader(strLocalPath);

                    dt.Columns.Add("BCIL", typeof(string));
                    dt.Columns.Add("BARCODE", typeof(string));
                    dt.Columns.Add("REJECT_BY", typeof(string));
                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {

                            dr = dt.NewRow();
                            iRow = iRow + 1;
                            dr[0] = iRow.ToString();
                            dr[1] = strData.ToString();
                            dr[2] = PL_Login.UserID.ToString();

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();
                 
                }
                else if (strInput == "Mapping")
                {
                    sr = new StreamReader(strLocalPath);

                    dt.Columns.Add("BCIL", typeof(string));
                    dt.Columns.Add("P_BARCODE", typeof(string));
                    dt.Columns.Add("C_BARCODE", typeof(string));
                    dt.Columns.Add("PACK_SIZE", typeof(int));
                    dt.Columns.Add("P_PREFIX", typeof(int));
                    dt.Columns.Add("TRAN_BY", typeof(string));
                    dt.Columns.Add("PARTIAL_ST", typeof(string));
                    dt.Columns.Add("BATCH", typeof(string));


                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {
                            dr = dt.NewRow();
                            iRow = iRow + 1;

                            dr[0] = iRow.ToString();
                            dr[1] = strData.Split('#').GetValue(0).ToString();
                            dr[2] = strData.Split('#').GetValue(1).ToString();
                            dr[3] = Convert.ToInt32(strData.Split('#').GetValue(2).ToString());
                            dr[4] = Convert.ToInt32(strData.Split('#').GetValue(3).ToString());
                            dr[5] = PL_Login.UserID.ToString();
                            dr[6] = Convert.ToInt32(strData.Split('#').GetValue(6).ToString());
                            dr[7] = strData.Split('#').GetValue(5).ToString();
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();

                           

                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();
                }
                else if (strInput == "MappingFull")
                {
                    sr = new StreamReader(strLocalPath);

                    
                    dt.Columns.Add("P_BARCODE", typeof(string));
                    dt.Columns.Add("C_BARCODE", typeof(string));
                    dt.Columns.Add("PACK_SIZE", typeof(int));
                    dt.Columns.Add("P_PREFIX", typeof(int));
                    dt.Columns.Add("GTIN", typeof(string));
                    dt.Columns.Add("BATCH", typeof(string));
                    dt.Columns.Add("PARTIAL_ST", typeof(string));



                    do
                    {
                        strData = sr.ReadLine();
                        if (strData != "")
                        {
                            dr = dt.NewRow();
                            

                            
                            dr[0] = strData.Split('#').GetValue(0).ToString();
                            dr[1] = strData.Split('#').GetValue(1).ToString();
                            dr[2] = Convert.ToInt32(strData.Split('#').GetValue(2).ToString());
                            dr[3] = Convert.ToInt32(strData.Split('#').GetValue(3).ToString());
                            dr[4] = strData.Split('#').GetValue(4).ToString();
                            dr[5] = strData.Split('#').GetValue(5).ToString();
                            dr[6] = Convert.ToInt32(strData.Split('#').GetValue(6).ToString());
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();



                        }
                    }
                    while (!sr.EndOfStream);

                    sr.Close();
                    sr.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr = null;
            }
            return dt;
        }

        public void BindList(DataTable dt, ListView ls)
        {
            ListViewItem lv;
            try
            {
                for (int i = 0; i <= dt.Columns.Count-1; i++)
                {
                    ls.Columns.Add(dt.Columns[i].ToString());
                }

                for (int i = 0; i <= dt.Columns.Count-1; i++)
                {
                   
                    for (int j = 0; j <= dt.Rows.Count-1; j++)
                    {
                        lv = new ListViewItem(dt.Rows[j][i].ToString());
                        //lv.SubItems.Add(dt.Rows[j][i].ToString());
                        ls.Items.Add(lv);
                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            string strVal = "";
            try
            {
                // First we will write the headers.

                //DataTable dt = m_dsProducts.Tables[0];

                int iColCount = dtDataTablesList.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {

                    sw.Write(dtDataTablesList.Columns[i]);

                    if (i < iColCount - 1)
                    {

                        sw.Write(",");

                    }

                }

                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dtDataTablesList.Rows)
                {

                    for (int i = 0; i < iColCount; i++)
                    {
                        strVal = "";
                        if (!Convert.IsDBNull(dr[i]))
                        {

                            strVal = dr[i].ToString();
                            if (strVal.Contains("\n-") == true)
                            {
                                strVal = strVal.Replace("\n-", "-");
                            }
                            if (strVal.Contains(",") == true)
                            {
                                strVal = strVal.Replace(",", " ");
                            }
                            if (strVal.Contains("\n") == true)
                            {
                                strVal = strVal.Replace("\n", "-");
                            }
                            sw.Write(strVal.Trim());

                            //if (dr[i].ToString().Contains("\n-") == true)
                            //{
                            //    sw.Write(dr[i].ToString().Replace(",", "-").ToString().Trim());
                            //}
                        }
                        else
                        {
                            sw.Write("--");
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }

                    sw.Write(sw.NewLine);
                }

                sw.Close();
               

            }
            catch (Exception ex)
            {
                sw.Close();
                MessageBox.Show(ex.ToString());
               
            }
        }

        public void BindListMapping(DataTable dt, ListView ls)
        {
          
            try
            {
                ls.Items.Clear();
                ls.Columns.Clear();
                
                
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    ls.Columns.Add(dt.Columns[i].ToString());
                    ls.Columns[i].Width = 150;  
                   
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    ListViewItem lv = new ListViewItem(dt.Rows[i][0].ToString());
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        lv.SubItems.Add(dt.Rows[i][j].ToString());

                    }
                    ls.Items.Add(lv);

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
