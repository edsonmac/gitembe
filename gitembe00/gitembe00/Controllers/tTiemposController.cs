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
    public class tTiemposController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tTiempos
        public ActionResult Index()
        {
            return View(db.tTiempoes.ToList());
        }

        // GET: tTiempos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTiempo tTiempo = db.tTiempoes.Find(id);
            if (tTiempo == null)
            {
                return HttpNotFound();
            }
            return View(tTiempo);
        }

        // GET: tTiempos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tTiempos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TiempoID,TiempoDesc")] tTiempo tTiempo)
        {
            if (ModelState.IsValid)
            {
                db.tTiempoes.Add(tTiempo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tTiempo);
        }

        // GET: tTiempos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTiempo tTiempo = db.tTiempoes.Find(id);
            if (tTiempo == null)
            {
                return HttpNotFound();
            }
            return View(tTiempo);
        }

        // POST: tTiempos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TiempoID,TiempoDesc")] tTiempo tTiempo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tTiempo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tTiempo);
        }

        // GET: tTiempos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTiempo tTiempo = db.tTiempoes.Find(id);
            if (tTiempo == null)
            {
                return HttpNotFound();
            }
            return View(tTiempo);
        }

        // POST: tTiempos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tTiempo tTiempo = db.tTiempoes.Find(id);
            db.tTiempoes.Remove(tTiempo);
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
