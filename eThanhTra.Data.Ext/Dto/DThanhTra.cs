using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Data.Ext.Dto
{
    public class DThanhTraDto : DThanhTra
    {
        public string MaCQTDto
        {
            get { return MaCQT; }
            set { MaCQT = value; OnPropertyChanged(); }
        }
    }
}
