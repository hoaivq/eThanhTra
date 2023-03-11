using Common;
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

namespace eThanhTra.ViewModel.NhatKy
{
    public class ThanhTraDetailAddViewModel : BaseViewModel<IThanhTraDetailAdd, ThanhTraDetailAddModel>
    {
        public ThanhTraDetailAddViewModel(IThanhTraDetailAdd View) : base(View)
        {
        }

        private async Task LoadDanhMuc()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListCongViecByThanhVien",
               new SqlParam("IdThanhTra", _Model.IdThanhTra, SqlDbType.BigInt),
               new SqlParam("IdThanhVien", _Model.IdThanhVien, SqlDbType.BigInt)
               ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListCongViecByThanhVien = msgResult.Value;
        }

        private async Task LoadData()
        {
            if (_Model.ObjChiTiet == null)
            {
                _Model.ObjChiTiet = new DThanhTraThanhVienCongViecChiTietDto();
                _Model.ObjChiTiet.IdThanhTra = _Model.IdThanhTra;
            }
            await Task.CompletedTask;
        }
        public async override Task LoadView(object p = null)
        {
            await LoadDanhMuc();
            await LoadData();
        }

        public async override Task SaveView(object p = null)
        {
            DataRow dr = ((DataRowView)_Model.RowCongViecByThanhVien).Row;
            _Model.ObjChiTiet.IdThanhTra = dr["IdThanhTra"].ToLong();
            _Model.ObjChiTiet.IdThanhVien = dr["IdThanhVien"].ToLong();
            _Model.ObjChiTiet.IdCongViec = dr["IdCongViec"].ToLong();
            _Model.ObjChiTiet.IdThanhVienCongViec = dr["Id"].ToLong();
            _Model.ObjChiTiet.NgayNhatKy = _Model.NgayNhatKy;
            MsgResult<DThanhTraThanhVienCongViecChiTietDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjChiTiet);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjChiTiet = msgResult.Value;
        }

        //private async Task SaveNhatKy(object p = null)
        //{
        //    //DataRow drCongViec = ((DataRowView)_Model.RowCongViecByThanhVien).Row;
        //    //DataRow drLichTrinh = ((DataRowView)_Model.RowLichTrinh).Row;

        //    //DThanhTraThanhVienCongViecChiTietDto obj = ((DataRowView)p).Row.ToObject<DThanhTraThanhVienCongViecChiTietDto>();
        //    //obj.IdThanhTra = drCongViec["IdThanhTra"].ToLong();
        //    //obj.IdThanhVien = drCongViec["IdThanhVien"].ToLong();
        //    //obj.IdCongViec = drCongViec["IdCongViec"].ToLong();
        //    ////obj.IdThanhVienCongViec = drCongViec["Id"].ToLong();
        //    //obj.NgayNhatKy = (DateTime)drLichTrinh["Ngay"];
        //    ////obj.NoiDung = drNhatKy["NoiDung"].ToString();
        //    ////obj.GhiChu = drNhatKy["GhiChu"].ToString();
        //    //MsgResult<DThanhTraThanhVienCongViecChiTietDto> msgResult = await MyObject.ObjApp.SaveObject(obj);
        //    //if (msgResult.Success == false)
        //    //{
        //    //    throw new Exception(msgResult.Message);
        //    //}
        //    //obj = msgResult.Value;
        //    //obj.Mode = "View";
        //    //obj.TenCongViec = drCongViec["TenCongViec"].ToString();
        //    //((DataRowView)p).Row.GetDataFrom(obj);
        //}
    }
}
