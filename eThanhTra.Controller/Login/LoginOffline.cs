using Common;
using eThanhTra.Api.Controllers;
using eThanhTra.Model;
using eThanhTra.Network;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.Login
{
    public class LoginOffline : ILoginNetwork
    {
        LoginController loginController = new LoginController();
        public async Task<MsgResult<SUser>> PostLogin(dynamic Input)
        {
            return await loginController.PostLogin(Input);
        }
    }
}
