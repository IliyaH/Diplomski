using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Stadion = new HashSet<Stadion>();
            Tim = new HashSet<Tim>();
        }

        public int GradId { get; set; }
        public string Drzava { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<Stadion> Stadion { get; set; }
        public virtual ICollection<Tim> Tim { get; set; }
    }
}
