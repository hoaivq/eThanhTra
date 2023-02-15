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
        public async Task<MsgResult<DThanhTraDto>> Save(DThanhTraDto dto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<DThanhTraDto>>(dto, "NhatKy", "Save");
        }
    }
}
