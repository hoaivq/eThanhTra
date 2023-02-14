using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Common.Class
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
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        
    }
}
