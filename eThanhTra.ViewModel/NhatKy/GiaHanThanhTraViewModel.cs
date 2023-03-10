using eThanhTra.Model.NhatKy;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel.NhatKy
{
    public class GiaHanThanhTraViewModel : BaseViewModel<IGiaHanTT, GiaHanThanhTraModel>
    {

        public GiaHanThanhTraViewModel(IGiaHanTT View) : base(View)
        {

        }

        public override Task LoadView(object p = null)
        {
            
        }
    }
}
