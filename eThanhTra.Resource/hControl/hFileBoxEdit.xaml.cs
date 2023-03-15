using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static Common.Core.Enums;

namespace eThanhTra.Resource
{
    /// <summary>
    /// Interaction logic for hFileBoxEdit.xaml
    /// </summary>
    public partial class hFileBoxEdit : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        public long? IdCha
        {
            get { return (long?)GetValue(IdChaProperty); }
            set { SetValue(IdChaProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IdCha.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdChaProperty =
            DependencyProperty.Register("IdCha", typeof(long?), typeof(hFileBoxEdit), new PropertyMetadata(OnIdChaChangedCallBack));

        private static async void OnIdChaChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            hFileBoxEdit hFileBoxEdit = sender as hFileBoxEdit;
            if (hFileBoxEdit.ListFile != null)
            {
                foreach (DFileDto dto in hFileBoxEdit.ListFile)
                {
                    if (dto.FileMode == (int)EFileMode.Add)
                    {
                        dto.IdCha = e.NewValue.ToLong();
                        dto.FileData = Convert.ToBase64String(File.ReadAllBytes(dto.FilePath));
                    }
                }

                MsgResult<ObservableCollection<DFileDto>> msgResult = await MyObject.ObjApp.SaveFile(hFileBoxEdit.ListFile);
                if (msgResult.Success == false)
                {
                    System.Windows.MessageBox.Show(msgResult.Message);
                    return;
                }
                hFileBoxEdit.ListFile = msgResult.Value;
            }
        }

        public string TableName
        {
            get { return (string)GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TableName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TableNameProperty =
            DependencyProperty.Register("TableName", typeof(string), typeof(hFileBoxEdit), new PropertyMetadata(string.Empty));



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
            DependencyProperty.Register("_CaptionText", typeof(string), typeof(hFileBoxEdit), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((hFileBoxEdit)d)._CaptionVisibility = string.IsNullOrEmpty(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(hFileBoxEdit), new PropertyMetadata(Visibility.Collapsed));


        private ObservableCollection<DFileDto> _ListFile;
        public ObservableCollection<DFileDto> ListFile
        {
            get { return _ListFile; }
            set
            {
                _ListFile = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddFileCommand { get; set; }
        public ICommand ViewFileCommand { get; set; }
        public ICommand DeleteFileCommand { get; set; }

        public hFileBoxEdit()
        {
            InitializeComponent();

            AddFileCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Multiselect = true;
                    bool? result = ofd.ShowDialog();
                    if (result.HasValue && result.Value)
                    {
                        foreach (string FileName in ofd.FileNames)
                        {
                            FileInfo fi = new FileInfo(FileName);
                            DFileDto dto = new DFileDto();
                            dto.IdCha = IdCha;
                            dto.TableName = TableName;
                            dto.FilePath = fi.FullName;
                            dto.FileName = fi.Name;
                            dto.FileSize = fi.Length;
                            dto.FileType = fi.Extension;
                            dto.FileMode = (int)EFileMode.Add;

                            if (IdCha.HasValue)
                            {
                                dto.FileData = Convert.ToBase64String(File.ReadAllBytes(dto.FilePath));
                            }

                            ListFile.Add(dto);
                        }

                        if (IdCha.HasValue)
                        {
                            MsgResult<ObservableCollection<DFileDto>> msgResult = await MyObject.ObjApp.SaveFile(ListFile);
                            if (msgResult.Success == false)
                            {
                                throw new Exception(msgResult.Message);
                            }
                            ListFile = msgResult.Value;
                        }
                    }

                    //DataView dv = ListFile.DefaultView;
                    //dv.RowFilter = "FileMode <> " + (int)EFileMode.Delete;
                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            ViewFileCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    DFileDto dto = (DFileDto)p;

                    if (string.IsNullOrEmpty(dto.FilePath))
                    {
                        if (dto.Id.HasValue)
                        {
                            MsgResult<string> msgResult = await MyObject.ObjApp.ViewFile(dto.Id.Value);
                            if (msgResult.Success == false)
                            {
                                throw new Exception(msgResult.Message);
                            }
                            dto.FileData = msgResult.Value;
                            string FileDir = MyApp.Common.PathCombine(MyApp.Setting.AppPath, dto.TableName, IdCha.Value.ToString());
                            if (Directory.Exists(FileDir) == false) { Directory.CreateDirectory(FileDir); }
                            dto.FilePath = MyApp.Common.PathCombine(FileDir, dto.FileName);
                            File.WriteAllBytes(dto.FilePath, Convert.FromBase64String(dto.FileData));
                            Process.Start(dto.FilePath);
                        }
                    }
                    else
                    {
                        Process.Start(dto.FilePath);
                    }

                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteFileCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    DFileDto dto = (DFileDto)p;
                    dto.FileMode = (int)EFileMode.Delete;

                    if (dto.Id.HasValue)
                    {
                        await MyObject.ObjApp.DeleteFile(dto.Id.Value);
                    }

                    ListFile.Remove(dto);
                    //DataView dv = ListFile.DefaultView;
                    //dv.RowFilter = "FileMode <> " + (int)EFileMode.Delete;

                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MsgResult<ObservableCollection<DFileDto>> msgResult = await MyObject.ObjApp.GetListFile(CallSPDto.Create("PGetListFile",
                new SqlParam("IdCha", IdCha, SqlDbType.BigInt)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            ListFile = msgResult.Value;
        }
    }
}
