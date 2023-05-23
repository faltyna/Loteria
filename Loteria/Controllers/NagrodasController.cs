using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loteria.Models;
using Loteria.Models.DbModels;

namespace Loteria.Controllers
{
    public class NagrodasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Nagrodas
        public ActionResult Index()
        {
            return View(db.Nagrody.ToList());
        }

        // GET: Nagrodas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagroda nagroda = db.Nagrody.Find(id);
            if (nagroda == null)
            {
                return HttpNotFound();
            }
            return View(nagroda);
        }

        // GET: Nagrodas/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Nagroda());
        }

        // POST: Nagrodas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nagrodaId,nagroda")] Nagroda nagroda)
        {
            if (ModelState.IsValid)
            {
                db.Nagrody.Add(nagroda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nagroda);
        }

        // GET: Nagrodas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagroda nagroda = db.Nagrody.Find(id);
            if (nagroda == null)
            {
                return HttpNotFound();
            }
            return View(nagroda);
        }

        // POST: Nagrodas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nagrodaId,nagroda")] Nagroda nagroda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nagroda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nagroda);
        }

        // GET: Nagrodas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagroda nagroda = db.Nagrody.Find(id);
            if (nagroda == null)
            {
                return HttpNotFound();
            }
            return View(nagroda);
        }

        // POST: Nagrodas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nagroda nagroda = db.Nagrody.Find(id);
            db.Nagrody.Remove(nagroda);
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
