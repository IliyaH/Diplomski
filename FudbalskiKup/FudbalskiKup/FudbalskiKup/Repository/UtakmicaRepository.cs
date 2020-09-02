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

        Random rand = new Random();
        public List<UtakmicaInfo> PribaviUtakmice()
        {
            using (var db = new DiplomskiBazaEntities())
            {
                int i = 0;
                var tempUtakmice = db.Igras.GroupBy(x => x.Utakmica_UtakmicaID).ToList();
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
                                imePrviTim = db.Tims.Where(x => x.TimID == tim.Tim_TimID).Select(c => c.Ime).FirstOrDefault();
                                brojGolovaPrvogTima = db.Igras.Where(x => x.Tim_TimID == tim.Tim_TimID && x.Utakmica_UtakmicaID == tim.Utakmica_UtakmicaID).Select(x => x.BrojGolova).FirstOrDefault();
                                fazaTakmičenja = db.Utakmicas.Where(x => x.UtakmicaID == tim.Utakmica_UtakmicaID).Select(c => c.FazaTakmicenja).FirstOrDefault();
                                odigranaUtakmicaBaza = db.Utakmicas.Where(x => x.UtakmicaID == tim.Utakmica_UtakmicaID).Select(c => c.Odigrana).FirstOrDefault();
                                utakmicaID = tim.Utakmica_UtakmicaID;
                                //TODO: Pogresno kupljenje broja golova
                                if (odigranaUtakmicaBaza == "0")
                                    odigranaUtakmica = false;
                                else
                                    odigranaUtakmica = true;
                            }
                            if (i == 2)
                            {
                                imeDrugiTim = db.Tims.Where(x => x.TimID == tim.Tim_TimID).Select(c => c.Ime).FirstOrDefault();
                                brojGolovaDrugogTima = db.Igras.Where(x => x.Tim_TimID == tim.Tim_TimID && x.Utakmica_UtakmicaID == tim.Utakmica_UtakmicaID).Select(x => x.BrojGolova).FirstOrDefault();
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
                igras = db.Igras.Where(x => x.Utakmica_UtakmicaID == utakmicaID).ToList();

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

                //Kreiraj Novu Utakmicu

                if (brojGolovaPrvogTima > brojGolovaDrugogTima && utakmica.FazaTakmicenja != "Finale")
                {
                    kreirajUtakmicu(utakmica.FazaTakmicenja, igras[0].Tim_TimID);
                }
                else if (brojGolovaPrvogTima < brojGolovaDrugogTima && utakmica.FazaTakmicenja != "Finale")
                {
                    kreirajUtakmicu(utakmica.FazaTakmicenja, igras[1].Tim_TimID);
                }

                int timPrviID = igras[0].Tim_TimID;
                int timDrugiID = igras[1].Tim_TimID;

                igraciPrviTim = db.Igracs.Where(x => x.Tim_TimId == timPrviID).ToList();
                igraciDrugiTim = db.Igracs.Where(x => x.Tim_TimId == timDrugiID).ToList();


                //TODO: unesi golove igracima     
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
                var tempUtakmice = db.Igras.GroupBy(x => x.Utakmica_UtakmicaID).ToList();
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
    }
}