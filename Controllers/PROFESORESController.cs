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
    public class PROFESORESController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: PROFESORES
        public ActionResult Index()
        {
            return View(db.PROFESORES.ToList());
        }

        // GET: PROFESORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESORES pROFESORES = db.PROFESORES.Find(id);
            if (pROFESORES == null)
            {
                return HttpNotFound();
            }
            return View(pROFESORES);
        }

        // GET: PROFESORES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROFESORES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,CORREO")] PROFESORES pROFESORES)
        {
            if (ModelState.IsValid)
            {
                db.PROFESORES.Add(pROFESORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROFESORES);
        }

        // GET: PROFESORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESORES pROFESORES = db.PROFESORES.Find(id);
            if (pROFESORES == null)
            {
                return HttpNotFound();
            }
            return View(pROFESORES);
        }

        // POST: PROFESORES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,CORREO")] PROFESORES pROFESORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFESORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROFESORES);
        }

        // GET: PROFESORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESORES pROFESORES = db.PROFESORES.Find(id);
            if (pROFESORES == null)
            {
                return HttpNotFound();
            }
            return View(pROFESORES);
        }

        // POST: PROFESORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROFESORES pROFESORES = db.PROFESORES.Find(id);
            db.PROFESORES.Remove(pROFESORES);
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
