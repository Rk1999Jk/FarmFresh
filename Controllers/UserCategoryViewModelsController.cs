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
    public class UserCategoryViewModelsController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: UserCategoryViewModels
        public ActionResult Index()
        {
            return View(db.UserCategoryViewModels.ToList());
        }

        // GET: UserCategoryViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategoryViewModel userCategoryViewModel = db.UserCategoryViewModels.Find(id);
            if (userCategoryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userCategoryViewModel);
        }

        // GET: UserCategoryViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCategoryViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cid,UserEmail,ChosenCategory")] UserCategoryViewModel userCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                db.UserCategoryViewModels.Add(userCategoryViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCategoryViewModel);
        }

        // GET: UserCategoryViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategoryViewModel userCategoryViewModel = db.UserCategoryViewModels.Find(id);
            if (userCategoryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userCategoryViewModel);
        }

        // POST: UserCategoryViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cid,UserEmail,ChosenCategory")] UserCategoryViewModel userCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCategoryViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCategoryViewModel);
        }

        // GET: UserCategoryViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategoryViewModel userCategoryViewModel = db.UserCategoryViewModels.Find(id);
            if (userCategoryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userCategoryViewModel);
        }

        // POST: UserCategoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCategoryViewModel userCategoryViewModel = db.UserCategoryViewModels.Find(id);
            db.UserCategoryViewModels.Remove(userCategoryViewModel);
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
