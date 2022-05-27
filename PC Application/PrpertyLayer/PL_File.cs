using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyLayer
{
    public class PL_File
    {
        #region "Globle Variables"

        public static string strUsername;
        public static string strSiteName;
        public static string TerSep;
        public static string TerMonth;
        public static string servicePath;
        public static string strCurrentDevice;
        public static string strStoreId = "";
        public static string strPickList = "";
        public static string strItem = "";

        #endregion

        #region "File Path Declaration"

        public static string strDirectory = Application.StartupPath;

        
        #endregion
    }
}
