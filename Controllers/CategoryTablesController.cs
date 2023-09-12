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
    public class CategoryTablesController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: CategoryTables
        public ActionResult Index()
        {
            return View(db.CategoryTables.ToList());
        }

        // GET: CategoryTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            return View(categoryTable);
        }

        // GET: CategoryTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTables.Add(categoryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryTable);
        }

        // GET: CategoryTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            return View(categoryTable);
        }

        // POST: CategoryTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryTable);
        }

        // GET: CategoryTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            return View(categoryTable);
        }

        // POST: CategoryTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            db.CategoryTables.Remove(categoryTable);
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
