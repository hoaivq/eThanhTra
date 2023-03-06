using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for TSDWaitWindow.xaml
    /// </summary>
    public partial class TSDWaitWindow2 : Window
    {
        private BackgroundWorker bgwMain = new BackgroundWorker();
        public Func<Task<MsgResult<T>>> MyFunction;
        public MsgResult<T> msgResult;

        public TSDWaitWindow2()
        {
            InitializeComponent();
            bgwMain.DoWork += BgwMain_DoWork;
            bgwMain.RunWorkerCompleted += BgwMain_RunWorkerCompleted;

        }

        private async void BgwMain_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Cursor = Cursors.Wait;
                this.Owner.Opacity = 0.5;
            }
            msgResult = await MyFunction.Invoke();
        }

        private void BgwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Cursor = Cursors.Arrow;
                this.Owner.Opacity = 1;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bgwMain.RunWorkerAsync();
        }
    }
}
