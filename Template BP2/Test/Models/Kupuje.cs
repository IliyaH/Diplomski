using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Kupuje
    {
        public Kupuje()
        {
            Posecuje = new HashSet<Posecuje>();
        }

        public int KartaKartaId { get; set; }
        public int NavijacNavijacId { get; set; }

        public virtual Karta KartaKarta { get; set; }
        public virtual Navijac NavijacNavijac { get; set; }
        public virtual ICollection<Posecuje> Posecuje { get; set; }
    }
}
