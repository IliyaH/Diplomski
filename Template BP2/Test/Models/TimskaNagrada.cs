using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class TimskaNagrada
    {
        public int NagradaId { get; set; }
        public string TipNagrade { get; set; }
        public int? TimTimId { get; set; }

        public virtual Nagrada Nagrada { get; set; }
        public virtual Tim TimTim { get; set; }
    }
}
