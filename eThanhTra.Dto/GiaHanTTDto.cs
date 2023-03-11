using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Dto
{
    public class GiaHanTTDto: BaseDto
    {
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

        private DateTime _batDauGH;

        public DateTime BatDauGH
        {
            get { return _batDauGH ; }
            set { _batDauGH = value; OnPropertyChanged(); }
        }

        private DateTime _ketThucGH;

        public DateTime KetThucGH
        {
            get { return _ketThucGH; }
            set { _ketThucGH = value; OnPropertyChanged(); }
        }


    }
}
