using DevExpress.Xpf.Core;
using Common;
using Common.Class;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Resource
{
    public class TSDWindow : ThemedWindow, IView
    {
        public TSDWindow()
        {
            this.Loaded += TSDWindow_Loaded;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TSDWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Opacity = 0.5;
            }

            if (this.DataContext != null)
            {
                if (this.DataContext is CoreViewModel)
                {
                    ((CoreViewModel)this.DataContext).LoadViewCommand?.Execute(null);
                }
            }
        }

        public async Task CloseView() { this.Close(); await Task.CompletedTask; }

        public void ShowMsg(string Message)
        {
            System.Windows.MessageBox.Show(Message);
        }

        public void ShowMsg(Exception ex, string Title = "")
        {
            if (string.IsNullOrEmpty(Title)) { Title = "ShowMsg"; }
            MyApp.Log.GhiLog(Title, ex);
            ShowMsg(ex.Message);
        }

        public async Task<MsgResult<T>> ShowWait<T>(string MethodName, Func<Task<MsgResult<T>>> MyFunction)
        {
            MsgResult<T> msgResult = new MsgResult<T>();
            TSDWaitWindow objF = new TSDWaitWindow();

            objF.Owner = this;
            await Task.Run(new Action(() =>
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        this.Opacity = 0.5;
                        objF.ShowDialog();
                    }
                    catch { }
                }));

                Task<MsgResult<T>> ketQua = MyFunction.Invoke();
                if(ketQua.Exception != null)
                {
                    string ErrMsg = string.Empty;
                    List<Exception> exceptions = ketQua.Exception.GetExceptions(ref ErrMsg);
                    msgResult.Success = false;
                    msgResult.Message = ErrMsg;
                    MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);
                }
                else
                {
                    msgResult = ketQua.Result;
                }
            })).ContinueWith(new Action<Task>(task =>
            {
                this.Opacity = 1;
                objF.Close();
            }), TaskScheduler.FromCurrentSynchronizationContext());

            return msgResult;
        }
    }
}
