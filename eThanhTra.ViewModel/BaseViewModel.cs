using Common;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel
{
    public class BaseViewModel<T, TModel> : CoreViewModel where T : IView where TModel : BaseModel, new()
    {
        public T _View;
        public TModel _Model { get; set; } = new TModel();
        public MsgResult<DataTable> msgResult { get; set; }

        public bool IsFirstLoad { get; set; } = true;
        public BaseViewModel(T View)
        {
            _View = View;

            CloseViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await _View.CloseView();
            });

            FirstLoadViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await View.ShowWait("LoadView", () => LoadView());
                    IsFirstLoad = false;
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "FirstLoadViewCommand");
                }
            });

            LoadViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (_View.IsFirstLoad) { return; }

                try
                {
                    await View.ShowWait("LoadView", () => LoadView());
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "FirstLoadViewCommand");
                }
            });

            SaveViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await SaveView();
            });
        }


    }
}
