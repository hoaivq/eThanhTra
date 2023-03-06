using Common.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.View.NhatKy
{
    public interface IThemMoiNhatKy : IView
    {
        Task<string> ShowUserChon(long IdThanhTra);
        Task<long?> ShowAddNewCongViec(long IdThanhTra, DataRowView RowCongViec);
    }
}
