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
    public class ALUMNOSController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: ALUMNOS
        public ActionResult Index()
        {
            return View(db.ALUMNOS.ToList());
        }

        // GET: ALUMNOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNOS aLUMNOS = db.ALUMNOS.Find(id);
            if (aLUMNOS == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNOS);
        }

        // GET: ALUMNOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALUMNOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,CORREO,FECHA_INGRESO")] ALUMNOS aLUMNOS)
        {
            if (ModelState.IsValid)
            {
                db.ALUMNOS.Add(aLUMNOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLUMNOS);
        }

        // GET: ALUMNOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNOS aLUMNOS = db.ALUMNOS.Find(id);
            if (aLUMNOS == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNOS);
        }

        // POST: ALUMNOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,CORREO,FECHA_INGRESO")] ALUMNOS aLUMNOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUMNOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLUMNOS);
        }

        // GET: ALUMNOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNOS aLUMNOS = db.ALUMNOS.Find(id);
            if (aLUMNOS == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNOS);
        }

        // POST: ALUMNOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUMNOS aLUMNOS = db.ALUMNOS.Find(id);
            db.ALUMNOS.Remove(aLUMNOS);
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
