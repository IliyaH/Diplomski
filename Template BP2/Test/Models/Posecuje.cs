using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Posecuje
    {
        public int KupujeKartaKartaId { get; set; }
        public int KupujeNavijacNavijacId { get; set; }
        public int OdrzavaUtakmicaId { get; set; }
        public int OdrzavaStadionId { get; set; }

        public virtual Kupuje Kupuje { get; set; }
        public virtual Odrzava Odrzava { get; set; }
    }
}
