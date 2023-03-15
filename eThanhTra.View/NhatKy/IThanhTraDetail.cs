using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.View.NhatKy
{
    public interface IThanhTraDetail : IView
    {
        Task<bool> OpenGiaHanView(long idThanhTra);
        Task<bool> ShowChiTiet(DThanhTraThanhVienCongViecChiTietDto dChiTietDto, long IdThanhTra, long? IdThanhVien,DateTime NgayNhatKy);
        void ScrollView();
    }
}
