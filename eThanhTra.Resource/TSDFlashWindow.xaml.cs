using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for TSDFlashWindow.xaml
    /// </summary>
    public partial class TSDFlashWindow : Window
    {
        private DispatcherTimer _Timer { get; set; }
        public TSDFlashWindow(string _Message = "Ghi dữ liệu thành công")
        {
            InitializeComponent();
            txtMsg.Text = _Message;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _Timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
            _Timer.Tick += _Timer_Tick;
            _Timer.Start();
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
