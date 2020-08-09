using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Karta
    {
        public Karta()
        {
            Kupuje = new HashSet<Kupuje>();
        }

        public int OdrzavaUtakmicaId { get; set; }
        public int OdrzavaStadionId { get; set; }
        public int KartaId { get; set; }
        public int Cena { get; set; }

        public virtual Odrzava Odrzava { get; set; }
        public virtual ICollection<Kupuje> Kupuje { get; set; }
    }
}
