using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class AppDao
    {
        public DataTable GetTable(string TSQL, SqlParameter[] myParamArr = null, SqlConnection myConn = null)
        {
            try
            {
                if (myConn == null)
                {
                    using (SqlConnection conn = new SqlConnection(MyApp.Setting.DBConnStr))
                    {
                        return GetTable(TSQL, myParamArr, conn);
                    }
                }

                if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                using (SqlDataAdapter da = new SqlDataAdapter(TSQL, myConn))
                {
                    using (DataTable dt = new DataTable("DataTable"))
                    {
                        if (myParamArr != null && myParamArr.Length > 0)
                        {
                            da.SelectCommand.Parameters.AddRange(myParamArr);
                        }
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.SelectCommand.CommandTimeout = MyApp.Setting.TimeOut;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetTable", ex, TSQL, myParamArr);
                throw ex;
            }
            finally
            {
                if (myConn != null) { myConn.Close(); }
            }
        }
        public DataTable GetTable(string TSQL, params SqlParameter[] myParamArr)
        {
            try
            {

                using (SqlConnection myConn = new SqlConnection(MyApp.Setting.DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlDataAdapter da = new SqlDataAdapter(TSQL, myConn))
                    {
                        using (DataTable dt = new DataTable("DataTable"))
                        {
                            if (myParamArr != null && myParamArr.Length > 0)
                            {
                                da.SelectCommand.Parameters.AddRange(myParamArr);
                            }
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = MyApp.Setting.TimeOut;
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetTable", ex, TSQL, myParamArr);
                throw ex;
            }
        }
        public DataTable GetTable(string TSQL, string DBConnStr, SqlParameter[] myParamArr = null)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlDataAdapter da = new SqlDataAdapter(TSQL, myConn))
                    {
                        using (DataTable dt = new DataTable("DataTable"))
                        {
                            if (myParamArr != null && myParamArr.Length > 0)
                            {
                                da.SelectCommand.Parameters.AddRange(myParamArr);
                            }
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = MyApp.Setting.TimeOut;
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetTable", ex, TSQL, myParamArr);
                throw ex;
            }
        }

        public async Task<DataTable> GetTableSPAsync(string SPName, params SqlParameter[] myParamArr)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(MyApp.Setting.DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlCommand cmd = new SqlCommand(SPName, myConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = MyApp.Setting.TimeOut;
                        if (myParamArr != null && myParamArr.Length > 0)
                        {
                            cmd.Parameters.AddRange(myParamArr);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable(SPName);
                            da.Fill(dt);
                            return await Task.FromResult(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetSPAsync", ex, SPName, myParamArr);
                throw ex;
            }
        }

        public async Task<DataSet> GetDataSetSPAsync(string SPName, params SqlParameter[] myParamArr)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(MyApp.Setting.DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlCommand cmd = new SqlCommand(SPName, myConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = MyApp.Setting.TimeOut;
                        if (myParamArr != null && myParamArr.Length > 0)
                        {
                            cmd.Parameters.AddRange(myParamArr);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet(SPName))
                            {
                                da.Fill(ds);
                                return await Task.FromResult(ds);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetDataSetSPAsync", ex, SPName, myParamArr);
                throw ex;
            }
        }

        public async Task<DataTable> GetTableAsync(string TSQL, params SqlParameter[] myParamArr)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(MyApp.Setting.DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlDataAdapter da = new SqlDataAdapter(TSQL, myConn))
                    {
                        using (DataTable dt = new DataTable("DataTable"))
                        {
                            if (myParamArr != null && myParamArr.Length > 0)
                            {
                                da.SelectCommand.Parameters.AddRange(myParamArr);
                            }
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = MyApp.Setting.TimeOut;
                            da.Fill(dt);
                            return await Task.FromResult(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetTable", ex, TSQL, myParamArr);
                throw ex;
            }
        }
        public async Task<DataTable> GetTableAsync(string TSQL, SqlParameter[] myParamArr = null, SqlConnection myConn = null)
        {
            try
            {
                if (myConn == null)
                {
                    using (SqlConnection conn = new SqlConnection(MyApp.Setting.DBConnStr))
                    {
                        return await GetTableAsync(TSQL, myParamArr, conn);
                    }
                }

                if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                using (SqlDataAdapter da = new SqlDataAdapter(TSQL, myConn))
                {
                    using (DataTable dt = new DataTable("DataTable"))
                    {
                        if (myParamArr != null && myParamArr.Length > 0)
                        {
                            da.SelectCommand.Parameters.AddRange(myParamArr);
                        }
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.SelectCommand.CommandTimeout = MyApp.Setting.TimeOut;
                        da.Fill(dt);
                        return await Task.FromResult(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("GetTableAsync", ex, TSQL, myParamArr);
                throw ex;
            }
            finally
            {
                if (myConn != null) { myConn.Close(); }
            }
        }

        public int ExecSQL(string TSQL, SqlParameter[] myParamArr = null, SqlConnection myConn = null, SqlTransaction myTrans = null)
        {
            try
            {
                if (myConn == null)
                {
                    using (SqlConnection conn = new SqlConnection(MyApp.Setting.DBConnStr))
                    {
                        return ExecSQL(TSQL, myParamArr, conn, myTrans);
                    }
                }

                if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                using (SqlCommand cmd = new SqlCommand(TSQL, myConn))
                {
                    if (myParamArr != null && myParamArr.Length > 0)
                    {
                        cmd.Parameters.AddRange(myParamArr);
                    }
                    cmd.Transaction = myTrans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = MyApp.Setting.TimeOut;
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("ExecSQL", ex, TSQL, myParamArr);
                throw ex;
            }
            finally
            {
                if (myConn != null)
                {
                    if (myTrans == null)
                    {
                        myConn.Close();
                    }
                }
            }
        }

        

        public int ExecSQL(string TSQL, string DBConnStr, SqlParameter[] myParamArr = null)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(DBConnStr))
                {
                    if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                    using (SqlCommand cmd = new SqlCommand(TSQL, myConn))
                    {
                        if (myParamArr != null && myParamArr.Length > 0)
                        {
                            cmd.Parameters.AddRange(myParamArr);
                        }
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = MyApp.Setting.TimeOut;
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("ExecSQL", ex, TSQL, myParamArr);
                throw ex;
            }
        }

        public async Task<int> ExecSQLAsync(string TSQL, SqlParameter[] myParamArr = null, SqlConnection myConn = null, SqlTransaction myTrans = null)
        {
            return await Task.FromResult(ExecSQL(TSQL, myParamArr, myConn, myTrans));
        }

        public async Task<int> ExecSQLAsync(string TSQL, string DBConnStr, SqlParameter[] myParamArr = null)
        {
            return await Task.FromResult(ExecSQL(TSQL, DBConnStr, myParamArr));
        }

        public int ExecSQLGetId(string TSQL, SqlParameter[] myParamArr = null, SqlConnection myConn = null)
        {
            try
            {
                if (myConn == null)
                {
                    using (SqlConnection conn = new SqlConnection(MyApp.Setting.DBConnStr))
                    {
                        return ExecSQLGetId(TSQL, myParamArr, conn);
                    }
                }

                if (myConn.State != ConnectionState.Open) { myConn.Open(); }

                TSQL = TSQL + " SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(TSQL, myConn))
                {
                    if (myParamArr != null && myParamArr.Length > 0)
                    {
                        cmd.Parameters.AddRange(myParamArr);
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = MyApp.Setting.TimeOut;
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("ExecSQLGetId", ex, TSQL, myParamArr);
                throw ex;
            }
            finally
            {
                if (myConn != null) { myConn.Close(); }
            }
        }
        public int ExecSQLGetId(string TSQL, string DBConnStr, SqlParameter[] myParamArr = null)
        {
            try
            {

                using (SqlConnection myConn = new SqlConnection(DBConnStr))
                {
                    return ExecSQLGetId(TSQL, myParamArr, myConn);
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("ExecSQLGetId", ex, TSQL, myParamArr);
                throw ex;
            }
        }


    }
}
