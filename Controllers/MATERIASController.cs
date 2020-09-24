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
    public class MATERIASController : Controller
    {
        private MectronicsEntities db = new MectronicsEntities();

        // GET: MATERIAS
        public ActionResult Index()
        {
            return View(db.MATERIAS.ToList());
        }

        // GET: MATERIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIAS mATERIAS = db.MATERIAS.Find(id);
            if (mATERIAS == null)
            {
                return HttpNotFound();
            }
            return View(mATERIAS);
        }

        // GET: MATERIAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MATERIAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION")] MATERIAS mATERIAS)
        {
            if (ModelState.IsValid)
            {
                db.MATERIAS.Add(mATERIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mATERIAS);
        }

        // GET: MATERIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIAS mATERIAS = db.MATERIAS.Find(id);
            if (mATERIAS == null)
            {
                return HttpNotFound();
            }
            return View(mATERIAS);
        }

        // POST: MATERIAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION")] MATERIAS mATERIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATERIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mATERIAS);
        }

        // GET: MATERIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIAS mATERIAS = db.MATERIAS.Find(id);
            if (mATERIAS == null)
            {
                return HttpNotFound();
            }
            return View(mATERIAS);
        }

        // POST: MATERIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATERIAS mATERIAS = db.MATERIAS.Find(id);
            db.MATERIAS.Remove(mATERIAS);
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
