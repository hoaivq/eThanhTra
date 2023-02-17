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

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for TSDWaitWindow.xaml
    /// </summary>
    public partial class TSDWaitWindow : Window
    {
        public TSDWaitWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Opacity = 1;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Opacity = 0.5;
            }
        }
    }
}
