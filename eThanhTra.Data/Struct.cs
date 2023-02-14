using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Data
{
    public class DanhMucChung
    {
        public List<PGetCQTByMaCQT_Result> ListCQT { get; set; }
        public List<PGetUserByMaCQT_Result> ListUser { get; set; }
    }

    public static class Extensions
    {
        public static async Task<List<T>> SpQueryAsync<T>(this Database database, string SPName, params SqlParameter[] parameters)
        {
            StringBuilder sbParam = new StringBuilder();
            if (parameters != null && parameters.Length > 0)
            {
                foreach (SqlParameter p in parameters)
                {
                    sbParam.Append(" @" + p.ParameterName);
                }
            }
            return await database.SqlQuery<T>(SPName + sbParam.ToString(), parameters).ToListAsync();
        }
    }

    public class ExtProp
    {
        public bool IsChecked { get; set; }
    }
}
