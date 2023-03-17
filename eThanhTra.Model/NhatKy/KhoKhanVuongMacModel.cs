using Common.Core;
using DevExpress.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class KhoKhanVuongMacModel : BaseModel
    {
		private long _IdThanhTra;

		public long IdThanhTra
		{
			get { return _IdThanhTra; }
			set { _IdThanhTra = value; OnPropertyChanged(); }
		}

		private KhoKhanVuongMacModel _objKhoKhanVuongMac;

		public KhoKhanVuongMacModel ObjKhoKhanVuongMac
		{
			get { return _objKhoKhanVuongMac; }
			set { _objKhoKhanVuongMac = value; OnPropertyChanged(); }
		}
	}
}
