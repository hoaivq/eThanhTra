using Common;
using Common.Core;
using eThanhTra.Resource.PropertiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace eThanhTra.Resource
{
    public class TSDUserControl : UserControl, IView
    {



        public bool IsSaveView
        {
            get { return (bool)GetValue(IsSaveViewProperty); }
            set { SetValue(IsSaveViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSaveView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSaveViewProperty =
            DependencyProperty.Register("IsSaveView", typeof(bool), typeof(TSDUserControl), new PropertyMetadata(false));



        public Window Owner { get; set; }
        public bool IsFirstLoad { get; set; } = true;
        public bool IsReload { get; set; } = false;
        public bool IsDataChanged { get; set; } = false;
        public bool IsValid
        {
            get
            {
                return this.Valid();
            }
        }

        public TSDUserControl(Window _Owner)
        {
            Owner = _Owner;
            this.Loaded += TSDUserControl_Loaded;

            if (GlobalResource.MainWindow != null)
            {
                GlobalResource.MainWindow.Cursor = Cursors.Wait;
            }
        }
        public TSDUserControl()
        {
            this.Loaded += TSDUserControl_Loaded;

            if (GlobalResource.MainWindow != null)
            {
                GlobalResource.MainWindow.Cursor = Cursors.Wait;
            }
        }

        private void TSDUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (this.DataContext != null)
                {
                    if (this.DataContext is CoreViewModel)
                    {
                        ((CoreViewModel)this.DataContext).FirstLoadCommand.Execute(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("TSDUserControl_Loaded", ex);
                throw ex;
            }
            finally
            {
                if (GlobalResource.MainWindow != null)
                {
                    GlobalResource.MainWindow.Cursor = Cursors.Arrow;
                }
            }
        }

        public async Task CloseView()
        {
            if (IsDataChanged && IsSaveView)
            {
                bool IsYes = ShowQuestion("Dữ liệu đã bị thay đổi, bạn có muốn tiếp tục?");
                if (!IsYes) { return; }
            }

            GlobalResource.MyDXTabControl.RemoveTabItem(this.Parent);
            await Task.CompletedTask;
        }

        public void ShowMsg(string Message, bool IsError = false)
        {
            ArrowCursor();
            System.Windows.MessageBox.Show(Message, "Thông báo", MessageBoxButton.OK, IsError ? MessageBoxImage.Error : MessageBoxImage.None);
        }
        public bool ShowQuestion(string Question)
        {
            ArrowCursor();
            MessageBoxResult rs = System.Windows.MessageBox.Show(Question, "Thông báo", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
            if (rs == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowMsg(Exception ex, string Title = "")
        {
            this.Cursor = Cursors.Arrow;
            if (string.IsNullOrEmpty(Title)) { Title = "ShowMsg"; }
            MyApp.Log.GhiLog(Title, ex);
            ShowMsg(ex.Message);
        }


        public async Task<MsgResult<T>> ShowWait<T>(string MethodName, Func<Task<MsgResult<T>>> MyFunction)
        {
            try
            {
                WaitCursor();
                return await MyFunction.Invoke();
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog(MethodName, ex);
                throw ex;
            }
            finally
            {
                ArrowCursor();
            }

            //MsgResult<T> msgResult = new MsgResult<T>();
            //TSDWaitWindow objF = new TSDWaitWindow();

            //objF.Owner = GlobalResource.MainWindow;
            //await Task.Run(new Action(() =>
            //{
            //    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        try
            //        {
            //            objF.ShowDialog();
            //        }
            //        catch { }
            //    }));

            //    Task<MsgResult<T>> ketQua = MyFunction.Invoke();

            //    if (ketQua.Exception != null)
            //    {
            //        throw ketQua.Exception;
            //    }
            //    else
            //    {
            //        msgResult = ketQua.Result;
            //    }
            //})).ContinueWith(new Action<Task>(task =>
            //{
            //    objF.Close();

            //    if (task.Exception != null)
            //    {
            //        string ErrMsg = string.Empty;
            //        List<Exception> exceptions = task.Exception.GetExceptions(ref ErrMsg);
            //        MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);

            //        StringBuilder stringBuilder = new StringBuilder();
            //        foreach (Exception item in exceptions)
            //        {
            //            stringBuilder.AppendLine(item.Message + " : " + item.InnerException?.Message);
            //        }
            //        throw new Exception(stringBuilder.ToString());
            //    }

            //}), TaskScheduler.FromCurrentSynchronizationContext());

            //return msgResult;
        }
        public async Task<T> ShowWait<T>(string MethodName, Func<Task<T>> MyFunction)
        {
            try
            {
                WaitCursor();
                return await MyFunction.Invoke();
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog(MethodName, ex);
                throw ex;
            }
            finally
            {
                ArrowCursor();
            }
        }
        public async Task ShowWait(string MethodName, Func<Task> MyFunction)
        {
            try
            {
                WaitCursor();
                await MyFunction.Invoke();
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog(MethodName, ex);
                throw ex;
            }
            finally
            {
                ArrowCursor();
            }

            //TSDWaitWindow objF = new TSDWaitWindow();

            //objF.Owner = GlobalResource.MainWindow;
            //await Task.Run(new Action(() =>
            //{
            //    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        try
            //        {
            //            objF.ShowDialog();
            //        }
            //        catch { }
            //    }));

            //    Task ketQua = MyFunction.Invoke();
            //    if (ketQua.Exception != null) { throw ketQua.Exception; }
            //})).ContinueWith(new Action<Task>(task =>
            //{
            //    objF.Close();

            //    if (task.Exception != null)
            //    {
            //        string ErrMsg = string.Empty;
            //        List<Exception> exceptions = task.Exception.GetExceptions(ref ErrMsg);
            //        MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);

            //        StringBuilder stringBuilder = new StringBuilder();
            //        foreach (Exception item in exceptions)
            //        {
            //            stringBuilder.AppendLine(item.Message + " : " + item.InnerException?.Message);
            //        }
            //        throw new Exception(stringBuilder.ToString());
            //    }

            //}), TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void WaitCursor()
        {
            this.Cursor = Cursors.Wait;
        }

        public void ArrowCursor()
        {
            this.Cursor = Cursors.Arrow;
        }

        public void ShowFlashMsg(string Message = "Ghi dữ liệu thành công")
        {
            try
            {
                TSDFlashWindow objF = new TSDFlashWindow(Message);
                objF.Owner = GlobalResource.MainWindow;
                objF.ShowDialog();
            }
            catch { }
        }



    }
}
