using Common;
using Common.Core;
using eThanhTra.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class ThemMoiNhatKyModel : BaseModel
    {
        private object _ListCQT = null;
        public object ListCQT
        {
            get
            {
                if (_ListCQT == null)
                {
                    _ListCQT = AppViewModel.DanhMucChung.ListCQT;
                }
                return _ListCQT;
            }
            set
            {
                _ListCQT = value;
                OnPropertyChanged();
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
            set
            {
                _ListUser = value;
                OnPropertyChanged();
            }
        }


        private DThanhTra _ObjThanhTra;
        public DThanhTra ObjThanhTra
        {
            get { return _ObjThanhTra; }
            set
            {
                _ObjThanhTra = value;
                OnPropertyChanged();
            }
        }

    }
}
