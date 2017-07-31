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
    public class tLugaresController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tLugares
        public ActionResult Index()
        {
            return View(db.tLugars.ToList());
        }

        // GET: tLugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tLugar tLugar = db.tLugars.Find(id);
            if (tLugar == null)
            {
                return HttpNotFound();
            }
            return View(tLugar);
        }

        // GET: tLugares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tLugares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LugarID,LugarDesc,LugarStatus")] tLugar tLugar)
        {
            if (ModelState.IsValid)
            {
                db.tLugars.Add(tLugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tLugar);
        }

        // GET: tLugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tLugar tLugar = db.tLugars.Find(id);
            if (tLugar == null)
            {
                return HttpNotFound();
            }
            return View(tLugar);
        }

        // POST: tLugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LugarID,LugarDesc,LugarStatus")] tLugar tLugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tLugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tLugar);
        }

        // GET: tLugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tLugar tLugar = db.tLugars.Find(id);
            if (tLugar == null)
            {
                return HttpNotFound();
            }
            return View(tLugar);
        }

        // POST: tLugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tLugar tLugar = db.tLugars.Find(id);
            db.tLugars.Remove(tLugar);
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
