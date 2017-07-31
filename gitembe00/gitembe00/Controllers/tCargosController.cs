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
    public class tCargosController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tCargos
        public ActionResult Index()
        {
            return View(db.tCargos.ToList());
        }

        // GET: tCargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCargo tCargo = db.tCargos.Find(id);
            if (tCargo == null)
            {
                return HttpNotFound();
            }
            return View(tCargo);
        }

        // GET: tCargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tCargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoID,CargoSigla,CargoDesc,CargoStatus")] tCargo tCargo)
        {
            if (ModelState.IsValid)
            {
                db.tCargos.Add(tCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tCargo);
        }

        // GET: tCargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCargo tCargo = db.tCargos.Find(id);
            if (tCargo == null)
            {
                return HttpNotFound();
            }
            return View(tCargo);
        }

        // POST: tCargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoID,CargoSigla,CargoDesc,CargoStatus")] tCargo tCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tCargo);
        }

        // GET: tCargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCargo tCargo = db.tCargos.Find(id);
            if (tCargo == null)
            {
                return HttpNotFound();
            }
            return View(tCargo);
        }

        // POST: tCargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tCargo tCargo = db.tCargos.Find(id);
            db.tCargos.Remove(tCargo);
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
