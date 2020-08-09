using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Sudija
    {
        public Sudija()
        {
            Igra = new HashSet<Igra>();
        }

        public int SudijaId { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<Igra> Igra { get; set; }
    }
}
