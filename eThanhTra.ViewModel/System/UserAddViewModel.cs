using Common.Core;
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
        public ICommand AddUsercommand { get; set; }
        public UserAddViewModel(IUserAdd View) : base(View)
        {
            AddUsercommand = new RelayCommand<object> ((p) =>{return true; }, async (p) =>
            {

                try {

                }
                catch (Exception)
                {

		            throw;
                }
            });
        }

        

        
    }
}
