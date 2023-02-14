using Common;
using Common.Core;
using eThanhTra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace eThanhTra.Api.Controllers
{
    public partial class AppController : ApiController
    {
        public SUser MyUser
        {
            get
            {
                if (Request == null)
                {
                    return new SUser
                    {
                        UserName = AppViewModel.MyUser.UserName,// Request.GetHeader("UserName"),
                        MaCQT = AppViewModel.MyUser.MaCQT,
                        UserType = AppViewModel.MyUser.UserType,
                    };
                }
                else
                {
                    return new SUser
                    {
                        UserName = Request.GetHeader("UserName"),
                        MaCQT = Request.GetHeader("MaCQT"),
                        UserType = Request.GetHeader("UserType").ToInt(),
                    };
                }
            }
        }
    }
}