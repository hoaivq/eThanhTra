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
    /// Interaction logic for hDateEdit.xaml
    /// </summary>
    public partial class hDateEdit : UserControl
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

        public hDateEdit()
        {
            InitializeComponent();
        }

        // Caption
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
            DependencyProperty.Register("_CaptionText", typeof(string), typeof(hDateEdit), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((hDateEdit)d)._CaptionVisibility = string.IsNullOrEmpty(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(hDateEdit), new PropertyMetadata(Visibility.Collapsed));


        public DateTime? EditValue
        {
            get { return (DateTime?)GetValue(EditValueProperty); }
            set { SetValue(EditValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for EditValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditValueProperty =
            DependencyProperty.Register("EditValue", typeof(DateTime?), typeof(hDateEdit), new PropertyMetadata(null));


        public DateTime? DateTime
        {
            get{return (DateTime?)GetValue(DateTimeProperty);}
            set{SetValue(DateTimeProperty, value);}
        }
        // Using a DependencyProperty as the backing store for DateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime?), typeof(hDateEdit), new PropertyMetadata(null));


        public string DisplayFormatString
        {
            get { return (string)GetValue(DisplayFormatStringProperty); }
            set { SetValue(DisplayFormatStringProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DisplayFormatString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayFormatStringProperty =
            DependencyProperty.Register("DisplayFormatString", typeof(string), typeof(hDateEdit), new PropertyMetadata("dd/MM/yyyy"));

        public bool IsValidEmpty
        {
            get { return (bool)GetValue(IsValidEmptyProperty); }
            set { SetValue(IsValidEmptyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValidEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidEmptyProperty =
            DependencyProperty.Register("IsValidEmpty", typeof(bool), typeof(hDateEdit), new PropertyMetadata(false));


        public ICommand EditValueChangedCommand
        {
            get { return (ICommand)GetValue(EditValueChangedCommandProperty); }
            set { SetValue(EditValueChangedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditValueChangedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditValueChangedCommandProperty =
            DependencyProperty.Register("EditValueChangedCommand", typeof(ICommand), typeof(hDateEdit), new PropertyMetadata(null));

        private void DateEdit_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (Owner == null) { return; }
            IView v = (IView)Owner;
            if (v.IsFirstLoad) { return; }
            v.IsDataChanged = true;
        }

        private void DateEdit_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (IsValidEmpty)
            {
                if (e.Value == null)
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
    }
}
