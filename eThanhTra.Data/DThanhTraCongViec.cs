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
    
    public partial class DThanhTraCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DThanhTraCongViec()
        {
            this.DThanhTraThanhVienCongViecs = new HashSet<DThanhTraThanhVienCongViec>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdThanhTra { get; set; }
        public string TenCongViec { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DThanhTra DThanhTra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DThanhTraThanhVienCongViec> DThanhTraThanhVienCongViecs { get; set; }
    }
}
