using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    // Hoaivq
    public class SUser
    {
        public string UserName { get; set; }

        private string Password { get; set; }

        public int UserType { get; set; }

        public string HoVaTen { get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public string MaCQT { get; set; }

        public bool IsEnable { get; set; }

    }

}