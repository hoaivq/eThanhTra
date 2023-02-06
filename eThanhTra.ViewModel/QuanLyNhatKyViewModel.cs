using Common;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel
{
    public class QuanLyNhatKyViewModel : BaseViewModel<IQuanLyNhatKy, QuanLyNhatKyModel>
    {
        public QuanLyNhatKyViewModel(IQuanLyNhatKy View) : base(View)
        {
            
        }
    }
}
