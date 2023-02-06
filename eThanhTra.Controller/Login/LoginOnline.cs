﻿using Common;
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
        public async Task<MsgResult<SUser>> PostLogin(dynamic Input)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<SUser>>(Input, "Login", "PostLogin");
        }
    }
}
