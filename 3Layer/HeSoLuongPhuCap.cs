//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _3Layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeSoLuongPhuCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HeSoLuongPhuCap()
        {
            this.LichSuChuyenBacs = new HashSet<LichSuChuyenBac>();
            this.NhanViens = new HashSet<NhanVien>();
        }
    
        public int id { get; set; }
        public string MaHeSo { get; set; }
        public string TenHeSo { get; set; }
        public double HeSo { get; set; }
        public string MaNgach { get; set; }
    
        public virtual NgachLuong NgachLuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuChuyenBac> LichSuChuyenBacs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
