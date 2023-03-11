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
using static Common.Core.Enums;

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for ucoThanhTra.xaml
    /// </summary>
    public partial class ucoThanhTra : TSDUserControl, IThanhTra
    {
        public ucoThanhTra()
        {
            InitializeComponent();
            this.DataContext = new ThanhTraViewModel(this);

        }

        public async Task<bool> ShowDetail(DThanhTraDto dThanhTraDto, bool IsEditQuyetDinh = false)
        {
            try
            {
                WaitCursor();

                if (dThanhTraDto == null || dThanhTraDto.TrangThai == (int)ETrangThai.ChoCongBo || IsEditQuyetDinh)
                {
                    popThanhTraAdd objF = new popThanhTraAdd();
                    ((ThanhTraAddViewModel)objF.DataContext)._Model.ObjThanhTra = dThanhTraDto;
                    objF.ShowPopUp();
                    await Task.CompletedTask;
                    return objF.IsReload;
                }
                else
                {
                    popThanhTraDetail objF = new popThanhTraDetail();
                    ((ThanhTraDetailViewModel)objF.DataContext)._Model.ObjThanhTra = dThanhTraDto;
                    objF.ShowPopUp();
                    await Task.CompletedTask;
                    return objF.IsReload;
                }
            }
            catch (Exception ex)
            {
                ShowMsg(ex, "ShowThanhTraAdd");
                return false;
            }
        }
    }
}
