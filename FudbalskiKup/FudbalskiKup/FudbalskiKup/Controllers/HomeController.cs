using FudbalskiKup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FudbalskiKup.Controllers
{
    public class HomeController : Controller
    {
        //Get Register View
        public ActionResult Register()
        {
            return View();
        }

        //Add Navijac in Base
        public ActionResult RegisterNavijac(string username, string email, string password)
        {
            ViewBag.username = username;
            ViewBag.email = email;
            ViewBag.password = password;

            Navijac novi = new Navijac();
            novi.KorisnickoIme = username;
            novi.Email = email;
            novi.Sifra = password;

            NavijacRepository navijacRepository = new NavijacRepository();

            navijacRepository.Insert(novi);

            return View("Profile");
        }


    }
}