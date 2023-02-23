using Common.Core;
using eThanhTra.Model.NhatKy;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.NhatKy
{
    public class ChonThanhVienViewModel : BaseViewModel<IChonThanhVien, ChonThanhVienModel>
    {
        public ICommand ChonTruongDoanCommand { get; set; }
        public ICommand ChonThanhVienCommand { get; set; }
        public ChonThanhVienViewModel(IChonThanhVien View) : base(View)
        {
            ChonTruongDoanCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    //await _View.ShowChiTiet(((DataRowView)p)?.Row.ToObject<DThanhTraDto>());
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "ChonTruongDoanCommand");
                }
            });

            ChonThanhVienCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    //await _View.ShowChiTiet(((DataRowView)p)?.Row.ToObject<DThanhTraDto>());
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "ChonThanhVienCommand");
                }
            });
        }
    }
}
