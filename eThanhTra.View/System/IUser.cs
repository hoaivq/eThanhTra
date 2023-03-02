using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.View.System
{
    public interface IUser : IView
    {
       Task<bool> ShowDetail(SUserDto sUserDto = null);
    }
}
