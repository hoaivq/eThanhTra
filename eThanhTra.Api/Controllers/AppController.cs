using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace eThanhTra.Api.Controllers
{
    public class AppController : ApiController
    {
        public SUser MyUser
        {
            get
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