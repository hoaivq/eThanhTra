using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core
{
    public class AppViewModel
    {
        public static SUserDto MyUser { get; set; } = null;
        public static DataSet DanhMucChung { get; set; } = null;

        private static DataTable _ListTrangThai = null;
        public static DataTable ListTrangThai
        {
            get
            {
                if (_ListTrangThai == null)
                {
                    _ListTrangThai = new DataTable();
                    _ListTrangThai.Columns.Add("Ma", typeof(int));
                    _ListTrangThai.Columns.Add("Ten", typeof(string));

                    _ListTrangThai.AddRow(0, "Chờ công bố");
                    _ListTrangThai.AddRow(1, "Đang tiến hành");
                    _ListTrangThai.AddRow(2, "Đã kết thúc");
                }


                return _ListTrangThai;
            }
        }
    }


}
