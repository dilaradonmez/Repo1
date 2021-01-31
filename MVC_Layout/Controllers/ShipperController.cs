using MVC_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    public class ShipperController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        public ActionResult AddShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipper(Shippers shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index");
        }

        public ActionResult RemoveShipper(int shipperId)
        {
            var shipper = db.Shippers.Find(shipperId);
            if (shipper != null)
            {
                db.Shippers.Remove(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateShipper(int shipperId)
        {
            var shipper= db.Shippers.Find(shipperId);
            return View(shipper);
        }

        [HttpPost]
        public ActionResult UpdateShipper(Shippers shipper)//Telefon
        {
            var updated = db.Shippers.Find(shipper.ShipperID);//Test
            updated.CompanyName = shipper.CompanyName;
            updated.Orders = shipper.Orders;
            updated.Phone = shipper.Phone;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}