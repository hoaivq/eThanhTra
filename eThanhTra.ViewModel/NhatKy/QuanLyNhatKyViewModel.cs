using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Model;
using eThanhTra.Model.NhatKy;
using eThanhTra.View;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.NhatKy
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

        public override async Task LoadView()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListThanhTra",
            new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5),
            new SqlParam("TrangThai", _Model.TrangThai, SqlDbType.VarChar, 50),
            new SqlParam("MST", _Model.MST, SqlDbType.NVarChar, 50),
            new SqlParam("TenNNT", _Model.TenNNT, SqlDbType.NVarChar, 500),
            new SqlParam("NgayCongBoTu", _Model.NgayCongBoTu.ToDateStrSQL(), SqlDbType.VarChar, 8),
            new SqlParam("NgayCongBoDen", _Model.NgayCongBoDen.ToDateStrSQL(), SqlDbType.VarChar, 8),
            new SqlParam("IsShowCQTCapDuoi", 1, SqlDbType.Int)
          ));

            if (msgResult.Success == false)
            {
                _View.ShowMsg(msgResult.Message);
                return;
            }

            _Model.ListThanhTra = msgResult.Value;
        }
    }
}
