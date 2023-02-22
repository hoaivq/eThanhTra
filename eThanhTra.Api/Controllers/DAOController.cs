using Common;
using Common.Core;
using eThanhTra.Dto;
using eThanhTra.Network.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace eThanhTra.Api.Controllers
{
    public partial class DAOController : ApiController, IDAONetwork
    {
        public SUser MyUser
        {
            get
            {
                if (Request == null)
                {
                    return new SUser
                    {
                        UserName = AppViewModel.MyUser.UserName,// Request.GetHeader("UserName"),
                        MaCQT = AppViewModel.MyUser.MaCQT,
                        UserType = AppViewModel.MyUser.UserType,
                    };
                }
                else
                {
                    return new SUser
                    {
                        UserName = Request.GetHeader("UserName"),
                        MaCQT = Request.GetHeader("MaCQT"),
                        UserType = Request.GetHeader("UserType").ToInt(),
                    };
                }
            }
        }

        [HttpPost]
        public async Task<MsgResult<DataTable>> GetTable([FromBody] CallSPDto callSPDto)
        {
            string JSON = string.Empty;
            try
            {
                JSON = JsonConvert.SerializeObject(callSPDto);
                using (DataTable dt = await MyApp.Dao.GetTableSPAsync(callSPDto.SPName, callSPDto.GetSqlParameter()))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("CallSP", ex, JSON);
            }
            finally
            {
                MyApp.Log.GhiLog("CallSP", JSON);
            }
        }
    }
}