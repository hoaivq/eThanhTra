using eThanhTra.Model.NhatKy;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel.NhatKy
{
    public class KhoKhanVuongMacViewModel : BaseViewModel<IKhoKhanVuongMac,KhoKhanVuongMacModel>
    {
        public KhoKhanVuongMacViewModel(IKhoKhanVuongMac View) : base(View) { }
    }
} 
