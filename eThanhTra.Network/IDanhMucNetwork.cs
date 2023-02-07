using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Network
{
    public interface IDanhMucNetwork
    {
        Task<MsgResult<DataSet>> GetDanhMucChung();
        Task<MsgResult<DataTable>> GetCQTByMaCQT();
        Task<MsgResult<DataTable>> GetUserByMaCQT();
        Task<MsgResult<DataTable>> GetUserByInfo(string Info);
    }
}
