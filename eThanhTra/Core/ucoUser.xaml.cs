using eThanhTra.Resource;
using eThanhTra.View.System;
using eThanhTra.ViewModel.System;
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

namespace eThanhTra.Core
{
    /// <summary>
    /// Interaction logic for popChonThanhVien.xaml
    /// </summary>
    public partial class ucoUser : TSDUserControl, IUser
    {
        public ucoUser()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this);
        }
    }
}
