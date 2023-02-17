﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public static int ToInt(this object obj)
        {
            if (obj == null) { return 0; }
            try
            {
                return int.Parse(obj.ToString());
            }
            catch { return 0; }
        }

        public static long ToLong(this object obj)
        {
            if (obj == null) { return 0; }
            try
            {
                return long.Parse(obj.ToString());
            }
            catch { return 0; }
        }

        public static T ToObject<T>(this string inputStr)
        {
            return JsonConvert.DeserializeObject<T>(inputStr);
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
                        if (dr[column.ColumnName] == DBNull.Value)
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
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

        public static bool HasValue(this long Value)
        {
            if (Value == 0 || Value == -1) { return false; }
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
            if(type == typeof(string))
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
            if(dateTime.HasValue == false) { return DBNull.Value; }
            return dateTime.Value.ToString("yyyyMMdd");
        }
    }
}
