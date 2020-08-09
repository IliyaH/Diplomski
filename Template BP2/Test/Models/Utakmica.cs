using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Utakmica
    {
        public Utakmica()
        {
            Igra = new HashSet<Igra>();
            Odrzava = new HashSet<Odrzava>();
        }

        public int UtakmicaId { get; set; }
        public string Odigrana { get; set; }
        public DateTime Datum { get; set; }
        public string FazaTakmicenja { get; set; }

        public virtual ICollection<Igra> Igra { get; set; }
        public virtual ICollection<Odrzava> Odrzava { get; set; }
    }
}
