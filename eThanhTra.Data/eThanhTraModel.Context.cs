﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eThanhTra.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public partial class eThanhTraEntities : DbContext
    {
        public eThanhTraEntities()
            : base("name=eThanhTraEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<SCQT> SCQTs { get; set; }
        public virtual DbSet<SUser> SUsers { get; set; }
        public virtual DbSet<SUserCQT> SUserCQTs { get; set; }

        public virtual async Task<List<PGetUserByMaCQT_Result>> PGetUserByMaCQT(string maCQT)
        {
            var maCQTParameter = maCQT != null ?
                new SqlParameter("MaCQT", maCQT) :
                new SqlParameter("MaCQT", typeof(string));

            return await this.Database.SpQueryAsync<PGetUserByMaCQT_Result>("PGetUserByMaCQT", maCQTParameter);
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PGetUserByMaCQT_Result>("PGetUserByMaCQT", maCQTParameter);
        }

        public async virtual Task<List<PGetCQTByMaCQT_Result>> PGetCQTByMaCQT(string maCQTCha)
        {
            var maCQTChaParameter = maCQTCha != null ?
                new SqlParameter("MaCQTCha", maCQTCha) :
                new SqlParameter("MaCQTCha", typeof(string));

            return await this.Database.SpQueryAsync<PGetCQTByMaCQT_Result>("PGetCQTByMaCQT", maCQTChaParameter);
        }
    }
}
