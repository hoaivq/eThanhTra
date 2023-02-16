using Common;
using eThanhTra.Network.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.App
{
    public class AppOnline : IAppNetwork
    {
        public async Task<MsgResult<DataTable>> CallSP(CallSPDto callSPDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<DataTable>>(callSPDto, "App", "CallSP");
        }
    }
}
