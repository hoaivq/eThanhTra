using DevExpress.Xpf.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for hSimpleButton.xaml
    /// </summary>
    public partial class hSimpleButton : SimpleButton
    {
        public hSimpleButton()
        {
            InitializeComponent();
        }

        private void SimpleButton_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement frameworkElement = this.GetRootParent();
        }
    }
}
