using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model.NhatKy;
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
    public class ThanhTraDetailViewModel : BaseViewModel<IThanhTraDetail, ThanhTraDetailModel>
    {
        public ICommand ChonNgayCommand { get; set; }
        public ThanhTraDetailViewModel(IThanhTraDetail View) : base(View)
        {
            ChonNgayCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await _View.ShowWait("LoadChiTietCongViec", async () => await LoadChiTietCongViec(p));
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "ChonNgayCommand");
                }
            });
        }

        public async override Task LoadView(object p = null)
        {
            await LoadVaiTro();
            await LoadDanhMuc();
            await LoadLichTrinh();
            await LoadChiTietCongViec();
        }

        private async Task LoadVaiTro()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetVaiTro",
               new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt),
               new SqlParam("UserName", AppViewModel.MyUser.UserName, SqlDbType.VarChar, 50)
               ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            if (msgResult.Value.Rows.Count > 0)
            {
                _Model.ObjThanhTraThanhVien = msgResult.Value.Rows[0].ToObject<DThanhTraThanhVienDto>();
            }
        }
        private async Task LoadDanhMuc()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListCongViecByThanhVien",
               new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt),
               new SqlParam("IdThanhVien", _Model.ObjThanhTraThanhVien?.Id, SqlDbType.BigInt)
               ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListCongViecByThanhVien = msgResult.Value;
        }
        private async Task LoadLichTrinh()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PTaoLichTrinhById",
                new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt)));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.LichTrinh = msgResult.Value;
        }

        private async Task LoadChiTietCongViec(object p = null)
        {
            if (_Model.RowLichTrinh == null) { return; }

            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListChiTietCongViec",
                new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt),
                new SqlParam("NgayNhatKy", ((DateTime)_Model.RowLichTrinh["Ngay"]).Date, SqlDbType.Date)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListChiTietCongViec = msgResult.Value;
        }
        public override Task<bool> AddNewView(object p = null)
        {
            DataRow dr = _Model.ListChiTietCongViec.NewRow();
            _Model.ListChiTietCongViec.Rows.InsertAt(dr, 0);
            return Task.FromResult(true);
        }
    }
}
