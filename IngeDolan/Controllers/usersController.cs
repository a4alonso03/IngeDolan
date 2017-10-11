using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngeDolan.Models;

namespace IngeDolan.Controllers
{
    public class usersController : Controller
    {
        private dolansoftEntities db = new dolansoftEntities();

        // GET: users
        public ActionResult Index()
        {
            var uSERS = db.USERS.Include(u => u.PROJECT).Include(u => u.ROLE);
            return View(uSERS.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS");
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERS_ID,ROLE_TYPE,EMAIL,USERNAME,SURNAME,LASTNAME,PASSWORDS,PROJECT_ID,STUDENT_ID,REMEMBER")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USERS.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", uSER.PROJECT_ID);
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSER.ROLE_TYPE);
            return View(uSER);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", uSER.PROJECT_ID);
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSER.ROLE_TYPE);
            return View(uSER);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERS_ID,ROLE_TYPE,EMAIL,USERNAME,SURNAME,LASTNAME,PASSWORDS,PROJECT_ID,STUDENT_ID,REMEMBER")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", uSER.PROJECT_ID);
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSER.ROLE_TYPE);
            return View(uSER);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USERS.Find(id);
            db.USERS.Remove(uSER);
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
