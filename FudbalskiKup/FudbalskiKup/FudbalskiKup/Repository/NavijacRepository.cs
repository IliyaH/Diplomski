using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Models
{
    public class NavijacRepository : BaseRepository<Korisnik>
    {
        public string ProveriKorisnickoIme(Korisnik korisnik) 
        {
            using (var db = new DiplomskiBazaEntities()) 
            {
                var navijacInfo = db.Korisnik.Where(x => x.KorisnickoIme == korisnik.KorisnickoIme).FirstOrDefault();
                if (navijacInfo != null) 
                {
                    return "Korisnicko ime je zauzeto";
                }
                return null;
            }
        }

        public Korisnik ProveriPostojanjeProfila(string korisnickoIme, string sifra) 
        {
            using (var db = new DiplomskiBazaEntities()) 
            {
                var navijacInfo = db.Korisnik.Where(x => (x.KorisnickoIme == korisnickoIme) && ( x.Sifra == sifra)).FirstOrDefault();
                if (navijacInfo == null)
                {
                    return null;
                }
                return navijacInfo;
            }
        }

        public Tuple<Korisnik , string> IzmeniNavijaca(Korisnik izmenjenKorisnik)
        {
            Korisnik orginalniNavijac = null; 
            using (var db = new DiplomskiBazaEntities())
            {
                 orginalniNavijac = db.Korisnik.Where(orginal => orginal.KorisnikID == izmenjenKorisnik.KorisnikID).FirstOrDefault();
            }
            if (orginalniNavijac.Sifra == izmenjenKorisnik.Sifra)
            {
                Update(izmenjenKorisnik);
                return Tuple.Create(izmenjenKorisnik, string.Empty);
            }
            else
            {
                return Tuple.Create(orginalniNavijac, "Pogresna Sifra, podaci naloga nisu izmenjeni!");
            }
        }
    }
}