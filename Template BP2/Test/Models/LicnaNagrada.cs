using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class LicnaNagrada
    {
        public int NagradaId { get; set; }
        public string VrstaNagrade { get; set; }
        public int? IgracIgracId { get; set; }

        public virtual Igrac IgracIgrac { get; set; }
        public virtual Nagrada Nagrada { get; set; }
    }
}
