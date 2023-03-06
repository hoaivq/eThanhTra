using Common;
using Common.Core;
using DevExpress.Xpf.Editors;
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
    /// Interaction logic for hSpinEdit.xaml
    /// </summary>
    public partial class hSpinEdit : SpinEdit
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

        public hSpinEdit()
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
           DependencyProperty.Register("_CaptionText", typeof(string), typeof(hSpinEdit), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((hSpinEdit)d)._CaptionVisibility = string.IsNullOrEmpty(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }
        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(hSpinEdit), new PropertyMetadata(Visibility.Collapsed));

        public bool IsValidEmpty
        {
            get { return (bool)GetValue(IsValidEmptyProperty); }
            set { SetValue(IsValidEmptyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValidEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidEmptyProperty =
            DependencyProperty.Register("IsValidEmpty", typeof(bool), typeof(hSpinEdit), new PropertyMetadata(false));

        protected override void OnTextChanged(string oldText, string text)
        {
            base.OnTextChanged(oldText, text);
            if (Owner == null) { return; }
            IView v = (IView)Owner;
            if (v.IsFirstLoad) { return; }
            v.IsDataChanged = true;
        }
        private void SpinEdit_Validate(object sender, ValidationEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (IsValidEmpty)
            {
                if (e.Value == null)
                {
                    e.IsValid = false;
                    sb.AppendLine("Trường dữ liệu không được để trống");
                }
                else if (e.Value.ToLong().Value <= 0)
                {
                    e.IsValid = false;
                    sb.AppendLine("Trường dữ liệu phải > 0");
                }
            }

            if (sb.Length > 0)
            {
                e.ErrorContent = sb.ToString();
            }
        }
    }
}
