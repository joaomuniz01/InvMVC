using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvMVC.Models;

namespace InvMVC.Controllers
{
    public class AtivoController : Controller
    {
        private AtivoContext db = new AtivoContext();

        // GET: Ativo
        public ActionResult Index()
        {
            var ativos = db.Ativos.Include(a => a.Usuario);
            return View(ativos.ToList());
        }

        // GET: Ativo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // GET: Ativo/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Ativo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtivoId,Descricao,Tipo,Local,UsuarioId")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Ativos.Add(ativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", ativo.UsuarioId);
            return View(ativo);
        }

        // GET: Ativo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", ativo.UsuarioId);
            return View(ativo);
        }

        // POST: Ativo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtivoId,Descricao,Tipo,Local,UsuarioId")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", ativo.UsuarioId);
            return View(ativo);
        }

        // GET: Ativo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // POST: Ativo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ativo ativo = db.Ativos.Find(id);
            db.Ativos.Remove(ativo);
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
