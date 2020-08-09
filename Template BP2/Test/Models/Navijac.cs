using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Navijac
    {
        public Navijac()
        {
            Kupuje = new HashSet<Kupuje>();
        }

        public int NavijacId { get; set; }
        public int Ime { get; set; }
        public int Prezime { get; set; }

        public virtual ICollection<Kupuje> Kupuje { get; set; }
    }
}
