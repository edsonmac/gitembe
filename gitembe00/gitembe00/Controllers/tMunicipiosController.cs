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
    public class tMunicipiosController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tMunicipios
        public ActionResult Index()
        {
            return View(db.tMunicipios.ToList());
        }

        // GET: tMunicipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMunicipio tMunicipio = db.tMunicipios.Find(id);
            if (tMunicipio == null)
            {
                return HttpNotFound();
            }
            return View(tMunicipio);
        }

        // GET: tMunicipios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tMunicipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipioID,MunicipioDesc,MunicipioStatus")] tMunicipio tMunicipio)
        {
            if (ModelState.IsValid)
            {
                db.tMunicipios.Add(tMunicipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tMunicipio);
        }

        // GET: tMunicipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMunicipio tMunicipio = db.tMunicipios.Find(id);
            if (tMunicipio == null)
            {
                return HttpNotFound();
            }
            return View(tMunicipio);
        }

        // POST: tMunicipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipioID,MunicipioDesc,MunicipioStatus")] tMunicipio tMunicipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tMunicipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tMunicipio);
        }

        // GET: tMunicipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMunicipio tMunicipio = db.tMunicipios.Find(id);
            if (tMunicipio == null)
            {
                return HttpNotFound();
            }
            return View(tMunicipio);
        }

        // POST: tMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tMunicipio tMunicipio = db.tMunicipios.Find(id);
            db.tMunicipios.Remove(tMunicipio);
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
