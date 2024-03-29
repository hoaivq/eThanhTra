﻿using Common;
using eThanhTra.Dto;
using eThanhTra.Resource;
using eThanhTra.View.NhatKy;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eThanhTra.NhatKy
{
    /// <summary>
    /// Interaction logic for ucoThanhTraDetail.xaml
    /// </summary>
    public partial class popThanhTraDetail : TSDPopUp, IThanhTraDetail
    {
        public popThanhTraDetail()
        {
            InitializeComponent();
            this.DataContext = new ThanhTraDetailViewModel(this);
        }

        public void ScrollView()
        {
            lstLichTrinh.UpdateLayout();
            lstLichTrinh.ScrollIntoView(lstLichTrinh.SelectedItem);
        }

        
        public async Task<bool> ShowChiTiet(DThanhTraThanhVienCongViecChiTietDto dChiTietDto, long IdThanhTra, long? IdThanhVien, DateTime NgayNhatKy)
        {
            popThanhTraDetailAdd objF = new popThanhTraDetailAdd();
            ((ThanhTraDetailAddViewModel)objF.DataContext)._Model.ObjChiTiet = dChiTietDto;
            ((ThanhTraDetailAddViewModel)objF.DataContext)._Model.IdThanhTra = IdThanhTra;
            ((ThanhTraDetailAddViewModel)objF.DataContext)._Model.IdThanhVien = IdThanhVien;
            ((ThanhTraDetailAddViewModel)objF.DataContext)._Model.NgayNhatKy = NgayNhatKy;
            objF.ShowPopUp(this);
            await Task.CompletedTask;
            return objF.IsReload;
        }


        public async Task<bool> OpenGiaHanView(long IdThanhTra)
        {
            popGiaHanThanhTra objGiaHan = new popGiaHanThanhTra();
            ((GiaHanThanhTraViewModel)objGiaHan.DataContext)._Model.IdThanhTra = IdThanhTra;
            objGiaHan.ShowPopUp(this);
            await Task.CompletedTask;
            return objGiaHan.IsReload;
        }

        public async Task<bool> OpenTamDungView(long IdThanhTra)
        {
            popTamDungThanhTra objTamDung = new popTamDungThanhTra();
            ((TamDungThanhTraViewModel)objTamDung.DataContext)._Model.IdThanhTra = IdThanhTra;
            objTamDung.ShowPopUp(this);
            await Task.CompletedTask;
            return objTamDung.IsReload; 
        }

        public async Task<bool> OpenKhoKhanView(long IdThanhTra)
        {
            popKhoKhanVuongMac objKhoKhan = new popKhoKhanVuongMac();
            ((KhoKhanVuongMacViewModel)objKhoKhan.DataContext)._Model.IdThanhTra = IdThanhTra;
            objKhoKhan.ShowPopUp(this);
            await Task.CompletedTask;
            return objKhoKhan.IsReload;
        }
    }
}
