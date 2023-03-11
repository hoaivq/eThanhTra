using eThanhTra.Resource;
using eThanhTra.View.NhatKy;
using eThanhTra.ViewModel.NhatKy;
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

namespace eThanhTra.NhatKy
{
    /// <summary>
    /// Interaction logic for popGiaHanThanhTra.xaml
    /// </summary>
    public partial class popGiaHanThanhTra : TSDPopUp , IGiaHanTT
    {
        public popGiaHanThanhTra()
        {
            InitializeComponent();
            this.DataContext = new GiaHanThanhTraViewModel(this);
        }
    }
}
