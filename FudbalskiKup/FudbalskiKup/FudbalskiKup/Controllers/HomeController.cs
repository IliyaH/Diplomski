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

        //Get Register View
        public ActionResult RegistracijaStranica()
        {
            return View();
        }

        //Add Navijac in Base
        [HttpPost]
        public ActionResult Registracija(Korisnik korisnik)
        {
            string porukaGreske = navijacRepository.ProveriKorisnickoIme(korisnik);

            if (porukaGreske == null)
            {
                korisnik.Rola = "user";
                navijacRepository.Insert(korisnik);
                Session["KorisnikID"] = korisnik.KorisnikID;
                Session["KorisnickoIme"] = korisnik.KorisnickoIme;

                timoviLista = timRepository.GetList();
                ViewBag.Tim = timoviLista;

                return View("Profil", korisnik);
            }

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
           // NavijacRepository navijacRepository = new NavijacRepository();
            korisnik = navijacRepository.ProveriPostojanjeProfila(logovanjePodaci.KorisnickoIme, logovanjePodaci.Sifra);

            if (korisnik == null)
            {
                ViewBag.porukaGreske = "Korisnicko ime ili sifra nisu ispravni";
                return View("LogovanjeStranica");
            }

            timoviLista = timRepository.GetList();
            ViewBag.Tim = timoviLista;

            Session["KorisnikID"] = korisnik.KorisnikID;
            Session["KorsinickoIme"] = korisnik.KorisnickoIme;
            return View("Profil", korisnik);

        }

        public ActionResult IzmenaNaloga(Korisnik korisnik,string submitButton)
        {
            switch (submitButton)
            {
                case "Izmeni Nalog":
                    // delegate sending to another controller action
                    return (IzmeniNalog(korisnik));
                case "Obrisi Nalog":
                    // call another action to perform the cancellation
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