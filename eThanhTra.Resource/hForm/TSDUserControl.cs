using Common;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eThanhTra.Resource
{
    public class TSDUserControl : UserControl, IView
    {
        public Window Owner { get; set; }
        public bool IsFirstLoad { get; set; } = true;

        public TSDUserControl(Window _Owner)
        {
            Owner = _Owner;
            this.Loaded += TSDUserControl_Loaded;
        }
        public TSDUserControl()
        {
            this.Loaded += TSDUserControl_Loaded;
        }

        private void TSDUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
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
            GlobalResource.MyDXTabControl.RemoveTabItem(this.Parent);
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

            objF.Owner = GlobalResource.MainWindow;
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

            objF.Owner = GlobalResource.MainWindow;
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
