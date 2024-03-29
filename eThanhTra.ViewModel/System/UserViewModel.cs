﻿using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model.System;
using eThanhTra.View.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.System
{
    public class UserViewModel : BaseViewModel<IUser, UserModel> 
    {
        public ICommand AddUserCommand { get; set; }
        
        public UserViewModel(IUser View) : base(View)
        {
            AddUserCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                try
                {
                    //await _View.ShowChiTiet(((DataRowView)p)?.Row.ToObject<DThanhTraDto>());


                }
                catch (Exception ex)
                {
                    _View.ShowMsg(ex, "AddUserCommand");
                }
            });

            //AddEditCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            //{
            //    try
            //    {
                    
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //});
        }

        public override async Task LoadView(object p = null)
        {
            msgResult = await MyObject.ObjApp.GetTable(CallSPDto.Create("PGetListUser"));

            if (msgResult.Success == false)
            {
                _View.ShowMsg(msgResult.Message);
                return;
            }

            _Model.ListUser = msgResult.Value;
            //string GenClass =  _Model.ListUser.GenClass();
        }

        public override async Task<bool> AddEditView(object p = null)
        {
            SUserDto sUserDto = ((DataRowView)p)?.Row.ToObject<SUserDto>();
            return await _View.ShowDetail(sUserDto);
        }
    }
}
