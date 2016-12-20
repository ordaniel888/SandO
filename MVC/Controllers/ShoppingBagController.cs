using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.DAL;

namespace SandO.Controllers
{
    public class ShoppingBagController : Controller
    {
        private ShopContext db = new ShopContext();

        //
        // GET: /ShoppingBag/

        public ActionResult Index()
        {
            List<Product> list = new List<Product>();

            int total = 0;

            foreach (var item in (List<int>)System.Web.HttpContext.Current.Session["shoppingList"])
            {
                var p = db.Products.Where(s => s.ProductID == item).FirstOrDefault();
                if(p!= null)
                {
                    list.Add(p);
                    total += p.Price;
                }
            }

            ViewBag.Total = total;
            return View(list);
        }

        public JsonResult AddToBag(int productId)
        {
            List<int> list = (List<int>)System.Web.HttpContext.Current.Session["shoppingList"];
            list.Add(productId);
            return Json(list.Count);
        }

        public JsonResult Delete(int id = 0)
        {
            List<int> list = (List<int>)System.Web.HttpContext.Current.Session["shoppingList"];
            list.Remove(id);
            return Json(list.Count);
        }

        public JsonResult Buy()
        {
            if (System.Web.HttpContext.Current.Session["userLogged"] == null)
            {
                return Json(false);
            }
            else
            {
                foreach (var item in (List<int>)System.Web.HttpContext.Current.Session["shoppingList"])
                {
                    Order o = new Order
                    {
                        CustomerID = ((Customer)System.Web.HttpContext.Current.Session["userLogged"]).CustomerID,
                        ProductID = db.Products.Where(x=>x.ProductID == item).FirstOrDefault().ProductID,
                        PurchaseDate = DateTime.Now
                    };

                    db.Orders.Add(o);  
                }

                db.SaveChanges();
                ((List<int>)System.Web.HttpContext.Current.Session["shoppingList"]).Clear();

                return Json(true);
            }
        }

    }
}
