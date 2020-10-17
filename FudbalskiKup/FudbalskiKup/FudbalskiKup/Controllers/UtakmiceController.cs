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
        List<UtakmicaInfo> utakmiceOsmina = new List<UtakmicaInfo>(8);
        List<UtakmicaInfo> utakmiceCetvrtina = new List<UtakmicaInfo>(4);
        List<UtakmicaInfo> utakmicePolu = new List<UtakmicaInfo>(2);
        UtakmicaInfo finale = new UtakmicaInfo();
        List<bool> osminaPomocnaLista = new List<bool>() { false, false, false, false , false, false, false, false };
        List<bool> cetvrirnaPomocnaLista = new List<bool>() { false , false , false , false };
        List<bool> poluPomocnaLista = new List<bool>() { false, false };


        // GET: Utakmice
        public ActionResult Utakmice()
        {
            sveUtakmice = utakmicaRepository.PribaviUtakmice();
            sveUtakmice = sveUtakmice.OrderBy(x => x.OznakaUtakmice).ToList();

            foreach (var utakmica in sveUtakmice) 
            {
                if (utakmica.Odigrana == false) 
                {
                    neodigraneUtakmice.Add(utakmica);
                }

                if (utakmica.FazaTakmicenja == "Osmina Finala")
                {
                   
                    if (utakmica.OznakaUtakmice == "A1")
                    {
                        osminaPomocnaLista[0] = true;
                        utakmiceOsmina.Insert(0, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A2")
                    {
                        osminaPomocnaLista[1] = true;
                        utakmiceOsmina.Insert(1, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A3")
                    {
                        osminaPomocnaLista[2] = true;
                        utakmiceOsmina.Insert(2, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A4")
                    {
                        osminaPomocnaLista[3] = true;
                        utakmiceOsmina.Insert(3, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A5")
                    {
                        osminaPomocnaLista[4] = true;
                        utakmiceOsmina.Insert(4, utakmica);

                    }
                    else if (utakmica.OznakaUtakmice == "A6")
                    {
                        osminaPomocnaLista[5] = true;
                        utakmiceOsmina.Insert(5, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A7")
                    {
                        osminaPomocnaLista[6] = true;
                        utakmiceOsmina.Insert(6, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "A8")
                    {
                        osminaPomocnaLista[7] = true;
                        utakmiceOsmina.Insert(7, utakmica);
                    }
                }
                else if (utakmica.FazaTakmicenja == "Cetvrtina Finala")
                {
                    if (utakmica.OznakaUtakmice == "B1")
                    {
                        cetvrirnaPomocnaLista[0] = true;
                        utakmiceCetvrtina.Insert(0 ,utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "B2")
                    {
                        cetvrirnaPomocnaLista[1] = true;
                        utakmiceCetvrtina.Insert(1, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "B3")
                    {
                        cetvrirnaPomocnaLista[2] = true;
                        utakmiceCetvrtina.Insert(2, utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "B4")
                    {
                        cetvrirnaPomocnaLista[3] = true;
                        utakmiceCetvrtina.Insert(3, utakmica);
                    }
                }
                else if (utakmica.FazaTakmicenja == "Polu Finale")
                {
                   
                    if (utakmica.OznakaUtakmice == "C1")
                    {
                        poluPomocnaLista[0] = true;
                        utakmicePolu.Insert(0 ,utakmica);
                    }
                    else if (utakmica.OznakaUtakmice == "C2")
                    {
                        poluPomocnaLista[1] = true;
                        utakmicePolu.Insert(0, utakmica);
                    }
                }
                else if (utakmica.FazaTakmicenja == "Finale")
                {
                    finale = utakmica;
                }
            }

          

            utakmiceOsmina = utakmiceOsmina.OrderBy(x => x.OznakaUtakmice).ToList();
            utakmiceCetvrtina = utakmiceCetvrtina.OrderBy(x => x.OznakaUtakmice).ToList();
            utakmicePolu = utakmicePolu.OrderBy(x => x.OznakaUtakmice).ToList();


            ViewBag.neodigraneUtakmice = neodigraneUtakmice;
            ViewBag.Osmina = utakmiceOsmina;
            if (utakmiceCetvrtina.Count != 0)
                ViewBag.Cetvrtina = utakmiceCetvrtina;
            if (utakmicePolu.Count != 0)
                ViewBag.Polu = utakmicePolu;
            ViewBag.Finale = finale;

            ViewBag.osminaPomoc = osminaPomocnaLista;
            ViewBag.cetvrtinaPomoc = cetvrirnaPomocnaLista;
            ViewBag.poluPomoc = poluPomocnaLista;
            return View("Utakmice");
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