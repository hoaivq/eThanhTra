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
    public class DAOOffline : IDAONetwork
    {
        
        public async Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto)
        {
            using (DAOController controller = new DAOController())
            {
                return await controller.GetTable(callSPDto);
            }
        }
    }
}
