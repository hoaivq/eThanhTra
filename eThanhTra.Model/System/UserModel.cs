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
    public class UserModel : BaseModel
    {
        private List<SUserDto> _listUserDto;

        public List<SUserDto> ListUserDto
        {
            get { return _listUserDto; }
            set { _listUserDto = value; }
        }


        private DataTable _ListUser;

        public DataTable ListUser
        {
            get { return _ListUser; }
            set { _ListUser = value;  OnPropertyChanged(); }
        }




    }
}
