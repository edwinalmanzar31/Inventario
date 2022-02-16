using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class tiposInventariosController : Controller
    {
        private inventarioEntities db = new inventarioEntities();

        // GET: tiposInventarios
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tiposInventarios.ToList());
        }

        // GET: tiposInventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposInventario tiposInventario = db.tiposInventarios.Find(id);
            if (tiposInventario == null)
            {
                return HttpNotFound();
            }
            return View(tiposInventario);
        }

        // GET: tiposInventarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tiposInventarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,cuentaContable,estado")] tiposInventario tiposInventario)
        {
            if (ModelState.IsValid)
            {
                db.tiposInventarios.Add(tiposInventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposInventario);
        }

        // GET: tiposInventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposInventario tiposInventario = db.tiposInventarios.Find(id);
            if (tiposInventario == null)
            {
                return HttpNotFound();
            }
            return View(tiposInventario);
        }

        // POST: tiposInventarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,cuentaContable,estado")] tiposInventario tiposInventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposInventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposInventario);
        }

        // GET: tiposInventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposInventario tiposInventario = db.tiposInventarios.Find(id);
            if (tiposInventario == null)
            {
                return HttpNotFound();
            }
            return View(tiposInventario);
        }

        // POST: tiposInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tiposInventario tiposInventario = db.tiposInventarios.Find(id);
            db.tiposInventarios.Remove(tiposInventario);
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
