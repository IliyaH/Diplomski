using FudbalskiKup.Models;
using FudbalskiKup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FudbalskiKup.Controllers
{
    public class TimController : Controller
    {
        TimRepository timRepository = new TimRepository();
        Tuple<Tim, Grad, List<Igrac>> timInfo;
        // GET: Utakmica
        public ActionResult PrikazTima(int timID)
        {
            timInfo = timRepository.PribaviInformacijeTima(timID);
            ViewBag.Tim = timInfo.Item1;
            ViewBag.Grad = timInfo.Item2;
            ViewBag.Igraci = timInfo.Item3;
            return View("Tim");
        }
    }
}