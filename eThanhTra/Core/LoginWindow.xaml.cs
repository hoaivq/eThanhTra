﻿using eThanhTra.Resource;
using eThanhTra.View;
using eThanhTra.View.System;
using eThanhTra.ViewModel;
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

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : TSDPopUp, ILogin
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(this);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            
            base.OnRenderSizeChanged(sizeInfo);
        }
        public void ShowMainWindow()
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMsg(ex, "ShowMainWindow");
            }
        }
    }
}
