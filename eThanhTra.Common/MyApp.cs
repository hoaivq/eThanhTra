using Common;
using eThanhTra.Common.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Common
{
    public class MyApp 
    {
        public static AppDao Dao = new AppDao();
        public static AppLog Log = new AppLog();
        public static AppSetting Setting = new AppSetting();
        public static AppCommon Common = new AppCommon();
    }
}
