using System;
using System.Collections.Generic;
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
}
