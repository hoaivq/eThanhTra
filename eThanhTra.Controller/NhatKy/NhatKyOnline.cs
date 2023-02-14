using Common;
using eThanhTra.Data;
using eThanhTra.Network.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.NhatKy
{
    public class NhatKyOnline : INhatKyNetwork
    {
        public async Task<MsgResult<DThanhTra>> Save(DThanhTra dto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<DThanhTra>>(dto, "NhatKy", "Save");
        }
    }
}
