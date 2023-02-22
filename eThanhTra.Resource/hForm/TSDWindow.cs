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
        public bool IsFirstLoad { get; set; } = true;

        public TSDWindow()
        {
            this.Loaded += TSDWindow_Loaded;
            this.Closed += TSDWindow_Closed;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TSDWindow_Closed(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Opacity = 1;
            }
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
                    IsFirstLoad = true;
                    ((CoreViewModel)this.DataContext).FirstLoadViewCommand.Execute(null);
                    IsFirstLoad = false;
                }
            }
        }

        public async Task CloseView()
        {
            this.Close();
            await Task.CompletedTask;
        }

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
                        objF.ShowDialog();
                    }
                    catch { }
                }));

                Task<MsgResult<T>> ketQua = MyFunction.Invoke();

                if (ketQua.Exception != null)
                {
                    throw ketQua.Exception;
                }
                else
                {
                    msgResult = ketQua.Result;
                }
            })).ContinueWith(new Action<Task>(task =>
            {
                objF.Close();

                if (task.Exception != null)
                {
                    string ErrMsg = string.Empty;
                    List<Exception> exceptions = task.Exception.GetExceptions(ref ErrMsg);
                    MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (Exception item in exceptions)
                    {
                        stringBuilder.AppendLine(item.Message + " : " + item.InnerException?.Message);
                    }
                    throw new Exception(stringBuilder.ToString());
                }

            }), TaskScheduler.FromCurrentSynchronizationContext());

            return msgResult;
        }

        public async Task ShowWait(string MethodName, Func<Task> MyFunction)
        {
            TSDWaitWindow objF = new TSDWaitWindow();

            objF.Owner = this;
            await Task.Run(new Action(() =>
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        objF.ShowDialog();
                    }
                    catch { }
                }));

                Task ketQua = MyFunction.Invoke();
                if (ketQua.Exception != null) { throw ketQua.Exception; }
            })).ContinueWith(new Action<Task>(task =>
            {
                objF.Close();

                if (task.Exception != null)
                {
                    string ErrMsg = string.Empty;
                    List<Exception> exceptions = task.Exception.GetExceptions(ref ErrMsg);
                    MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (Exception item in exceptions)
                    {
                        stringBuilder.AppendLine(item.Message + " : " + item.InnerException?.Message);
                    }
                    throw new Exception(stringBuilder.ToString());
                }

            }), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
