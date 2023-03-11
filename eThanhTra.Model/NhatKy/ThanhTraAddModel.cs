using Common;
using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model.NhatKy
{
    public class ThanhTraAddModel : BaseModel
    {
        private bool _IsEnableCongBo;
        public bool IsEnableCongBo
        {
            get { return _IsEnableCongBo; }
            set { _IsEnableCongBo = value; OnPropertyChanged(); }
        }

        private DataRowView _RowCongViec;

        public DataRowView RowCongViec
        {
            get { return _RowCongViec; }
            set { _RowCongViec = value; OnPropertyChanged(); }
        }


        private DataTable _ListCQT = null;
        public DataTable ListCQT
        {
            get
            {
                if (_ListCQT == null)
                {
                    _ListCQT = AppViewModel.DanhMucChung.Tables[0];
                }
                return _ListCQT;
            }
            set
            {
                _ListCQT = value;
                OnPropertyChanged();
            }
        }

        private DataTable _ListTrangThai;
        public DataTable ListTrangThai
        {
            get
            {
                if (_ListTrangThai == null)
                {
                    _ListTrangThai = AppViewModel.ListTrangThai;
                }
                return _ListTrangThai;
            }
            set { _ListTrangThai = value; OnPropertyChanged(); }
        }


        private DataTable _ListUser = null;
        public DataTable ListUser
        {
            get
            {
                return _ListUser;
            }
            set
            {
                _ListUser = value;
                OnPropertyChanged();
            }
        }


        private DThanhTraDto _ObjThanhTra;
        public DThanhTraDto ObjThanhTra
        {
            get { return _ObjThanhTra; }
            set
            {
                _ObjThanhTra = value;
                IsEnabledEdit = (value != null && value.Id.HasValue);

                IsEnableCongBo = (ObjThanhTra != null && ListThanhVien != null && ListThanhVien.Rows.Count > 0 && ListCongViec != null && ListCongViec.Rows.Count > 0);
                OnPropertyChanged();
            }
        }


        private DataTable _ListThanhVien;
        public DataTable ListThanhVien
        {
            get { return _ListThanhVien; }
            set
            {
                _ListThanhVien = value;
                IsEnableCongBo = (ObjThanhTra != null && ListThanhVien != null && ListThanhVien.Rows.Count > 0 && ListCongViec != null && ListCongViec.Rows.Count > 0);
                OnPropertyChanged();
            }
        }


        private DataTable _ListCongViec;
        public DataTable ListCongViec
        {
            get { return _ListCongViec; }
            set
            {
                _ListCongViec = value;
                IsEnableCongBo = (ObjThanhTra != null && ListThanhVien != null && ListThanhVien.Rows.Count > 0 && ListCongViec != null && ListCongViec.Rows.Count > 0);
                OnPropertyChanged();
            }
        }


        private DataTable _ListThanhVienCongViec;
        public DataTable ListThanhVienCongViec
        {
            get { return _ListThanhVienCongViec; }
            set { _ListThanhVienCongViec = value; OnPropertyChanged(); }
        }

        private bool _IsEnabledEdit = true;
        public bool IsEnabledEdit
        {
            get { return _IsEnabledEdit; }
            set { _IsEnabledEdit = value; OnPropertyChanged(); }
        }

        

    }
}
