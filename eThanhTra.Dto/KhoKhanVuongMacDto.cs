using System;
using eThanhTra.Dto;

namespace eThanhTra.Model.NhatKy
{
    public class DThanhTraKKVMDto : BaseDto
    {
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long _IdThanhTra;
        public long IdThanhTra { get { return _IdThanhTra; } set { _IdThanhTra = value; OnPropertyChanged(); } }

        private string _NoiDung;
        public string NoiDung { get { return _NoiDung; } set { _NoiDung = value; OnPropertyChanged(); } }

        private string _NguyenNhan;
        public string NguyenNhan { get { return _NguyenNhan; } set { _NguyenNhan = value; OnPropertyChanged(); } }

    }
}