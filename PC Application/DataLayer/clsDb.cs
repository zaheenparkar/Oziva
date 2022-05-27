using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using PropertyLayer;

namespace DataLayer
{
    public class clsDb
    {
        //SqlConnection m_Con;
        //SqlCommand com;
        // SqlTransaction sqlDBTrans;
        public SqlConnection m_Con;
        SqlCommand com;
        SqlTransaction sqlBDTrans;

        public static string GstrSqlOrgID;
        public static string GstrPlantID;
        public static string GstrWebService;
        public static string GstrDatabaseName;
        public static string GstrDBUsername;
        public static string GstrDBPassword;
        //public static string GstrDBServer;


        public static string dbPath = "\\Application\\APODIS\\";

        public static string Foldername = "SCANDATA";
        public static string Filename = "BARCODEDATA.txt";

        private bool m_IsConnected;
        public bool IsConnected
        {
            get { return m_IsConnected; }
            set { m_IsConnected = value; }

        }

        public clsDb()
        {
            m_Con = new SqlConnection();
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
                    if (strArr[0].Trim().ToUpper() == "SERVERNAME")
                        GstrSqlOrgID = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "PLANT")
                        GstrPlantID  = strArr[1].Trim();
                    if (strArr[0].Trim().ToUpper() == "WEBSERVICE")
                        GstrWebService = strArr[1].Trim();
                }
                while (strLine != null);
                ReadServer.Close();
                ReadServer = null;
                ServerFile = null;
                return true;
            }
            return false;
        }

        public static string GetGlobleDetails(string returnField)
        {
            if (File.Exists(PL_File.strDirectory.Trim() + "\\SysConfig.xml") == false)
            {
                throw new Exception("Configuration File Not Found.");
            }

            DataSet ds = new DataSet();
            ds.ReadXml(PL_File.strDirectory.Trim() + "\\SysConfig.xml");
            if (ds.Tables["TBLCONFIG"].Rows.Count != 0)
            {
                return ds.Tables["TBLCONFIG"].Rows[0][returnField].ToString().Trim();
            }
            else
            {
                throw new Exception("Configuration File Not Found.");
            }
        }

        public static void writeLog(String Description, String procName, String Val)
        {
            try
            {
                String strNewDate, strDate, strFolder;
                strFolder = Application.StartupPath + "\\LogFolder"; //System.DateTime.Now.Date.ToShortDateString();

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
                //logWriter.Write(versionName + " ");
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
                //m_Con.ConnectionString = "Data Source=" + GstrSqlOrgID + ";Initial catalog=" + GstrDatabaseName + ";uid=" + GstrDBUsername + ";pwd=" + GstrDBPassword;
                m_Con.ConnectionString = "server=" + GstrSqlOrgID + "; userid=" + GstrDBUsername + ";password=" + GstrDBPassword + ";pooling=yes;Database=" + GstrDatabaseName;

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
            //sqlTrans = new MySqlTransaction();
            try
            {
                sqlBDTrans = m_Con.BeginTransaction(IsolationLevel.ReadCommitted);
                com.Transaction = sqlBDTrans;
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
                sqlBDTrans.Commit();
                sqlBDTrans.Dispose();
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
                sqlBDTrans.Rollback();
                sqlBDTrans.Dispose();
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

        public string ExecuteProcedureParam(string Proc, SqlParameter[] param, string varOut, string result)
        {

            SqlCommand cmd = new SqlCommand();

            try
            {

                if (m_Con.State == ConnectionState.Closed)
                    connect();

                sqlBDTrans = m_Con.BeginTransaction();
                cmd.Connection = m_Con;
                cmd.Transaction = sqlBDTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = Proc;
                string str = Convert.ToString(cmd.ExecuteScalar());
                if (cmd.Parameters[result].Value.ToString() != "")
                {
                    sqlBDTrans.Commit();
                    return cmd.Parameters[varOut].Value.ToString();
                }
                else
                { return string.Empty; }

                if (m_Con.State == ConnectionState.Open)
                    Disconnect();



            }
            catch (Exception ex)
            {
                sqlBDTrans.Rollback();
                throw ex;
            }
            finally
            {
                if (m_Con.State == ConnectionState.Open) { m_Con.Close(); }
                cmd = null;
            }
        }

        //public DataSet getRights(string userid)
        //{
        //    clsDb db = new clsDb();
        //    string strQuery;
        //    DataSet ds = new DataSet();
        //    try
        //    {

        //        strQuery = "select menuid from tblmenu where id in (" + db.ExecuteScalarString("select LRole from login where LName='" + userid + "'") + "0)";
        //        ds = db.GetDataset(strQuery);

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //    finally
        //    {
        //        strQuery = "";
        //        db = null;
        //        ds = null;
        //    }
        //}


    }
}
