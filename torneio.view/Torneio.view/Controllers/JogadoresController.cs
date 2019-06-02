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
    public class JogadoresController : Controller
    {
        private TorneioEntities db = new TorneioEntities();

        // GET: Jogadores
        public ActionResult Index()
        {
            var jogadores = db.Jogadores.Include(j => j.Times);
            return View(jogadores.ToList());
        }

        // GET: Jogadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // GET: Jogadores/Create
        public ActionResult Create()
        {
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Idade,Nacionalidade,DataNascimento,IDTime")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Jogadores.Add(jogadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", jogadores.IDTime);
            return View(jogadores);
        }

        // GET: Jogadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", jogadores.IDTime);
            return View(jogadores);
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Idade,Nacionalidade,DataNascimento,IDTime")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", jogadores.IDTime);
            return View(jogadores);
        }

        // GET: Jogadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogadores jogadores = db.Jogadores.Find(id);
            db.Jogadores.Remove(jogadores);
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
