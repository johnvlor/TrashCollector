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
    public class BillingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Billings
        public ActionResult Index()
        {
            var loggedUser = User.Identity.GetUserId();

            var billings = db.Billing.Where(c => db.Customer.Any(a => a.BillingID == c.ID && a.UserID == loggedUser));

            var newCustomer = db.Customer.First(c => c.UserID == loggedUser);
            
            int? pickupday = newCustomer.PickupID;

            DateTime today = DateTime.Now;
            DateTime dtFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            ViewBag.pickupDaysOwed = CountPickupDays(dtFirst, today, pickupday);

            return View(billings);
        }

        private int CountPickupDays(DateTime startDate, DateTime endDate, int? pickupday)
        {
            int count = 0;
            DayOfWeek dow = 0;

            switch (pickupday)
            {
                case 1:
                    dow = DayOfWeek.Monday;
                    break;
                case 2:
                    dow = DayOfWeek.Tuesday;
                    break;
                case 3:
                    dow = DayOfWeek.Wednesday;
                    break;
                case 4:
                    dow = DayOfWeek.Thursday;
                    break;
                case 5:
                    dow = DayOfWeek.Friday;
                    break;
                default:
                    break;
            }
            
            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
            {
                if (dt.DayOfWeek == dow)
                {
                    count++;
                }
            }

            return count;
        }

        // GET: Billings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Charges")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billing.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billing);
        }

        // GET: Billings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Charges")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        // GET: Billings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billing.Find(id);
            db.Billing.Remove(billing);
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
