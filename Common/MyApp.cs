using Common.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public MsgResult(string Title, Exception ex)
        {
            MyApp.Log.GhiLog(Title, ex);
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
}
