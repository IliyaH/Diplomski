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
    
    public partial class LicnaNagrada
    {
        public int NagradaID { get; set; }
        public string VrstaNagrade { get; set; }
        public Nullable<int> Igrac_IgracID { get; set; }
    
        public virtual Igrac Igrac { get; set; }
        public virtual Nagrada Nagrada { get; set; }
    }
}
