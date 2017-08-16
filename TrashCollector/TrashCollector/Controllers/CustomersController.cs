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
            //ViewBag.Email = User.Identity.GetUserName();
            var loggedUser = User.Identity.GetUserId();
            var customer = /*db.Customer.Include(c => c.Address).ToList();*/
            (from c in db.Customer
             //join a in db.Address on c.AddressID equals a.ID
             join u in db.Users on c.UserID equals u.Id
             where c.UserID == loggedUser
             select c).Include("Address").ToList();

            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ////Customer customer = db.Customer.Find(id);
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
            //ViewBag.AddressID = new SelectList(db.Address, "ID", "Street");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Phone,AddressID,Email")] Customer customer, [Bind(Include = "ID,Street,City,State,Zip")] Address address)
        {
            if (ModelState.IsValid)
            {
                customer.UserID = User.Identity.GetUserId();
                customer.Email = User.Identity.GetUserName();
                db.Address.Add(address);
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AddressID = new SelectList(db.Address, "ID", "Street", customer.AddressID);
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
            //ViewBag.AddressID = new SelectList(db.Address, "ID", "Street", customer.AddressID);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Phone,AddressID,Email")] Customer customer, [Bind(Include = "ID,Street,City,State,Zip")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Address, "ID", "Street", customer.AddressID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
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
