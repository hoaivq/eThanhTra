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
    public class TamDungThanhTraViewModel : BaseViewModel<ITamDungTT, TamDungThanhTraModel>
    {
        public TamDungThanhTraViewModel(ITamDungTT view) : base(view)
        {

        }

        public override async Task LoadView(object p = null)
        {
            if (_Model.ObjTamDung == null)
            {
                _Model.ObjTamDung = new DThanhTraTamDungDto() { IDThanhTra = _Model.IdThanhTra };
            }
            await Task.CompletedTask;
        }
        
        public override async Task SaveView(object p = null)
        {
            MsgResult<DThanhTraTamDungDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjTamDung);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
        }
    }
}


