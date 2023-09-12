using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class FarmerDetailsController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: FarmerDetails
        public ActionResult Index()
        {
            return View(db.FarmerDetails.ToList());
        }

        // GET: FarmerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmerDetails farmerDetails = db.FarmerDetails.Find(id);
            if (farmerDetails == null)
            {
                return HttpNotFound();
            }
            return View(farmerDetails);
        }

        // GET: FarmerDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmerId,FarmersName,FarmersMobileNumber,FarmsAddress,FarmersEmail,FPassword,FConfirmPassword")] FarmerDetails farmerDetails)
        {
            if (ModelState.IsValid)
            {
                db.FarmerDetails.Add(farmerDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmerDetails);
        }

        // GET: FarmerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmerDetails farmerDetails = db.FarmerDetails.Find(id);
            if (farmerDetails == null)
            {
                return HttpNotFound();
            }
            return View(farmerDetails);
        }

        // POST: FarmerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmerId,FarmersName,FarmersMobileNumber,FarmsAddress,FarmersEmail,FPassword,FConfirmPassword")] FarmerDetails farmerDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmerDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmerDetails);
        }

        // GET: FarmerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmerDetails farmerDetails = db.FarmerDetails.Find(id);
            if (farmerDetails == null)
            {
                return HttpNotFound();
            }
            return View(farmerDetails);
        }

        // POST: FarmerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FarmerDetails farmerDetails = db.FarmerDetails.Find(id);
            db.FarmerDetails.Remove(farmerDetails);
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
