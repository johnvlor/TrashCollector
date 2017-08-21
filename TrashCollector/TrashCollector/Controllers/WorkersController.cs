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
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workers
        public ActionResult Index()
        {
            var loggedUser = User.Identity.GetUserId();
            var workers = db.Worker.Where(w => w.UserID == loggedUser).Include(w => w.ApplicationUser);

            return View(workers);
        }

        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                worker.UserID = User.Identity.GetUserId();
                db.Worker.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Worker.Find(id);
            db.Worker.Remove(worker);
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

        // GET: Workers
        public ActionResult IndexRoute()
        {
            var loggedUser = User.Identity.GetUserId();
            var workers = db.Worker.Where(w => w.UserID == loggedUser).Include(w => w.ApplicationUser);

            return View(workers);
        }

        public ActionResult IndexRouteCustomer()
        {
            var loggedUser = User.Identity.GetUserId();
            var workers =
                from w in db.Worker
                join c in db.Customer on w.Zip equals c.Address.Zip
                where w.UserID == loggedUser
                select w;
            var customers =
                (from c in db.Customer
                join w in db.Worker on c.Address.Zip equals w.Zip
                where w.UserID == loggedUser
                select c).Include("Address");

            return View(customers);
        }

        // GET: Workers/CreateRoute
        public ActionResult CreateRoute()
        {
            //var loggedUser = User.Identity.GetUserId();
            //var workers = db.Worker.Single(w => w.UserID == loggedUser);

            ViewBag.Route = new SelectList(db.Address.Select(z => z.Zip)/*.Distinct()*/, "Zip");

            return View();
        }

        // POST: Workers/CreateRoute
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoute(Worker worker, [Bind(Include = "Zip")] Address address)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = User.Identity.GetUserId();
                var workers = db.Worker.Single(w => w.UserID == loggedUser);

                workers.Zip = address.Zip;
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();

                //db.Worker.Add(worker);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Route = new SelectList(db.Address, "Zip");

            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult EditRoute()
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Worker worker = db.Worker.Find(id);
            var loggedUser = User.Identity.GetUserId();
            var worker = db.Worker.Single(w => w.UserID == loggedUser);

            ViewBag.Route = new SelectList(db.Address/*.Distinct()*/, "ID","Zip",worker.Zip);
            //if (worker == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRoute(Worker worker, Address address)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = User.Identity.GetUserId();
                var workers = db.Worker.Single(w => w.UserID == loggedUser);

                workers.Zip = address.Zip;

                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Route = new SelectList(db.Address/*.Distinct()*/, "ID", "Zip", worker.Zip);
            return View(worker);
        }
    }
}
