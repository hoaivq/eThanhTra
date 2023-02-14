using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Common
{
    public class MyApp
    {
        //public static AppDao Dao = new AppDao();
        //public static AppLog Log = new AppLog();
        //public static AppSetting Setting = new AppSetting();
        //public static AppCommon Common = new AppCommon();
    }

    public class MsgResult<T> : global::Common.MsgResult<T>
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
            global::Common.MyApp.Log.GhiLog(Title, ex);
            Success = false;
            Message = ex.Message + ex.InnerException;
            Value = default(T);
        }
    }
}
