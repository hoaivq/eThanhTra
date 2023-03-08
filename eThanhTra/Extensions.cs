using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using eThanhTra.Core;
using eThanhTra.NhatKy;
using eThanhTra.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace eThanhTra
{
    public static class Extensions
    {
        public static void ShowTabPage(this DXTabControl tabMain, HamburgerMenuNavigationButton menu, Window Owner)
        {
            DXTabItem hasItem = tabMain.Items.GetItemByName(menu.Name);
            if (hasItem == null)
            {
                hasItem = new DXTabItem() { Name = menu.Name, Header = menu.Content };
                TSDUserControl Content = null;
                if (hasItem.Name == "Home")
                {
                    Content = new ucoHome();
                }
                else if (hasItem.Name == "QuanLyUser")
                {
                    Content = new ucoUser();
                }
                else if (hasItem.Name == "ThanhTra")
                {
                    Content = new ucoThanhTra();
                }

                if (Content != null)
                {
                    Content.Owner = Owner;
                    hasItem.Content = Content;
                    tabMain.Items.Add(hasItem);
                }
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


        public static bool? ShowPopUp(this TSDPopUp pop, Window Owner = null)
        {
            if (Owner == null)
            {
                Owner = GlobalResource.MainWindow;
            }
            pop.Owner = Owner;
            return pop.ShowDialog();
        }
    }
}
