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
        public DateTime? NgayCongBo { get { return _NgayCongBo; } set { _NgayCongBo = value; OnPropertyChanged(); } }

        private int? _ThoiGian;
        public int? ThoiGian { get { return _ThoiGian; } set { _ThoiGian = value; OnPropertyChanged(); } }

        private DateTime? _HanKetThuc;
        public DateTime? HanKetThuc { get { return _HanKetThuc; } set { _HanKetThuc = value; OnPropertyChanged(); } }

        private DateTime? _NgayKetThuc;
        public DateTime? NgayKetThuc { get { return _NgayKetThuc; } set { _NgayKetThuc = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhap;
        public DateTime? NgayNhap { get { return _NgayNhap; } set { _NgayNhap = value; OnPropertyChanged(); } }

    }
}
