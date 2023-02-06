using Common;
using eThanhTra.Controller.Login;
using eThanhTra.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller
{
    public class MyObject
    {
        private static ILoginNetwork _ObjLogin;
        public static ILoginNetwork ObjLogin
        {
            get
            {
                if (_ObjLogin == null)
                {
                    _ObjLogin = MyApp.Common.GetObjectController<ILoginNetwork, LoginOnline, LoginOffline>();
                }
                return _ObjLogin;
            }
        }
    }
}
