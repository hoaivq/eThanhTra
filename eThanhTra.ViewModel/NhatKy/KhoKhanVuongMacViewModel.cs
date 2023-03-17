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
using System.Windows.Input;

namespace eThanhTra.ViewModel.NhatKy
{
    public class KhoKhanVuongMacViewModel : BaseViewModel<IKhoKhanVuongMac,KhoKhanVuongMacModel>
    {
        
        public KhoKhanVuongMacViewModel(IKhoKhanVuongMac View) : base(View) 
        {
            
        }

        public override async Task LoadView(object p = null)
        {
            if(_Model.ObjKhoKhanVuongMac == null)
            {
                _Model.ObjKhoKhanVuongMac = new DThanhTraKKVMDto() { IdThanhTra = _Model.IdThanhTra };
            }
            await Task.CompletedTask;
        }

        public override async Task SaveView(object p = null)
        {
            MsgResult<DThanhTraKKVMDto> msgResult = await MyObject.ObjApp.SaveObject(_Model.ObjKhoKhanVuongMac);
            if (msgResult.Success == false)
            {
                throw new Exception(msgResult.Message);
            }
            _Model.ObjKhoKhanVuongMac = msgResult.Value;
        }
    }
} 
