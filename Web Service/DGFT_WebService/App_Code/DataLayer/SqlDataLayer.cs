using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Net;
using System.Security.Cryptography;
using System.IO;

public class SqlDataLayer
{


    #region "Variable Zone"

    public SqlTransaction sqlTran;
    public SqlConnection con;
    public string strSqlConn = fn_Decrypt_String(ConfigurationManager.ConnectionStrings["dbLocal"].ConnectionString, "0B0C0I0L");

    #endregion
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
    public static string fn_Decrypt_String(string stringToDecrypt, string sEncryptionKey)
    {
        byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
             des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
    public static Boolean checkConnectivity()
    {
        try
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["Central_Service.Service"].ToString());
            myRequest.Timeout = 1000;
            var response = (HttpWebResponse)myRequest.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK) { response.Close(); return true; } else { return false; }
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    public bool Connect(string strConnection)
    {
        con = new SqlConnection(strConnection);
        SqlTransaction trans;
        try
        {
           
            //trans = con.BeginTransaction();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = strConnection;
                con.Open();
                //trans.Commit();
                return true;
            }
            else if (con.State == ConnectionState.Open)
            {
                //trans.Commit();
                return true;
            }
            return false;

        }
        catch (Exception ex)
        {
            //trans.Rollback();
            throw new Exception(ex.ToString());
        }
        finally
        {
            con.Close();
            con = null;
        }
    }

    public string ExecuteProcedureParam(string strConnection, string Proc, SqlParameter[] param, string varOut, string result)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = Proc;
                string str = Convert.ToString(cmd.ExecuteScalar());
                sqlTran.Commit();
                if (cmd.Parameters[result].Value.ToString() != "") { return cmd.Parameters[varOut].Value.ToString(); }
                else { return string.Empty; }
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public void ExecuteProcedureParam(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = Proc;
                cmd.ExecuteScalar();
                sqlTran.Commit();
               
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataTable ExecuteProcedureParamTable(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(Proc, con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds.Tables[0];
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteNonQuery(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                int i = (int)cmd.ExecuteNonQuery();
                sqlTran.Commit();
                return i;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteNonQuery_Proc(string strConnection, string Proc, DataTable dtWrong, DataTable tbLog)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            sqlTran = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = sqlTran;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@WSCAN", dtWrong));
            cmd.Parameters.Add(new SqlParameter("@LOG", tbLog));
            cmd.CommandText = Proc;
            int i = cmd.ExecuteNonQuery();
            sqlTran.Commit();
            return i;
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString());
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }


    public int ExecuteScalar(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                sqlTran.Commit();
                return i;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public double ExecuteScalar_Double(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                double i = Convert.ToDouble(cmd.ExecuteScalar());
                sqlTran.Commit();
                return i;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataSet ExecuteDataset(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter OracleSda = new SqlDataAdapter(qry, con);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                DataSet ds_Dataset = new DataSet();
                OracleSda.SelectCommand.Transaction = sqlTran;
                OracleSda.Fill(ds_Dataset);
                sqlTran.Commit();
                return ds_Dataset;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            OracleSda = null;
            con = null;
        }

    }

    public int ExecuteQueryParam(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = Proc;
                int _Result = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (_Result != 0)
                {
                    sqlTran.Commit();
                    return _Result;
                }
                else
                { return 0; }
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

  
    public DataTable ExecuteProcedure_Table(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds.Tables[0];
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }

    public DataSet ExecuteProcedure_DataSet(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }

    public string ExecuteProcedure_String(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }

    public string ExecuteProc_String(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }

            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }

    public string Execute_String(string strConnection, string strQuery)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }

            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }

}

