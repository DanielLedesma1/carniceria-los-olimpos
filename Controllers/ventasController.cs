using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Olimpos.Models;

namespace Olimpos.Controllers
{
    public class ventasController : Controller
    {
        private carniceriaEntities db = new carniceriaEntities();

        // GET: ventas
        public ActionResult Index()
        {
            var ventas = db.ventas.Include(v => v.clientes).Include(v => v.productos);
            return View(ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            ViewBag.cliente_venta = new SelectList(db.clientes, "id_cliente", "doc_cliente");
            ViewBag.producto_venta = new SelectList(db.productos, "id_producto", "nom_producto");
            return View();
        }

        // POST: ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_venta,cliente_venta,producto_venta,fecha_venta,cantidad_venta,precio_total_venta")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_venta = new SelectList(db.clientes, "id_cliente", "doc_cliente", ventas.cliente_venta);
            ViewBag.producto_venta = new SelectList(db.productos, "id_producto", "nom_producto", ventas.producto_venta);
            return View(ventas);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_venta = new SelectList(db.clientes, "id_cliente", "doc_cliente", ventas.cliente_venta);
            ViewBag.producto_venta = new SelectList(db.productos, "id_producto", "nom_producto", ventas.producto_venta);
            return View(ventas);
        }

        // POST: ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_venta,cliente_venta,producto_venta,fecha_venta,cantidad_venta,precio_total_venta")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_venta = new SelectList(db.clientes, "id_cliente", "doc_cliente", ventas.cliente_venta);
            ViewBag.producto_venta = new SelectList(db.productos, "id_producto", "nom_producto", ventas.producto_venta);
            return View(ventas);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ventas ventas = db.ventas.Find(id);
            db.ventas.Remove(ventas);
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
