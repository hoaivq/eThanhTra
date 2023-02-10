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
        private object _ListCQT = null;
        public object ListCQT
        {
            get
            {
                if(_ListCQT == null)
                {
                    _ListCQT = AppViewModel.DanhMucChung.ListCQT;
                }
                return _ListCQT;
            }
        }

        private object _ListUser = null;
        public object ListUser
        {
            get
            {
                if (_ListUser == null)
                {
                    _ListUser = AppViewModel.DanhMucChung.ListUser;
                }
                return _ListUser;
            }
        }

        public object ListUserSelected { get; set; }
    }

    public class A : PGetUserByMaCQT_Result
    {
        public bool IsChecked { get; set; }
    }
}
