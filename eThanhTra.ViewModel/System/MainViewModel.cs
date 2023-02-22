using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Data;
using eThanhTra.Model;
using eThanhTra.Model.System;
using eThanhTra.View;
using eThanhTra.View.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.System
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
                    //msgResult = await MyObject.ObjApp.GetTable(new CallSPDto("PGetLichLamViec", new SqlParam("Nam", 2000)));

                    if (AppViewModel.DanhMucChung != null && AppViewModel.DanhMucChung.Tables.Count > 0) { return; }
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
                AppViewModel.DanhMucChung = new DataSet("DanhMucChung");
                msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetCQTByMaCQT", new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5)));
                if (msgResult.Success)
                {
                    AppViewModel.DanhMucChung.Tables.Add(msgResult.Value);
                }

                msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetUserByMaCQT", new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5)));
                if (msgResult.Success)
                {
                    AppViewModel.DanhMucChung.Tables.Add(msgResult.Value);
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
