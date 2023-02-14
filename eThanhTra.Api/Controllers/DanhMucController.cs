using Common;
using eThanhTra.Data;
using eThanhTra.Network;
using eThanhTra.Network.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
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
        public async Task<MsgResult<DanhMucChung>> GetDanhMucChung()
        {
            try
            {
                DanhMucChung danhMucChung = new DanhMucChung();

                MsgResult<List<PGetCQTByMaCQT_Result>> rsCQT = await GetCQTByMaCQT();
                if (rsCQT.Success == false)
                {
                    throw new Exception(rsCQT.Message);
                }
                danhMucChung.ListCQT = rsCQT.Value;

                MsgResult<List<PGetUserByMaCQT_Result>> rsUser  = await GetUserByMaCQT();
                if (rsUser.Success == false)
                {
                    throw new Exception(rsUser.Message);
                }
                danhMucChung.ListUser = rsUser.Value;

                return new MsgResult<DanhMucChung>(true, danhMucChung);
            }
            catch (Exception ex)
            {
                return new MsgResult<DanhMucChung>("GetDanhMucChung", ex);
            }
        }

        [HttpGet]
        public async Task<MsgResult<List<PGetCQTByMaCQT_Result>>> GetCQTByMaCQT()
        {
            try
            {
                using (eThanhTraDB eThanhTraDB  = new eThanhTraDB())
                {
                    List<PGetCQTByMaCQT_Result> ketQua = await eThanhTraDB.PGetCQTByMaCQT(MyUser.MaCQT);
                    return new MsgResult<List<PGetCQTByMaCQT_Result>>(true, ketQua);
                }
                //using (DataTable dt = await MyApp.Dao.GetSPAsync("PGetCQTByMaCQT", new SqlParameter("MaCQTCha", MyUser.MaCQT)))
                //{
                //    return new MsgResult<DataTable>(true, dt);
                //}
            }
            catch (Exception ex)
            {
                return new MsgResult<List<PGetCQTByMaCQT_Result>>("GetCQTByMaCQT", ex);
            }
        }

        [HttpGet]
        public async Task<MsgResult<List<PGetUserByMaCQT_Result>>> GetUserByMaCQT()
        {
            try
            {
                using (eThanhTraDB eThanhTraDB = new eThanhTraDB())
                {
                    List<PGetUserByMaCQT_Result> ketQua = await eThanhTraDB.PGetUserByMaCQT(MyUser.MaCQT);
                    return new MsgResult<List<PGetUserByMaCQT_Result>>(true, ketQua.ToList());
                }

                //using (DataTable dt = await MyApp.Dao.GetSPAsync("PGetUserByMaCQT", new SqlParameter("MaCQT", MyUser.MaCQT)))
                //{
                //    return new MsgResult<DataTable>(true, dt);
                //}
            }
            catch (Exception ex)
            {
                return new MsgResult<List<PGetUserByMaCQT_Result>>("GetUserByMaCQT", ex);
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
