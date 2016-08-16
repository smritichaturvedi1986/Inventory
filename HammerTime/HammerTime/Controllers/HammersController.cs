using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HammerTime.Models;

namespace HammerTime.Controllers
{
    public class HammersController : Controller
    {
        private HTContext db = new HTContext();

        // GET: Hammers
        public ActionResult Index()
        {
            return View(db.Hammers.ToList());
        }

        // GET: Hammers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hammer hammer = db.Hammers.Find(id);
            if (hammer == null)
            {
                return HttpNotFound();
            }
            return View(hammer);
        }

        // GET: Hammers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hammers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HammerId,Size,type")] Hammer hammer)
        {
            if (ModelState.IsValid)
            {
                db.Hammers.Add(hammer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hammer);
        }

        // GET: Hammers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hammer hammer = db.Hammers.Find(id);
            if (hammer == null)
            {
                return HttpNotFound();
            }
            return View(hammer);
        }

        // POST: Hammers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HammerId,Size,type")] Hammer hammer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hammer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hammer);
        }

        // GET: Hammers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hammer hammer = db.Hammers.Find(id);
            if (hammer == null)
            {
                return HttpNotFound();
            }
            return View(hammer);
        }

        // POST: Hammers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hammer hammer = db.Hammers.Find(id);
            db.Hammers.Remove(hammer);
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
