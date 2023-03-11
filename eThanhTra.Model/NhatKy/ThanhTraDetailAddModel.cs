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
    public class ThanhTraDetailAddModel : BaseModel
    {
        private DThanhTraCongViecDto _ObjCongViec;
        public DThanhTraCongViecDto ObjCongViec
        {
            get { return _ObjCongViec; }
            set { _ObjCongViec = value; OnPropertyChanged(); }
        }


        private DThanhTraThanhVienCongViecChiTietDto _ObjChiTiet;
        public DThanhTraThanhVienCongViecChiTietDto ObjChiTiet
        {
            get { return _ObjChiTiet; }
            set { _ObjChiTiet = value; OnPropertyChanged(); }
        }

        private long _IdThanhTra;
        public long IdThanhTra
        {
            get { return _IdThanhTra; }
            set { _IdThanhTra = value; OnPropertyChanged(); }
        }

        private long? _IdThanhVien;
        public long? IdThanhVien
        {
            get { return _IdThanhVien; }
            set { _IdThanhVien = value; OnPropertyChanged(); }
        }

        private DateTime _NgayNhatKy;
        public DateTime NgayNhatKy
        {
            get { return _NgayNhatKy; }
            set { _NgayNhatKy = value; OnPropertyChanged(); }
        }


        private DataRowView _RowCongViecByThanhVien;
        public DataRowView RowCongViecByThanhVien
        {
            get { return _RowCongViecByThanhVien; }
            set { _RowCongViecByThanhVien = value; OnPropertyChanged(); }
        }

        private DataTable _ListCongViecByThanhVien;
        public DataTable ListCongViecByThanhVien
        {
            get { return _ListCongViecByThanhVien; }
            set { _ListCongViecByThanhVien = value; OnPropertyChanged(); }
        }
    }
}
