using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Samochody.Models;
using Samochody.Security;

namespace Samochody.Controllers
{
    public class CarsController : Controller
    {
        private CarDBCtxt db = new CarDBCtxt();

        [CustomAuthorize(Roles = "admin,regular")]
        public ActionResult Index(string sortowanie, SearchCar Model, int? page)
        {
            
            ViewBag.SortedBy = sortowanie;
            ViewBag.SortByModel = sortowanie == null ? "Model_Malejaco" : "";
            ViewBag.SortByPrice = sortowanie == "Price_Malejaco" ? "Price_Rosnaco" : "Price_Malejaco";

            var cars = from i in db.Cars
                       select i;
            if (ModelState.IsValid)
            {
                if (Model.BrandZnajdz != null && Model.ModelZnajdz != null)
                {
                    cars = from i in db.Cars
                           where i.Model.Equals(Model.ModelZnajdz)
                           && i.Brand.Equals(Model.BrandZnajdz)
                           select i;
                }
                else if (Model.BrandZnajdz != null)
                {
                    cars = from i in db.Cars
                           where i.Brand.Equals(Model.BrandZnajdz)
                           select i;
                }
                else if (Model.ModelZnajdz != null)
                {
                    cars = from i in db.Cars
                           where i.Model.Equals(Model.ModelZnajdz)
                           select i;
                }
                ViewBag.BrandZnajdz = Model.BrandZnajdz;
                ViewBag.ModelZnajdz = Model.ModelZnajdz;
            }
            switch (sortowanie)
            {
                case "Model_Malejaco":
                    cars = cars.OrderByDescending(s => s.Model);
                    break;
                case "Price_Malejaco":
                    cars = cars.OrderByDescending(s => s.Price);
                    break;
                case "Price_Rosnaco":
                    cars = cars.OrderBy(s => s.Price);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Model);
                    break;
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cars/Details/5
        [CustomAuthorize(Roles = "admin,regular")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Model,Price,Bought,Sold")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Model,Price,Bought,Sold")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [CustomAuthorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
