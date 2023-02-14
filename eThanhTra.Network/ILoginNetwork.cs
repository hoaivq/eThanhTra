using Common;
using eThanhTra.Data;
using eThanhTra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Network
{
    public interface ILoginNetwork
    {
        Task<MsgResult<SUser>> Login(dynamic Input);
    }
}
