using Common;
using eThanhTra.Data;
using eThanhTra.Network;
using eThanhTra.Network.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.DanhMuc
{
    public class DanhMucOnline : IDanhMucNetwork
    {
        public async Task<MsgResult<DanhMucChung>> GetDanhMucChung()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<DanhMucChung>>(null, "DanhMuc", "GetDanhMucChung");
        }

        //public async Task<MsgResult<DataTable>> GetCQTByMaCQT()
        //{
        //    return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(null, "DanhMuc", "GetCQTByMaCQT");
        //}

        //public async Task<MsgResult<DataTable>> GetUserByMaCQT()
        //{
        //    return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(null, "DanhMuc", "GetUserByMaCQT");
        //}


        public async Task<MsgResult<DataTable>> GetUserByInfo(string Info)
        {
            dynamic Input = new ExpandoObject();
            Input.Info = Info;
            return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(Input, "DanhMuc", "GetUserByInfo");
        }

        public async Task<MsgResult<List<PGetCQTByMaCQT_Result>>> GetCQTByMaCQT()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<List<PGetCQTByMaCQT_Result>>>(null, "DanhMuc", "GetCQTByMaCQT");
        }

        public async Task<MsgResult<List<PGetUserByMaCQT_Result>>> GetUserByMaCQT()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<List<PGetUserByMaCQT_Result>>>(null, "DanhMuc", "GetUserByMaCQT");
        }
    }
}
