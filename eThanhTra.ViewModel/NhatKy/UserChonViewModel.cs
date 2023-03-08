using Common;
using Common.Core;
using eThanhTra.Controller;
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
    public class UserChonViewModel : BaseViewModel<IUserChon, UserChonModel>
    {
        public ICommand ChonUserCommand { get; set; }
        public UserChonViewModel(IUserChon View) : base(View)
        {
            ChonUserCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await View.ShowWait("ChonUser", () => ChonUser(p));
                    await _View.CloseView();
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "ChonUserCommand");
                }
            });
        }


        public async override Task LoadView(object p = null)
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListUser",
                  new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5),
                  new SqlParam("IdThanhTra", _Model.IdThanhTra, SqlDbType.BigInt),
                  new SqlParam("VaiTro", 2, SqlDbType.Int)
                  ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListUser = msgResult.Value;
        }

        private async Task ChonUser(object p)
        {
            if(p == null)
            {
                throw new Exception("Chưa chọn thành viên");
            }
            DataRow dr = ((DataRowView)p).Row;
            _Model.UserName = dr["UserName"].ToString();
            await Task.CompletedTask;
        }
    }
}
