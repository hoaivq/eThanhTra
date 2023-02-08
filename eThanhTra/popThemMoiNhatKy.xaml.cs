using eThanhTra.Resource;
using eThanhTra.View;
using eThanhTra.ViewModel;
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

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for frmThemMoiNhatKy.xaml
    /// </summary>
    public partial class popThemMoiNhatKy : TSDPopUp, IThemMoiNhatKy
    {
        public popThemMoiNhatKy()
        {
            InitializeComponent();
            this.DataContext = new ThemMoiNhatKyViewModel(this);
        }
    }
}
