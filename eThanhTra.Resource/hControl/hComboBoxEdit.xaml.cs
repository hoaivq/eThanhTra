using Common.Core;
using eThanhTra.Resource.PropertiesExtensions;
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
    /// Interaction logic for hComboBoxEdit.xaml
    /// </summary>
    public partial class hComboBoxEdit : UserControl
    {
        private FrameworkElement _Owner;
        public FrameworkElement Owner
        {
            get
            {
                if (_Owner == null)
                {
                    _Owner = this.GetRootOwner();
                }
                return _Owner;
            }
        }

        public hComboBoxEdit()
        {
            InitializeComponent();
        }

        public string _CaptionText
        {
            get { return (string)GetValue(_CaptionTextProperty); }
            set
            {
                SetValue(_CaptionTextProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for _CaptionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionTextProperty =
            DependencyProperty.Register("_CaptionText", typeof(string), typeof(hComboBoxEdit), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((hComboBoxEdit)d)._CaptionVisibility = string.IsNullOrEmpty(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(hComboBoxEdit), new PropertyMetadata(Visibility.Collapsed));



        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember", typeof(string), typeof(hComboBoxEdit), new PropertyMetadata(string.Empty));



        public string ValueMember
        {
            get { return (string)GetValue(ValueMemberProperty); }
            set { SetValue(ValueMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueMemberProperty =
            DependencyProperty.Register("ValueMember", typeof(string), typeof(hComboBoxEdit), new PropertyMetadata(string.Empty));





        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(hComboBoxEdit), new PropertyMetadata(null));




        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(hComboBoxEdit), new PropertyMetadata(null));



        public object EditValue
        {
            get { return (object)GetValue(EditValueProperty); }
            set { SetValue(EditValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditValueProperty =
            DependencyProperty.Register("EditValue", typeof(object), typeof(hComboBoxEdit), new PropertyMetadata(null));

        private void ComboBoxEdit_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (IsValidEmpty)
            {
                if (string.IsNullOrWhiteSpace(e.Value?.ToString()))
                {
                    e.IsValid = false;
                    sb.AppendLine("Trường dữ liệu không được để trống");
                }
            }

            if (sb.Length > 0)
            {
                e.ErrorContent = sb.ToString();
            }
        }




        public bool IsValidEmpty
        {
            get { return (bool)GetValue(IsValidEmptyProperty); }
            set { SetValue(IsValidEmptyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValidEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidEmptyProperty =
            DependencyProperty.Register("IsValidEmpty", typeof(bool), typeof(hComboBoxEdit), new PropertyMetadata(false));

        private void ComboBoxEdit_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (Owner == null) { return; }
            IView v = (IView)Owner;
            if (v.IsFirstLoad) { return; }
            v.IsDataChanged = true;
        }
    }
}
