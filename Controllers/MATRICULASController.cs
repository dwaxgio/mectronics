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
    public class MATRICULASController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: MATRICULAS
        public ActionResult Index()
        {
            var mATRICULAS = db.MATRICULAS.Include(m => m.ALUMNOS).Include(m => m.CLASES);
            return View(mATRICULAS.ToList());
        }

        // GET: MATRICULAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULAS mATRICULAS = db.MATRICULAS.Find(id);
            if (mATRICULAS == null)
            {
                return HttpNotFound();
            }
            return View(mATRICULAS);
        }

        // GET: MATRICULAS/Create
        public ActionResult Create()
        {
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNOS, "ID", "DOCUMENTO");
            ViewBag.ID_CLASE = new SelectList(db.CLASES, "ID", "ID");
            return View();
        }

        // POST: MATRICULAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_CLASE,ID_ALUMNO,NOTA,FECHA_NOTA")] MATRICULAS mATRICULAS)
        {
            if (ModelState.IsValid)
            {
                db.MATRICULAS.Add(mATRICULAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNOS, "ID", "DOCUMENTO", mATRICULAS.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASES, "ID", "ID", mATRICULAS.ID_CLASE);
            return View(mATRICULAS);
        }

        // GET: MATRICULAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULAS mATRICULAS = db.MATRICULAS.Find(id);
            if (mATRICULAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNOS, "ID", "DOCUMENTO", mATRICULAS.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASES, "ID", "ID", mATRICULAS.ID_CLASE);
            return View(mATRICULAS);
        }

        // POST: MATRICULAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_CLASE,ID_ALUMNO,NOTA,FECHA_NOTA")] MATRICULAS mATRICULAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATRICULAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNOS, "ID", "DOCUMENTO", mATRICULAS.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASES, "ID", "ID", mATRICULAS.ID_CLASE);
            return View(mATRICULAS);
        }

        // GET: MATRICULAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULAS mATRICULAS = db.MATRICULAS.Find(id);
            if (mATRICULAS == null)
            {
                return HttpNotFound();
            }
            return View(mATRICULAS);
        }

        // POST: MATRICULAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATRICULAS mATRICULAS = db.MATRICULAS.Find(id);
            db.MATRICULAS.Remove(mATRICULAS);
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
