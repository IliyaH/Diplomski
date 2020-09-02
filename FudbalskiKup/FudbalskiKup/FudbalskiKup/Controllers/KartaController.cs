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
        // GET: Karta
        public ActionResult KartaPocetak()
        {
            ViewBag.utakmice = kartaRepository.DobaviImeiIdUtakmice();
           

            return View();
        }

        public ActionResult DodajKartu(int utakmicaID, int cena)
        {
            int navijacID = 0;
            if (Session["NavijacID"] != null)
            {
                //Converting your session variable value to integer
                navijacID = Convert.ToInt32(Session["NavijacID"]);
            }

            kartaRepository.DodajKartu(utakmicaID, cena , navijacID);

            return RedirectToAction("KartaPocetak");
        }
    }
}