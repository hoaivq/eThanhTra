using Common;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model.NhatKy;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel.NhatKy
{
    public class ThemMoiCongViecViewModel : BaseViewModel<IThemMoiCongViec, ThemMoiCongViecModel>
    {
        public ThemMoiCongViecViewModel(IThemMoiCongViec View) : base(View)
        {
        }

        public async override Task LoadView(object p = null)
        {
            if (_Model.ObjCongViec == null)
            {
                _Model.ObjCongViec = new DThanhTraCongViecDto();
                _Model.ObjCongViec.IdThanhTra = _Model.IdThanhTra;
                _Model.ObjCongViec.NgayBatDau = DateTime.Now;
            }
            await Task.CompletedTask;
        }

        public async override Task SaveView(object p = null)
        {
            MsgResult<DThanhTraCongViecDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjCongViec);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjCongViec = msgResult.Value;
        }
    }
}
