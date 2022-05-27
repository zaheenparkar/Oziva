using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
    public class PL_Login
    {
        private string _USERID;
        private string _PASSWORD;
        private string _NEWPASSWORD;
        private string _PLANTCODE;
        public static string UserID = "";
        public static string PlantCode = "";
        public static string URights = "";
        public static string UType = "";
        public static int iExpiry = 0;

        public string strUserID
        {
            get
            {
                return _USERID;
            }
            set
            {
                _USERID = value;
            }
        }

        public string strPass
        {
            get
            {
                return _PASSWORD;
            }
            set
            {
                _PASSWORD = value;
            }
        }

        public string strNewPass
        {
            get
            {
                return _NEWPASSWORD;
            }
            set
            {
                _NEWPASSWORD = value;
            }
        }


        public string strPlantCode
        {
            get
            {
                return _PLANTCODE;
            }
            set
            {
                _PLANTCODE = value;
            }
        }

    }
}
