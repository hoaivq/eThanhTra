using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace eThanhTra
{
    public static class Extensions
    {
        public static void ShowTabPage(this DXTabControl tabMain, HamburgerMenuNavigationButton menu)
        {
            DXTabItem hasItem = tabMain.Items.GetItemByName(menu.Name);
            if (hasItem == null)
            {
                hasItem = new DXTabItem() { Name = menu.Name, Header = menu.Content };
                if (hasItem.Name == "Home")
                {
                    hasItem.Content = new ucoHome();
                }
                else if (hasItem.Name == "QuanLyNhatKy")
                {
                    hasItem.Content = new ucoQuanLyNhatKy();
                }
                tabMain.Items.Add(hasItem);
            }
            tabMain.SelectedValue = hasItem;
        }

        public static DXTabItem GetItemByName(this ItemCollection Items, string ItemName)
        {
            DXTabItem retVal = null;
            foreach (DXTabItem tabItem in Items)
            {
                if (tabItem.Name == ItemName)
                {
                    retVal = tabItem;
                    break;
                }
            }
            return retVal;
        }
    }
}
