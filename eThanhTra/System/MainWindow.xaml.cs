using DevExpress.Xpf.WindowsUI;
using Common;
using eThanhTra.Resource;
using eThanhTra.View;
using eThanhTra.ViewModel;
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
using eThanhTra.ViewModel.System;

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TSDWindow, IMain
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalResource.MyDXTabControl = tabMain;
            this.DataContext = new MainViewModel(this);
            ((MainViewModel)this.DataContext).LoadDanhMucCommand.Execute(null);
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
