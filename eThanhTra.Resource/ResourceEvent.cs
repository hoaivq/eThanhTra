using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace eThanhTra.Resource
{
    public partial class ResourceEvent : ResourceDictionary
    {
        public ResourceEvent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            object tabItem = ((SimpleButton)sender).Tag;
            GlobalResource.MyDXTabControl.RemoveTabItem(tabItem);
        }
    }
}
