using Common;
using eThanhTra.Controller;
using eThanhTra.Dto;
using eThanhTra.Model.NhatKy;
using eThanhTra.View.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel.NhatKy
{
    public class GiaHanThanhTraViewModel : BaseViewModel<IGiaHanTT, GiaHanThanhTraModel>
    {
        public GiaHanThanhTraViewModel(IGiaHanTT View) : base(View)
        {

        }

        public override async Task LoadView(object p = null)
        {
            if (_Model.ObjGiaHan == null)
            {
                _Model.ObjGiaHan = new DGiaHanTTDto()
                {
                    IdThanhTra = _Model.IdThanhTra
                };
                await Task.CompletedTask;
            }
        }

        public override async Task SaveView(object p = null)
        {
            MsgResult<DGiaHanTTDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjGiaHan);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjGiaHan = msgResult.Value;
        }
    }
}
