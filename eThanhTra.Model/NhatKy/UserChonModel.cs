using Common.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class UserChonModel : BaseModel
    {
        private long _IdThanhTra;
        public long IdThanhTra
        {
            get { return _IdThanhTra; }
            set { _IdThanhTra = value; OnPropertyChanged(); }
        }

        private DataTable _ListUser;
        public DataTable ListUser
        {
            get { return _ListUser; }
            set { _ListUser = value; OnPropertyChanged(); }
        }

        private string _UserName = string.Empty;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }

    }

}
