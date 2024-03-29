﻿namespace eThanhTra.Dto
{
    using System;
    using System.Collections.Generic;

    public partial class SUserDto : BaseDto
    {

        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private int _UserType;
        public int UserType { get { return _UserType; } set { _UserType = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }

        private string _HoVaTen;
        public string HoVaTen { get { return _HoVaTen; } set { _HoVaTen = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }

        private string _SoDienThoai;
        public string SoDienThoai { get { return _SoDienThoai; } set { _SoDienThoai = value; OnPropertyChanged(); } }

        private string _MaCQT;
        public string MaCQT { get { return _MaCQT; } set { _MaCQT = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set 
            {
                _GhiChu = value;
                  OnPropertyChanged();    
            }
        }


        private bool _IsEnable;
        public bool IsEnable { get { return _IsEnable; } set { _IsEnable = value; OnPropertyChanged(); } }

    }

}
