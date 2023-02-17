using eThanhTra.Api.Controllers;
using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eThanhTra.View.System;
using eThanhTra.Model.System;
using eThanhTra.Dto;

namespace eThanhTra.ViewModel.System
{
    public class LoginViewModel : BaseViewModel<ILogin, LoginModel>
    {

        public ICommand LoginCommand { get; set; }
        public LoginViewModel(ILogin View) : base(View)
        {
            LoginCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    msgResult = await View.ShowWait("Login", () => Login());

                    if (msgResult.Success == false)
                    {
                        View.ShowMsg(msgResult.Message);
                        return;
                    }

                    AppViewModel.MyUser = msgResult.Value.Rows[0].ToObject<SUser>();
                    View.ShowMainWindow();
                }
                catch (Exception ex)
                {
                    View.ShowMsg(ex, "LoginCommand");
                }
            });
        }

        public async Task<MsgResult<DataTable>> Login()
        {
            return await MyObject.ObjApp.GetTable(CallSPDto.Create("PLogin",
               new SqlParam("UserName", _Model.UserName, SqlDbType.VarChar, 100),
               new SqlParam("Password", _Model.Password, SqlDbType.VarChar, 100)));
        }
    }
}
