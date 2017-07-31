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
    public class tPersonasController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tPersonas
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: tPersonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tPersona tPersona = db.Personas.Find(id);
            if (tPersona == null)
            {
                return HttpNotFound();
            }
            return View(tPersona);
        }

        // GET: tPersonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tPersonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaID,DocIdentidad,Nombre,Apellidos,PersonaStatus")] tPersona tPersona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(tPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tPersona);
        }

        // GET: tPersonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tPersona tPersona = db.Personas.Find(id);
            if (tPersona == null)
            {
                return HttpNotFound();
            }
            return View(tPersona);
        }

        // POST: tPersonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaID,DocIdentidad,Nombre,Apellidos,PersonaStatus")] tPersona tPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tPersona);
        }

        // GET: tPersonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tPersona tPersona = db.Personas.Find(id);
            if (tPersona == null)
            {
                return HttpNotFound();
            }
            return View(tPersona);
        }

        // POST: tPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tPersona tPersona = db.Personas.Find(id);
            db.Personas.Remove(tPersona);
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
