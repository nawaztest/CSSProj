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
    public class StatusMasterController : Controller
    {
        private CSSDBEntities db = new CSSDBEntities();

        // GET: StatusMaster
        public ActionResult Index()
        {
            return View(db.StatusMasters.ToList());
        }

        // GET: StatusMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = db.StatusMasters.Find(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // GET: StatusMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StatusCode,Status")] StatusMaster statusMaster)
        {
            if (ModelState.IsValid)
            {
                db.StatusMasters.Add(statusMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusMaster);
        }

        // GET: StatusMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = db.StatusMasters.Find(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // POST: StatusMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StatusCode,Status")] StatusMaster statusMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusMaster);
        }

        // GET: StatusMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = db.StatusMasters.Find(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // POST: StatusMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusMaster statusMaster = db.StatusMasters.Find(id);
            db.StatusMasters.Remove(statusMaster);
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
