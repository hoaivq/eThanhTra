using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IView
    {
        Task CloseView();
        void ShowMsg(string Message);
        void ShowMsg(Exception ex, string Title = "");

        Task<MsgResult<T>> ShowWait<T>(string MethodName, Func<Task<MsgResult<T>>> MyFunction);
    }
}
