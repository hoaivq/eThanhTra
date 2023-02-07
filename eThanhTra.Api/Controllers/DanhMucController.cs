using Common;
using eThanhTra.Network;
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
    public class DanhMucController : AppController, IDanhMucNetwork
    {
        [HttpGet]
        public async Task<MsgResult<DataSet>> GetDanhMucChung()
        {
            try
            {
                DataSet dsDanhMucChung = new DataSet("DanhMucChung");
                MsgResult<DataTable> msgResult = await GetCQTByMaCQT();
                if (msgResult.Success == false)
                {
                    throw new Exception(msgResult.Message);
                }
                dsDanhMucChung.Tables.Add(msgResult.Value);

                msgResult = await GetUserByMaCQT();
                if (msgResult.Success == false)
                {
                    throw new Exception(msgResult.Message);
                }
                dsDanhMucChung.Tables.Add(msgResult.Value);

                return new MsgResult<DataSet>(true, dsDanhMucChung);
            }
            catch (Exception ex)
            {
                return new MsgResult<DataSet>("GetDanhMucChung", ex);
            }
        }

        [HttpGet]
        public async Task<MsgResult<DataTable>> GetCQTByMaCQT()
        {
            try
            {
                using (DataTable dt = await MyApp.Dao.GetSPAsync("PGetCQTByMaCQT", new SqlParameter("MaCQTCha", MyUser.MaCQT)))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("GetCQTByMaCQT", ex);
            }
        }

        [HttpGet]
        public async Task<MsgResult<DataTable>> GetUserByMaCQT()
        {
            try
            {
                using (DataTable dt = await MyApp.Dao.GetSPAsync("PGetUserByMaCQT", new SqlParameter("MaCQT", MyUser.MaCQT)))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("GetUserByMaCQT", ex);
            }
        }

        [HttpGet]
        public async Task<MsgResult<DataTable>> GetUserByInfo(string Info)
        {
            try
            {
                using (DataTable dt = await MyApp.Dao.GetSPAsync("PGetUserByInfo", new SqlParameter("Info", Info)))
                {
                    return new MsgResult<DataTable>(true, dt);
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DataTable>("GetUserByInfo", ex);
            }
        }



    }
}
