using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Nagrada
    {
        public int NagradaId { get; set; }

        public virtual LicnaNagrada LicnaNagrada { get; set; }
        public virtual TimskaNagrada TimskaNagrada { get; set; }
    }
}
