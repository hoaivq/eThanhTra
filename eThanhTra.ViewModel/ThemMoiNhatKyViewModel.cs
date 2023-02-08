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
    public class ThemMoiNhatKyViewModel : BaseViewModel<IThemMoiNhatKy, ThemMoiNhatKyModel>
    {
        public ICommand SaveCommand { get; set; }
        public ThemMoiNhatKyViewModel(IThemMoiNhatKy View) : base(View)
        {
            SaveCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                object o = _Model.ListUserSelected;
                await Task.CompletedTask;
            });
        }
    }
}
