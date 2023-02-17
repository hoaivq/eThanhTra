using Common;
using Common.Core;
using eThanhTra.Controller;
using eThanhTra.Data;
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

        public override Task LoadView()
        {
            _Model.ObjThanhTra = new DThanhTraDto();
            _Model.ObjThanhTra.MaCQT = AppViewModel.MyUser.MaCQT;
            _Model.ObjThanhTra._NgayCongBo = DateTime.Now;
            _Model.ObjThanhTra._ThoiGian = 10;

            _Model.ObjThanhTra.UpdateChange();
            return base.LoadView();
        }

        public async override Task SaveView()
        {
            //MsgResult<DThanhTraDto> msgResult = await MyObject.ObjNhatKy.Save(_Model.ObjThanhTra);
            //_Model.ObjThanhTra = msgResult.Value;
        }
    }
}
