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
    public class SALONESController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: SALONES
        public ActionResult Index()
        {
            return View(db.SALONES.ToList());
        }

        // GET: SALONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALONES sALONES = db.SALONES.Find(id);
            if (sALONES == null)
            {
                return HttpNotFound();
            }
            return View(sALONES);
        }

        // GET: SALONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALONES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION")] SALONES sALONES)
        {
            if (ModelState.IsValid)
            {
                db.SALONES.Add(sALONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALONES);
        }

        // GET: SALONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALONES sALONES = db.SALONES.Find(id);
            if (sALONES == null)
            {
                return HttpNotFound();
            }
            return View(sALONES);
        }

        // POST: SALONES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION")] SALONES sALONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALONES);
        }

        // GET: SALONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALONES sALONES = db.SALONES.Find(id);
            if (sALONES == null)
            {
                return HttpNotFound();
            }
            return View(sALONES);
        }

        // POST: SALONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALONES sALONES = db.SALONES.Find(id);
            db.SALONES.Remove(sALONES);
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
