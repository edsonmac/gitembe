using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gitembe.Models;

namespace gitembe.Controllers
{
    public class tEscalafonesController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tEscalafones
        public ActionResult Index()
        {
            return View(db.tEscalafons.ToList());
        }

        // GET: tEscalafones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tEscalafon tEscalafon = db.tEscalafons.Find(id);
            if (tEscalafon == null)
            {
                return HttpNotFound();
            }
            return View(tEscalafon);
        }

        // GET: tEscalafones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tEscalafones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EscalafonID,EscalafonDesc")] tEscalafon tEscalafon)
        {
            if (ModelState.IsValid)
            {
                db.tEscalafons.Add(tEscalafon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEscalafon);
        }

        // GET: tEscalafones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tEscalafon tEscalafon = db.tEscalafons.Find(id);
            if (tEscalafon == null)
            {
                return HttpNotFound();
            }
            return View(tEscalafon);
        }

        // POST: tEscalafones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EscalafonID,EscalafonDesc")] tEscalafon tEscalafon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEscalafon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEscalafon);
        }

        // GET: tEscalafones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tEscalafon tEscalafon = db.tEscalafons.Find(id);
            if (tEscalafon == null)
            {
                return HttpNotFound();
            }
            return View(tEscalafon);
        }

        // POST: tEscalafones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tEscalafon tEscalafon = db.tEscalafons.Find(id);
            db.tEscalafons.Remove(tEscalafon);
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
