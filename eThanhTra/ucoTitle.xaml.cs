using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace eThanhTra
{
    /// <summary>
    /// Interaction logic for ucoTitle.xaml
    /// </summary>
    public partial class ucoTitle : UserControl
    {
        private Window _ParentWindow = null;
        public Window ParentWindow
        {
            get
            {
                if (_ParentWindow == null)
                {
                    _ParentWindow = Window.GetWindow(this);
                }
                return _ParentWindow;
            }
            set
            {
                _ParentWindow = value;
            }
        }

      

        public ucoTitle()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.ClickCount >= 2)
                {
                    if (MaximumVisibility == Visibility.Visible)
                    {
                        ParentWindow.WindowState = (ParentWindow.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
                    }
                }
                else
                {
                    ParentWindow.DragMove();
                }
            }

        }

        private void Minimum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ParentWindow.ShowInTaskbar = true;
                ParentWindow.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Maximum_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ParentWindow.WindowState = (ParentWindow.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ParentWindow.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }




        public Visibility MinimizeVisibility
        {
            get { return (Visibility)GetValue(MinimizeVisibilityProperty); }
            set { SetValue(MinimizeVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinimizeVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimizeVisibilityProperty =
            DependencyProperty.Register("MinimizeVisibility", typeof(Visibility), typeof(ucoTitle), new PropertyMetadata(Visibility.Visible));

        public Visibility MaximumVisibility
        {
            get { return (Visibility)GetValue(MaximumVisibilityProperty); }
            set { SetValue(MaximumVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MaximumVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumVisibilityProperty =
            DependencyProperty.Register("MaximumVisibility", typeof(Visibility), typeof(ucoTitle), new PropertyMetadata(Visibility.Visible));

        public Visibility CloseVisibility
        {
            get { return (Visibility)GetValue(CloseVisibilityProperty); }
            set { SetValue(CloseVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CloseVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseVisibilityProperty =
            DependencyProperty.Register("CloseVisibility", typeof(Visibility), typeof(ucoTitle), new PropertyMetadata(Visibility.Visible));





        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ucoTitle), new PropertyMetadata(string.Empty));


    }
}
