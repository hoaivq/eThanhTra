using DevExpress.Xpf.WindowsUI;
using eThanhTra.Common;
using eThanhTra.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TSDWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalResource.MyDXTabControl = tabMain;
        }

        private void mnuMain_PreviewItemClick(object sender, HamburgerMenuPreviewItemClickEventArgs e)
        {
            if (e.HamburgerItem is HamburgerMenuNavigationButton)
            {
                HamburgerMenuNavigationButton menu = (HamburgerMenuNavigationButton)e.HamburgerItem;
                tabMain.ShowTabPage(menu);
            }
        }
    }
}
