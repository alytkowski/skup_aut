using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samochody.ViewModels;
using Samochody.Models;
using Samochody.Security;

namespace Samochody.Controllers
{
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Title = "O nas";
            ViewBag.Message = "Strona pozwalająca na dodawanie samochodów a także przeglądów tych aut.";

            if (SessionPersister.Username == string.Empty || SessionPersister.Username == null)
            {
                return View("About", "_NotLoggedLayout");
            }
            return View("About", "_Layout");
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Title = "Kontakt";


            if (SessionPersister.Username == string.Empty || SessionPersister.Username == null)
            {
                return View("Contact", "_NotLoggedLayout");
            }
            return View("Contact", "_Layout");
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (SessionPersister.Username != string.Empty && SessionPersister.Username != null)
            {
                return View("Success");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel am = new AccountModel();
            if(string.IsNullOrEmpty(avm.Account.Username) || string.IsNullOrEmpty(avm.Account.Password) 
                || am.login(avm.Account.Username, avm.Account.Password) == null)
            {
                ViewBag.Error = "Nieprawidłowe hasło lub nazwa użytkownika";
                return View("Index");
            }
            SessionPersister.Username = avm.Account.Username;
            return View("Success");
        }

        public ActionResult Logout(AccountViewModel avm)
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}