using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class ThanhTraCongViecAddModel : BaseModel
    {
        private DThanhTraCongViecDto _ObjCongViec;
        public DThanhTraCongViecDto ObjCongViec
        {
            get { return _ObjCongViec; }
            set { _ObjCongViec = value; OnPropertyChanged(); }
        }



        private long _IdThanhTra;

        public long IdThanhTra
        {
            get { return _IdThanhTra; }
            set { _IdThanhTra = value; OnPropertyChanged(); }
        }

    }
}
