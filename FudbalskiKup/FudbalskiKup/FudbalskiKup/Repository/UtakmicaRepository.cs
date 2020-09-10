using FudbalskiKup.Models;
using FudbalskiKup.Models.Extended;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FudbalskiKup.Repository
{
    public class UtakmicaRepository : BaseRepository<Utakmica>
    {
        List<UtakmicaInfo> utakmice = new List<UtakmicaInfo>();
        TimskaNagradaRepository TimskaNagradaRepository = new TimskaNagradaRepository();
        LicnaNagradaRepository LicnaNagradaRepository = new LicnaNagradaRepository();

        Random rand = new Random();
        public List<UtakmicaInfo> PribaviUtakmice()
        {
            using (var db = new DiplomskiBazaEntities())
            {
                int i = 0;
                var tempUtakmice = db.Igra.GroupBy(x => x.Utakmica_UtakmicaID).ToList();
                string imePrviTim = String.Empty;
                string imeDrugiTim = String.Empty;
                string fazaTakmičenja = String.Empty;
                int? brojGolovaPrvogTima = 0;
                int? brojGolovaDrugogTima = 0;
                bool odigranaUtakmica = false;
                int utakmicaID = 0;
                string odigranaUtakmicaBaza = "";

                foreach (var utakmica in tempUtakmice)
                {
                    if (utakmica.Count() == 2)
                    {
                        foreach (var tim in utakmica)
                        {
                            i++;
                            if (i == 1)
                            {
                                imePrviTim = db.Tim.Where(x => x.TimID == tim.Tim_TimID).Select(c => c.Ime).FirstOrDefault();
                                brojGolovaPrvogTima = db.Igra.Where(x => x.Tim_TimID == tim.Tim_TimID && x.Utakmica_UtakmicaID == tim.Utakmica_UtakmicaID).Select(x => x.BrojGolova).FirstOrDefault();
                                fazaTakmičenja = db.Utakmica.Where(x => x.UtakmicaID == tim.Utakmica_UtakmicaID).Select(c => c.FazaTakmicenja).FirstOrDefault();
                                odigranaUtakmicaBaza = db.Utakmica.Where(x => x.UtakmicaID == tim.Utakmica_UtakmicaID).Select(c => c.Odigrana).FirstOrDefault();
                                utakmicaID = tim.Utakmica_UtakmicaID;
                                //TODO: Pogresno kupljenje broja golova
                                if (odigranaUtakmicaBaza == "0")
                                    odigranaUtakmica = false;
                                else
                                    odigranaUtakmica = true;
                            }
                            if (i == 2)
                            {
                                imeDrugiTim = db.Tim.Where(x => x.TimID == tim.Tim_TimID).Select(c => c.Ime).FirstOrDefault();
                                brojGolovaDrugogTima = db.Igra.Where(x => x.Tim_TimID == tim.Tim_TimID && x.Utakmica_UtakmicaID == tim.Utakmica_UtakmicaID).Select(x => x.BrojGolova).FirstOrDefault();
                            }
                        }
                        i = 0;
                        UtakmicaInfo utakmicaInfo = new UtakmicaInfo
                        {
                            UtakmicaID = utakmicaID,
                            BrojGolovaPrviTim = brojGolovaPrvogTima,
                            BrojGolovaDrugiTim = brojGolovaDrugogTima,
                            FazaTakmicenja = fazaTakmičenja,
                            ImePrviTim = imePrviTim,
                            ImeDrugiTim = imeDrugiTim,
                            Odigrana = odigranaUtakmica
                        };

                        utakmice.Add(utakmicaInfo);
                    }
                    if (utakmica.Count() == 1)
                    {
                        //TODO: ISPISI AKO PRONADJES UTAKMICU SA SAMO JEDNIM TIMOM
                    }
                }
                return utakmice;
            }
        }

        public void OdigrajUtakmicu(int utakmicaID)
        {
            int brojGolovaPrvogTima = rand.Next(6);
            int brojGolovaDrugogTima = rand.Next(6);
            Utakmica utakmica = new Utakmica();
            List<Igra> igras = new List<Igra>();
            List<Igrac> igraciPrviTim = new List<Igrac>();
            List<Igrac> igraciDrugiTim = new List<Igrac>();

            using (var db = new DiplomskiBazaEntities())
            {
                utakmica = FindByID(utakmicaID);
                igras = db.Igra.Where(x => x.Utakmica_UtakmicaID == utakmicaID).ToList();

                if (brojGolovaPrvogTima == brojGolovaDrugogTima)
                {
                    brojGolovaDrugogTima++;
                }

                igras[0].BrojGolova = brojGolovaPrvogTima;
                igras[1].BrojGolova = brojGolovaDrugogTima;

                utakmica.Odigrana = "1";


                Update(utakmica);

                db.Set<Igra>().Attach(igras[0]);
                db.Entry(igras[0]).State = EntityState.Modified;
                db.SaveChanges();

                db.Set<Igra>().Attach(igras[1]);
                db.Entry(igras[1]).State = EntityState.Modified;
                db.SaveChanges();


                if (brojGolovaPrvogTima > brojGolovaDrugogTima && utakmica.FazaTakmicenja != "Finale")
                {
                    kreirajUtakmicu(utakmica.FazaTakmicenja, igras[0].Tim_TimID);
                }
                else if (brojGolovaPrvogTima < brojGolovaDrugogTima && utakmica.FazaTakmicenja != "Finale")
                {
                    kreirajUtakmicu(utakmica.FazaTakmicenja, igras[1].Tim_TimID);
                }
                else if (brojGolovaPrvogTima > brojGolovaDrugogTima && utakmica.FazaTakmicenja == "Finale") 
                {
                    DodeliNagrade(igras[0].Tim_TimID, igras[1].Tim_TimID);
                }
                else if (brojGolovaPrvogTima < brojGolovaDrugogTima && utakmica.FazaTakmicenja == "Finale")
                {
                    DodeliNagrade(igras[1].Tim_TimID, igras[0].Tim_TimID);
                }

                int timPrviID = igras[0].Tim_TimID;
                int timDrugiID = igras[1].Tim_TimID;

                igraciPrviTim = db.Igrac.Where(x => x.Tim_TimId == timPrviID).ToList();
                igraciDrugiTim = db.Igrac.Where(x => x.Tim_TimId == timDrugiID).ToList();

             
                dodeliGoloveIgracima(brojGolovaPrvogTima , igraciPrviTim);
                dodeliGoloveIgracima(brojGolovaDrugogTima, igraciDrugiTim);
            }

            UpdateIgraci(igraciPrviTim);
            UpdateIgraci(igraciDrugiTim);

            for (int i = 0; i < 6; i++) 
            {
                Nagrada nagrada = new Nagrada();
                using (var db = new DiplomskiBazaEntities())
                {
                    db.Set<Nagrada>().Add(nagrada);
                    db.SaveChanges();
                }
            }
        }

        public void kreirajUtakmicu(string fazaTakmicenja, int pobednickiTimID)
        {
            Random random = new Random();
            bool pronasao = false;
            int utakmicaID = 0;

            using (var db = new DiplomskiBazaEntities())
            {
                var tempUtakmice = db.Igra.GroupBy(x => x.Utakmica_UtakmicaID).ToList();
                foreach (var utakmicaGrupa in tempUtakmice)
                {
                    if (utakmicaGrupa.Count() == 1)
                    {
                        foreach (var tim in utakmicaGrupa)
                        {
                            utakmicaID = tim.Utakmica_UtakmicaID;
                            pronasao = true;
                            break;
                        }
                    }
                    if (pronasao)
                        break;
                }
            }
            if (!pronasao)
            {
                Utakmica utakmica = new Utakmica();
                var dateAndTime = DateTime.Now;
                utakmica.Datum = dateAndTime.Date;
                utakmica.Odigrana = "0";

                if (fazaTakmicenja == "Osmina Finala")
                {
                    utakmica.FazaTakmicenja = "Cetvrtina Finala";
                }
                if (fazaTakmicenja == "Cetvrtina Finala")
                {
                    utakmica.FazaTakmicenja = "Polu Finale";
                }
                if (fazaTakmicenja == "Polu Finale")
                {
                    utakmica.FazaTakmicenja = "Finale";
                }

                Insert(utakmica);

                utakmicaID = utakmica.UtakmicaID;
            }

            Igra igra = new Igra() { Tim_TimID = pobednickiTimID, BrojGolova = null };
            using (var db = new DiplomskiBazaEntities())
            {
                List<sudija> sudije = new List<sudija>();
                sudije = db.Set<sudija>().ToList();
                int index = random.Next(sudije.Count);
                igra.Sudija_SudijaID = sudije[index].SudijaID;
                igra.Utakmica_UtakmicaID = utakmicaID;

                db.Set<Igra>().Add(igra);
                db.SaveChanges();
            }


        }

        public void dodeliGoloveIgracima(int brojGolova , List<Igrac> listaIgraca) 
        {
            int index = 0;
            Random random = new Random();
            for (int i = brojGolova; i > 0; i--) 
            {
                index = random.Next(listaIgraca.Count);
                listaIgraca[index].BrojPostignutihGolova++;
            }
        }

        public void UpdateIgraci(List<Igrac> igraci)
        { 
            using (var db = new DiplomskiBazaEntities())
            {
                foreach (var igrac in igraci)
                {
                    db.Set<Igrac>().Attach(igrac);
                    db.Entry(igrac).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }       
        }

        public void DodeliNagrade(int idPobednickogTima, int idGubitnickogTima) 
        {
            LicnaNagrada licnaNagradaFerplej = new LicnaNagrada();
            LicnaNagrada licnaNagradaNajbolji = new LicnaNagrada();
            LicnaNagrada licnaNagradaStrelac = new LicnaNagrada();
            TimskaNagrada timskaNagradaPrvoMesto = new TimskaNagrada();
            TimskaNagrada timskaNagradaDrugoMesto = new TimskaNagrada();

            //Upisi ID u Grupne Nagrade
            using (var db = new DiplomskiBazaEntities())
            {
                Random random = new Random();

                timskaNagradaPrvoMesto = db.TimskaNagrada.Where(x => x.TipNagrade == "Prvo Mesto").FirstOrDefault();
                timskaNagradaPrvoMesto.Tim_TimID = idPobednickogTima;
                timskaNagradaDrugoMesto = db.TimskaNagrada.Where(x => x.TipNagrade == "Drugo Mesto").FirstOrDefault();
                timskaNagradaDrugoMesto.Tim_TimID = idGubitnickogTima;

                
                //Nadji igrace pobednickog tima i odaberi najboljeg - random

                List<Igrac> pobednickiIgraci = new List<Igrac>();
                pobednickiIgraci = db.Igrac.Where(x => x.Tim_TimId == idPobednickogTima).ToList();

                //najbolji igrac
                int index = random.Next(pobednickiIgraci.Count);
                licnaNagradaNajbolji = db.LicnaNagrada.Where(x => x.VrstaNagrade == "Najbolji Igrac").FirstOrDefault();
                licnaNagradaNajbolji.Igrac_IgracID = pobednickiIgraci[index].IgracID;

                //radnom ferplej igrac
                List<Igrac> sviIgraci = db.Igrac.ToList();
                index = rand.Next(sviIgraci.Count);
                licnaNagradaFerplej = db.LicnaNagrada.Where(x => x.VrstaNagrade == "Ferplej").FirstOrDefault();
                licnaNagradaFerplej.Igrac_IgracID = sviIgraci[index].IgracID;

                //igrac sa najvise golova
                licnaNagradaStrelac = db.LicnaNagrada.Where(x => x.VrstaNagrade == "Najbolji Strelac").FirstOrDefault();
                Igrac najboljiStrelac = sviIgraci.OrderByDescending(x => x.BrojPostignutihGolova).First();
                licnaNagradaStrelac.Igrac_IgracID = najboljiStrelac.IgracID;
            }

            TimskaNagradaRepository.Update(timskaNagradaPrvoMesto);
            TimskaNagradaRepository.Update(timskaNagradaDrugoMesto);
            LicnaNagradaRepository.Update(licnaNagradaStrelac);
            LicnaNagradaRepository.Update(licnaNagradaNajbolji);
            LicnaNagradaRepository.Update(licnaNagradaFerplej);

        }

        //napravi metodu koja prikazuje pobednike
    }
}