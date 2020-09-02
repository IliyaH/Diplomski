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
        Navijac navijac = new Navijac();

        //Get Register View
        public ActionResult RegistracijaStranica()
        {
            return View();
        }

        //Add Navijac in Base
        [HttpPost]
        public ActionResult Registracija(Navijac navijac)
        {
            string porukaGreske = navijacRepository.ProveriKorisnickoIme(navijac);

            if (porukaGreske == null)
            {
                navijacRepository.Insert(navijac);
                Session["NavijacID"] = navijac.NavijacID;
                Session["KorisnickoIme"] = navijac.KorisnickoIme;

                return View("Profil", navijac);
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
            navijac = navijacRepository.ProveriPostojanjeProfila(logovanjePodaci.KorisnickoIme, logovanjePodaci.Sifra);

            if (navijac == null)
            {
                ViewBag.porukaGreske = "Korisnicko ime ili sifra nisu ispravni";
                return View("LogovanjeStranica");
            }

            timoviLista = timRepository.GetList();
            ViewBag.Tim = timoviLista;

            Session["NavijacID"] = navijac.NavijacID;
            Session["KorsinickoIme"] = navijac.KorisnickoIme;
            return View("Profil", navijac);

        }

        public ActionResult IzmenaNaloga(Navijac navijac,string submitButton)
        {
            switch (submitButton)
            {
                case "Izmeni Nalog":
                    // delegate sending to another controller action
                    return (IzmeniNalog(navijac));
                case "Obrisi Nalog":
                    // call another action to perform the cancellation
                    return (ObrisiNalog(navijac));
                default:
                    return View("RegistracijaStranica");
            }
        }

        private ActionResult  IzmeniNalog(Navijac izmenjeniNavijac)
        {
            Tuple<Navijac , string> tupleNavijac = navijacRepository.IzmeniNavijaca(izmenjeniNavijac);
            ViewBag.porukaGreske = tupleNavijac.Item2;
            return View("Profil" , tupleNavijac.Item1);
        }

        private ActionResult ObrisiNalog(Navijac navijac)
        {
            navijacRepository.Delete(navijac.NavijacID);
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