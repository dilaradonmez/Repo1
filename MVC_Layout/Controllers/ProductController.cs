using MVC_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CancelProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                  db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}