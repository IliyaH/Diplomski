using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Igrac
    {
        public Igrac()
        {
            LicnaNagrada = new HashSet<LicnaNagrada>();
        }

        public int IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojPostignutihGolova { get; set; }
        public int TimTimId { get; set; }

        public virtual Tim TimTim { get; set; }
        public virtual ICollection<LicnaNagrada> LicnaNagrada { get; set; }
    }
}
