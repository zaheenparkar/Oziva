using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyLayer;
using BusinessLayer.localhost;
using System.Web;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;



namespace BusinessLayer
{
    public class BL_Reports
    {
        public static Service objLocal;
        PL_Generator objPL_Gen;

        public DataTable BLGet_GetParentChild(string Batch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetParentChildRpt(Batch);
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
        public DataTable BLGet_GetUnutilizedSec(string Batch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetUnutilizedRptSec(Batch);
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

        public DataTable BLGet_GetUnutilizedTer(string Batch)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetUnutilizedRptTer(Batch);
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

        public DataTable BLGet_SumHead(string Batch, string strPlant,int ArcFlag)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetSumNEW(Batch, strPlant, ArcFlag);
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
        public DataTable BLGet_SumUploadHead(string Batch, string strPlant, int ArcFlag)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetUploadSumNEW(Batch, strPlant, ArcFlag);
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

        public DataTable BLGet_SumRpt(string strGTIN, string strERP, string strPACKING, string strBATCH,int ArcFlag)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetSummaryRpt(strGTIN, strERP, strPACKING, strBATCH, ArcFlag);
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

        public DataTable BLGet_TerRpt(string strBatch, string strPlant, string strCriteria)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetTerRpt(strBatch, strPlant, strCriteria);
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

        public DataTable BLGet_SecRpt(string strBatch, string strPlant, string strCriteria)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetSecRpt(strBatch, strPlant, strCriteria);
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

        public DataTable BLGet_WrongRpt(string strBatch, string strFrom, string strTo, string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetWrongPackRpt(strBatch, strFrom, strTo, strPlant);
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

        public DataTable BLGet_AuditRpt(string strFrom, string strTo, string strPlant)
        {
            try
            {
                objLocal = new Service();
                objLocal.Url = PL_File.servicePath;
                objLocal.Timeout = 60000;
                return objLocal.GetAuditRpt(strFrom, strTo, strPlant);
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

        public void ExportToExcel(ListView lv)
        {
            string strRow = (lv.Items.Count + 1).ToString();
            char cLast = (char)((int)'A' + lv.Columns.Count);


            try
            {
                OleDbConnection con = new OleDbConnection();
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                Microsoft.Office.Interop.Excel.Range oRange;
                Microsoft.Office.Interop.Excel.Range oDataRange;

                oRange = ExcelApp.get_Range("A1", cLast.ToString() + "1");

                oDataRange = ExcelApp.get_Range("A2", cLast.ToString() + strRow);

                oDataRange.NumberFormat = "@";

                oRange.Font.Size = 11;
                oRange.Font.Bold = true;
                oRange.ColumnWidth = 20;

                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    ExcelApp.Cells[1, i + 1] = lv.Columns[i].Text.ToString();
                }

                for (int i = 0; i < lv.Items.Count; i++)
                {

                    for (int j = 0; j < lv.Columns.Count; j++)
                    {
                        ExcelApp.Application.Cells[i + 2, j + 1] = lv.Items[i].SubItems[j].Text.ToString();
                    }
                }

                //if (strPickList.ToString() != "")
                //{



                //    //Microsoft.Office.Interop.Excel.Range oBorder;
                //    //oBorder = ExcelApp.get_Range("B3:B" + BoxRow.ToString() , "D3:D" + BoxRow.ToString());
                //    //oBorder.Cells.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                //    oRange = ExcelApp.get_Range("B3:B" + (EANRow - 1).ToString(), "D3:D" + (EANRow - 1).ToString());
                //    oRange.Cells.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                //}

                using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                {

                    exportSaveFileDialog.Title = "Select Excel File";
                    exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xls)|*.xls";

                    if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
                    {
                        string fullFileName = exportSaveFileDialog.FileName;


                        ExcelApp.ActiveWorkbook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                        ExcelApp.ActiveWorkbook.Saved = true;

                        ExcelApp.Quit();

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void ExportPCToExcel(ListView lv)
        {
            string strRow = ((lv.Items.Count + 1) * 3).ToString();
            char cLast = (char)((int)'A' + lv.Columns.Count - 1);
            string strTerBarcode = "";
            int iSumQty = 0, iPerQty = 0;

            try
            {
                OleDbConnection con = new OleDbConnection();
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                Microsoft.Office.Interop.Excel.Range oRange;
                Microsoft.Office.Interop.Excel.Range oDataRange;

                oDataRange = ExcelApp.get_Range("B1", cLast.ToString() + strRow);
                oDataRange.NumberFormat = "@";


                oRange = ExcelApp.get_Range("A1", cLast.ToString() + "1");
                oRange.Font.Size = 11;
                oRange.Font.Bold = true;
                oRange.ColumnWidth = 20;

                ExcelApp.Cells[1, 1] = "Tertiary Barcode";
                strTerBarcode = lv.Items[0].SubItems[0].Text.ToString();
                ExcelApp.Cells[1, 2] = strTerBarcode;


                for (int c = 1; c < lv.Columns.Count; c++)
                {
                    ExcelApp.Cells[3, c + 1] = lv.Columns[c].Text.ToString();
                }

                oRange = ExcelApp.get_Range("B3", cLast.ToString() + "3");

                //Mayur
                oRange.Font.Size = 11;
                oRange.Font.Bold = true;


                int i = 4, j = 2;

                foreach (ListViewItem comp in lv.Items)
                {


                    if (comp.Text == strTerBarcode)
                    {
                        iPerQty += 1;
                    }
                    else
                    {
                        i += 1;
                        ExcelApp.Cells[i, 7] = "Total";
                        ExcelApp.Cells[i, 8] = iPerQty.ToString();
                        oRange = ExcelApp.get_Range("G" + i, "H" + i);
                        //oRange.NumberFormat = "@";
                        //Mayur
                        oRange.Font.Size = 11;
                        oRange.Font.Bold = true;

                        i += 1;
                        ExcelApp.Cells[i, 1] = "Tertiary Barcode";
                        ExcelApp.Cells[i, 2] = comp.Text.ToString();
                        strTerBarcode = comp.Text.ToString();
                        oRange = ExcelApp.get_Range("A" + i, "B" + i);
                        oRange.Font.Size = 11;
                        oRange.Font.Bold = true;

                        i += 2;

                        for (int c = 1; c < lv.Columns.Count; c++)
                        {
                            ExcelApp.Cells[i, c + 1] = lv.Columns[c].Text.ToString();
                        }

                        oRange = ExcelApp.get_Range("B" + i, cLast.ToString() + i.ToString());
                        oRange.Font.Size = 11;
                        oRange.Font.Bold = true;

                        i += 1;
                        iSumQty = iSumQty + iPerQty;
                        iPerQty = 1;


                        //Istart = i
                    }

                    int ifirst = 1;

                    foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                    {
                        if (ifirst > 1)
                        {
                            ExcelApp.Cells[i, j] = drv.Text.ToString();
                            j += 1;
                        }
                        ifirst += 1;
                    }

                    j = 2; i += 1;

                }
                i += 1;

                iSumQty = iSumQty + iPerQty;

                ExcelApp.Cells[i, 7] = "Total";
                ExcelApp.Cells[i, 8] = iPerQty.ToString();

                ExcelApp.Cells[i + 2, 7] = "Grand Total";
                ExcelApp.Cells[i + 2, 8] = iSumQty.ToString();

                //oDataRange = ExcelApp.get_Range("B1", cLast.ToString() + (i+2).ToString());
                //oDataRange.NumberFormat = "@";

                //ExcelApp.get_Range("H" + i, "H" + (i + 2).ToString()).NumberFormat = "@";
                ExcelApp.get_Range("G" + i, "H" + (i + 2).ToString()).Font.Size = 11;
                ExcelApp.get_Range("G" + i, "H" + (i + 2).ToString()).Font.Bold = true;

                ExcelApp.get_Range("A1", cLast.ToString() + (i + 2).ToString()).Borders.Weight = 2;



                using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                {

                    exportSaveFileDialog.Title = "Select Excel File";
                    exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xls)|*.xls";

                    if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
                    {
                        string fullFileName = exportSaveFileDialog.FileName;
                        ExcelApp.ActiveWorkbook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                        ExcelApp.ActiveWorkbook.Saved = true;

                        ExcelApp.Quit();

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

            }

        }


        public void KillProcess()
        {
            try
            {
                foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
                {
                    if (myProc.ProcessName == "EXCEL")
                    {
                        myProc.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void ExportToCsvPC(string strFilePath, ListView lv)
        {
            string strTerBarcode = "";
            int iPerQty = 0, iSumQty = 0, iTerQty = 0;
            StreamWriter sw = new StreamWriter(strFilePath);

            sw.Write("Tertiary Barcode");
            sw.Write(",");
            strTerBarcode = lv.Items[0].SubItems[0].Text.ToString();
            iTerQty++;
            sw.Write(String.Format("=\"{0}\"", strTerBarcode));

            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);

            for (int c = 0; c < lv.Columns.Count; c++)
            {
                if (c == 0)
                {
                    sw.Write(" ");
                }
                else
                {
                    sw.Write(lv.Columns[c].Text.ToString());
                }

                if (c < lv.Columns.Count)
                {
                    sw.Write(",");
                }
            }

            sw.Write(sw.NewLine);

            foreach (ListViewItem comp in lv.Items)
            {
                if (comp.Text == strTerBarcode)
                {
                    iPerQty += 1;
                }
                else
                {

                    iTerQty++;
                    sw.Write(sw.NewLine);

                    sw.Write("Total");
                    sw.Write(",");
                    sw.Write(iPerQty.ToString());




                    sw.Write(sw.NewLine);
                    sw.Write("Tertiary Barcode");
                    sw.Write(",");
                    strTerBarcode = comp.Text.ToString();
                    sw.Write(String.Format("=\"{0}\"", comp.Text.ToString()));



                    sw.Write(sw.NewLine);
                    sw.Write(sw.NewLine);

                    for (int c = 0; c < lv.Columns.Count; c++)
                    {
                        if (c == 0)
                        {
                            sw.Write(" ");
                        }
                        else
                        {
                            sw.Write(lv.Columns[c].Text.ToString());
                        }

                        if (c < lv.Columns.Count)
                        {
                            sw.Write(",");
                        }
                    }


                    sw.Write(sw.NewLine);

                    iSumQty = iSumQty + iPerQty;
                    iPerQty = 1;

                }

                int ifirst = 1;

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    if (ifirst > 1)
                    {
                        sw.Write(String.Format("=\"{0}\"", drv.Text.ToString().Replace(",","")));
                    }
                    else
                    {
                        sw.Write(" ");
                    }
                    if (ifirst < comp.SubItems.Count)
                    {
                        sw.Write(",");
                    }


                    ifirst += 1;
                }

                sw.Write(sw.NewLine);

            }

            sw.Write(sw.NewLine);

            iSumQty = iSumQty + iPerQty;

            sw.Write("Total");
            sw.Write(",");
            sw.Write(iPerQty.ToString());

            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);

            sw.Write("Grand Parent Total");
            sw.Write(",");
            sw.Write(iTerQty.ToString());
            sw.WriteLine();
            sw.Write("Grand Child Total");
            sw.Write(",");
            sw.Write(iSumQty.ToString());
            sw.Close();
            //ExcelApp.Cells[i, 7] = "Total";
            //ExcelApp.Cells[i, 8] = iPerQty.ToString();

            //ExcelApp.Cells[i + 2, 7] = "Grand Total";
            //ExcelApp.Cells[i + 2, 8] = iSumQty.ToString();


        }

        public void ExportToCsv(string strFilePath, ListView lv)
        {

            StreamWriter sw = new StreamWriter(strFilePath);

            try
            {

                for (int c = 0; c < lv.Columns.Count; c++)
                {
                    sw.Write(lv.Columns[c].Text.ToString());

                    if (c < lv.Columns.Count)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);

                
                for (int r = 0; r < lv.Items.Count; r++)
                {
                    for (int c = 0; c < lv.Columns.Count; c++)
                    {
                        
                        sw.Write(String.Format("=\"{0}\"",lv.Items[r].SubItems[c].Text.ToString().Replace(",","")));
                        sw.Write(",");

                    }
                    sw.Write(sw.NewLine);
                }
                

                sw.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sw.Dispose();
                sw = null;
            }


        }


        //public DataTable BLGetMasterBatch(string strPlant)
        //{
        //    try
        //    {
        //        objLocal = new Service();
        //        objLocal.Url = PL_File.servicePath;
        //        objLocal.Timeout = 60000;

        //        return objLocal.GetMasterBatch(strPlant);
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

        //public DataSet BLGetLineInfo(PL_Generator objField, string strPlant)
        //{
        //    try
        //    {
        //        objLocal = new Service();
        //        objLocal.Url = PL_File.servicePath;
        //        objLocal.Timeout = 60000;

        //        return objLocal.GetLineInfo(objField.strPackLevel, strPlant, objField.strLableType);
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
    }
}

