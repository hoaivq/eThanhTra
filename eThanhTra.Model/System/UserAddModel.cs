using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.System
{
    public class UserAddModel : BaseModel
    {
        private SUserDto _user;
        public SUserDto User 
        {
            get 
            {
                return _user; 
            }
            set
            {
                if (_user != value) 
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private DataTable _listUserType;

        public DataTable ListUserType
        {
            get
            {
                if(_listUserType == null)
                {
                    return AppViewModel.DanhMucChung.Tables[2];
                }
                return _listUserType; 
            }
            set { _listUserType = value; }
        }


    }
}
