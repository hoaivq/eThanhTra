using Common.Core;
using eThanhTra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.View.NhatKy
{
    public interface IThanhTra : IView
    {
        Task<bool> ShowDetail(DThanhTraDto dThanhTraDto = null);
    }
}
