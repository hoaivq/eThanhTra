using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class GiaHanThanhTraModel : BaseModel
    {
        private long _IdThanhTra;

        public long IdThanhTra
        {
            get { return _IdThanhTra; }
            set { _IdThanhTra = value; OnPropertyChanged(); }
        }


        private DGiaHanTTDto _ObjGiaHan;

        public DGiaHanTTDto ObjGiaHan
        {
            get { return _ObjGiaHan; }
            set { _ObjGiaHan = value; OnPropertyChanged(); }
        }

    }
}
