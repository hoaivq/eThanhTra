using DevExpress.Xpf.Editors;
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

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for hListBoxEdit.xaml
    /// </summary>
    public partial class hListBoxEdit : ListBoxEdit
    {
        public hListBoxEdit()
        {
            InitializeComponent();
        }

        public string _CaptionText
        {
            get { return (string)GetValue(_CaptionTextProperty); }
            set { SetValue(_CaptionTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionTextProperty =
           DependencyProperty.Register("_CaptionText", typeof(string), typeof(hListBoxEdit), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((hListBoxEdit)d)._CaptionVisibility = string.IsNullOrEmpty(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }


        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(hListBoxEdit), new PropertyMetadata(Visibility.Collapsed));
    }
}
