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

        public ICommand FirstLoadCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddNewCommand { get; set; }

        public ICommand EditRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }

        public virtual async Task LoadView(object p = null)
        {
            await Task.CompletedTask;
        }

        public virtual async Task SaveView(object p = null)
        {
            await Task.CompletedTask;
        }

        public virtual async Task<bool> AddNewView(object p = null)
        {
            return await Task.FromResult(false);
        }

        public virtual async Task EditRow(object p = null)
        {
            await Task.CompletedTask;
        }

        public virtual async Task DeleteRow(object p = null)
        {
            await Task.CompletedTask;
        }
    }
}
