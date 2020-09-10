using FudbalskiKup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Repository
{
    public class LicnaNagradaRepository : BaseRepository<LicnaNagrada>
    {
        public Tuple<LicnaNagrada , Igrac> PribaviLicneNagrad(string tipNagrade) 
        {
            using (var db = new DiplomskiBazaEntities())
            {
                LicnaNagrada licnaNagrada= db.LicnaNagrada.Where(x => x.VrstaNagrade == tipNagrade).FirstOrDefault();
                Igrac igrac = db.Igrac.Where(x => x.IgracID == licnaNagrada.Igrac_IgracID).FirstOrDefault();
                return Tuple.Create(licnaNagrada, igrac);
            } 
        }
    }
}