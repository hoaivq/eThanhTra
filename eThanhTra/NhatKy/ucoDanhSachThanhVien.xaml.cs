﻿using eThanhTra.Core;
using eThanhTra.Dto;
using eThanhTra.Resource;
using eThanhTra.View.NhatKy;
using eThanhTra.ViewModel.NhatKy;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eThanhTra.NhatKy
{
    /// <summary>
    /// Interaction logic for ucoChonThanhVien.xaml
    /// </summary>
    public partial class ucoDanhSachThanhVien : TSDUserControl, IChonThanhVien
    {
        public ucoDanhSachThanhVien()
        {
            InitializeComponent();
            this.DataContext = new ChonThanhVienViewModel(this);
        }
    }
}
