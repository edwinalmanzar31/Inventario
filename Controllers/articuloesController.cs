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
    public class articuloesController : Controller
    {
        private inventarioEntities db = new inventarioEntities();

        // GET: articuloes
        [Authorize]
        public ActionResult Index()
        {
            var articulos = db.articulos.Include(a => a.tiposInventario);
            return View(articulos.ToList());
        }

        // GET: articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: articuloes/Create
        public ActionResult Create()
        {
            ViewBag.idTipoInventario = new SelectList(db.tiposInventarios, "id", "descripcion");
            return View();
        }

        // POST: articuloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,existencia,idTipoInventario,costoUnitario,estado")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoInventario = new SelectList(db.tiposInventarios, "id", "descripcion", articulo.idTipoInventario);
            return View(articulo);
        }

        // GET: articuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoInventario = new SelectList(db.tiposInventarios, "id", "descripcion", articulo.idTipoInventario);
            return View(articulo);
        }

        // POST: articuloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,existencia,idTipoInventario,costoUnitario,estado")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoInventario = new SelectList(db.tiposInventarios, "id", "descripcion", articulo.idTipoInventario);
            return View(articulo);
        }

        // GET: articuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            articulo articulo = db.articulos.Find(id);
            db.articulos.Remove(articulo);
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
