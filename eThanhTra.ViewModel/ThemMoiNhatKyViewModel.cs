using Common;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel
{
    public class ThemMoiNhatKyViewModel : BaseViewModel<IThemMoiNhatKy, ThemMoiNhatKyModel>
    {
        public ThemMoiNhatKyViewModel(IThemMoiNhatKy View) : base(View)
        {
        }
    }
}
