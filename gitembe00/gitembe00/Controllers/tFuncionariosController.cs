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
    public class tFuncionariosController : Controller
    {
        private gitembeContext db = new gitembeContext();

        // GET: tFuncionarios
        public ActionResult Index()
        {
            var tFuncionarios = db.tFuncionarios.Include(t => t.tCargo).Include(t => t.tEscalafon).Include(t => t.tLugares).Include(t => t.tMunicipios).Include(t => t.tPersona).Include(t => t.tTiempo);
            return View(tFuncionarios.ToList());
        }

        // GET: tFuncionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFuncionario tFuncionario = db.tFuncionarios.Find(id);
            if (tFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tFuncionario);
        }

        // GET: tFuncionarios/Create
        public ActionResult Create()
        {
            ViewBag.CargoID = new SelectList(db.tCargos, "CargoID", "CargoSigla");
            ViewBag.EscalafonID = new SelectList(db.tEscalafons, "EscalafonID", "EscalafonDesc");
            ViewBag.LugarID = new SelectList(db.tLugars, "LugarID", "LugarDesc");
            ViewBag.MunicipioID = new SelectList(db.tMunicipios, "MunicipioID", "MunicipioDesc");
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "DocIdentidad");
            ViewBag.TiempoID = new SelectList(db.tTiempoes, "TiempoID", "TiempoDesc");
            return View();
        }

        // POST: tFuncionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuncionarioID,Item,Basico,CargoID,PersonaID,TiempoID,EscalafonID,LugarID,MunicipioID")] tFuncionario tFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.tFuncionarios.Add(tFuncionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoID = new SelectList(db.tCargos, "CargoID", "CargoSigla", tFuncionario.CargoID);
            ViewBag.EscalafonID = new SelectList(db.tEscalafons, "EscalafonID", "EscalafonDesc", tFuncionario.EscalafonID);
            ViewBag.LugarID = new SelectList(db.tLugars, "LugarID", "LugarDesc", tFuncionario.LugarID);
            ViewBag.MunicipioID = new SelectList(db.tMunicipios, "MunicipioID", "MunicipioDesc", tFuncionario.MunicipioID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "DocIdentidad", tFuncionario.PersonaID);
            ViewBag.TiempoID = new SelectList(db.tTiempoes, "TiempoID", "TiempoDesc", tFuncionario.TiempoID);
            return View(tFuncionario);
        }

        // GET: tFuncionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFuncionario tFuncionario = db.tFuncionarios.Find(id);
            if (tFuncionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoID = new SelectList(db.tCargos, "CargoID", "CargoSigla", tFuncionario.CargoID);
            ViewBag.EscalafonID = new SelectList(db.tEscalafons, "EscalafonID", "EscalafonDesc", tFuncionario.EscalafonID);
            ViewBag.LugarID = new SelectList(db.tLugars, "LugarID", "LugarDesc", tFuncionario.LugarID);
            ViewBag.MunicipioID = new SelectList(db.tMunicipios, "MunicipioID", "MunicipioDesc", tFuncionario.MunicipioID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "DocIdentidad", tFuncionario.PersonaID);
            ViewBag.TiempoID = new SelectList(db.tTiempoes, "TiempoID", "TiempoDesc", tFuncionario.TiempoID);
            return View(tFuncionario);
        }

        // POST: tFuncionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioID,Item,Basico,CargoID,PersonaID,TiempoID,EscalafonID,LugarID,MunicipioID")] tFuncionario tFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFuncionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoID = new SelectList(db.tCargos, "CargoID", "CargoSigla", tFuncionario.CargoID);
            ViewBag.EscalafonID = new SelectList(db.tEscalafons, "EscalafonID", "EscalafonDesc", tFuncionario.EscalafonID);
            ViewBag.LugarID = new SelectList(db.tLugars, "LugarID", "LugarDesc", tFuncionario.LugarID);
            ViewBag.MunicipioID = new SelectList(db.tMunicipios, "MunicipioID", "MunicipioDesc", tFuncionario.MunicipioID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "DocIdentidad", tFuncionario.PersonaID);
            ViewBag.TiempoID = new SelectList(db.tTiempoes, "TiempoID", "TiempoDesc", tFuncionario.TiempoID);
            return View(tFuncionario);
        }

        // GET: tFuncionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFuncionario tFuncionario = db.tFuncionarios.Find(id);
            if (tFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tFuncionario);
        }

        // POST: tFuncionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tFuncionario tFuncionario = db.tFuncionarios.Find(id);
            db.tFuncionarios.Remove(tFuncionario);
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
