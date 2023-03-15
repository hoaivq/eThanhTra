using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Dto
{
    public class BaseDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class CheckBoxDto : BaseDto
    {
        private string _Ma;
        public string Ma
        {
            get { return _Ma; }
            set { _Ma = value; OnPropertyChanged(); }
        }


        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; OnPropertyChanged(); }
        }

        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; OnPropertyChanged(); }
        }

    }

    public class DListFile
    {
        public ObservableCollection<DFileDto> ListFile { get; set; }
    }
    public class DFileDto : BaseDto
    {
        private long? _Id;
        public long? Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }

        private long? _IdCha;
        public long? IdCha { get { return _IdCha; } set { _IdCha = value; OnPropertyChanged(); } }

        private string _TableName;
        public string TableName { get { return _TableName; } set { _TableName = value; OnPropertyChanged(); } }

        private string _FileName;
        public string FileName { get { return _FileName; } set { _FileName = value; OnPropertyChanged(); } }

        private string _FileType;
        public string FileType { get { return _FileType; } set { _FileType = value; OnPropertyChanged(); } }

        private double? _FileSize;
        public double? FileSize { get { return _FileSize; } set { _FileSize = value; OnPropertyChanged(); } }

        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; OnPropertyChanged(); } }

        private int _FileMode;
        public int FileMode
        {
            get { return _FileMode; }
            set { _FileMode = value; OnPropertyChanged(); }
        }

        private string _FilePath;
        public string FilePath { get { return _FilePath; } set { _FilePath = value; OnPropertyChanged(); } }

        private string _FileData;
        public string FileData { get { return _FileData; } set { _FileData = value; OnPropertyChanged(); } }
    }


}
