using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Tim
    {
        public Tim()
        {
            Igra = new HashSet<Igra>();
            Igrac = new HashSet<Igrac>();
            TimskaNagrada = new HashSet<TimskaNagrada>();
        }

        public int TimId { get; set; }
        public string Ime { get; set; }
        public int GradGradId { get; set; }

        public virtual Grad GradGrad { get; set; }
        public virtual ICollection<Igra> Igra { get; set; }
        public virtual ICollection<Igrac> Igrac { get; set; }
        public virtual ICollection<TimskaNagrada> TimskaNagrada { get; set; }
    }
}
