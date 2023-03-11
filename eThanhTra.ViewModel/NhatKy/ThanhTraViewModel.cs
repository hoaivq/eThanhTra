using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model;
using eThanhTra.Model.NhatKy;
using eThanhTra.View;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.NhatKy
{
    public class ThanhTraViewModel : BaseViewModel<IThanhTra, ThanhTraModel>
    {
        public ICommand EditQuyetDinhCommand { get; set; }
        public ThanhTraViewModel(IThanhTra View) : base(View)
        {
            EditQuyetDinhCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await _View.ShowWait("EditQuyetDinh", async () => await EditQuyetDinh(p));
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "EditQuyetDinhCommand");
                }
            });
        }

        
        public override async Task LoadView(object p = null)
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListThanhTra",
                   new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5),
                   new SqlParam("UserName", AppViewModel.MyUser.UserName, SqlDbType.VarChar, 50),
                   new SqlParam("UserType", AppViewModel.MyUser.UserType, SqlDbType.Int),
                   new SqlParam("TrangThai", _Model.TrangThai, SqlDbType.VarChar, 50),
                   new SqlParam("MST", _Model.MST, SqlDbType.NVarChar, 50),
                   new SqlParam("TenNNT", _Model.TenNNT, SqlDbType.NVarChar, 500),
                   new SqlParam("NgayCongBoTu", _Model.NgayCongBoTu.ToDateStrSQL(), SqlDbType.VarChar, 8),
                   new SqlParam("NgayCongBoDen", _Model.NgayCongBoDen.ToDateStrSQL(), SqlDbType.VarChar, 8),
                   new SqlParam("IsShowCQTCapDuoi", 1, SqlDbType.Int)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListThanhTra = msgResult.Value;
        }

        public override async Task<bool> AddEditView(object p = null)
        {
            DThanhTraDto dThanhTraDto = ((DataRowView)p)?.Row.ToObject<DThanhTraDto>();
            return await _View.ShowDetail(dThanhTraDto);
        }

        public override async Task DeleteRow(object p = null)
        {
            DataRow dr = ((DataRowView)p).Row;
            MsgResult<object> msgResult = await MyObject.ObjApp.DeleteObject(DeleteDto.Create("DThanhTra", dr["Id"].ToLong().Value));
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            dr.Delete();
        }
        private async Task<bool> EditQuyetDinh(object p = null)
        {
            DThanhTraDto dThanhTraDto = ((DataRowView)p)?.Row.ToObject<DThanhTraDto>();
            return await _View.ShowDetail(dThanhTraDto, true);
        }
    }
}
