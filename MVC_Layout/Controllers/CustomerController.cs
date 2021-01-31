using MVC_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    public class CustomerController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
       
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customers customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult RemoveCustomer(int customerId)
        {
            var customer = db.Customers.Find(customerId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateCustomer(int customerId)
        {
            var customer = db.Customers.Find(customerId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customers customer)
        {
            var updated = db.Customers.Find(customer.CustomerID);
            updated.CompanyName = customer.CompanyName;
            updated.ContactName = customer.ContactName;
            updated.Address = customer.Address;
            updated.City = customer.City;
            updated.Phone = customer.Phone;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}