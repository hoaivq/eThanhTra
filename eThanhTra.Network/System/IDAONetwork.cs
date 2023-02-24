using Common;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Network.System
{
    public interface IDAOApiNetwork
    {
        Task<MsgResult<DataTable>> GetTable(CallSPDto callSPDto);

        Task<MsgResult<ObservableCollection<object>>> GetListObject(CallSPDto callSPDto);

        Task<MsgResult<object>> SaveObject(object Object);

    }

    public interface IDAONetwork : IDAOApiNetwork
    {
        Task<MsgResult<T>> SaveObject<T>(T Object);
    }
}
