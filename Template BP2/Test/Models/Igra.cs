using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Igra
    {
        public int TimTimId { get; set; }
        public int UtakmicaUtakmicaId { get; set; }
        public int SudijaSudijaId { get; set; }
        public int? BrojGolova { get; set; }

        public virtual Sudija SudijaSudija { get; set; }
        public virtual Tim TimTim { get; set; }
        public virtual Utakmica UtakmicaUtakmica { get; set; }
    }
}
