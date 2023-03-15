using DevExpress.Xpf.Core;
using Common;
using Common.Class;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using eThanhTra.Resource.PropertiesExtensions;

namespace eThanhTra.Resource
{
    public class TSDWindow : ThemedWindow, IView
    {
        public bool IsSaveView
        {
            get { return (bool)GetValue(IsSaveViewProperty); }
            set { SetValue(IsSaveViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSaveView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSaveViewProperty =
            DependencyProperty.Register("IsSaveView", typeof(bool), typeof(TSDWindow), new PropertyMetadata(true));


        public UserControl OwnerUC { get; set; }
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

        public bool IsCloseOnSave { get; set; } = true;

        public TSDWindow()
        {
            if (this.OwnerUC == null)
            {
                if (GlobalResource.MyDXTabControl != null)
                {
                    if (GlobalResource.MyDXTabControl.SelectedItem != null)
                    {
                        this.OwnerUC = ((UserControl)((System.Windows.Controls.ContentControl)GlobalResource.MyDXTabControl.SelectedItem).Content);
                    }
                }
            }

            if (this.OwnerUC != null)
            {
                this.OwnerUC.Cursor = Cursors.Wait;
            }

            this.Loaded += TSDWindow_Loaded;
            this.Closed += TSDWindow_Closed;
            this.Closing += TSDWindow_Closing;
            this.MaxHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TSDWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsDataChanged && IsSaveView)
            {
                bool IsYes = ShowQuestion("Dữ liệu đã bị thay đổi, bạn có muốn tiếp tục?");
                if (!IsYes) { e.Cancel = true; }
            }
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
            try
            {
                if (this.Owner != null)
                {
                    this.Owner.Opacity = 0.5;
                }

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
                MyApp.Log.GhiLog("TSDWindow_Loaded", ex);
                throw ex;
            }
            finally
            {
                if (this.OwnerUC != null)
                {
                    this.OwnerUC.Cursor = Cursors.Arrow;
                }
            }
        }

        public async Task CloseView()
        {
            this.Close();
            await Task.CompletedTask;
        }

        public void ShowMsg(string Message, bool IsError = false)
        {
            ArrowCursor();
            System.Windows.MessageBox.Show(Message, "Thông báo", MessageBoxButton.OK, IsError ? MessageBoxImage.Error : MessageBoxImage.None);
        }

        public void ShowMsg(Exception ex, string Title = "")
        {
            if (string.IsNullOrEmpty(Title)) { Title = "ShowMsg"; }
            MyApp.Log.GhiLog(Title, ex);
            ShowMsg(ex.Message, true);
        }


        public Func<Task<MsgResult<object>>> CastFunc<T>(Func<Task<MsgResult<T>>> p) where T : class
        {
            Func<Task<MsgResult<object>>> f = () => p() as Task<MsgResult<object>>;
            return f;
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

            // MsgResult<T> msgResult = new MsgResult<T>();
            // TSDWaitWindow objF = new TSDWaitWindow();

            // objF.Owner = this;

            // await Task.Run(new Action(() =>
            //{
            //    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //       {
            //           try
            //           {
            //               objF.ShowDialog();
            //           }
            //           catch { }
            //       }));

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

            // return msgResult;
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

            //T msgResult = default(T);
            //TSDWaitWindow objF = new TSDWaitWindow();

            //objF.Owner = this;
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

            //    Task<T> ketQua = MyFunction.Invoke();

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

            //return Task.Run(MyFunction);
            // //TSDWaitWindow objF = new TSDWaitWindow();

            // //objF.Owner = this;
            // Task.Run(new Action(async () =>
            //{
            //         //System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //         //{
            //         //    try
            //         //    {
            //         //        objF.ShowDialog();
            //         //    }
            //         //    catch { }
            //         //}));

            //         await MyFunction.Invoke();
            //         //if (ketQua.Exception != null) { throw ketQua.Exception; }
            //     })).ContinueWith(new Action<Task>(task =>
            //     {
            //         //objF.Close();

            //         if (task.Exception != null)
            //         {
            //             string ErrMsg = string.Empty;
            //             List<Exception> exceptions = task.Exception.GetExceptions(ref ErrMsg);
            //             MyApp.Log.GhiLog("ShowWait." + MethodName, exceptions);

            //             StringBuilder stringBuilder = new StringBuilder();
            //             foreach (Exception item in exceptions)
            //             {
            //                 stringBuilder.AppendLine(item.Message + " : " + item.InnerException?.Message);
            //             }
            //             throw new Exception(stringBuilder.ToString());
            //         }

            //     }), TaskScheduler.FromCurrentSynchronizationContext());

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
                objF.Owner = this;
                objF.ShowDialog();
            }
            catch { }
        }


        public void ShowWaitBox()
        {
            TSDWaitWindow objF = new TSDWaitWindow();
            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    objF.ShowDialog();
                }
                catch { }
            }));
        }
    }
}
