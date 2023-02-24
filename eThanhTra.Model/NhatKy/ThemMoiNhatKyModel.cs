using Common;
using Common.Core;
using eThanhTra.Dto;
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
        private DataTable _ListCQT = null;
        public DataTable ListCQT
        {
            get
            {
                if (_ListCQT == null)
                {
                    _ListCQT = AppViewModel.DanhMucChung.Tables[0];
                }
                return _ListCQT;
            }
            set
            {
                _ListCQT = value;
                OnPropertyChanged();
            }
        }


        private DataTable _ListUser = null;
        public DataTable ListUser
        {
            get
            {
                if (_ListUser == null)
                {
                    _ListUser = AppViewModel.DanhMucChung.Tables[1];
                }
                return _ListUser;
            }
            set
            {
                _ListUser = value;
                OnPropertyChanged();
            }
        }


        private DThanhTraDto _ObjThanhTra;
        public DThanhTraDto ObjThanhTra
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
