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
    public class ThanhTraDetailModel : BaseModel
    {
        private DataTable _ListThanhVien;
        public DataTable ListThanhVien
        {
            get { return _ListThanhVien; }
            set
            {
                _ListThanhVien = value;
                OnPropertyChanged();
            }
        }

        private DThanhTraThanhVienDto _ObjThanhTraThanhVien;
        public DThanhTraThanhVienDto ObjThanhTraThanhVien
        {
            get { return _ObjThanhTraThanhVien; }
            set { _ObjThanhTraThanhVien = value; OnPropertyChanged(); }
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

        private DataRowView _RowLichTrinh;
        public DataRowView RowLichTrinh
        {
            get { return _RowLichTrinh; }
            set { _RowLichTrinh = value; OnPropertyChanged(); }
        }

        private DataTable _LichTrinh;
        public DataTable LichTrinh
        {
            get { return _LichTrinh; }
            set { _LichTrinh = value; OnPropertyChanged(); }
        }

        private DataTable _ListChiTietCongViec;

        public DataTable ListChiTietCongViec
        {
            get { return _ListChiTietCongViec; }
            set { _ListChiTietCongViec = value;  OnPropertyChanged(); }
        }

        private DataRowView _RowChiTietCongViec;
        public DataRowView RowChiTietCongViec
        {
            get { return _RowChiTietCongViec; }
            set { _RowChiTietCongViec = value; OnPropertyChanged(); }
        }


        


    }
}
