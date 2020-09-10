using FudbalskiKup.Models;
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
        LicnaNagradaRepository LicnaNagradaRepository = new LicnaNagradaRepository();
        TimskaNagradaRepository TimskaNagradaRepository = new TimskaNagradaRepository();

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
                if (utakmica.FazaTakmicenja == "Finale") 
                {
                  
                }
            }
            ViewBag.neodigraneUtakmice = neodigraneUtakmice;
            ViewBag.utakmice = sveUtakmice;
            return View();
        }

        public ActionResult OdigrajUtakmicu(int utakmicaID) 
        {
            utakmicaRepository.OdigrajUtakmicu(utakmicaID);
            return RedirectToAction("Utakmice");
        }

        public ActionResult PrikaziNagrade() 
        {
            Tuple<LicnaNagrada, Igrac> najboljiIgrac = LicnaNagradaRepository.PribaviLicneNagrad("Najbolji Igrac");
            Tuple<LicnaNagrada, Igrac> ferplejIgrac = LicnaNagradaRepository.PribaviLicneNagrad("Ferplej");
            Tuple<LicnaNagrada, Igrac> najboljiStrelac = LicnaNagradaRepository.PribaviLicneNagrad("Najbolji Strelac");

            ViewBag.NajboljiIgrac = najboljiIgrac;
            ViewBag.FerplejIgrac = ferplejIgrac;
            ViewBag.NajboljiStrelac = najboljiStrelac;

            Tuple<TimskaNagrada, Tim> prviTim = TimskaNagradaRepository.PribaviTimskeNagrade("Prvo Mesto");
            Tuple<TimskaNagrada, Tim> drugiTim = TimskaNagradaRepository.PribaviTimskeNagrade("Drugo Mesto");

            ViewBag.PrvoMesto = prviTim;
            ViewBag.DrugoMesto = drugiTim;

            return View();
        }

       


    }
}