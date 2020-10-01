using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Models.Extended
{
    public class UtakmicaInfo
    {
        public string ImePrviTim { get; set; }
        public string ImeDrugiTim { get; set;}
        public string FazaTakmicenja { get; set; }
        public int? BrojGolovaPrviTim { get; set; }
        public int? BrojGolovaDrugiTim { get; set; }
        public bool Odigrana { get; set; }
        public int UtakmicaID { get; set; }
        public string OznakaUtakmice { get; set; }
    }
}