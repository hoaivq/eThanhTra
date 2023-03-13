using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common.Core
{
    public interface IView
    {
        //Biến trạng thái
        bool IsSaveView { get; set; }
        bool IsFirstLoad { get; set; }
        bool IsReload { get; set; }
        bool IsDataChanged { get; set; }
        bool IsValid { get; }
        bool IsCloseOnSave { get; set; }
        Task CloseView();

        void ShowMsg(string Message, bool IsError = false);
        bool ShowQuestion(string Question);
        void ShowMsg(Exception ex, string Title = "");
        void ShowFlashMsg(string Message = "Ghi dữ liệu thành công");
        Task<MsgResult<T>> ShowWait<T>(string MethodName, Func<Task<MsgResult<T>>> MyFunction);
        Task ShowWait(string MethodName, Func<Task> MyFunction);
        Task<T> ShowWait<T>(string MethodName, Func<Task<T>> MyFunction);


        void WaitCursor();
        void ArrowCursor();

    }
}
