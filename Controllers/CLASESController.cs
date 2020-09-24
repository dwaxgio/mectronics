using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MECTRONICS.Models;

namespace MECTRONICS.Controllers
{
    public class CLASESController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: CLASES
        public ActionResult Index()
        {
            var cLASES = db.CLASES.Include(c => c.MATERIAS).Include(c => c.PROFESORES).Include(c => c.SALONES);
            return View(cLASES.ToList());
        }

        // GET: CLASES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASES cLASES = db.CLASES.Find(id);
            if (cLASES == null)
            {
                return HttpNotFound();
            }
            return View(cLASES);
        }

        // GET: CLASES/Create
        public ActionResult Create()
        {
            ViewBag.ID_MATERIA = new SelectList(db.MATERIAS, "ID", "DESCRIPCION");
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESORES, "ID", "DOCUMENTO");
            ViewBag.ID_SALON = new SelectList(db.SALONES, "ID", "DESCRIPCION");
            return View();
        }

        // POST: CLASES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PROFESOR,ID_MATERIA,ID_SALON")] CLASES cLASES)
        {
            if (ModelState.IsValid)
            {
                db.CLASES.Add(cLASES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MATERIA = new SelectList(db.MATERIAS, "ID", "DESCRIPCION", cLASES.ID_MATERIA);
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESORES, "ID", "DOCUMENTO", cLASES.ID_PROFESOR);
            ViewBag.ID_SALON = new SelectList(db.SALONES, "ID", "DESCRIPCION", cLASES.ID_SALON);
            return View(cLASES);
        }

        // GET: CLASES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASES cLASES = db.CLASES.Find(id);
            if (cLASES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIAS, "ID", "DESCRIPCION", cLASES.ID_MATERIA);
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESORES, "ID", "DOCUMENTO", cLASES.ID_PROFESOR);
            ViewBag.ID_SALON = new SelectList(db.SALONES, "ID", "DESCRIPCION", cLASES.ID_SALON);
            return View(cLASES);
        }

        // POST: CLASES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PROFESOR,ID_MATERIA,ID_SALON")] CLASES cLASES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIAS, "ID", "DESCRIPCION", cLASES.ID_MATERIA);
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESORES, "ID", "DOCUMENTO", cLASES.ID_PROFESOR);
            ViewBag.ID_SALON = new SelectList(db.SALONES, "ID", "DESCRIPCION", cLASES.ID_SALON);
            return View(cLASES);
        }

        // GET: CLASES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASES cLASES = db.CLASES.Find(id);
            if (cLASES == null)
            {
                return HttpNotFound();
            }
            return View(cLASES);
        }

        // POST: CLASES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASES cLASES = db.CLASES.Find(id);
            db.CLASES.Remove(cLASES);
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
