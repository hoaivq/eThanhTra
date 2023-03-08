using Common;
using eThanhTra.Dto;
using eThanhTra.Resource;
using eThanhTra.View;
using eThanhTra.View.NhatKy;
using eThanhTra.ViewModel;
using eThanhTra.ViewModel.NhatKy;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace eThanhTra.NhatKy
{
    /// <summary>
    /// Interaction logic for frmThanhTraAdd.xaml
    /// </summary>
    public partial class popThanhTraAdd : TSDPopUp, IThanhTraAdd
    {
        public popThanhTraAdd()
        {

            InitializeComponent();
            this.DataContext = new ThanhTraAddViewModel(this);
        }

        public async Task<long?> ShowAddNewCongViec(long IdThanhTra, DataRowView RowCongViec)
        {
            try
            {
                popThanhTraCongViecAdd objF = new popThanhTraCongViecAdd();
                ((ThanhTraCongViecAddViewModel)objF.DataContext)._Model.IdThanhTra = IdThanhTra;
                ((ThanhTraCongViecAddViewModel)objF.DataContext)._Model.ObjCongViec = RowCongViec.ToObject<DThanhTraCongViecDto>();
                objF.ShowPopUp(this);
                await Task.CompletedTask;

                if(((ThanhTraCongViecAddViewModel)objF.DataContext)._Model.ObjCongViec == null)
                {
                    return null;
                }

                return ((ThanhTraCongViecAddViewModel)objF.DataContext)._Model.ObjCongViec.Id;
            }
            catch (Exception ex)
            {
                ShowMsg(ex, "ShowAddNewCongViec");
                return null;
            }
        }

        public async Task<string> ShowUserChon(long IdThanhTra)
        {
            try
            {
                popUserChon objF = new popUserChon();
                ((UserChonViewModel)objF.DataContext)._Model.IdThanhTra = IdThanhTra;
                objF.ShowPopUp(this);
                await Task.CompletedTask;
                return ((UserChonViewModel)objF.DataContext)._Model.UserName;
            }
            catch (Exception ex)
            {
                ShowMsg(ex, "ShowUserChon");
                return string.Empty;
            }
        }
    }
}
