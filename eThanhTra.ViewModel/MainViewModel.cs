using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Model;
using eThanhTra.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel
{
    public class MainViewModel : BaseViewModel<IMain, MainModel>
    {
        public ICommand LoadDanhMucCommand { get; set; }

        BackgroundWorker bgwLoadDanhMuc = new BackgroundWorker();
        public MainViewModel(IMain View) : base(View)
        {
            bgwLoadDanhMuc.DoWork += BgwLoadDanhMuc_DoWork;
            bgwLoadDanhMuc.RunWorkerCompleted += BgwLoadDanhMuc_RunWorkerCompleted;

            LoadDanhMucCommand = new RelayCommand<object>((p) => { return !bgwLoadDanhMuc.IsBusy; }, async (p) =>
            {
                try
                {
                    if (AppViewModel.DsDanhMucChung != null) { return; }
                    bgwLoadDanhMuc.RunWorkerAsync();
                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    View.ShowMsg(ex, "LoadDanhMucCommand");
                }
            });
        }

        private async void BgwLoadDanhMuc_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MsgResult<DataSet> msgResult = await MyObject.ObjDanhMuc.GetDanhMucChung();
                if (msgResult.Success)
                {
                    AppViewModel.DsDanhMucChung = msgResult.Value;
                }
            }
            catch (Exception ex)
            {
                MyApp.Log.GhiLog("BgwLoadDanhMuc_DoWork", ex);
            }
        }

        private void BgwLoadDanhMuc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


    }
}
