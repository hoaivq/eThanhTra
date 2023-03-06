using Common;
using eThanhTra.Api.Controllers;
using eThanhTra.Dto;
using eThanhTra.Network.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller.App
{
    public class DAOOffline : IDAONetwork
    {
        public async Task<MsgResult<object>> DeleteObject(DeleteDto deleteDto)
        {
            using (DAOController controller = new DAOController())
            {
                return await controller.DeleteObject(deleteDto);
            }
        }

        public async Task<MsgResult<ObservableCollection<object>>> GetListObject(CallSPDto callSPDto)
        {
            using (DAOController controller = new DAOController())
            {
                return await controller.GetListObject(callSPDto);
            }
        }

        public async Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto)
        {
            using (DAOController controller = new DAOController())
            {
                return await controller.GetTable(callSPDto);
            }
        }

        public async Task<MsgResult<object>> SaveObject(object Object)
        {
            using (DAOController controller = new DAOController())
            {
                return await controller.SaveObject(Object);
            }
        }

        public async Task<MsgResult<T>> SaveObject<T>(T Object)
        {
            MsgResult<object> msgResult = await SaveObject((object)Object);
            return new MsgResult<T>() { Success = msgResult.Success, Message = msgResult.Message, Value = (T)msgResult.Value };
        }
    }
}
