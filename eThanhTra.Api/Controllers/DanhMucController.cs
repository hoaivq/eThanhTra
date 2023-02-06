using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eThanhTra.Api.Controllers
{
    public class DanhMucController : ApiController
    {
        [HttpGet]
        public async Task<MsgResult<DataTable>> GetSCQT(string MaCha)
        {
            try
            {
                //Request.GetHeader("")
                using (DataTable dt = await MyApp.Dao.GetTableAsync("EXEC PGetSCQT @MaCha", new SqlParameter("MaCha", MaCha)))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("GetSCQT", ex);
            }
        }
    }
}
