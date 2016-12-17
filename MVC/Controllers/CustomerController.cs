using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.DAL;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ShopContext db = new ShopContext();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            ViewBag.City = new SelectList(db.Customers.Select(x => x.City).Distinct());
            ViewBag.maxAge = db.Customers.Select(x => x.Age).Max();
            ViewBag.minAge = db.Customers.Select(x => x.Age).Min();
            return View(db.Customers);
        }

        [HttpPost]
        public ActionResult Index(string fisrtname, string lastname, int minAge, int maxAge, string City)
        {

            var customers = from p in db.Customers select p;

            customers = customers.Where(x => x.Age <= maxAge && x.Age >= minAge);

            if (!string.IsNullOrEmpty(fisrtname))
            {
                customers = customers.Where(x => x.FirstName.Contains(fisrtname));
            }
            if (!string.IsNullOrEmpty(lastname))
            {
                customers = customers.Where(x => x.LastName.Contains(lastname));
            }
            if (!string.IsNullOrEmpty(City))
            {
                customers = customers.Where(x => x.City == City);
            }

            ViewBag.City = new SelectList(db.Customers.Select(x => x.City).Distinct());
            ViewBag.maxAge = db.Customers.Select(x => x.Age).Max();
            ViewBag.minAge = db.Customers.Select(x => x.Age).Min();
            return View(customers);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            var bla = db.Orders.Where(x => x.CustomerID == id).Select(x => x.PurchaseDate).ToList();

            List<string> dates = new List<string>();
            foreach (var item in bla)
            {
                dates.Add(item.ToShortDateString());
            }

            ViewBag.Dates = new SelectList(dates.Distinct());

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Details(int id, string Dates)
        {
            var bla = db.Orders.Where(x => x.CustomerID == id).Select(x => x.PurchaseDate).ToList();

            List<string> dates = new List<string>();
            foreach (var item in bla)
            {
                dates.Add(item.ToShortDateString());
            }

            ViewBag.Dates = new SelectList(dates.Distinct());

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            if (Dates != "")
            {
                var b = customer.Orders.Where(x => x.PurchaseDate.ToShortDateString() == Dates);
                customer.Orders = b.ToList();
            }
            return View(customer);
        }

        //
        // GET: /Customer/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Customer/Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var userInDataBase = db.Customers.Where(s =>
                        s.Email == email &&
                        s.Password == password).SingleOrDefault();
            if (userInDataBase != null)
            {
                System.Web.HttpContext.Current.Session["userLogged"] = userInDataBase;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMsg = "שם משתמש או סיסמה שגויים.";
            return View();
        }

        // get: /Customer/Logout
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["userLogged"] = null;
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (db.Customers.Where(x => x.Email == customer.Email).Count() > 0)
                {
                    ViewBag.ErrorMsg = "כתובת אימייל קיימת, נא נסה כתובת אחרת";
                }
                else
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    System.Web.HttpContext.Current.Session["userLogged"] = customer;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(customer);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public JsonResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Json(id);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}