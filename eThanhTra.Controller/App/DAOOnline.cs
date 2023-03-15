using Common;
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
    public class DAOOnline : IDAONetwork
    {
        public async Task<MsgResult<int>> DeleteFile(long Id)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<int>>(Id, "DAO", "DeleteFile");
        }

        public async Task<MsgResult<object>> DeleteObject(DeleteDto deleteDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<object>>(deleteDto, "DAO", "DeleteObject");
        }

        public async Task<MsgResult<ObservableCollection<DFileDto>>> GetListFile(CallSPDto callSPDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<ObservableCollection<DFileDto>>>(callSPDto, "DAO", "GetListFile");
        }

        public async Task<MsgResult<ObservableCollection<object>>> GetListObject(CallSPDto callSPDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<ObservableCollection<object>>>(callSPDto, "DAO", "GetListObject");
        }

        public async Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<DataTable>>(callSPDto, "DAO", "GetTable");
        }

        public async Task<MsgResult<ObservableCollection<DFileDto>>> SaveFile(ObservableCollection<DFileDto> ListFile)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<ObservableCollection<DFileDto>>>(ListFile, "DAO", "SaveFile");
        }

        public async Task<MsgResult<object>> SaveObject(object Object)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<object>>(Object, "DAO", "SaveObject");
        }

        public async Task<MsgResult<T>> SaveObject<T>(T Object)
        {
            MsgResult<object> msgResult = await SaveObject((object)Object);
            return new MsgResult<T>() { Success = msgResult.Success, Message = msgResult.Message, Value = (msgResult.Success ? JsonConvert.DeserializeObject<T>(msgResult.Value.ToString()) : default(T)) };
        }

        public async Task<MsgResult<string>> ViewFile(long Id)
        {
            return await MyApp.Common.PostWebApiAsync<MsgResult<string>>(Id, "DAO", "ViewFile");
        }
    }
}
