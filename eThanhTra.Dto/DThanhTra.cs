using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Dto
{
    public class DThanhTraDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private string _MST;
        public string MST { get { return _MST; } set { _MST = value; OnPropertyChanged(); } }

        private string _TenNNT;
        public string TenNNT { get { return _TenNNT; } set { _TenNNT = value; OnPropertyChanged(); } }

        private string _MaCQT;
        public string MaCQT { get { return _MaCQT; } set { _MaCQT = value; OnPropertyChanged(); } }

        private string _UserNameTDTT;
        public string UserNameTDTT { get { return _UserNameTDTT; } set { _UserNameTDTT = value; OnPropertyChanged(); } }

        private int? _TrangThai;
        public int? TrangThai { get { return _TrangThai; } set { _TrangThai = value; OnPropertyChanged(); } }

        private DateTime? _NgayCongBo;
        public DateTime? NgayCongBo
        {
            get { return _NgayCongBo; }
            set
            {
                _NgayCongBo = value;
                if (NgayCongBo.HasValue && ThoiGian.HasValue)
                {
                    HanKetThuc = NgayCongBo.Value.AddDays(ThoiGian.Value);
                }

                OnPropertyChanged();
            }
        }

        private int? _ThoiGian;
        public int? ThoiGian
        {
            get { return _ThoiGian; }
            set
            {
                _ThoiGian = value;
                if (NgayCongBo.HasValue && ThoiGian.HasValue)
                {
                    HanKetThuc = NgayCongBo.Value.AddDays(ThoiGian.Value);
                }
                OnPropertyChanged();
            }
        }

        private DateTime? _HanKetThuc;
        public DateTime? HanKetThuc { get { return _HanKetThuc; } set { _HanKetThuc = value; OnPropertyChanged(); } }

        private DateTime? _NgayKetThuc;
        public DateTime? NgayKetThuc { get { return _NgayKetThuc; } set { _NgayKetThuc = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhap;
        public DateTime? NgayNhap { get { return _NgayNhap; } set { _NgayNhap = value; OnPropertyChanged(); } }

        private string _TrangThaiText;

        public string TrangThaiText
        {
            get { return _TrangThaiText; }
            set { _TrangThaiText = value; OnPropertyChanged(); }
        }

        private string _Mode;

        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; OnPropertyChanged(); }
        }

        private string _MaTenCQT;
        public string MaTenCQT
        {
            get { return _MaTenCQT; }
            set { _MaTenCQT = value; OnPropertyChanged(); }
        }

    }

    public class DThanhTraThanhVienDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long? _IdThanhTra;
        public long? IdThanhTra { get { return _IdThanhTra; } set { _IdThanhTra = value; OnPropertyChanged(); } }

        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private string _UserNameOld;
        public string UserNameOld { get { return _UserNameOld; } set { _UserNameOld = value; OnPropertyChanged(); } }

        private int? _VaiTro;
        public int? VaiTro { get { return _VaiTro; } set { _VaiTro = value; OnPropertyChanged(); } }

        private bool _IsEnable;
        public bool IsEnable { get { return _IsEnable; } set { _IsEnable = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

    }

    public class DThanhTraCongViecDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long? _IdThanhTra;
        public long? IdThanhTra { get { return _IdThanhTra; } set { _IdThanhTra = value; OnPropertyChanged(); } }

        private string _TenCongViec;
        public string TenCongViec { get { return _TenCongViec; } set { _TenCongViec = value; OnPropertyChanged(); } }

        private DateTime? _NgayBatDau;
        public DateTime? NgayBatDau { get { return _NgayBatDau; } set { _NgayBatDau = value; OnPropertyChanged(); } }

        private DateTime? _NgayKetThuc;
        public DateTime? NgayKetThuc { get { return _NgayKetThuc; } set { _NgayKetThuc = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

    }

    public class DThanhTraThanhVienCongViecDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long? _IdThanhTra;
        public long? IdThanhTra { get { return _IdThanhTra; } set { _IdThanhTra = value; OnPropertyChanged(); } }

        private long? _IdThanhVien;
        public long? IdThanhVien { get { return _IdThanhVien; } set { _IdThanhVien = value; OnPropertyChanged(); } }

        private long? _IdCongViec;
        public long? IdCongViec { get { return _IdCongViec; } set { _IdCongViec = value; OnPropertyChanged(); } }

        private bool? _IsEnable;
        public bool? IsEnable { get { return _IsEnable; } set { _IsEnable = value; OnPropertyChanged(); } }

    }

    public class DThanhTraThanhVienCongViecChiTietDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long? _IdThanhTra;
        public long? IdThanhTra { get { return _IdThanhTra; } set { _IdThanhTra = value; OnPropertyChanged(); } }

        private long? _IdThanhVien;
        public long? IdThanhVien { get { return _IdThanhVien; } set { _IdThanhVien = value; OnPropertyChanged(); } }

        private long? _IdCongViec;
        public long? IdCongViec { get { return _IdCongViec; } set { _IdCongViec = value; OnPropertyChanged(); } }

        private long? _IdThanhVienCongViec;
        public long? IdThanhVienCongViec { get { return _IdThanhVienCongViec; } set { _IdThanhVienCongViec = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhap;
        public DateTime? NgayNhap { get { return _NgayNhap; } set { _NgayNhap = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhatKy;
        public DateTime? NgayNhatKy { get { return _NgayNhatKy; } set { _NgayNhatKy = value; OnPropertyChanged(); } }

        private string _NoiDung;
        public string NoiDung { get { return _NoiDung; } set { _NoiDung = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

        //private string _Mode;
        //public string Mode
        //{
        //    get { return _Mode; }
        //    set { _Mode = value; OnPropertyChanged(); }
        //}

        private string _TenCongViec;

        public string TenCongViec
        {
            get { return _TenCongViec; }
            set { _TenCongViec = value; OnPropertyChanged(); }
        }


    }
}
