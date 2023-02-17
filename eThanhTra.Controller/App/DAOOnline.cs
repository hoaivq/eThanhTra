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
    public class DAOOnline : IDAONetwork
    {
        public async Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<DataTable>>(callSPDto, "DAO", "GetTable");
        }
    }
}
