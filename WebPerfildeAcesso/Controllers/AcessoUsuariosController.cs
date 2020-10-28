using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPerfildeAcesso.Models;

namespace WebPerfildeAcesso.Controllers
{
    public class AcessoUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcessoUsuarios
        public ActionResult Index()
        {
            var acessoUsuarios = db.AcessoUsuarios.Include(a => a.TipoUsuario);
            return View(acessoUsuarios.ToList());
        }

        // GET: AcessoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcessoUsuario acessoUsuario = db.AcessoUsuarios.Find(id);
            if (acessoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(acessoUsuario);
        }

        // GET: AcessoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuarios, "Id", "Tipousuario");
            return View();
        }

        // POST: AcessoUsuarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeOcupação,IdTipoUsuario")] AcessoUsuario acessoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.AcessoUsuarios.Add(acessoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuarios, "Id", "Tipousuario", acessoUsuario.IdTipoUsuario);
            return View(acessoUsuario);
        }

        // GET: AcessoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcessoUsuario acessoUsuario = db.AcessoUsuarios.Find(id);
            if (acessoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuarios, "Id", "Tipousuario", acessoUsuario.IdTipoUsuario);
            return View(acessoUsuario);
        }

        // POST: AcessoUsuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeOcupação,IdTipoUsuario")] AcessoUsuario acessoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acessoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuarios, "Id", "Tipousuario", acessoUsuario.IdTipoUsuario);
            return View(acessoUsuario);
        }

        // GET: AcessoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcessoUsuario acessoUsuario = db.AcessoUsuarios.Find(id);
            if (acessoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(acessoUsuario);
        }

        // POST: AcessoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcessoUsuario acessoUsuario = db.AcessoUsuarios.Find(id);
            db.AcessoUsuarios.Remove(acessoUsuario);
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
