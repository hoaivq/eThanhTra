using Common;
using eThanhTra.Api.Controllers;
using eThanhTra.Common;
using eThanhTra.Controller;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel
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

                    SUser sUser = msgResult.Value;
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
            return await MyObject.ObjLogin.PostLogin(Input);
        }
    }
}
