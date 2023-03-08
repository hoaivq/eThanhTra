using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model;
using eThanhTra.Model.NhatKy;
using eThanhTra.View;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Common.Core.Enums;

namespace eThanhTra.ViewModel.NhatKy
{
    public class ThanhTraAddViewModel : BaseViewModel<IThanhTraAdd, ThanhTraAddModel>
    {
        public ICommand LoadThanhVienCongViecCommand { get; set; }
        public ICommand AddNewThanhVienCommand { get; set; }
        public ICommand AddNewCongViecCommand { get; set; }
        public ICommand UpdateThanhVienCongViecCommand { get; set; }
        public ICommand CongBoCommand { get; set; }

        public ThanhTraAddViewModel(IThanhTraAdd View) : base(View)
        {
            LoadThanhVienCongViecCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await LoadThanhVienCongViec();
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "FirstLoadCommand");
                }
            });

            AddNewThanhVienCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await AddNewThanhVien(p);
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "AddNewThanhVienCommand");
                }
            });

            AddNewCongViecCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await AddNewCongViec(p);
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "AddNewCongViecCommand");
                }
            });

            UpdateThanhVienCongViecCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await _View.ShowWait("UpdateThanhVienCongViecCommand", () => UpdateThanhVienCongViec(p));
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "UpdateThanhVienCongViecCommand");
                }
            });

            CongBoCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await _View.ShowWait("CongBoCommand", () => CongBo(p));
                    _View.IsReload = true;
                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "CongBoCommand");
                }
            });
        }

        public override async Task LoadView(object p = null)
        {
            await LoadListUser();
            await LoadThongTinChung();
            await LoadThanhVien();
            await LoadCongViec();
            await LoadThanhVienCongViec();
        }

        private async Task LoadListUser()
        {
            long? IdThanhTra = _Model.ObjThanhTra?.Id;
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListUser",
                  new SqlParam("MaCQT", AppViewModel.MyUser.MaCQT, SqlDbType.VarChar, 5),
                  new SqlParam("IdThanhTra", IdThanhTra, SqlDbType.BigInt),
                  new SqlParam("VaiTro", 1, SqlDbType.Int)
                  ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListUser = msgResult.Value;
        }

        private async Task LoadThongTinChung()
        {
            if (_Model.ObjThanhTra == null)
            {
                _Model.ObjThanhTra = new DThanhTraDto();
                _Model.ObjThanhTra.MaCQT = AppViewModel.MyUser.MaCQT;
                _Model.ObjThanhTra.NgayCongBo = DateTime.Now;
                _Model.ObjThanhTra.ThoiGian = 10;
            }
            await Task.CompletedTask;
        }

        private async Task LoadThanhVien()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListThanhVien",
                   new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListThanhVien = msgResult.Value;
        }

        private async Task LoadCongViec()
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListCongViec",
                   new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListCongViec = msgResult.Value;
        }

        private async Task LoadThanhVienCongViec(long? IdCongViec = null)
        {
            if (IdCongViec.HasValue == false)
            {
                if (_Model.RowCongViec == null)
                {
                    if (_Model.ListCongViec.Rows.Count == 0)
                    {
                        return;
                    }
                    _Model.RowCongViec = _Model.ListCongViec.DefaultView[0];
                }
            }
            else
            {
                _Model.RowCongViec = _Model.ListCongViec.GetDataRowViewById(IdCongViec);
            }

            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListThanhVienCongViec",
                new SqlParam("IdThanhTra", _Model.ObjThanhTra.Id, SqlDbType.BigInt),
                new SqlParam("IdCongViec", _Model.RowCongViec.Row["Id"].ToInt().Value, SqlDbType.BigInt)
            ));

            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }

            _Model.ListThanhVienCongViec = msgResult.Value;
        }


        public async override Task SaveView(object p = null)
        {
            MsgResult<DThanhTraDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjThanhTra);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjThanhTra = msgResult.Value;
        }



        private async Task AddNewThanhVien(object p)
        {
            string UserName = await _View.ShowUserChon(_Model.ObjThanhTra.Id.Value);

            if (string.IsNullOrEmpty(UserName) == false)
            {
                DThanhTraThanhVienDto dThanhTraThanhVienDto = new DThanhTraThanhVienDto()
                {
                    IdThanhTra = _Model.ObjThanhTra.Id,
                    IsEnable = true,
                    UserName = UserName,
                    VaiTro = 2,
                };

                await MyObject.ObjApp.SaveObject(dThanhTraThanhVienDto);
                await LoadListUser();
                await LoadThanhVien();
                await LoadThanhVienCongViec();
            }
        }

        private async Task AddNewCongViec(object p)
        {
            long? IdCongViec = await _View.ShowAddNewCongViec(_Model.ObjThanhTra.Id.Value, null);

            if (IdCongViec.HasValue)
            {
                await LoadCongViec();
                await LoadThanhVienCongViec(IdCongViec);
            }
        }

        private async Task UpdateThanhVienCongViec(object p)
        {
            DataRow dr = ((DataRowView)p).Row;
            DThanhTraThanhVienCongViecDto dThanhTraThanhVienCongViecDto = dr.ToObject<DThanhTraThanhVienCongViecDto>();
            MsgResult<DThanhTraThanhVienCongViecDto> msgResult = await MyObject.ObjApp.SaveObject(dThanhTraThanhVienCongViecDto);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
        }

        private async Task CongBo(object p = null)
        {
            _Model.ObjThanhTra.TrangThai = (int)ETrangThai.DangTienHanh;
            MsgResult<DThanhTraDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjThanhTra);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjThanhTra = msgResult.Value;
        }

        public override async Task EditRow(object p = null)
        {
            long? IdCongViec = await _View.ShowAddNewCongViec(_Model.ObjThanhTra.Id.Value, ((DataRowView)p));

            if (IdCongViec.HasValue)
            {
                await LoadCongViec();
                await LoadThanhVienCongViec(IdCongViec);
            }
        }
        public override async Task DeleteRow(object p = null)
        {
            DataRow dr = ((DataRowView)p).Row;
            if (dr.Table.TableName == "PGetListCongViec")
            {
                MsgResult<object> msgResult = await MyObject.ObjApp.DeleteObject(DeleteDto.Create("DThanhTraCongViec", dr["Id"].ToLong().Value));
                if (msgResult.Success == false)
                {
                    throw new Exception(msgResult.Message);
                }

                dr.Delete();
            }
            else
            {
                MsgResult<object> msgResult = await MyObject.ObjApp.DeleteObject(DeleteDto.Create("DThanhTraThanhVien", dr["Id"].ToLong().Value));
                if (msgResult.Success == false)
                {
                    throw new Exception(msgResult.Message);
                }

                dr.Delete();
                await LoadListUser();
                await LoadThanhVienCongViec();
            }
        }
    }
}
