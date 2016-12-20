using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.DAL;
using System.IO;

namespace SandO.Controllers
{
    public class CatalogController : Controller
    {
        private ShopContext db = new ShopContext();

        //
        // GET: /Catalog/

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Branch);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name");

            ViewBag.MaxPrice = db.Products.Select(x => x.Price).Max();
            return View(products.ToList());
        }

        [HttpPost]
        public ActionResult Index(string txt, e_Size? size, int? BranchID, int pricesRange, e_Category? category)
        {

            var products = from p in db.Products select p;

            products = products.Where(x => x.Price <= pricesRange);

            if (!string.IsNullOrEmpty(txt))
            {
                products = products.Where(x => x.Name.Contains(txt));
            }
            if (size != null)
            {
                products = products.Where(x => x.Size == size);
            }
            if (BranchID != null)
            {
                products = products.Where(x => x.BranchID == BranchID);
            }
            if (category != null)
            {
                products = products.Where(x => x.Category == category);
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name");
            ViewBag.MaxPrice = db.Products.Select(x => x.Price).Max();


            return View(products.ToList());      
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Catalog/Create

        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name");
            return View();
        }

        //
        // POST: /Catalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            var physicalPath = "";
             
            if (file != null && file.ContentLength > 0)
            {
                var FileName = string.Format("{0}.{1}", Guid.NewGuid(), "jpg");
                var path = Path.Combine(Server.MapPath("~/Content/images"), FileName);
                file.SaveAs(path);

                physicalPath = "/content/images/" + FileName; 

            }

            product.Image = physicalPath;
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            if (ModelState.IsValid || (errors[0].Key == "Image" && errors[0].Errors.Count == 1 && product.Image != "") )
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name", product.BranchID);
            return View(product);
        }

        //
        // GET: /Catalog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name", product.BranchID);
            ViewBag.image = product.Image;
            return View(product);
        }

        //
        // POST: /Catalog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            var physicalPath = "";

            if (file != null && file.ContentLength > 0)
            {
                var FileName = string.Format("{0}.{1}", Guid.NewGuid(), "jpg");
                var path = Path.Combine(Server.MapPath("~/Content/images"), FileName);
                file.SaveAs(path);

                physicalPath = "/Content/images/" + FileName;

            }
            if (physicalPath != "")
            {
                product.Image = physicalPath;
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            if (ModelState.IsValid || (errors[0].Key == "Image" && errors[0].Errors.Count == 1 && product.Image != null))
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "Name", product.BranchID);
            return View(product);
        }

        public JsonResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            ((List<int>)System.Web.HttpContext.Current.Session["shoppingList"]).Remove(id);
            return Json(((List<int>)System.Web.HttpContext.Current.Session["shoppingList"]).Count);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}