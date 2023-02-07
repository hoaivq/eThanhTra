using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static T ToObject<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
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

            if(exception.InnerExceptions.Count == 0)
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
    }
}
