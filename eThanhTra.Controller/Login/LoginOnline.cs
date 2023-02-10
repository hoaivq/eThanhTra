using Common;
using Common;
using eThanhTra.Data;
using eThanhTra.Model;
using eThanhTra.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.Login
{
    public class LoginOnline : ILoginNetwork
    {
        public async Task<MsgResult<SUser>> Login(dynamic Input)
        {
            return await Common.MyApp.Common.PostWebApiAsync<MsgResult<SUser>>(Input, "Login", "Login");
        }
    }
}
