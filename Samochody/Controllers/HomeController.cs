using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samochody.Security;

namespace Samochody.Controllers
{
    public class HomeController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Title = "O nas";
            ViewBag.Message = "Strona pozwalająca na dodawanie samochodów a także przeglądów tych aut.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Title = "Kontakt";
            

            return View();
        }
    }
}