using Common.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyApp
    {
        public static AppDao Dao = new AppDao();
        public static AppLog Log = new AppLog();
        public static AppSetting Setting = new AppSetting();
        public static AppCommon Common = new AppCommon();
    }

    public class MsgResult<T>
    {
        public MsgResult()
        {

        }

        public MsgResult(bool _Success, string _Message, T _Value)
        {
            Success = _Success;
            Message = _Message;
            Value = _Value;
        }

        public MsgResult(bool _Success, T _Value)
        {
            Success = _Success;
            Value = _Value;
        }

        public MsgResult(string Title, Exception ex, params string[] MoreInfos)
        {
            MyApp.Log.GhiLog(Title, ex, MoreInfos);
            Success = false;
            Message = ex.Message + ex.InnerException;
            Value = default(T);
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CallSPDto
    {
        public static CallSPDto Create(string _SPName, params SqlParam[] _Params)
        {
            return new CallSPDto(_SPName, _Params);
        }

        public static CallSPDto Create(string _SPName)
        {
            return new CallSPDto(_SPName);
        }

        public CallSPDto()
        {

        }

        public CallSPDto(string _SPName)
        {
            SPName = _SPName;
        }

        public CallSPDto(string _SPName, params SqlParam[] _Params)
        {
            SPName = _SPName;
            Params = _Params;
        }
        public string SPName { get; set; }
        public SqlParam[] Params { get; set; }
    }

    public class DeleteDto
    {
        public static DeleteDto Create(string _TableName, long _Id)
        {
            return new DeleteDto(_TableName, _Id);
        }
        public DeleteDto()
        {

        }
        public DeleteDto(string _TableName, long _Id)
        {
            TableName = _TableName;
            Id = _Id;
        }
        public string TableName { get; set; }
        public long Id { get; set; }
    }

    public class SqlParam
    {
        public SqlParam(string _Name, object _Value, SqlDbType? _Type = null, int? _Size = null)
        {
            Name = _Name;
            Value = (_Value == null) ? DBNull.Value : _Value;
            Type = _Type;
            Size = _Size;
        }
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlDbType? Type { get; set; }
        public int? Size { get; set; }
    }
}
