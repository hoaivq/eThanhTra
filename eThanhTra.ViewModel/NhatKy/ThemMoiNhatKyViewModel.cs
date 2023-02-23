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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eThanhTra.ViewModel.NhatKy
{
    public class ThemMoiNhatKyViewModel : BaseViewModel<IThemMoiNhatKy, ThemMoiNhatKyModel>
    {

        public ThemMoiNhatKyViewModel(IThemMoiNhatKy View) : base(View)
        {
        }

        public override async Task LoadView(object p = null)
        {
            if (_Model.ObjThanhTra == null)
            {
                _Model.ObjThanhTra = new DThanhTraDto();
                _Model.ObjThanhTra.MaCQT = AppViewModel.MyUser.MaCQT;
                _Model.ObjThanhTra.NgayCongBo = DateTime.Now;
                _Model.ObjThanhTra.ThoiGian = 10;
            }
            await base.LoadView();
        }

        public async override Task SaveView(object p = null)
        {
            MsgResult<DThanhTraDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjThanhTra);
            if(msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjThanhTra = msgResult.Value;
        }
    }
}
