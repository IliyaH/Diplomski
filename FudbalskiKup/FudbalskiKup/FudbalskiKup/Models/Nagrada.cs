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
    
    public partial class Nagrada
    {
        public int NagradaID { get; set; }
    
        public virtual LicnaNagrada LicnaNagrada { get; set; }
        public virtual TimskaNagrada TimskaNagrada { get; set; }
    }
}
