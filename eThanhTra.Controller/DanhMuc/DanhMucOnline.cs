using Common;
using eThanhTra.Network;
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
        public async Task<MsgResult<DataSet>> GetDanhMucChung()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<DataSet>>(null, "DanhMuc", "GetDanhMucChung");
        }

        public async Task<MsgResult<DataTable>> GetCQTByMaCQT()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(null, "DanhMuc", "GetCQTByMaCQT");
        }

        public async Task<MsgResult<DataTable>> GetUserByMaCQT()
        {
            return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(null, "DanhMuc", "GetUserByMaCQT");
        }


        public async Task<MsgResult<DataTable>> GetUserByInfo(string Info)
        {
            dynamic Input = new ExpandoObject();
            Input.Info = Info;
            return await MyApp.Common.GetWebApiAsync<MsgResult<DataTable>>(Input, "DanhMuc", "GetUserByInfo");
        }

       
    }
}
