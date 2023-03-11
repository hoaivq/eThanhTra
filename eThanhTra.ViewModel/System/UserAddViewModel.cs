using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model.System;
using eThanhTra.View.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.System
{
    public class UserAddViewModel : BaseViewModel<IUserAdd, UserAddModel>
    {
        public ICommand AddUserCommand { get; set; }
        public UserAddViewModel(IUserAdd View) : base(View)
        {
            //AddUserCommand = new RelayCommand<object> ((p) =>{return true; }, async (p) =>
            //{

            //    try {
            //        await _View.ShowWait("AddUserCommand", () => AddUser());
            //        _View.IsReload = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        _View.ShowMsg(ex, "AddUserCommand");
            //    }
            //});
        }

        public override async Task LoadView(object p = null)
        {
            if(_Model.User == null)
            {
                _Model.User = new SUserDto();
            }
            await Task.CompletedTask;
        }

        public override async Task SaveView(object p = null)
        {
            MsgResult<SUserDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.User);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.User = msgResult.Value;
        }
        //public async Task AddUser(SUserDto User)
        //{
        //    MsgResult<SUserDto> msgResult = await MyObject.ObjApp.SaveObject(User);
        //    if (msgResult.Success == false)
        //    {
        //        throw new Exception(msgResult.Message);
        //    }
        //    _Model.User = msgResult.Value;
        //}
    }
}
