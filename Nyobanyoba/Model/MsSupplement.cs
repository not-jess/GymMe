//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nyobanyoba.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsSupplement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsSupplement()
        {
            this.MsCarts = new HashSet<MsCart>();
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }
    
        public int SupplementID { get; set; }
        public string SupplementName { get; set; }
        public System.DateTime SupplementExpiryDate { get; set; }
        public int SupplementPrice { get; set; }
        public int SupplementTypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MsCart> MsCarts { get; set; }
        public virtual MsSupplementType MsSupplementType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
