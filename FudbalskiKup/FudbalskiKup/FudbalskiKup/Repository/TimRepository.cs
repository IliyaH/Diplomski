using FudbalskiKup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FudbalskiKup.Repository
{
    public class TimRepository : BaseRepository<Tim>
    { 
        public Tuple<Tim, Grad, List<Igrac>> PribaviInformacijeTima(int timID)
        {
            Tim tim = new Tim();
            Grad grad = new Grad();         
            List<Igrac> listaIgraca = new List<Igrac>();
          
            tim = FindByID(timID);

            using (var db = new DiplomskiBazaEntities())
            {
                listaIgraca = db.Igracs.Where(x => x.Tim_TimId == tim.TimID).ToList();
                grad = db.Grads.Where(x => x.GradID == tim.Grad_GradId).FirstOrDefault();             
            }

            return Tuple.Create(tim, grad, listaIgraca);
        }

    }
}