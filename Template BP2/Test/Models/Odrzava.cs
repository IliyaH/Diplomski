using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Odrzava
    {
        public Odrzava()
        {
            Karta = new HashSet<Karta>();
            Posecuje = new HashSet<Posecuje>();
        }

        public int UtakmicaUtakmicaId { get; set; }
        public int StadionStadionId { get; set; }

        public virtual Stadion StadionStadion { get; set; }
        public virtual Utakmica UtakmicaUtakmica { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
        public virtual ICollection<Posecuje> Posecuje { get; set; }
    }
}
