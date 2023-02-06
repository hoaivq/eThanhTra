using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace eThanhTra.Resource
{
    public class TSDUserControl : UserControl, IView
    {
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

        public void CloseView()
        {
            GlobalResource.MyDXTabControl.RemoveTabItem(this.Parent);
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
