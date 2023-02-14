using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Model
{
    public class LoginModel : BaseModel
    {
        public string UserName { get; set; } = "HOAIVQ";
        public string Password { get; set; } = string.Empty;
    }
}
