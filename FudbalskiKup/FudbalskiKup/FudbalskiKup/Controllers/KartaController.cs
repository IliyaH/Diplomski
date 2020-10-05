using FudbalskiKup.Models;
using FudbalskiKup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FudbalskiKup.Controllers
{
    public class KartaController : Controller
    {
        KartaRepository kartaRepository = new KartaRepository();
        

        public ActionResult KartaPocetak()
        {
            ViewBag.utakmice = kartaRepository.DobaviImeiIdUtakmice();
            return View();
        }

        public ActionResult DodajKartu(int utakmicaID, int cena)
        {
            int navijacID = 0;

            if (Session["KorisnikID"] != null)
            {
                navijacID = Convert.ToInt32(Session["KorisnikID"]);
            }

            kartaRepository.DodajKartu(utakmicaID, cena , navijacID);

            return RedirectToAction("KartaPocetak");
        }
    }
}