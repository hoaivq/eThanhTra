using Common;
using Common.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public BaseViewModel(T View)
        {
            _View = View;

            CloseCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await _View.CloseView();
            });

            FirstLoadCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    _View.IsFirstLoad = true;
                    await View.ShowWait("LoadView", () => LoadView(p));
                    _View.IsFirstLoad = false;
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "FirstLoadCommand");
                }
            });

            LoadCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (_View.IsFirstLoad) { return; }

                try
                {
                    await _View.ShowWait("LoadView", () => LoadView(p));
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "LoadCommand");
                }
            });

            SaveCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    if (_View.IsValid == false)
                    {
                        _View.ShowMsg("Trường dữ liệu nhập chưa chính xác, vui lòng kiểm tra lại!");
                        return;
                    }
                    await _View.ShowWait("SaveView", () => SaveView(p));
                    _View.ShowFlashMsg();
                    _View.IsReload = true;
                    _View.IsDataChanged = false;
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "SaveCommand");
                }
            });


            AddNewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    bool IsReload = await _View.ShowWait("AddNewView", () => AddNewView(p));
                    if (IsReload)
                    {
                        await LoadView();
                    }
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "AddNewCommand");
                }
            });
        }


    }
}
