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
    public class UserCartsController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: UserCarts
        public ActionResult Index()
        {
            return View(db.UserCarts.ToList());
        }

        // GET: UserCarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCart userCart = db.UserCarts.Find(id);
            if (userCart == null)
            {
                return HttpNotFound();
            }
            return View(userCart);
        }

        // GET: UserCarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartId,ProductId,ItemName,Quantity,RatePerKg,Amount,FarmerEmail")] UserCart userCart)
        {
            if (ModelState.IsValid)
            {
                db.UserCarts.Add(userCart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCart);
        }

        // GET: UserCarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCart userCart = db.UserCarts.Find(id);
            if (userCart == null)
            {
                return HttpNotFound();
            }
            return View(userCart);
        }

        // POST: UserCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartId,ProductId,ItemName,Quantity,RatePerKg,Amount,FarmerEmail")] UserCart userCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCart);
        }

        // GET: UserCarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCart userCart = db.UserCarts.Find(id);
            if (userCart == null)
            {
                return HttpNotFound();
            }
            return View(userCart);
        }

        // POST: UserCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCart userCart = db.UserCarts.Find(id);
            db.UserCarts.Remove(userCart);
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
