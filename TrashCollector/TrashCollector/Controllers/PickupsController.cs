using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pickups
        public ActionResult Index()
        {
            var loggedUser = User.Identity.GetUserId();

            var pickups = db.Pickup.Where(c => db.Customer.Any(a => a.PickupID == c.ID));

            //(from c in db.Customer
            // join u in db.Users on c.UserID equals u.Id
            // where (c.UserID == loggedUser)
            // select c).Include("Pickup").ToList();

            return View(pickups);
        }

        // GET: Pickups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
        }

        // GET: Pickups/Create
        public ActionResult Create()
        {
            var pickups = db.Pickup.ToList();
            Customer customer = new Customer()
            {
                Pickups = pickups
            };
            return View(customer);
        }

        // POST: Pickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,AlternateDay")] Pickup pickup)
        {
            if (ModelState.IsValid)
            {
                db.Pickup.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pickup);
        }

        // GET: Pickups/Edit/5
        public ActionResult Edit(int? id)
        {

            Pickup pickup = db.Pickup.Find(id);

            //var loggedUser = User.Identity.GetUserId();
            //var customers = db.Customer.Single(c => c.UserID == loggedUser);

            ViewBag.PickupId = new SelectList(db.Pickup, "ID", "Day"/*, customers.PickupID*/);

            return View(pickup);
        }

        // POST: Pickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pickup pickup, Customer customer)
        {            
            if (ModelState.IsValid)
            {
                var loggedUser = User.Identity.GetUserId();            
                var customers = db.Customer.Single(c => c.UserID == loggedUser);

                customers.PickupID = customer.PickupID;
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pickup);
        }

        // GET: Pickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
        }

        // POST: Pickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pickup pickup = db.Pickup.Find(id);
            db.Pickup.Remove(pickup);
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
