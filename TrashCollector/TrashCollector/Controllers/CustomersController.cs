using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Core.Objects;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {            
            var loggedUser = User.Identity.GetUserId();
            var customers = db.Customer.Where(c => c.UserID == loggedUser).Include(m => m.Address);
            return View(customers);
        }

        public ActionResult IndexCustomerRoute()
        {
            var today = DateTime.Today.DayOfWeek;
            var loggedUser = User.Identity.GetUserId();
            var workers =
                (from w in db.Worker
                 join c in db.Customer on w.Zip equals c.Address.Zip
                 join a in db.Address on c.AddressID equals a.ID
                 join p in db.Pickup on c.PickupID equals p.ID
                 where w.UserID == loggedUser && w.Zip == c.Address.Zip && c.Pickup.Day == today.ToString()
                 select c).Include("Address"); 

            return View(workers);
        }

        public ActionResult IndexHolds()
        {
            var loggedUser = User.Identity.GetUserId();
            var customers = db.Customer.Where(c => c.UserID == loggedUser);
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customers = db.Customer.Include(m => m.Address).SingleOrDefault(m => m.ID == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.Email = User.Identity.GetUserName();

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer, Address address)
        {
            if (ModelState.IsValid)
            {               
                customer.UserID = User.Identity.GetUserId();    
                customer.Email = User.Identity.GetUserName();
                customer.BillingID = 1;
                db.Address.Add(address);
                db.Customer.Add(customer);
                db.SaveChanges();
                
                return RedirectToAction("Create", "Pickups");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customer.Find(id);
            var customers = db.Customer.Include(m => m.Address).SingleOrDefault(m => m.ID == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer, Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AddressID = new SelectList(db.Address, "ID", "Street", customer.AddressID);
            return View(customer);
        }

        // GET: Customers/EditHolds/5
        public ActionResult EditHolds()
        {
            //Customer customer = db.Customer.Find(id);
            var loggedUser = User.Identity.GetUserId();
            var customers = db.Customer.Single(c => c.UserID == loggedUser);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHolds(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = User.Identity.GetUserId();
                var customers = db.Customer.Single(w => w.UserID == loggedUser);

                customers.StartDate = customer.StartDate;
                customers.EndDate = customer.EndDate;
                customers.Comment = customer.Comment;

                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customer.Find(id);
            var customers = db.Customer.Include(m => m.Address).SingleOrDefault(m => m.ID == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
