
using Common;
using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class QuanLyNhatKyModel : BaseModel
    {

        private ObservableCollection<CheckBoxDto> _ListTrangThai;

        public ObservableCollection<CheckBoxDto> ListTrangThai
        {
            get
            {
                if (_ListTrangThai == null)
                {
                    _ListTrangThai = new ObservableCollection<CheckBoxDto>();
                    _ListTrangThai.Add(new CheckBoxDto() { Ma = "ChoCongBo", Ten = "Chờ công bố", IsChecked = true });
                    _ListTrangThai.Add(new CheckBoxDto() { Ma = "DangTienHanh", Ten = "Đang tiến hành", IsChecked = true });
                    _ListTrangThai.Add(new CheckBoxDto() { Ma = "DaKetThuc", Ten = "Đã kết thúc", IsChecked = true });
                }
                return _ListTrangThai;
            }
            set { _ListTrangThai = value; OnPropertyChanged(); }
        }

        private DataTable _ListThanhTra;
        public DataTable ListThanhTra
        {
            get
            {
                return _ListThanhTra;
            }
            set
            {
                _ListThanhTra = value; OnPropertyChanged();
            }
        }

        private DateTime? _NgayCongBoTu = DateTime.Now.AddMonths(-6);
        public DateTime? NgayCongBoTu
        {
            get { return _NgayCongBoTu; }
            set
            {
                _NgayCongBoTu = value; OnPropertyChanged();
            }
        }

        private DateTime? _NgayCongBoDen = DateTime.Now.AddMonths(6);
        public DateTime? NgayCongBoDen
        {
            get { return _NgayCongBoDen; }
            set { _NgayCongBoDen = value; OnPropertyChanged(); }
        }


        public string TrangThai
        {
            get
            {
                return (ListTrangThai.FirstOrDefault(c => c.Ma == "ChoCongBo").IsChecked ? "1" : "0") + (ListTrangThai.FirstOrDefault(c => c.Ma == "DangTienHanh").IsChecked ? "1" : "0") + (ListTrangThai.FirstOrDefault(c => c.Ma == "DaKetThuc").IsChecked ? "1" : "0");
            }
        }

        private string _MST;
        public string MST
        {
            get { return _MST; }
            set { _MST = value; OnPropertyChanged(); }
        }

        private string _TenNNT;
        public string TenNNT
        {
            get { return _TenNNT; }
            set { _TenNNT = value; OnPropertyChanged(); }
        }


    }
}
