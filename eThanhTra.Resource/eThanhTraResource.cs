using Common.Core;
using DevExpress.Xpf.Core;
using eThanhTra.Resource.PropertiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eThanhTra.Resource
{
    public partial class eThanhTraResource : ResourceDictionary
    {
        public eThanhTraResource()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DXTabItem tabItem = (DXTabItem)((SimpleButton)sender).Tag;
            IView v = ((IView)(FrameworkElement)tabItem.Content);

            if (v.IsDataChanged)
            {
                bool IsYes = v.ShowQuestion("Dữ liệu đã bị thay đổi, bạn có muốn tiếp tục?");
                if (!IsYes) { return; }
            }

            GlobalResource.MyDXTabControl.RemoveTabItem(tabItem);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = ((FrameworkElement)sender).GetRootOwner();
            ((Common.Core.CoreViewModel)c.DataContext).CloseCommand.Execute(null);
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = ((FrameworkElement)sender).GetRootOwner();
            ((Common.Core.CoreViewModel)c.DataContext).SaveCommand.Execute(null);
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = ((FrameworkElement)sender).GetRootOwner();
            ((Common.Core.CoreViewModel)c.DataContext).LoadCommand.Execute(null);
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = ((FrameworkElement)sender).GetRootOwner();
            ((Common.Core.CoreViewModel)c.DataContext).AddEditCommand.Execute(null);
        }
    }

}
