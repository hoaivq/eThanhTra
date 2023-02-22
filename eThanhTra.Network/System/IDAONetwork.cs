using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Network.System
{
    public interface IDAONetwork
    {
        Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto);
    }
}
