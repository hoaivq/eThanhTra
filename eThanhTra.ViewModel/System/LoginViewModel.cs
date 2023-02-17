using eThanhTra.Api.Controllers;
using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Data;
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
                    MsgResult<SUser> msgResult = await View.ShowWait("Login", () => Login());

                    if (msgResult.Success == false)
                    {
                        View.ShowMsg(msgResult.Message);
                        return;
                    }

                    AppViewModel.MyUser = msgResult.Value;
                    View.ShowMainWindow();
                }
                catch (Exception ex)
                {
                    View.ShowMsg(ex, "LoginCommand");
                }
            });
        }

        public async Task<MsgResult<SUser>> Login()
        {
            dynamic Input = new ExpandoObject();
            Input.UserName = _Model.UserName;
            Input.Password = _Model.Password;
            MsgResult<DataTable> msgResult = await MyObject.ObjApp.CallSP(CallSPDto.Create("PLogin", new SqlParam("UserName", _Model.UserName), new SqlParam("Password", _Model.Password)));
            
            return await MyObject.ObjLogin.Login(Input);
        }
    }
}
