using Common.Core;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.QuanLyNhatKy
{
    public class QuanLyNhatKyViewModel : BaseViewModel<IQuanLyNhatKy, QuanLyNhatKyModel>
    {
        public ICommand ShowThemMoiNhatKyCommand { get; set; }
        public QuanLyNhatKyViewModel(IQuanLyNhatKy View) : base(View)
        {
            ShowThemMoiNhatKyCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await _View.ShowThemMoiNhatKy();
            });
        }
    }
}
