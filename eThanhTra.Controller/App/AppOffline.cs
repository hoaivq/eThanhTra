using Common;
using eThanhTra.Api.Controllers;
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
    public class AppOffline : IAppNetwork
    {
        AppController controller = new AppController();
        public async Task<MsgResult<DataTable>> CallSP(CallSPDto callSPDto)
        {
            return await controller.CallSP(callSPDto);
        }
    }
}
