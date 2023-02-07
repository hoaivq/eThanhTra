using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common
{
    public class BaseViewModel<T, TModel> : CoreViewModel where T : IView where TModel : BaseModel, new()
    {
        public T _View;
        public TModel _Model { get; set; } = new TModel();

        public BaseViewModel(T View)
        {
            _View = View;

            CloseViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                _View.CloseView();
                await Task.CompletedTask;
            });

            LoadViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await Task.CompletedTask;
            });
        }

    }
}
