using Common;
using eThanhTra.Data;
using eThanhTra.Model;
using eThanhTra.Network;
using Newtonsoft.Json.Linq;
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
    public class LoginController : ApiController, ILoginNetwork
    {
        [HttpPost]
        public async Task<MsgResult<SUser>> Login([FromBody] dynamic Input)
        {
            try
            {
                using (DataTable dt = await MyApp.Dao.GetSPAsync("PLogin", new SqlParameter("UserName", Input.UserName.ToString()), new SqlParameter("Password", Input.Password.ToString())))
                {
                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("Tài khoản chưa được đăng ký");
                    }

                    SUser sUser = dt.Rows[0].ToObject<SUser>();
                    return new MsgResult<SUser>(true, sUser);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<SUser>("Login", ex);
            }
        }
    }
}
