using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Windows.Forms;


namespace PC_Application
{
    public class clsDb
    {
        SqlConnection m_Con;
        SqlConnection sqlCon;
        SqlCommand com;
        SqlTransaction sqlDBTrans;

        public static string GstrSqlOrgID;
        public static string GstrDatabaseName;
        public static string GstrDBUsername;
        public static string GstrDBPassword;

        private bool m_IsConnected;
        public bool IsConnected
        {
            get { return m_IsConnected; }
            set { m_IsConnected = value; }

        }

        public clsDb()
        {
            m_Con = new SqlConnection();
            sqlCon = new SqlConnection(); 
        }

        public static Boolean ReadSetting()
        {
            FileInfo ServerFile = new FileInfo(Application.StartupPath + "\\Setting.SYS");
            string strLine = "";

            if (ServerFile.Exists == true)
            {
                string[] strArr;
                StreamReader ReadServer = new StreamReader(Application.StartupPath + "\\Setting.SYS");
                do
                {
                    strLine = ReadServer.ReadLine();
                    if (strLine.Trim().ToUpper() == "</LOCAL_SETTING>")
                        break;
                    strArr = strLine.Split('~');

                    if (strArr[0].Trim().ToUpper() == "DATABASENAME")
                        GstrDatabaseName = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "USERNAME")
                        GstrDBUsername = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "PASSWORD")
                        GstrDBPassword = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "SERVERNAME")
                        GstrSqlOrgID = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "PLANT")
                        clsGlobal.gstrPlantID = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "WEBSERVICE")
                        clsGlobal.gstWebService = strArr[1].Trim();
                }
                while (strLine != null);
                ReadServer.Close();
                ReadServer = null;
                ServerFile = null;
                return true;
            }
            return false;
        }

        public void InsertErrorLog(string strForm, string strMethod, string strType, string strDetails, string strProgram, string strUser)
        {
            //SqlConnection cnn = clsSettings.cnnCap;
            //SqlTransaction trxn = null;
            int iResult = 0;
            string strSql = "";
            try
            {

                strSql = "Insert into tblLog(Form,Method,Type,Details,CR_Date,CR_User,Program) values ('" + strForm + "','" + strMethod + "','" + strType + "','" + strDetails + "',Getdate(),'" + strUser + "','" + strProgram + "'";
                iResult = ExecuteQuery(strSql);
               
            }
            catch (Exception ex)
            {
                //if (trxn != null) trxn.Rollback();
                //cnn.Close();
            }

        }

        public static void writeLog(String Description, String procName, String Val)
        {
            try
            {
                String strNewDate, strDate, strFolder;
                strFolder = Application.StartupPath + "\\LogFolder";

                DirectoryInfo LogFolder = new DirectoryInfo(strFolder);
                if (LogFolder.Exists == false)
                {
                    LogFolder.Create();
                }
                strDate = strFolder + "\\" + System.DateTime.Now.Date.ToShortDateString();
                strNewDate = strDate.Replace("/", "_");
                StreamWriter logWriter;
                logWriter = File.AppendText(strNewDate + ".ini");
                logWriter.WriteLine();
                logWriter.Write(" " + System.DateTime.Now.ToShortTimeString() + " ");
                logWriter.Write(" " + Description + " ");
                logWriter.Write(" " + procName + " ");
                logWriter.Write(" " + Val + " ");
                logWriter.Dispose();
                logWriter.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void connect()
        {
            try
            {
                ReadSetting();
                m_Con.ConnectionString = "Data Source=" + GstrSqlOrgID + ";Initial catalog=" + GstrDatabaseName + ";uid=" + GstrDBUsername + ";pwd=" + GstrDBPassword;
                sqlCon.ConnectionString = "Data Source=" + GstrSqlOrgID + ";Initial Catalog=" + GstrDatabaseName + ";User ID=" + GstrDBUsername + ";Password=" + GstrDBPassword + ";";
                //BcilLib.SqlHelper.conStringbcil = "Data Source=" + GstrSqlOrgID + ";Initial Catalog =" + GstrDatabaseName + ";User ID=" + GstrDBUsername + ";Password = " + GstrDBPassword;

                
                m_Con.Open();
               
                com = new SqlCommand();
                com = m_Con.CreateCommand();
                m_IsConnected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {

                if (m_Con != null && m_Con.State == ConnectionState.Open)
                {
                    com.Dispose();
                    m_Con.Close();
                    m_IsConnected = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDataset(string strQuery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                if (m_Con.State == ConnectionState.Closed)
                    connect();

                ds = new DataSet();
                da = new SqlDataAdapter(strQuery, m_Con);
                da.Fill(ds);
                da.Dispose();

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int ExecuteQuery(string StrSql)
        {

            int result = 0;
            try
            {
                if (m_Con.State == ConnectionState.Closed)
                    connect();

                com.CommandText = StrSql;
                result = com.ExecuteNonQuery();

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void BeginTrans()
        {
            //sqlTrans = new SqlTransaction();
            try
            {
                sqlDBTrans = m_Con.BeginTransaction(IsolationLevel.ReadCommitted);
                com.Transaction = sqlDBTrans;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void CommitTrans()
        {
            try
            {
                sqlDBTrans.Commit();
                sqlDBTrans.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RollBack()
        {
            try
            {
                sqlDBTrans.Rollback();
                sqlDBTrans.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDatatable(string strSql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {

                if (m_Con.State == ConnectionState.Closed)
                    connect();

                dt = new DataTable();
                da = new SqlDataAdapter(strSql, m_Con);
                da.Fill(dt);
                da.Dispose();

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string ExecuteScalarString(string strSql)
        {
            DataTable dt = new DataTable();
            string strOutput = "";
            SqlDataAdapter da;
            try
            {

                if (m_Con.State == ConnectionState.Closed)
                    connect();

                dt = new DataTable();
                da = new SqlDataAdapter(strSql, m_Con);
                da.Fill(dt);
                da.Dispose();

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();

                if (dt.Rows.Count > 0)
                    strOutput = dt.Rows[0][0].ToString();
                else
                    strOutput = "";


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strOutput;
        }

        public DataSet GetDataSet(string strSql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {

                if (m_Con.State == ConnectionState.Closed)
                    connect();

                ds = new DataSet();
                da = new SqlDataAdapter(strSql, m_Con);
                da.Fill(ds);
                da.Dispose();

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static void Msgbox(string Message, MessageBoxIcon msgIcon)
        {
            MessageBox.Show(Message, "RAPTAKOS", MessageBoxButtons.OK, msgIcon);
        }

       

    }
}
