using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Models
{
    public class NavijacRepository : BaseRepository<Navijac>
    {
        public string ProveriKorisnickoIme(Navijac navijac) 
        {
            using (var db = new DiplomskiBazaEntities()) 
            {
                var navijacInfo = db.Navijacs.Where(x => x.KorisnickoIme == navijac.KorisnickoIme).FirstOrDefault();
                if (navijacInfo != null) 
                {
                    return "Korisnicko ime je zauzeto";
                }
                return null;
            }
        }

        public Navijac ProveriPostojanjeProfila(string korisnickoIme, string sifra) 
        {
            using (var db = new DiplomskiBazaEntities()) 
            {
                var navijacInfo = db.Navijacs.Where(x => (x.KorisnickoIme == korisnickoIme) && ( x.Sifra == sifra)).FirstOrDefault();
                if (navijacInfo == null)
                {
                    return null;
                }
                return navijacInfo;
            }
        }

        public Tuple<Navijac , string> IzmeniNavijaca(Navijac izmenjenNavijac)
        {
            Navijac orginalniNavijac = null; 
            using (var db = new DiplomskiBazaEntities())
            {
                 orginalniNavijac = db.Navijacs.Where(orginal => orginal.NavijacID == izmenjenNavijac.NavijacID).FirstOrDefault();
            }
            if (orginalniNavijac.Sifra == izmenjenNavijac.Sifra)
            {
                Update(izmenjenNavijac);
                return Tuple.Create(izmenjenNavijac , string.Empty);
            }
            else
            {
                return Tuple.Create(orginalniNavijac, "Pogresna Sifra, podaci naloga nisu izmenjeni!");
            }
        }
    }
}