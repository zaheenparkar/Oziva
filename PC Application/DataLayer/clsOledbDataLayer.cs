using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace DataLayer
{
    public class clsOledbDataLayer
    {
        public OleDbConnection ole_Con;
        OleDbCommand Olecom;
        OleDbTransaction OledBDTrans;

        public clsOledbDataLayer()
        {
            ole_Con = new OleDbConnection();
        }

        private bool m_IsConnected;
        public bool IsConnected
        {
            get { return m_IsConnected; }
            set { m_IsConnected = value; }

        }

        private string GetConnectionString()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Application.StartupPath + "\\db_tracknTrace.mdb";
        }

        public DataSet GetDataset(string strQuery)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da;
            try
            {
                if (ole_Con.State == ConnectionState.Closed)
                    connect();

                ds = new DataSet();
                da = new OleDbDataAdapter(strQuery, ole_Con);
                da.Fill(ds);
                da.Dispose();

                if (ole_Con.State == ConnectionState.Open)
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
                if (ole_Con.State == ConnectionState.Closed)
                    connect();

                Olecom.CommandText = StrSql;
                result = Olecom.ExecuteNonQuery();

                if (ole_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void connect()
        {
            try
            {
                //m_Con.ConnectionString = "Data Source=" + GstrSqlOrgID + ";Initial catalog=" + GstrDatabaseName + ";uid=" + GstrDBUsername + ";pwd=" + GstrDBPassword;
                ole_Con.ConnectionString = GetConnectionString();

                ole_Con.Open();
                Olecom = new OleDbCommand();
                Olecom = ole_Con.CreateCommand();
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

                if (ole_Con != null && ole_Con.State == ConnectionState.Open)
                {
                    Olecom.Dispose();
                    ole_Con.Close();
                    m_IsConnected = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BeginTrans()
        {
            //sqlTrans = new MySqlTransaction();
            try
            {
                OledBDTrans = ole_Con.BeginTransaction(IsolationLevel.ReadCommitted);
                Olecom.Transaction = OledBDTrans;
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
                OledBDTrans.Commit();
                OledBDTrans.Dispose();
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
                OledBDTrans.Rollback();
                OledBDTrans.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDatatable(string strSql)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da;
            try
            {

                if (ole_Con.State == ConnectionState.Closed)
                    connect();

                dt = new DataTable("temp");
                da = new OleDbDataAdapter(strSql, ole_Con);
                da.Fill(dt);
                da.Dispose();

                if (ole_Con.State == ConnectionState.Open)
                    Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }


}
