using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AppExtensions
    {
        public static int? ToInt(this object obj)
        {
            if (obj == null) { return null; }
            try
            {
                return int.Parse(obj.ToString());
            }
            catch { return null; }
        }

        public static long? ToLong(this object obj)
        {
            if (obj == null) { return null; }
            try
            {
                return long.Parse(obj.ToString());
            }
            catch { return null; }
        }

        public static DateTime? ToDateTime(this object obj)
        {
            if (obj == null) { return null; }
            try
            {
                return DateTime.Parse(obj.ToString());
            }
            catch { return null; }
        }

        public static T ToObject<T>(this string inputStr)
        {
            return JsonConvert.DeserializeObject<T>(inputStr);
        }

        public static ObservableCollection<T> ToListObject<T>(this DataTable dt)
        {
            ObservableCollection<T> lstObject = new ObservableCollection<T>();

            foreach (DataRow dr in dt.Rows)
            {
                lstObject.Add(ToObject<T>(dr));
            }
            return lstObject;
        }

        public static T ToObject<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        try
                        {
                            if (dr[column.ColumnName] == DBNull.Value)
                            {
                                pro.SetValue(obj, null, null);
                            }
                            else
                            {
                                if (pro.PropertyType == typeof(int) || pro.PropertyType == typeof(int?))
                                {
                                    pro.SetValue(obj, dr[column.ColumnName].ToInt(), null);
                                }
                                else if (pro.PropertyType == typeof(long) || pro.PropertyType == typeof(long?))
                                {
                                    pro.SetValue(obj, dr[column.ColumnName].ToLong(), null);
                                }
                                else if (pro.PropertyType == typeof(DateTime) || pro.PropertyType == typeof(DateTime?))
                                {
                                    pro.SetValue(obj, dr[column.ColumnName].ToDateTime(), null);
                                }
                                else
                                {
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(pro.Name + ": " + ex.Message);
                        }
                    }
                }
            }
            return obj;
        }

        public static string GetHeader(this HttpRequestMessage httpRequestMessage, string headerName)
        {
            try
            {
                return httpRequestMessage.Headers.GetValues(headerName).First();
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
        public static List<Exception> GetExceptions(this AggregateException exception, ref string ErrMsg)
        {
            List<Exception> lstException = new List<Exception>();
            if (exception.InnerExceptions == null)
            {
                ErrMsg = exception.Message;
                lstException.Add(new Exception(exception.Message));
                return lstException;
            }

            if (exception.InnerExceptions.Count == 0)
            {
                ErrMsg = exception.Message;
                lstException.Add(new Exception(exception.Message));
                return lstException;
            }

            StringBuilder sbMsg = new StringBuilder();
            foreach (Exception errEx in exception.InnerExceptions)
            {
                sbMsg.AppendLine(errEx.Message);
                lstException.Add(errEx);
            }
            ErrMsg = sbMsg.ToString();
            return lstException;
        }

        public static bool HasValue(this long? val)
        {
            if(val.HasValue == false) { return false; }
            if (val.Value == 0 || val.Value == -1) { return false; }
            return true;
        }

        public static SqlParameter[] GetSqlParameter(this CallSPDto callSPDto)
        {
            if (callSPDto.Params == null)
            {
                return null;
            }

            if (callSPDto.Params.Length == 0)
            {
                return null;
            }

            List<SqlParameter> lstParam = new List<SqlParameter>();
            foreach (SqlParam item in callSPDto.Params)
            {
                try
                {
                    SqlParameter p = new SqlParameter(item.Name, item.Value);
                    if (item.Type.HasValue)
                    {
                        p.SqlDbType = item.Type.Value;
                    }

                    if (item.Size.HasValue)
                    {
                        p.Size = item.Size.Value;
                    }
                    lstParam.Add(p);
                }
                catch (Exception ex)
                {
                    MyApp.Log.GhiLog("GetSqlParameter", ex, item.Name);
                    throw ex;
                }
            }
            return lstParam.ToArray();
        }


        public static string GenClass(this DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace eThanhTra.Dto");
            sb.AppendLine("{");
            sb.AppendLine("    using System;");
            sb.AppendLine("    using System.Collections.Generic;");
            sb.AppendLine("");
            sb.AppendLine("    public partial class " + dt.TableName + " : BaseDto");
            sb.AppendLine("    {");

            foreach (DataColumn col in dt.Columns)
            {
                sb.AppendLine("        private " + col.DataType.GetColType() + " _" + col.ColumnName + ";");
                sb.AppendLine("        public " + col.DataType.GetColType() + " " + col.ColumnName + " { get { return _" + col.ColumnName + "; } set { _" + col.ColumnName + " = value; OnPropertyChanged(); } }");
                sb.AppendLine();
            }

            //sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public static string GetColType(this Type type)
        {
            if (type == typeof(string))
            {
                return "string";
            }
            else if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(DateTime))
            {
                return "DateTime";
            }
            else if (type == typeof(bool))
            {
                return "bool";
            }
            else
            {
                return type.Name;
            }
        }


        public static object ToDateStrSQL(this DateTime? dateTime)
        {
            if (dateTime.HasValue == false) { return DBNull.Value; }
            return dateTime.Value.ToString("yyyyMMdd");
        }

        public static TDes GetDataFrom<TDes, TSource>(this TDes Destination, TSource Source)
        {
            foreach (PropertyInfo p in Source.GetType().GetProperties())
            {
                Destination.GetType().GetProperty(p.Name)?.SetValue(Destination, p.GetValue(Source));
            }
            return Destination;
        }

        public static T Cast<T>(this object Source) where T : new()
        {
            T Destination = new T();
            foreach (PropertyInfo p in Source.GetType().GetProperties())
            {
                Destination.GetType().GetProperty(p.Name)?.SetValue(Destination, p.GetValue(Source));
            }
            return Destination;
        }
    }
}
