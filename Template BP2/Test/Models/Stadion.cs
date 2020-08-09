using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Stadion
    {
        public Stadion()
        {
            Odrzava = new HashSet<Odrzava>();
        }

        public int StadionId { get; set; }
        public string Ime { get; set; }
        public int GradGradId { get; set; }

        public virtual Grad GradGrad { get; set; }
        public virtual ICollection<Odrzava> Odrzava { get; set; }
    }
}
