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
    public class PytaniesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Pytanies
        public ActionResult Index()
        {
            return View(db.Pytania.ToList());
        }

        // GET: Pytanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pytanie pytanie = db.Pytania.Find(id);
            if (pytanie == null)
            {
                return HttpNotFound();
            }
            return View(pytanie);
        }

        // GET: Pytanies/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Pytanie());
        }

        // POST: Pytanies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pytanieId,tresc")] Pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                db.Pytania.Add(pytanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pytanie);
        }

        // GET: Pytanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pytanie pytanie = db.Pytania.Find(id);
            if (pytanie == null)
            {
                return HttpNotFound();
            }
            return View(pytanie);
        }

        // POST: Pytanies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pytanieId,tresc")] Pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pytanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pytanie);
        }

        // GET: Pytanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pytanie pytanie = db.Pytania.Find(id);
            if (pytanie == null)
            {
                return HttpNotFound();
            }
            return View(pytanie);
        }

        // POST: Pytanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pytanie pytanie = db.Pytania.Find(id);
            db.Pytania.Remove(pytanie);
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
