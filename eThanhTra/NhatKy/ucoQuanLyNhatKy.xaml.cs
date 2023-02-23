using eThanhTra.Dto;
using eThanhTra.NhatKy;
using eThanhTra.Resource;
using eThanhTra.View;
using eThanhTra.View.NhatKy;
using eThanhTra.ViewModel;
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

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for ucoQuanLyNhatKy.xaml
    /// </summary>
    public partial class ucoQuanLyNhatKy : TSDUserControl, IQuanLyNhatKy
    {
        public ucoQuanLyNhatKy()
        {
            InitializeComponent();
            this.DataContext = new QuanLyNhatKyViewModel(this);
        }

        public async Task<bool> ShowDetail(DThanhTraDto dThanhTraDto)
        {
            try
            {
                popThemMoiNhatKy objF = new popThemMoiNhatKy();
                ((ThemMoiNhatKyViewModel)objF.DataContext)._Model.ObjThanhTra = dThanhTraDto;
                objF.ShowPopUp();
                await Task.CompletedTask;
                return objF.IsReload;
            }
            catch (Exception ex)
            {
                ShowMsg(ex, "ShowThemMoiNhatKy");
                return false;
            }
        }
    }
}
