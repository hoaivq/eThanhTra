using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eThanhTra.Resource
{
    public class TSDPopUp : TSDWindow, IView
    {
        public TSDPopUp()
        {
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.ShowInTaskbar = false;

        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
    }
}
