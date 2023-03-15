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
        public ICommand EditNhatKyCommand { get; set; }
        public ICommand SaveNhatKyCommand { get; set; }
        public ICommand AddGiaHanCommand {  get; set; }
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

            AddGiaHanCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await _View.ShowWait("AddGiaHanView", async () => await AddGiaHanView((long)_Model.ObjThanhTra.Id));
                }
                catch (Exception ex)
                {

                    _View.ShowMsg(ex, "AddGiaHanCommand");
                }
            });

            //EditNhatKyCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            //{
            //    try
            //    {
            //        await _View.ShowWait("EditNhatKy", async () => await EditNhatKy(p));
            //    }
            //    catch (Exception ex)
            //    {
            //        _View.ShowMsg(ex, "EditNhatKyCommand");
            //    }
            //});

            //SaveNhatKyCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            //{
            //    try
            //    {
            //        await _View.ShowWait("SaveNhatKyCommand", async () => await SaveNhatKy(p));
            //    }
            //    catch (Exception ex)
            //    {
            //        _View.ShowMsg(ex, "SaveNhatKyCommand");
            //    }
            //});
        }

        private async Task<bool> AddGiaHanView(long IdThanhTra)
        {
            return await _View.OpenGiaHanView(IdThanhTra);
        }

        //private async Task EditNhatKy(object p = null)
        //{
        //    DataRow dr = ((DataRowView)p).Row;
        //    dr["Mode"] = "Edit";
        //    await Task.CompletedTask;
        //}
        //private async Task SaveNhatKy(object p = null) 
        //{
        //    DataRow drCongViec = ((DataRowView)_Model.RowCongViecByThanhVien).Row;
        //    DataRow drLichTrinh = ((DataRowView)_Model.RowLichTrinh).Row;

        //    DThanhTraThanhVienCongViecChiTietDto obj = ((DataRowView)p).Row.ToObject<DThanhTraThanhVienCongViecChiTietDto>();
        //    obj.IdThanhTra = drCongViec["IdThanhTra"].ToLong();
        //    obj.IdThanhVien = drCongViec["IdThanhVien"].ToLong();
        //    obj.IdCongViec = drCongViec["IdCongViec"].ToLong();
        //    //obj.IdThanhVienCongViec = drCongViec["Id"].ToLong();
        //    obj.NgayNhatKy = (DateTime)drLichTrinh["Ngay"];
        //    //obj.NoiDung = drNhatKy["NoiDung"].ToString();
        //    //obj.GhiChu = drNhatKy["GhiChu"].ToString();
        //    MsgResult<DThanhTraThanhVienCongViecChiTietDto> msgResult = await MyObject.ObjApp.SaveObject(obj);
        //    if (msgResult.Success == false)
        //    {
        //        throw new Exception(msgResult.Message);
        //    }
        //    obj = msgResult.Value;
        //    //obj.Mode = "View";
        //    obj.TenCongViec = drCongViec["TenCongViec"].ToString();
        //    ((DataRowView)p).Row.GetDataFrom(obj);
        //}

        public async override Task LoadView(object p = null)
        {
            await LoadVaiTro();
            await LoadThanhVien();
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

        private async Task LoadThanhVien()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListThanhVien",
                   new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListThanhVien = msgResult.Value;
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
            if (_Model.RowLichTrinh == null)
            {
                DataRow dr = _Model.LichTrinh.AsEnumerable().FirstOrDefault(c => ((DateTime)c["Ngay"]).Date == DateTime.Now.Date);
                if (dr != null)
                {
                    _Model.RowLichTrinh = _Model.LichTrinh.DefaultView[_Model.LichTrinh.Rows.IndexOf(dr)];
                }
                else
                {
                    _Model.RowLichTrinh = _Model.LichTrinh.DefaultView[0];
                }
            }
            _View.ScrollView();

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

        public override async Task<bool> AddEditView(object p = null)
        {
            DataRow drLichTrinh = ((DataRowView)_Model.RowLichTrinh).Row;
            DThanhTraThanhVienCongViecChiTietDto dChiTietDto = ((DataRowView)p)?.Row.ToObject<DThanhTraThanhVienCongViecChiTietDto>();
            return await _View.ShowChiTiet(dChiTietDto, _Model.ObjThanhTra.Id.Value, _Model.ObjThanhTraThanhVien?.Id, (DateTime)drLichTrinh["Ngay"]);
        }

        public override async Task ReloadView(object p = null)
        {
            await LoadChiTietCongViec(p);
        }

        public override async Task DeleteRow(object p = null)
        {
            DataRow dr = ((DataRowView)p).Row;
            MsgResult<object> msgResult = await MyObject.ObjApp.DeleteObject(DeleteDto.Create("DThanhTraThanhVienCongViecChiTiet", dr["Id"].ToLong().Value));
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            dr.Delete();
        }
    }
}
