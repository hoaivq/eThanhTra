﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace eThanhTra.Resource.PropertiesExtensions
{
    public static class Extensions
    {
        public static Window MainWindow { get; set; } = null;
        public static readonly DependencyProperty WindowStartupLocationProperty;
        public static readonly DependencyProperty WindowMaxHeightProperty;

        static Extensions()
        {
            WindowStartupLocationProperty = DependencyProperty.RegisterAttached("WindowStartupLocation", typeof(WindowStartupLocation), typeof(Extensions), new UIPropertyMetadata(WindowStartupLocation.Manual, OnWindowStartupLocationChanged));
            WindowMaxHeightProperty = DependencyProperty.RegisterAttached("WindowMaxHeight", typeof(double), typeof(Extensions), new UIPropertyMetadata(SystemParameters.MaximizedPrimaryScreenHeight, OnWindowMaxHeightChanged));
        }

        private static void OnWindowStartupLocationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Window window = sender as Window;

            if (window != null)
            {
                window.WindowStartupLocation = GetWindowStartupLocation(window);
            }
        }
        public static WindowStartupLocation GetWindowStartupLocation(DependencyObject sender)
        {
            return (WindowStartupLocation)sender.GetValue(WindowStartupLocationProperty);
        }
        public static void SetWindowStartupLocation(DependencyObject sender, WindowStartupLocation value)
        {
            sender.SetValue(WindowStartupLocationProperty, value);
        }


        private static void OnWindowMaxHeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Window window = sender as Window;

            if (window != null)
            {
                window.MaxHeight = GetWindowMaxHeight(window);
            }
        }
        public static double GetWindowMaxHeight(DependencyObject sender)
        {
            return SystemParameters.MaximizedPrimaryScreenHeight;
        }
        public static void SetWindowMaxHeight(DependencyObject sender, double value)
        {
            sender.SetValue(WindowMaxHeightProperty, SystemParameters.MaximizedPrimaryScreenHeight);
        }


        public static FrameworkElement GetRootOwner(this FrameworkElement frameworkElement)
        {
            if (frameworkElement == null) { return null; }
            if (frameworkElement.Parent is TSDWindow || frameworkElement.Parent is TSDUserControl)
            {
                return (FrameworkElement)frameworkElement.Parent;
            }
            else
            {
                return GetRootOwner((FrameworkElement)frameworkElement.Parent);
            }
        }

        public static List<FrameworkElement> GetAllChild(this DependencyObject current)
        {
            List<FrameworkElement> lstChild = new List<FrameworkElement>();
            FindAllChild(current, ref lstChild);
            return lstChild;
        }

        private static Type[] ControlTypeArr
        {
            get { return new Type[] { typeof(hTextEdit), typeof(hDateEdit), typeof(hComboBoxEdit), typeof(hSpinEdit) }; }
        }

        private static void FindAllChild(DependencyObject current, ref List<FrameworkElement> lstChild)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
            {
                DependencyObject children = VisualTreeHelper.GetChild(current, i);
                if (children == null)
                {
                    return;
                }

                if (ControlTypeArr.Any(c => children.GetType() == c))
                {
                    lstChild.Add((FrameworkElement)children);
                }
                else
                {
                    FindAllChild(children, ref lstChild);
                }
            }
        }


        public static bool Valid(this DependencyObject frm)
        {
            bool _IsValid = true;
            List<FrameworkElement> lstChild = frm.GetAllChild();
            if (lstChild != null)
            {
                foreach (FrameworkElement element in lstChild)
                {
                    if (element is hTextEdit)
                    {
                        hTextEdit c = (hTextEdit)element;
                        if (c.HasValidationError)
                        {
                            c.Focus();
                            _IsValid = false;
                            break;
                        }
                    }
                    else if (element is hDateEdit)
                    {
                        hDateEdit c = (hDateEdit)element;
                        if (c.hControl.HasValidationError)
                        {
                            c.Focus();
                            _IsValid = false;
                            break;
                        }
                    }
                    else if (element is hComboBoxEdit)
                    {
                        hComboBoxEdit c = (hComboBoxEdit)element;
                        if (c.hControl.HasValidationError)
                        {
                            c.Focus();
                            _IsValid = false;
                            break;
                        }
                    }
                    else if (element is hSpinEdit)
                    {
                        hSpinEdit c = (hSpinEdit)element;
                        if (c.HasValidationError)
                        {
                            c.Focus();
                            _IsValid = false;
                            break;
                        }
                    }

                }
            }
            return _IsValid;
        }
    }
}
