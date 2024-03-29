﻿using Common;
using eThanhTra.Controller.App;
using eThanhTra.Network;
using eThanhTra.Network.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Controller
{
    public class MyObject
    {
        //private static ILoginNetwork _ObjLogin;
        //public static ILoginNetwork ObjLogin
        //{
        //    get
        //    {
        //        if (_ObjLogin == null)
        //        {
        //            _ObjLogin = MyApp.Common.GetObjectController<ILoginNetwork, LoginOnline, LoginOffline>();
        //        }
        //        return _ObjLogin;
        //    }
        //}


        //private static IDanhMucNetwork _ObjDanhMuc;
        //public static IDanhMucNetwork ObjDanhMuc
        //{
        //    get
        //    {
        //        if (_ObjDanhMuc == null)
        //        {
        //            _ObjDanhMuc = MyApp.Common.GetObjectController<IDanhMucNetwork, DanhMucOnline, DanhMucOffline>();
        //        }
        //        return _ObjDanhMuc;
        //    }
        //}


        //private static INhatKyNetwork _ObjNhatKy;
        //public static INhatKyNetwork ObjNhatKy
        //{
        //    get
        //    {
        //        if (_ObjNhatKy == null)
        //        {
        //            _ObjNhatKy = MyApp.Common.GetObjectController<INhatKyNetwork, NhatKyOnline, NhatKyOffline>();
        //        }
        //        return _ObjNhatKy;
        //    }
        //}

        private static IDAONetwork _ObjApp;
        public static IDAONetwork ObjApp
        {
            get
            {
                if (_ObjApp == null)
                {
                    _ObjApp = MyApp.Common.GetObjectController<IDAONetwork, DAOOnline, DAOOffline>();
                }
                return _ObjApp;
            }
        }
    }
}
