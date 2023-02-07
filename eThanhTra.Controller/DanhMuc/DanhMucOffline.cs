using Common;
using eThanhTra.Api.Controllers;
using eThanhTra.Network;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.DanhMuc
{
    public class DanhMucOffline : IDanhMucNetwork
    {
        DanhMucController controller = new DanhMucController();

        public async Task<MsgResult<DataSet>> GetDanhMucChung()
        {
            return await controller.GetDanhMucChung();
        }

        public async Task<MsgResult<DataTable>> GetCQTByMaCQT()
        {
            return await controller.GetCQTByMaCQT();
        }

        public async Task<MsgResult<DataTable>> GetUserByInfo(string Info)
        {
            return await controller.GetUserByInfo(Info);
        }

        public async Task<MsgResult<DataTable>> GetUserByMaCQT()
        {
            return await controller.GetUserByMaCQT();
        }
    }
}
