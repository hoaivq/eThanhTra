using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class TamDungThanhTraModel : BaseModel
    {
		private long _IdThanhTra;

		public long IdThanhTra
		{
			get { return _IdThanhTra; }
			set { _IdThanhTra = value; OnPropertyChanged(); }
		}


		private DThanhTraTamDungDto _objTamDung;

		public DThanhTraTamDungDto ObjTamDung
		{
			get { return _objTamDung; }
			set { _objTamDung = value; OnPropertyChanged(); }
		}

	}
}
