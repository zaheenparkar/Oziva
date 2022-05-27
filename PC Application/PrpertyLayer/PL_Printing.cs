using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
    public class PL_Printing
    {
        private string _PLANTCODE;
        private string _GTINCODE;
        private string _PRINTERPK;
        private string _PACKLEVEL;
        private string _LINENO;
        private string _LABELTYPE;
        private string _LABELSIZE;
        private string _PRNTMETHOD;
        private string _PRINTER;
        private string _PRODNAME;
        private string _BATCHNO;
        private string _NOOFLBL;
        private int _iREFNO;
        private string _strREFNO;
        private int _iLABELCOUNT;
        private int _iPRINTQTY;

        public int iLabelCount
        {
            get { return _iLABELCOUNT; }
            set { _iLABELCOUNT = value; }
        }

        public int iPrintQty
        {
            get { return _iPRINTQTY; }
            set { _iPRINTQTY = value; }
        }

        public int iRefNo
        {
            get { return _iREFNO; }
            set { _iREFNO = value; }
        }


        public string strRefNo
        {
            get { return _strREFNO; }
            set { _strREFNO = value; }
        }

        public string strPlantCode
        {
            get { return _PLANTCODE; }
            set { _PLANTCODE = value; }
        }

        public string strGTINCode
        {
            get { return _GTINCODE; }
            set { _GTINCODE = value; }
        }

        public string strPrinterPk
        {
            get { return _PRINTERPK; }
            set { _PRINTERPK = value; }
        }

        public string strPackLevel
        {
            get { return _PACKLEVEL; }
            set { _PACKLEVEL = value; }
        }

        public string strLineNo
        {
            get { return _LINENO; }
            set { _LINENO = value; }
        }

        public string strLabelType
        {
            get { return _LABELTYPE; }
            set { _LABELTYPE = value; }
        }

        public string strLabelSize
        {
            get { return _LABELSIZE; }
            set { _LABELSIZE = value; }
        }

        public string strPrintMethod
        {
            get { return _PRNTMETHOD; }
            set { _PRNTMETHOD = value; }
        }

        public string strPrinter
        {
            get { return _PRINTER; }
            set { _PRINTER = value; }
        }

        public string strProdName
        {
            get { return _PRODNAME; }
            set { _PRODNAME = value; }
        }

        public string strBatchNo
        {
            get { return _BATCHNO; }
            set { _BATCHNO = value; }
        }

        public string strNoOfLbl
        {
            get { return _NOOFLBL; }
            set { _NOOFLBL = value; }
        }

    }
}
