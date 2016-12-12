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
    public class BranchController : Controller
    {
        private ShopContext db = new ShopContext();

        //
        // GET: /Branch/

        public ActionResult Index()
        {
            ViewBag.City = new SelectList(db.Branches.Select(x => x.City).Distinct());

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name");
            return View(db.Branches.ToList());
        }

        [HttpPost]
        public ActionResult Index(string txt, int? BranchID, string City)
        {

            var branches = from b in db.Branches select b;

            if (!string.IsNullOrEmpty(txt))
            {
                branches = branches.Where(x => x.Name.Contains(txt));
            }
            if (BranchID != null)
            {
                branches = branches.Where(x => x.BranchID == BranchID);
            }
            if (!string.IsNullOrEmpty(City))
            {
                branches = branches.Where(x => x.City == City);
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name");
            ViewBag.City = new SelectList(db.Branches.Select(x => x.City).Distinct());

            return View(branches);
            
            
        }

        //
        // GET: /Branch/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Branch/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        //
        // GET: /Branch/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        //
        // POST: /Branch/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public JsonResult Delete(int id)
        {
            Branch branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
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