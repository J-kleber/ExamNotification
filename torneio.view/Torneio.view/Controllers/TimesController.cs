using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Torneio.model;

namespace Torneio.view.Views
{
    public class TimesController : Controller
    {
        private TorneioEntities db = new TorneioEntities();

        // GET: Times
        public ActionResult Index()
        {
            return View(db.Times.ToList());
        }

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Times times = db.Times.Find(id);
            if (times == null)
            {
                return HttpNotFound();
            }
            return View(times);
        }

        // GET: Times/Create
        [Authorize(Roles = "Organizador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organizador")]
        public ActionResult Create([Bind(Include = "ID,Nome,Emblema,Sigla")] Times times)
        {
            if (ModelState.IsValid)
            {
                db.Times.Add(times);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(times);
        }

        // GET: Times/Edit/5
        [Authorize(Roles = "Organizador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Times times = db.Times.Find(id);
            if (times == null)
            {
                return HttpNotFound();
            }
            return View(times);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organizador")]
        public ActionResult Edit([Bind(Include = "ID,Nome,Emblema,Sigla")] Times times)
        {
            if (ModelState.IsValid)
            {
                db.Entry(times).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(times);
        }

        // GET: Times/Delete/5
        [Authorize(Roles = "Organizador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Times times = db.Times.Find(id);
            if (times == null)
            {
                return HttpNotFound();
            }
            return View(times);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organizador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Times times = db.Times.Find(id);
            db.Times.Remove(times);
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
