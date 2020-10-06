using FudbalskiKup.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Repository
{
    public class KartaRepository : BaseRepository<Karta>
    {
        List<Tuple<string, string , int>> utakmice = new List<Tuple<string, string , int>>();
        public List<Tuple<string, string, int>> DobaviImeiIdUtakmice()
        {
            //Proadji utakmicu sa izabranim id i imenom(prosledjenim sa fronta)
            using (var db = new DiplomskiBazaEntities())
            {
                int i = 0;
                var tempUtakmice = db.Igra.GroupBy(x => x.Utakmica_UtakmicaID).ToList();
                string ime1 = String.Empty;
                string ime2 = String.Empty;
                int id = 0;

                foreach (var utakmica in tempUtakmice)
                {
                    foreach (var tim in utakmica)
                    {
                        //Proveri da li je prvi tim iz utakmice ili drugi(kako ne bismo ponovili utakmicu)
                        i++;
                        if (i == 1)
                        {
                            ime1 = db.SelektujImeTima(tim.Tim_TimID).FirstOrDefault();
                            id = db.Utakmica.Where(x => x.UtakmicaID == tim.Utakmica_UtakmicaID).Select(c => c.UtakmicaID).FirstOrDefault();
                        }
                        if (i == 2)
                        {
                            ime2 = db.SelektujImeTima(tim.Tim_TimID).FirstOrDefault();
                        }
                    }

                    i = 0;

                    Tuple<string, string, int> utakmicaTuple = Tuple.Create(ime1, ime2 , id);
                    utakmice.Add(utakmicaTuple);
                }

                return utakmice;
            }
        }

        public void DodajKartu(int utakmicaID, int cena , int KorisnikID) 
        {
            //Dodaj kartu u tabelu kao Karta kao i id karte i korsnika u medjutabelu
            Karta karta = new Karta();
            Kupuje kupuje = new Kupuje();

            using (var db = new DiplomskiBazaEntities())
            {
                int stadionID = (int)db.SelektujStadionID(utakmicaID).FirstOrDefault(); //db.Odrzava.Where(x => x.Utakmica_UtakmicaID == utakmicaID).Select(x => x.Stadion_StadionID).FirstOrDefault();
                karta.Odrzava_StadionID = stadionID;
                karta.Cena = cena;
                karta.Odrzava_UtakmicaID = utakmicaID;

                Insert(karta);

                //insertuj i u odrzava?
                kupuje.Korisnik_KorisnikID = KorisnikID;
                kupuje.Karta_KartaID = karta.KartaID;

                db.Set<Kupuje>().Add(kupuje);
                db.SaveChanges();
            }

        }
    }
}