//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FudbalskiKup.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stadion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stadion()
        {
            this.Odrzavas = new HashSet<Odrzava>();
        }
    
        public int StadionID { get; set; }
        public string Ime { get; set; }
        public int Grad_GradID { get; set; }
    
        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odrzava> Odrzavas { get; set; }
    }
}