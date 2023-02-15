using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Data
{
    public class DThanhTraDto : DThanhTra
    {
        public DateTime? _NgayCongBo
        {
            get { return NgayCongBo; }
            set
            {
                NgayCongBo = value;
                if (value.HasValue && _ThoiGian.HasValue)
                {
                    _HanKetThuc = value.Value.AddDays(_ThoiGian.Value);
                }

                OnPropertyChanged();
            }
        }
        public int? _ThoiGian
        {
            get { return ThoiGian; }
            set
            {
                ThoiGian = value;
                if (_NgayCongBo.HasValue && value.HasValue)
                {
                    _HanKetThuc = _NgayCongBo.Value.AddDays(value.Value);
                }
                OnPropertyChanged();
            }
        }

        public DateTime? _HanKetThuc { get { return HanKetThuc; } set { HanKetThuc = value; OnPropertyChanged(); } }

    }
}
