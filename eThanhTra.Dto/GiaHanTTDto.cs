using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Dto
{
    public class DGiaHanTTDto: BaseDto
    {
        private long? _IdThanhTra;

        public long? IdThanhTra
        {
            get { return _IdThanhTra; }
            set { _IdThanhTra = value; OnPropertyChanged(); }
        }


        private string _giaHanTT_ID;

		public string GiaHanTT_ID
		{
			get { return _giaHanTT_ID; }
			set { _giaHanTT_ID = value; OnPropertyChanged(); }
		}

        private string _lyDoGH;

        public string LyDoGH
        {
            get => _lyDoGH;
            set { _lyDoGH = value; OnPropertyChanged(); }
        }

        private int? _soNgay;

        public int? SoNgay
        {
            get { return _soNgay; }
            set
            {
                _soNgay = value;
                if (SoNgay.HasValue && BatDauGH.HasValue)
                {
                    KetThucGH = BatDauGH.Value.AddDays(SoNgay.Value);
                }
                OnPropertyChanged();
            }
        }

        private DateTime? _batDauGH;

        public DateTime? BatDauGH
        {
            get { return _batDauGH ; }
            set 
            {
                _batDauGH = value;
                if(SoNgay.HasValue && BatDauGH.HasValue)
                {
                    KetThucGH = BatDauGH.Value.AddDays(SoNgay.Value);
                }
                OnPropertyChanged();
            }
        }


        private DateTime? _ketThucGH;

        public DateTime? KetThucGH
        {
            get { return _ketThucGH; }
            set { _ketThucGH = value; OnPropertyChanged(); }
        }
    }
}
