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
    
    public partial class DThanhTraGiaHan
    {
        public int Id { get; set; }
        public string SoQuyetDinh { get; set; }
        public long IDThanhTra { get; set; }
        public Nullable<int> SoNgay { get; set; }
        public Nullable<System.DateTime> BatDauGH { get; set; }
        public Nullable<System.DateTime> KetThucGH { get; set; }
        public string LyDoGH { get; set; }
    
        public virtual DThanhTra DThanhTra { get; set; }
    }
}
