using FudbalskiKup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Repository
{
    public class TimskaNagradaRepository : BaseRepository<TimskaNagrada>
    {
        public Tuple<TimskaNagrada, Tim> PribaviTimskeNagrade(string tipNagrade)
        {
            using (var db = new DiplomskiBazaEntities())
            {
                TimskaNagrada timskaNarada = db.TimskaNagrada.Where(x => x.TipNagrade == tipNagrade).FirstOrDefault();
                Tim tim = db.Tim.Where(x => x.TimID == timskaNarada.Tim_TimID).FirstOrDefault();
                return Tuple.Create(timskaNarada, tim);
            }
        }
    }
}