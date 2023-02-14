using eThanhTra.Data.Ext.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eThanhTra.Data.Ext
{
    public class eThanhTraDB : eThanhTraEntities
    {
        public virtual DbSet<DThanhTraDto> DThanhTraDtos { get; set; }

        public async Task<List<PGetUserByMaCQT_Result>> PGetUserByMaCQT(string maCQT)
        {
            var maCQTParameter = maCQT != null ?
                new SqlParameter("MaCQT", maCQT) :
                new SqlParameter("MaCQT", typeof(string));

            return await this.Database.SpQueryAsync<PGetUserByMaCQT_Result>("PGetUserByMaCQT", maCQTParameter);
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PGetUserByMaCQT_Result>("PGetUserByMaCQT", maCQTParameter);
        }

        public async Task<List<PGetCQTByMaCQT_Result>> PGetCQTByMaCQT(string maCQTCha)
        {
            var maCQTChaParameter = maCQTCha != null ?
                new SqlParameter("MaCQTCha", maCQTCha) :
                new SqlParameter("MaCQTCha", typeof(string));

            return await this.Database.SpQueryAsync<PGetCQTByMaCQT_Result>("PGetCQTByMaCQT", maCQTChaParameter);
        }
    }
}
