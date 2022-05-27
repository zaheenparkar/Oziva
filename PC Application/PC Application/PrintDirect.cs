using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using DataLayer;

namespace PC_Application
{
    [StructLayout(LayoutKind.Sequential)]

    public struct DOCINFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]

        public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)]

        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)]

        public string pDataType;
    }

    public class PrintDirect
    {
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

        public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern long StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern long EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern long EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern long ClosePrinter(IntPtr hPrinter);



        public static int PrintTertiaryHomo(string printerName, DataTable dt, string strGTIN, string strProduct, string strBatch, string strPackSize, string dtExp, string strPRN)
        {
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            int pcWritten = 0;
            int iPrint = 0;
            Doc.pDocName = "Homogenious Label";
            Doc.pDataType = "RAW";
            string str, str2, hstr, hstr1 = "";
            try
            {



                string strMonth, strEXPDt, strYear, strExp = "";

                strExp = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                strMonth = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(DataLayer.clsDb.GetGlobleDetails("TERMONTH"));
                strYear = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy");

                //strExp = DateTime.ParseExact((dtExp).ToString("yyMMdd");
                //strMonth = Convert.ToDateTime(dtExp).ToString("MMM");
                //strYear = Convert.ToDateTime(dtExp).ToString("yyyy");

                strEXPDt = strMonth + "." + strYear;

                hstr = "(01)" + strGTIN + "(17)" + strExp + "(10)" + strBatch;
                hstr1 = "01" + strGTIN + "17" + strExp + "10" + strBatch;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);
                    try
                    {
                        //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                        strFileData = strPRN;


                        str = dt.Rows[i][0].ToString();
                        str2 = "(00)" + dt.Rows[i][0].ToString().Substring(2);

                        strFileData = strFileData.Replace("{ItemBarcode}", hstr1.Substring(0, 24));
                        strFileData = strFileData.Replace("{ItemBarcode2}", hstr1.Substring(24));

                        strFileData = strFileData.Replace("{ItemBarcode1}", hstr);
                        strFileData = strFileData.Replace("{SerialBarcode}", str);
                        strFileData = strFileData.Replace("{SerialBarcode1}", str2);

                        if (strProduct.Length > 27)
                        {
                            strFileData = strFileData.Replace("{VAR1}", strProduct.Substring(0, 27));
                            strFileData = strFileData.Replace("{VAR5}", strProduct.Substring(27));
                        }
                        else
                        {
                            strFileData = strFileData.Replace("{VAR1}", strProduct.Trim());
                            strFileData = strFileData.Replace("{VAR5}", "");
                        }

                        strFileData = strFileData.Replace("{VAR2}", strBatch);
                        strFileData = strFileData.Replace("{VAR3}", strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                        strFileData = strFileData.Replace("{VAR4}", strPackSize);

                        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                        iPrint++;
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                dt = null;
            }
            return iPrint;

        }


        public static int PrintShipperlabel(string printerName, string strGTIN,string serialno , string strProduct, string mfg, string exp, string strPRN)
        {
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            int pcWritten = 0;
            int iPrint = 0;
            Doc.pDocName = "Homogenious Label";
            Doc.pDataType = "RAW";
            string str, str2, hstr, hstr1 = "";
            try
            {



                string strMonth, strEXPDt, strYear, strExp = "";

                strExp = DateTime.ParseExact(mfg, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                strMonth = DateTime.ParseExact(mfg, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(DataLayer.clsDb.GetGlobleDetails("TERMONTH"));
                strYear = DateTime.ParseExact(mfg, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy");

                //strExp = DateTime.ParseExact((dtExp).ToString("yyMMdd");
                //strMonth = Convert.ToDateTime(dtExp).ToString("MMM");
                //strYear = Convert.ToDateTime(dtExp).ToString("yyyy");

                strEXPDt = strMonth + "." + strYear;

               // hstr = "(01)" + strGTIN + "(17)" + strExp + "(10)" + strBatch;
               // hstr1 = "01" + strGTIN + "17" + strExp + "10" + strBatch;

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);
                    try
                    {
                        //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                        strFileData = strPRN;


                        //str = dt.Rows[i][0].ToString();
                        //str2 = "(00)" + dt.Rows[i][0].ToString().Substring(2);

                        strFileData = strFileData.Replace("{ItemBarcode}", serialno);
                       // strFileData = strFileData.Replace("{ItemBarcode2}", hstr1.Substring(24));

                        //strFileData = strFileData.Replace("{ItemBarcode1}", hstr);
                        //strFileData = strFileData.Replace("{SerialBarcode}", str);
                        //strFileData = strFileData.Replace("{SerialBarcode1}", str2);

                         strFileData = strFileData.Replace("{VAR1}", strProduct.Trim());

                        //if (strProduct.Length > 27)
                        //{
                        //    strFileData = strFileData.Replace("{VAR1}", strProduct.Substring(0, 27));
                        //    strFileData = strFileData.Replace("{VAR5}", strProduct.Substring(27));
                        //}
                        //else
                        //{
                        //    strFileData = strFileData.Replace("{VAR1}", strProduct.Trim());
                        //    strFileData = strFileData.Replace("{VAR5}", "");
                        //}

                        strFileData = strFileData.Replace("{VAR2}", mfg);
                        strFileData = strFileData.Replace("{VAR3}", strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                        strFileData = strFileData.Replace("{VAR4}", exp);

                        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                        iPrint++;
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }

               // }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                //dt = null;
            }
            return iPrint;

        }

        public static int PrintTertiaryHetro(string printerName, DataTable dt, string strGTIN, string strProduct, string strBatch, string strPackSize, string dtExp, string strPRN)
        {
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            int pcWritten = 0, iPrint = 0;
            Doc.pDocName = "Tertiary Label";
            Doc.pDataType = "RAW";
            string str, str2, hstr, hstr1 = "";
            try
            {

                string strMonth, strEXPDt, strYear, strExp = "";

                //strMonth = Convert.ToDateTime(dtExp).ToString("MMM");
                //strYear = Convert.ToDateTime(dtExp).ToString("yyyy");

                strExp = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                strMonth = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(DataLayer.clsDb.GetGlobleDetails("TERMONTH"));
                strYear = DateTime.ParseExact(dtExp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy");


                strEXPDt = strMonth + "." + strYear;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);
                    try
                    {
                        //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                        strFileData = strPRN;


                        str = dt.Rows[i][0].ToString();
                        str2 = "(00)" + dt.Rows[i][0].ToString().Substring(2);

                        strFileData = strFileData.Replace("{SerialBarcode}", str);
                        strFileData = strFileData.Replace("{SerialBarcode1}", str2);
                        if (strProduct.Length > 45)
                        {
                            strFileData = strFileData.Replace("{VAR1}", strProduct.Substring(0, 45));
                            strFileData = strFileData.Replace("{VAR5}", strProduct.Substring(45));
                        }
                        else
                        {
                            strFileData = strFileData.Replace("{VAR1}", strProduct.Trim());
                            strFileData = strFileData.Replace("{VAR5}", "");
                        }


                        strFileData = strFileData.Replace("{VAR2}", strBatch);
                        strFileData = strFileData.Replace("{VAR3}", strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);

                        //strFileData = strFileData.Replace("{VAR4}", strPackSize);

                        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                        iPrint++;

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                dt = null;
            }
            return iPrint;
        }

        public static int PrintSecOneUP(string printerName, DataTable dt, string strGTIN, string strBatch, string strMGF, string strexp, string strPRN)
        {
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            int pcWritten = 0, iPrint = 0;
            Doc.pDocName = "Secondary Label";
            Doc.pDataType = "RAW";
            try
            {
                string strMonth, strEXPDt, strYear, strEXP = "";



                strEXP = strexp.Split('/').GetValue(0).ToString() + strexp.Split('/').GetValue(1).ToString() + strexp.Split('/').GetValue(2).ToString().Substring(2, 2).ToString();
                strMonth = strexp.Split('/').GetValue(0).ToString();
                strYear = strexp.Split('/').GetValue(2).ToString();

                //strEXP = Convert.ToDateTime(strexp).ToString("MMddyy");

                //strMonth = Convert.ToDateTime(strexp).ToString("MMM");
                //strYear = Convert.ToDateTime(strexp).ToString("yyyy");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);
                    string hstr1 = "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString();
                    try
                    {

                        //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                        strFileData = strPRN;
                        //strFileData = strFileData.Replace("{barcode}", hstr1.Substring(0, 24));
                        //strFileData = strFileData.Replace("{barcode1}", hstr1.Substring(24));
                        strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                       // strFileData = strFileData.Replace("{serialno}", "(01)" + strGTIN + "(17)" + strEXP + "(10)" + strBatch + "(21)" + dt.Rows[i][0].ToString());
                        strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                        strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                        strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + "/" + strYear);
                        strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());


                        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                        iPrint++;
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dt = null;
            }
            return iPrint;
        }

        public static int PrintSecTwoUP(string printerName, DataTable dt, string strGTIN, string strBatch, string strMGF, string strexp, string strPRN)
        {
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            string[] arrPRNTail;
            string[] arrPRNHead;
            bool flgSkip = false;
            int pcWritten = 0, iPrint = 0, icount = 0, iQty = 0, iMod = 0, iRem = 0;
            Doc.pDocName = "Secondary Label";
            Doc.pDataType = "RAW";
            try
            {
                string strMonth, strEXPDt, strYear, strEXP = "";

                //strEXP = Convert.ToDateTime(strexp).ToString("MMddyy");

                //strMonth = Convert.ToDateTime(strexp).ToString("MM");
                //strYear = Convert.ToDateTime(strexp).ToString("yyyy");


                strEXP = strexp.Split('/').GetValue(0).ToString() + strexp.Split('/').GetValue(1).ToString() + strexp.Split('/').GetValue(2).ToString().Substring(2, 2).ToString();
                strMonth = strexp.Split('/').GetValue(0).ToString();
                strYear = strexp.Split('/').GetValue(2).ToString();


              

                int iCurcount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);

                    try
                    {

                        if (iCurcount > 2)
                        {
                            icount = iCurcount - 2;
                            flgSkip = true;
                        }
                        else
                        {
                            icount = 0;
                        }

                        if ((iCurcount - icount) == 1)
                        {

                            arrPRNHead = Regex.Split(strFileData, "<2Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</2Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            strFileData = strFileData.Replace("{EXP}", strEXP);
                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + "/" + strYear);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode1}", "");
                            strFileData = strFileData.Replace("{VAR5}", "");
                            strFileData = strFileData.Replace("{VAR6}", "");
                            strFileData = strFileData.Replace("{VAR7}", "");
                            strFileData = strFileData.Replace("{VAR8}", "");

                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                            
                        }
                        else
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;
                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strEXP);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR7}", "(17)" + strMonth + "/" + strYear);
                            strFileData = strFileData.Replace("{VAR8}", "(21)" + dt.Rows[i + 1][0].ToString());


                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");


                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 2; i++; iCurcount -= 2;
                            


                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dt = null;
            }
            return iPrint;
        }

        public static int PrintSecFourUP(string printerName, DataTable dt, string strGTIN, string strBatch, string strMGF, string strexp, string strPRN)
        {
            Boolean flgSkip = false;
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            string[] arrPRNHead;
            string[] arrPRNTail;
            int pcWritten = 0, iPrint = 0, icount = 0, iQty = 0, iMod = 0, iRem = 0;
            Doc.pDocName = "Secondary Label";
            Doc.pDataType = "RAW";
            try
            {
                string strMonth, strEXPDt, strYear, strEXP = "";

                //strEXP = Convert.ToDateTime(strexp).ToString("MMddyy");

                //strMonth = Convert.ToDateTime(strexp).ToString("MM");
                //strYear = Convert.ToDateTime(strexp).ToString("yyyy");


                strEXP = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                strMonth = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(DataLayer.clsDb.GetGlobleDetails("TERMONTH"));
                strYear = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy");

                int iCurcount = dt.Rows.Count;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);

                    try
                    {
                        if (iCurcount > 4)
                        {
                            icount = iCurcount - 4;
                            flgSkip = true;
                        }
                        else
                        {
                            icount = 0;
                        }


                        if ((iCurcount - icount) == 1)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            arrPRNHead = Regex.Split(strFileData, "<2Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</4Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            

                            strFileData = strFileData.Replace("{barcode1}", "");
                            strFileData = strFileData.Replace("{VAR5}", "");
                            strFileData = strFileData.Replace("{VAR6}", "");
                            strFileData = strFileData.Replace("{VAR7}", "");
                            strFileData = strFileData.Replace("{VAR8}", "");

                            strFileData = strFileData.Replace("{barcode2}", "");
                            strFileData = strFileData.Replace("{VAR9}", "");
                            strFileData = strFileData.Replace("{VAR10}", "");
                            strFileData = strFileData.Replace("{VAR11}", "");
                            strFileData = strFileData.Replace("{VAR12}", "");

                            strFileData = strFileData.Replace("{barcode3}", "");
                            strFileData = strFileData.Replace("{VAR13}", "");
                            strFileData = strFileData.Replace("{VAR14}", "");
                            strFileData = strFileData.Replace("{VAR15}", "");
                            strFileData = strFileData.Replace("{VAR16}", "");

                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");
                            strFileData = strFileData.Replace("<4Across>", "");
                            strFileData = strFileData.Replace("</4Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                            iPrint++; icount += 1;
                            iCurcount -= 1;
                        }
                        else if ((iCurcount - icount) == 2)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            arrPRNHead = Regex.Split(strFileData, "<3Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</4Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR7}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR8}", "(21)" + dt.Rows[i + 1][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "");
                            strFileData = strFileData.Replace("{VAR9}", "");
                            strFileData = strFileData.Replace("{VAR10}", "");
                            strFileData = strFileData.Replace("{VAR11}", "");
                            strFileData = strFileData.Replace("{VAR12}", "");

                            strFileData = strFileData.Replace("{barcode3}", "");
                            strFileData = strFileData.Replace("{VAR13}", "");
                            strFileData = strFileData.Replace("{VAR14}", "");
                            strFileData = strFileData.Replace("{VAR15}", "");
                            strFileData = strFileData.Replace("{VAR16}", "");

                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");
                            strFileData = strFileData.Replace("<4Across>", "");
                            strFileData = strFileData.Replace("</4Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 2; icount += 2; i++;
                            iCurcount -= 2;

                        }
                        else if ((iCurcount - icount) == 3)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;
                            arrPRNHead = Regex.Split(strFileData, "<4Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</4Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR7}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR8}", "(21)" + dt.Rows[i + 1][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 2][0].ToString());
                            strFileData = strFileData.Replace("{VAR9}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR10}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR11}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR12}", "(21)" + dt.Rows[i + 2][0].ToString());

                            strFileData = strFileData.Replace("{barcode3}", "");
                            strFileData = strFileData.Replace("{VAR13}", "");
                            strFileData = strFileData.Replace("{VAR14}", "");
                            strFileData = strFileData.Replace("{VAR15}", "");
                            strFileData = strFileData.Replace("{VAR16}", "");

                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");
                            strFileData = strFileData.Replace("<4Across>", "");
                            strFileData = strFileData.Replace("</4Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 3; icount += 3; i += 2;
                            iCurcount -= 3;

                        }
                        else if ((iCurcount - icount) == 4)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR3}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR4}", "(21)" + dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR7}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR8}", "(21)" + dt.Rows[i + 1][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 2][0].ToString());
                            strFileData = strFileData.Replace("{VAR9}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR10}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR11}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR12}", "(21)" + dt.Rows[i + 2][0].ToString());

                            strFileData = strFileData.Replace("{barcode3}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 3][0].ToString());
                            strFileData = strFileData.Replace("{VAR13}", "(01)" + strGTIN);
                            strFileData = strFileData.Replace("{VAR14}", "(10)" + strBatch);
                            strFileData = strFileData.Replace("{VAR15}", "(17)" + strMonth + DataLayer.clsDb.GetGlobleDetails("TERSEP") + strYear);
                            strFileData = strFileData.Replace("{VAR16}", "(21)" + dt.Rows[i + 3][0].ToString());

                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");
                            strFileData = strFileData.Replace("<4Across>", "");
                            strFileData = strFileData.Replace("</4Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 4; icount += 4; i += 3;
                            iCurcount -= 4;
                            if (flgSkip == true)
                            {
                                icount = 4;
                                flgSkip = false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                dt = null;
            }
            return iPrint;
        }

        public static int PrintSecThreeUP(string printerName, DataTable dt, string strGTIN, string strBatch, string strMGF, string strexp, string strPRN)
        {
            Boolean flgSkip = false;
            IntPtr lhPrinter = new IntPtr();
            DOCINFO Doc = new DOCINFO();
            string strFileData = "";
            string[] arrPRNHead;
            string[] arrPRNTail;
            int pcWritten = 0, iPrint = 0, icount = 0, iQty = 0, iMod = 0, iRem = 0;
            Doc.pDocName = "Secondary Label";
            Doc.pDataType = "RAW";

           
            try
            {
                string strMonth, strEXPDt, strYear, strEXP = "";

                //strEXP = Convert.ToDateTime(strexp).ToString("MMddyy");

                strEXP = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyMMdd");
                strMonth = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(DataLayer.clsDb.GetGlobleDetails("TERMONTH"));
                strYear = DateTime.ParseExact(strexp, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy");




                int iCurcount = dt.Rows.Count;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                    PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                    PrintDirect.StartPagePrinter(lhPrinter);

                    try
                    {
                        if (iCurcount > 3)
                        {
                            icount = iCurcount - 3;
                            flgSkip = true;
                        }
                        else
                        {
                            icount = 0;
                        }


                        if ((iCurcount - icount) == 1)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            arrPRNHead = Regex.Split(strFileData, "<2Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</3Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", strBatch);
                            strFileData = strFileData.Replace("{VAR3}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR4}", dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "");
                            strFileData = strFileData.Replace("{VAR5}", "");
                            strFileData = strFileData.Replace("{VAR6}", "");
                            strFileData = strFileData.Replace("{VAR7}", "");
                            strFileData = strFileData.Replace("{VAR8}", "");

                            strFileData = strFileData.Replace("{barcode3}", "");
                            strFileData = strFileData.Replace("{VAR9}", "");
                            strFileData = strFileData.Replace("{VAR10}", "");
                            strFileData = strFileData.Replace("{VAR11}", "");
                            strFileData = strFileData.Replace("{VAR12}", "");


                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");

                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

                            iPrint++; icount += 1;
                            iCurcount -= 1;
                        }
                        else if ((iCurcount - icount) == 2)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            arrPRNHead = Regex.Split(strFileData, "<3Across>");
                            strFileData = arrPRNHead[0];
                            arrPRNTail = Regex.Split(strPRN, "</3Across>");
                            strFileData = strFileData + arrPRNTail[1];

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", strBatch);
                            strFileData = strFileData.Replace("{VAR3}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR4}", dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", strBatch);
                            strFileData = strFileData.Replace("{VAR7}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR8}", dt.Rows[i + 1][0].ToString());

                            strFileData = strFileData.Replace("{barcode3}", "");
                            strFileData = strFileData.Replace("{VAR9}", "");
                            strFileData = strFileData.Replace("{VAR10}", "");
                            strFileData = strFileData.Replace("{VAR11}", "");
                            strFileData = strFileData.Replace("{VAR12}", "");


                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");


                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 2; icount += 2; i++;
                            iCurcount -= 2;

                        }
                        else if ((iCurcount - icount) == 3)
                        {

                            //System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + strFilename);
                            strFileData = strPRN;

                            strFileData = strFileData.Replace("{EXP}", strEXP);

                            strFileData = strFileData.Replace("{barcode1}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i][0].ToString());
                            strFileData = strFileData.Replace("{VAR1}", strGTIN);
                            strFileData = strFileData.Replace("{VAR2}", strBatch);
                            strFileData = strFileData.Replace("{VAR3}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR4}", dt.Rows[i][0].ToString());

                            strFileData = strFileData.Replace("{barcode2}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 1][0].ToString());
                            strFileData = strFileData.Replace("{VAR5}", strGTIN);
                            strFileData = strFileData.Replace("{VAR6}", strBatch);
                            strFileData = strFileData.Replace("{VAR7}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR8}", dt.Rows[i + 1][0].ToString());

                            strFileData = strFileData.Replace("{barcode3}", "01" + strGTIN + "17" + strEXP + "10" + strBatch + "21" + dt.Rows[i + 2][0].ToString());
                            strFileData = strFileData.Replace("{VAR9}", strGTIN);
                            strFileData = strFileData.Replace("{VAR10}", strBatch);
                            strFileData = strFileData.Replace("{VAR11}", strMonth + "-" + strYear);
                            strFileData = strFileData.Replace("{VAR12}", dt.Rows[i + 2][0].ToString());


                            strFileData = strFileData.Replace("<2Across>", "");
                            strFileData = strFileData.Replace("</2Across>", "");
                            strFileData = strFileData.Replace("<3Across>", "");
                            strFileData = strFileData.Replace("</3Across>", "");


                            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
                            iPrint += 3; icount += 3; i += 2;
                            iCurcount -= 3;
                            if (flgSkip == true)
                            {
                                icount = 3;
                                flgSkip = false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    {
                        PrintDirect.EndPagePrinter(lhPrinter);
                        PrintDirect.EndDocPrinter(lhPrinter);
                        PrintDirect.ClosePrinter(lhPrinter);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                dt = null;
               
                
            }
            return iPrint;
        }


    }
}
