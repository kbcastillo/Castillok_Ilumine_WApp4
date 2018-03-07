using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileSalesTool.DAL;
using MobileSalesTool.Models;
using MobileSalesTool.ViewModels;

namespace MobileSalesTool.Controllers
{
    public class ConsumerController : Controller
    {
        private MobileSalesToolContext db = new MobileSalesToolContext();

        // GET: Consumer
        //public ActionResult Index()
        //{
        //    var consumers = db.Consumers.Include(c => c.AccountType);
        //    return View(consumers.ToList());
        //}

        public ActionResult Index(int? id, int? PromotionID)
        {
            var viewModel = new ConsumerIndexData
            {
                Consumers = db.Consumers
                .Include(i => i.AccountType)
                .Include(i => i.Promotions.Select(c => c.AccountType))
                .OrderBy(i => i.LastName)
            };

            if (id != null)
            {
                ViewBag.ConsumerID = id.Value;
                viewModel.Promotions = viewModel.Consumers.Where(
                    i => i.ID == id.Value).Single().Promotions;
            }

            if (PromotionID != null)
            {
                ViewBag.PromotionID = PromotionID.Value;
                viewModel.Enrollments = viewModel.Promotions.Where(
                    x => x.PromotionID == PromotionID).Single().Enrollments;
            }

            return View(viewModel);
        }
        // GET: Consumer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // GET: Consumer/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.AccountTypes, "ConsumerID", "Location");
            return View();
        }

        // POST: Consumer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,HireDate")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Consumers.Add(consumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.AccountTypes, "ConsumerID", "Location", consumer.ID);
            return View(consumer);
        }

        // GET: Consumer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.AccountTypes, "ConsumerID", "Location", consumer.ID);
            return View(consumer);
        }

        // POST: Consumer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,HireDate")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.AccountTypes, "ConsumerID", "Location", consumer.ID);
            return View(consumer);
        }

        // GET: Consumer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // POST: Consumer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumer consumer = db.Consumers.Find(id);
            db.Consumers.Remove(consumer);
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
