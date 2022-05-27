using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;

   public class SqlDataLayer11
    {


        #region "Variable Zone"

        public SqlTransaction sqlTran;
        public SqlConnection con;
        public string strLocal = ConfigurationManager.ConnectionStrings["dbLocal"].ConnectionString;
       // public string strStagging = clsStandards.fn_Decrypt_String(ConfigurationManager.ConnectionStrings[@"dbLocal"].ConnectionString, "0B0C0I0L");
        //public string strStagging_Scheme = clsStandards.fn_Decrypt_String(ConfigurationManager.ConnectionStrings[@"dbLocal"].ConnectionString, "0B0C0I0L");

        public bool Connect(string strConnection)
        {
            con = new SqlConnection(strConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = strConnection;
                    con.Open();
                    return true;
                }
                else if (con.State == ConnectionState.Open)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
                con = null;
            }
        }

        #endregion


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
                    cmd.CommandTimeout = 30000;
                    cmd.CommandText = Proc;
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters[result].Value.ToString() != "")
                    {
                        sqlTran.Commit();
                        return cmd.Parameters[varOut].Value.ToString();
                    }
                    else
                    { return string.Empty; }
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
                        return 1;
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

        public void ExecuteDataReader(string strConnection, string qry, DropDownList objCbo)
        {
            objCbo.Items.Clear();
            objCbo.Text = string.Empty;
            objCbo.Items.Add("Select");
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
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            objCbo.Items.Add(oReader[0].ToString());
                        }
                    }
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
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
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
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                cmd = null;
                con = null;
            }
        }

        public int ExecuteNonQuery_Param(string strConnection, string qry, SqlParameter[] obj)
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
                    cmd.Parameters.AddRange(obj);
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
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
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
                    OracleSda.SelectCommand.CommandTimeout = 6000;
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
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                OracleSda = null;
                con = null;
            }

        }

        public DataSet ExecuteDataset_Param(string strConnection, string qry, SqlParameter[] obj)
        {
            con = new SqlConnection(strConnection);
            SqlDataAdapter cmd = new SqlDataAdapter(qry, con);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    sqlTran = con.BeginTransaction();
                    DataSet ds_Dataset = new DataSet();
                    cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cmd.SelectCommand.Parameters.AddRange(obj);
                    cmd.SelectCommand.CommandTimeout = 6000;
                    cmd.Fill(ds_Dataset);
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
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                cmd = null;
                con = null;
            }
        }

        public String ExecuteScalarString_Parameter(string strConnection, string qry, SqlParameter[] param)
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
                    cmd.Parameters.AddRange(param);
                    cmd.CommandText = qry;
                    string strOutput = (string)cmd.ExecuteScalar();
                    sqlTran.Commit();
                    if (strOutput == null || strOutput == DBNull.Value.ToString())
                        return string.Empty;
                    return strOutput;
                }
                else
                {
                    throw new Exception("database connection not found");
                }
            }
            catch (Exception ex)
            {
                sqlTran.Rollback();
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                cmd = null;
                con = null;
            }
        }

        public String ExecuteScalarString(string strConnection, string qry)
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
                    string strOutput = (string)cmd.ExecuteScalar();
                    sqlTran.Commit();
                    if (strOutput == null || strOutput == DBNull.Value.ToString())
                        return string.Empty;
                    return strOutput;
                }
                else
                {
                    throw new Exception("database connection not found");
                }
            }
            catch (Exception ex)
            {
                sqlTran.Rollback();
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
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
                    int intOutput = (Int32)cmd.ExecuteScalar();
                    sqlTran.Commit();
                    return intOutput;
                }
                else
                {
                    throw new Exception("database connection not found");
                }
            }
            catch (Exception ex)
            {
                sqlTran.Rollback();
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                cmd = null;
                con = null;
            }
        }

        public int ExecuteScalar_Param(string strConnection, string qry, SqlParameter[] param)
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
                    cmd.Parameters.AddRange(param);
                    cmd.CommandText = qry;
                    int intOutput = (Int32)cmd.ExecuteScalar();
                    sqlTran.Commit();
                    return intOutput;
                }
                else
                {
                    throw new Exception("database connection not found");
                }
            }
            catch (Exception ex)
            {
                sqlTran.Rollback();
                throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                cmd = null;
                con = null;
            }
        }
    }

