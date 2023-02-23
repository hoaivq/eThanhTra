using eThanhTra.Model.System;
using eThanhTra.View.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.ViewModel.System
{
    public class UserAddViewModel : BaseViewModel<IUserAdd, UserAddModel>
    {
        public UserAddViewModel(IUserAdd View) : base(View)
        {
        }
    }
}
