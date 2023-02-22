using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core
{
    public class AppViewModel
    {
        public static SUser MyUser { get; set; } = null;

        public static DataSet DanhMucChung { get; set; } = null;
    }

    
}
