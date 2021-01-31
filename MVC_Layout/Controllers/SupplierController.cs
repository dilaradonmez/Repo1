using MVC_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    public class SupplierController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(Suppliers supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index");
        }

        public ActionResult RemoveSupplier(int supplierId)//2
        {
            var supplier = db.Suppliers.Find(supplierId);
            if (supplier!= null)
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateSupplier(int supplierId)
        {
            var supplier = db.Suppliers.Find(supplierId);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Suppliers supplier)//Telefon
        {
            var updated = db.Suppliers.Find(supplier.SupplierID);//Test
            updated.CompanyName = supplier.CompanyName;
            updated.ContactName = supplier.ContactName;
            updated.Address = supplier.Address;
            updated.City = supplier.City;
            updated.Phone = supplier.Phone;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}