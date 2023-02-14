using Common;
using eThanhTra.Api.Controllers;
using eThanhTra.Data;
using eThanhTra.Network.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.NhatKy
{
    public class NhatKyOffline : INhatKyNetwork
    {
        NhatKyController controller = new NhatKyController();
        public async Task<MsgResult<DThanhTra>> Save(DThanhTra dto)
        {
            return await controller.Save(dto);
        }
    }
}
