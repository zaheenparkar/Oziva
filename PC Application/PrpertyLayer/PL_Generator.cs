using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PropertyLayer
{
    public class PL_Generator
    {
       private string _PACKINGLEVEL;
       private string _FIELDCRITERIA;
       private string _FIELDVALUE;
       private string _LABELTYPE;
       private string _LINENO;
       private string _GTIN;
       private string _DESC;
       private string _PACKSIZE;
       private string _BATCHNO;
       private string _MFGDATE;
       private string _EXPDATE;
       private string _QTY;
       private string _COMPANYCODE;
       


        public string strPackLevel
        {
            get { return _PACKINGLEVEL; }
            set { _PACKINGLEVEL = value; }
        }

        public string strCompany
        {
            get { return _COMPANYCODE; }
            set { _COMPANYCODE = value; }
        }

        public string strFieldCriteria
        {
            get { return _FIELDCRITERIA; }
            set { _FIELDCRITERIA = value; }
        }

        public string strFieldValue
        {
            get { return _FIELDVALUE; }
            set { _FIELDVALUE = value; }
        }

        public string strLableType
        {
            get { return _LABELTYPE; }
            set { _LABELTYPE = value; }
        }


        public string strLineNo
        {
            get { return _LINENO; }
            set { _LINENO = value; }
        }

        public string strGTIN
        {
            get { return _GTIN; }
            set { _GTIN = value; }
        }

        public string strDesc
        {
            get { return _DESC; }
            set { _DESC = value; }
        }

        public string strPackSize
        {
            get { return _PACKSIZE; }
            set { _PACKSIZE = value; }
        }

        public string strBatch
        {
            get { return _BATCHNO; }
            set { _BATCHNO = value; }
        }

        public string strMfg
        {
            get { return _MFGDATE; }
            set { _MFGDATE = value; }
        }

        public string strExp
        {
            get { return _EXPDATE; }
            set { _EXPDATE = value; }
        }

        public string strQty
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
    }
}
