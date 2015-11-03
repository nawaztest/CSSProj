using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSSDBLibrary;

namespace CSSProj.Controllers
{
    public class ProductVersionController : Controller
    {
        private CSSDBEntities db = new CSSDBEntities();

        // GET: ProductVersion
        public ActionResult Index()
        {
            return View(db.ProductVersions.ToList());
        }

        // GET: ProductVersion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVersion productVersion = db.ProductVersions.Find(id);
            if (productVersion == null)
            {
                return HttpNotFound();
            }
            return View(productVersion);
        }

        // GET: ProductVersion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductVersion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductCode,ProductName,VersionCode,VersionName")] ProductVersion productVersion)
        {
            if (ModelState.IsValid)
            {
                db.ProductVersions.Add(productVersion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productVersion);
        }

        // GET: ProductVersion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVersion productVersion = db.ProductVersions.Find(id);
            if (productVersion == null)
            {
                return HttpNotFound();
            }
            return View(productVersion);
        }

        // POST: ProductVersion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductCode,ProductName,VersionCode,VersionName")] ProductVersion productVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productVersion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVersion);
        }

        // GET: ProductVersion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVersion productVersion = db.ProductVersions.Find(id);
            if (productVersion == null)
            {
                return HttpNotFound();
            }
            return View(productVersion);
        }

        // POST: ProductVersion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductVersion productVersion = db.ProductVersions.Find(id);
            db.ProductVersions.Remove(productVersion);
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
