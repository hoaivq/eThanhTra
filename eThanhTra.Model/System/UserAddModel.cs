using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
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
    }
}
