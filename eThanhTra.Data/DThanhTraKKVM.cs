//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DThanhTraKKVM
    {
        public int Id { get; set; }
        public Nullable<long> IdThanhTra { get; set; }
        public string NoiDung { get; set; }
        public string NguyenNhan { get; set; }
    
        public virtual DThanhTra DThanhTra { get; set; }
    }
}