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
    public class PrincipalMastersController : Controller
    {
        private CSSDBEntities db = new CSSDBEntities();

        // GET: PrincipalMasters
        public ActionResult Index()
        {
            return View(db.PrincipalMasters.ToList());
        }        

        // GET: PrincipalMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrincipalMaster principalMaster = db.PrincipalMasters.Find(id);
            if (principalMaster == null)
            {
                return HttpNotFound();
            }
            return View(principalMaster);
        }

        // GET: PrincipalMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrincipalMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PricipalID,PrincipalCode,PrincipalName,AddressLine1,AddressLine2,AddressLine3,Contact,Telephone1,Telephone2,CountryCode,CountryName,Fax1,Fax2,Email,Remarks")] PrincipalMaster principalMaster)
        {
            if (ModelState.IsValid)
            {
                db.PrincipalMasters.Add(principalMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(principalMaster);
        }

        // GET: PrincipalMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrincipalMaster principalMaster = db.PrincipalMasters.Find(id);
            if (principalMaster == null)
            {
                return HttpNotFound();
            }
            return View(principalMaster);
        }

        // POST: PrincipalMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PricipalID,PrincipalCode,PrincipalName,AddressLine1,AddressLine2,AddressLine3,Contact,Telephone1,Telephone2,CountryCode,CountryName,Fax1,Fax2,Email,Remarks")] PrincipalMaster principalMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(principalMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(principalMaster);
        }

        // GET: PrincipalMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrincipalMaster principalMaster = db.PrincipalMasters.Find(id);
            if (principalMaster == null)
            {
                return HttpNotFound();
            }
            return View(principalMaster);
        }

        // POST: PrincipalMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrincipalMaster principalMaster = db.PrincipalMasters.Find(id);
            db.PrincipalMasters.Remove(principalMaster);
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
