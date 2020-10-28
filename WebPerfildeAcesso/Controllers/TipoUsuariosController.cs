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
    public class TipoUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            return View(db.TipoUsuarios.ToList());
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipousuario")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuarios.Add(tipoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipousuario")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            db.TipoUsuarios.Remove(tipoUsuario);
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
