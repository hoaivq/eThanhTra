using Common;
using Common.Core;
using eThanhTra.Data;
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

        public object ListCQT
        {
            get
            {
                return AppViewModel.DanhMucChung.ListCQT;
            }
        }

        public object ListUser
        {
            get
            {
                return AppViewModel.DanhMucChung.ListUser;
            }
        }

        public object ListUserSelected { get; set; }
    }

    public class A : PGetUserByMaCQT_Result
    {
        public bool IsChecked { get; set; }
    }
}
