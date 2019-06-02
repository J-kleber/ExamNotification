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
    public class EscalacoesController : Controller
    {
        private TorneioEntities db = new TorneioEntities();

        // GET: Escalacoes
        public ActionResult Index()
        {
            var escalacoes = db.Escalacoes.Include(e => e.Jogadores).Include(e => e.Partidas).Include(e => e.Times);
            return View(escalacoes.ToList());
        }

        // GET: Escalacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacoes escalacoes = db.Escalacoes.Find(id);
            if (escalacoes == null)
            {
                return HttpNotFound();
            }
            return View(escalacoes);
        }

        // GET: Escalacoes/Create
        public ActionResult Create()
        {
            ViewBag.IDTime = new SelectList(db.Jogadores, "ID", "Nome");
            ViewBag.IDPartida = new SelectList(db.Partidas, "ID", "ID");
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome");
            return View();
        }

        // POST: Escalacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTime,IDPartida,IDJogador,Titular,Posicao")] Escalacoes escalacoes)
        {
            if (ModelState.IsValid)
            {
                db.Escalacoes.Add(escalacoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTime = new SelectList(db.Jogadores, "ID", "Nome", escalacoes.IDTime);
            ViewBag.IDPartida = new SelectList(db.Partidas, "ID", "ID", escalacoes.IDPartida);
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", escalacoes.IDTime);
            return View(escalacoes);
        }

        // GET: Escalacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacoes escalacoes = db.Escalacoes.Find(id);
            if (escalacoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTime = new SelectList(db.Jogadores, "ID", "Nome", escalacoes.IDTime);
            ViewBag.IDPartida = new SelectList(db.Partidas, "ID", "ID", escalacoes.IDPartida);
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", escalacoes.IDTime);
            return View(escalacoes);
        }

        // POST: Escalacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTime,IDPartida,IDJogador,Titular,Posicao")] Escalacoes escalacoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalacoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTime = new SelectList(db.Jogadores, "ID", "Nome", escalacoes.IDTime);
            ViewBag.IDPartida = new SelectList(db.Partidas, "ID", "ID", escalacoes.IDPartida);
            ViewBag.IDTime = new SelectList(db.Times, "ID", "Nome", escalacoes.IDTime);
            return View(escalacoes);
        }

        // GET: Escalacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacoes escalacoes = db.Escalacoes.Find(id);
            if (escalacoes == null)
            {
                return HttpNotFound();
            }
            return View(escalacoes);
        }

        // POST: Escalacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escalacoes escalacoes = db.Escalacoes.Find(id);
            db.Escalacoes.Remove(escalacoes);
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
