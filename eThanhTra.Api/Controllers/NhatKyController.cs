using eThanhTra.Network.NhatKy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eThanhTra.Data;
using Common;
using System.Threading.Tasks;

namespace eThanhTra.Api.Controllers
{
    public class NhatKyController : AppController, INhatKyNetwork
    {
        public async Task<MsgResult<DThanhTraDto>> Save(DThanhTraDto input)
        {
            try
            {
                using (eThanhTraDB db = new eThanhTraDB())
                {
                    DThanhTra output = input.Cast<DThanhTra>();
                    if (input.Id.HasValue())
                    {
                        output = db.DThanhTras.FirstOrDefault(c => c.Id == input.Id);
                        output.GetData(input);
                    }
                    else
                    {
                        db.DThanhTras.Add(output);
                    }
                    await db.SaveChangesAsync();

                    return new MsgResult<DThanhTraDto>(true, output.Cast<DThanhTraDto>());
                }
            }
            catch (Exception ex)
            {
                return new MsgResult<DThanhTraDto>("NhatKyController.Save", ex);
            }
        }
    }
}
