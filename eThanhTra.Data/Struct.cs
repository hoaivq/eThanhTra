using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Data
{
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

    public class BaseDto : INotifyPropertyChanged
    {
        public void UpdateChange()
        {
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                OnPropertyChanged(pi.Name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
