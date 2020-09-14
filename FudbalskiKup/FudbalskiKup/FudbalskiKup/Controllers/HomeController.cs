using FudbalskiKup.Models;
using FudbalskiKup.Models.Extended;
using FudbalskiKup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace FudbalskiKup.Controllers
{
    public class HomeController : Controller
    {
        NavijacRepository navijacRepository = new NavijacRepository();
        TimRepository timRepository = new TimRepository();
        List<Tim> timoviLista = new List<Tim>();
        Korisnik korisnik = new Korisnik();

        public ActionResult RegistracijaStranica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registracija(Korisnik korisnik)
        {
            //Proveri da li korisnicko ime postoji
            string porukaGreske = navijacRepository.ProveriKorisnickoIme(korisnik);

            //ako ne postoji, unesi ga i napravi sesiju
            if (porukaGreske == null)
            {
                korisnik.Rola = "user";
                navijacRepository.Insert(korisnik);
                Session["KorisnikID"] = korisnik.KorisnikID;
                Session["KorisnickoIme"] = korisnik.KorisnickoIme;
                Session["Rola"] = korisnik.Rola;

                //pribavi listu timova ya profil
                timoviLista = timRepository.GetList();
                ViewBag.Tim = timoviLista;

                return View("Profil", korisnik);
            }

            //ako korisnicko ime postoji - greska
            ViewBag.porukaGreske = porukaGreske;
            return View("RegistracijaStranica");
        }

        public ActionResult LogovanjeStranica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logovanje(LogovanjePodaci logovanjePodaci)
        {
            //uproveri da li postoji nalog
            korisnik = navijacRepository.ProveriPostojanjeProfila(logovanjePodaci.KorisnickoIme, logovanjePodaci.Sifra);

            // ne postoji
            if (korisnik == null)
            {
                ViewBag.porukaGreske = "Korisnicko ime ili sifra nisu ispravni";
                return View("LogovanjeStranica");
            }

            //postoji - pribavi timove i uloguj se
            timoviLista = timRepository.GetList();
            ViewBag.Tim = timoviLista;

            Session["KorisnikID"] = korisnik.KorisnikID;
            Session["KorsinickoIme"] = korisnik.KorisnickoIme;
            Session["Rola"] = korisnik.Rola;

            return View("Profil", korisnik);

        }

        public ActionResult IzmenaNaloga(Korisnik korisnik,string submitButton)
        {   
            //u zavisnosti od kliknutog dugmeta odradi akciju
            switch (submitButton)
            {
                case "Izmeni Nalog":
                    return (IzmeniNalog(korisnik));
                case "Obrisi Nalog":  
                    return (ObrisiNalog(korisnik));
                default:
                    return View("RegistracijaStranica");
            }
        }

        private ActionResult  IzmeniNalog(Korisnik izmenjeniKorisnik)
        {
            Tuple<Korisnik , string> tupleNavijac = navijacRepository.IzmeniNavijaca(izmenjeniKorisnik);
            ViewBag.porukaGreske = tupleNavijac.Item2;
            return View("Profil" , tupleNavijac.Item1);
        }

        private ActionResult ObrisiNalog(Korisnik korisnik)
        {
            navijacRepository.Delete(korisnik.KorisnikID);
            Session.Abandon();
            return RedirectToAction("RegistracijaStranica");
        }

        public ActionResult Izloguj() 
        {
            Session.Abandon();
            return RedirectToAction("RegistracijaStranica");
        }
    }
}