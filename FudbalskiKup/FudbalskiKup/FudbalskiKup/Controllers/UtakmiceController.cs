using FudbalskiKup.Models.Extended;
using FudbalskiKup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FudbalskiKup.Controllers
{
    public class UtakmiceController : Controller
    {
        UtakmicaRepository utakmicaRepository = new UtakmicaRepository();
        List<UtakmicaInfo> sveUtakmice = new List<UtakmicaInfo>();
        List<UtakmicaInfo> neodigraneUtakmice = new List<UtakmicaInfo>();

        // GET: Utakmice
        public ActionResult Utakmice()
        {
            sveUtakmice = utakmicaRepository.PribaviUtakmice();

            foreach (var utakmica in sveUtakmice) 
            {
                if (utakmica.Odigrana == false) 
                {
                    neodigraneUtakmice.Add(utakmica);
                }
               
            }
            ViewBag.neodigraneUtakmice = neodigraneUtakmice;

            ViewBag.utakmice = sveUtakmice;

            return View();
        }

        //TODO : Metoda za odigravanje izabrane utakmice
        //Potreban ID utakmice
        //Proveri da li je neki od timova String.Empty i da li je odigrana == 0
        //Edit broj golova oba tima i odigrana => 1
        //Vrati se na pocetak sa svim utakmicama

        public ActionResult OdigrajUtakmicu(int utakmicaID) 
        {
            utakmicaRepository.OdigrajUtakmicu(utakmicaID);
            return RedirectToAction("Utakmice");
        }


        //Napravi dodelu nagrada
    }
}