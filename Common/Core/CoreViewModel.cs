using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Core
{
    public class CoreViewModel : INotifyPropertyChanged
    {
        public CoreViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ICommand FirstLoadViewCommand { get; set; }
        public ICommand LoadViewCommand { get; set; }
        public ICommand CloseViewCommand { get; set; }
        public ICommand SaveViewCommand { get; set; }

        public virtual async Task LoadView()
        {
            await Task.CompletedTask;
        }

        public virtual async Task SaveView()
        {
            await Task.CompletedTask;
        }
    }
}
