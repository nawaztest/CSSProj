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
    public class EngineerMasterController : Controller
    {
        private CSSDBEntities db = new CSSDBEntities();

        // GET: EngineerMaster
        public ActionResult Index()
        {
            return View(db.EngineerMasters.ToList());
        }

        // GET: EngineerMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineerMaster engineerMaster = db.EngineerMasters.Find(id);
            if (engineerMaster == null)
            {
                return HttpNotFound();
            }
            return View(engineerMaster);
        }

        // GET: EngineerMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EngineerMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EngineerID,EngineerCode,EngineerName,CountryCode,CountryName,Phone,Mobile,Fax,Email")] EngineerMaster engineerMaster)
        {
            if (ModelState.IsValid)
            {
                db.EngineerMasters.Add(engineerMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engineerMaster);
        }

        // GET: EngineerMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineerMaster engineerMaster = db.EngineerMasters.Find(id);
            if (engineerMaster == null)
            {
                return HttpNotFound();
            }
            return View(engineerMaster);
        }

        // POST: EngineerMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EngineerID,EngineerCode,EngineerName,CountryCode,CountryName,Phone,Mobile,Fax,Email")] EngineerMaster engineerMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineerMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engineerMaster);
        }

        // GET: EngineerMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineerMaster engineerMaster = db.EngineerMasters.Find(id);
            if (engineerMaster == null)
            {
                return HttpNotFound();
            }
            return View(engineerMaster);
        }

        // POST: EngineerMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngineerMaster engineerMaster = db.EngineerMasters.Find(id);
            db.EngineerMasters.Remove(engineerMaster);
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
