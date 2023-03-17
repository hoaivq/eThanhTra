using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Dto
{
    public class DThanhTraTamDungDto : BaseDto
    {
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private string _QuyetDinhTD;
        public string QuyetDinhTD { get { return _QuyetDinhTD; } set { _QuyetDinhTD = value; OnPropertyChanged(); } }

        private long _IDThanhTra;
        public long IDThanhTra { get { return _IDThanhTra; } set { _IDThanhTra = value; OnPropertyChanged(); } }

        private int? _SoNgayTD;
        public int? SoNgayTD { 
            get { return _SoNgayTD; } 
            set {
                    _SoNgayTD = value;
                    if (SoNgayTD.HasValue && BatDauTD.HasValue) 
                    {
                        KetThucTD = BatDauTD.Value.AddDays(SoNgayTD.Value);
                    }  
                    OnPropertyChanged();    
                }
        }

        private DateTime? _BatDauTD;
        public DateTime? BatDauTD
        {
            get { return _BatDauTD; }
            set
            {
                _BatDauTD = value;
                if (SoNgayTD.HasValue && BatDauTD.HasValue)
                {
                    KetThucTD = BatDauTD.Value.AddDays(SoNgayTD.Value);
                }
                OnPropertyChanged();
            }
        }

        private DateTime? _KetThucTD;
        public DateTime? KetThucTD { get { return _KetThucTD; } set { _KetThucTD = value; OnPropertyChanged(); } }

        private string _LyDoTamDung;
        public string LyDoTamDung { get { return _LyDoTamDung; } set { _LyDoTamDung = value; OnPropertyChanged(); } }

    }

}
