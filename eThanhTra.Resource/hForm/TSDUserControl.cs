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
                    ((CoreViewModel)this.DataContext).LoadViewCommand?.Execute(null);
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

        public Task<MsgResult<T>> ShowWait<T>(string MethodName, Func<Task<MsgResult<T>>> MyFunction)
        {
            throw new NotImplementedException();
        }
    }
}
