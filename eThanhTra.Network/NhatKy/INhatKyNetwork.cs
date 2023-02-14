using Common;
using eThanhTra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Network.NhatKy
{
    public interface INhatKyNetwork
    {
        Task<MsgResult<DThanhTra>> Save(DThanhTra dto);
    }
}
