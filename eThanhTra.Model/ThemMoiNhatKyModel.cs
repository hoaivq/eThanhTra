using Common;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model
{
    public class ThemMoiNhatKyModel : BaseModel
    {

        public DataTable ListCQT
        {
            get { return AppViewModel.DsDanhMucChung.Tables["PGetCQTByMaCQT"]; }
        }

        public DataTable ListUser
        {
            get { return AppViewModel.DsDanhMucChung.Tables["PGetUserByMaCQT"]; }
        }

        public object ListUserSelected { get; set; }
    }
}
