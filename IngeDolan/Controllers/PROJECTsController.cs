using IngeDolan.App_Start;
using IngeDolan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Collections.Generic;


namespace IngeDolan.Controllers
{
    public class PROJECTsController : ToastrController
    {
        private dolansoftEntities db = new dolansoftEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: PROJECTs
        [Authorize(Roles = "Profesor")]
        //Oh snap!
        public ActionResult Index(int page = 1, string sort = "PROJECT_NAME", string sortdir = "asc", string search = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetProjects(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<PROJECT> GetProjects(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            var v = (from a in db.PROJECTs
                     where
                        a.PROJECT_ID.Contains(search) ||
                        a.PROJECT_NAME.Contains(search) ||
                        a.DESCRIPTIONS.Contains(search)
                     select a
                        );
            totalRecord = v.Count();
            v = v.OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                v = v.Skip(skip).Take(pageSize);
            }
            return v.ToList();
        }
        //Oh jeez

        // GET: PROJECTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // GET: PROJECTs/Create
        public ActionResult Create()
        {
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "USERS_ID");
            return View();
        }

        // POST: PROJECTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROJECT_ID,STARTING_DATE,FINAL_DATE,DESCRIPTIONS,PROJECT_NAME,LEADER_ID")] PROJECT pROJECT)
        {
            if (ModelState.IsValid)
            {
                db.PROJECTs.Add(pROJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "USERS_ID", pROJECT.LEADER_ID);
            return View(pROJECT);
        }

        // GET: PROJECTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE", pROJECT.LEADER_ID);
            return View(pROJECT);
        }

        // POST: PROJECTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROJECT_ID,STARTING_DATE,FINAL_DATE,DESCRIPTIONS,PROJECT_NAME,LEADER_ID")] PROJECT pROJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE", pROJECT.LEADER_ID);
            return View(pROJECT);
        }

        // GET: PROJECTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // POST: PROJECTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT pROJECT = db.PROJECTs.Find(id);
            db.PROJECTs.Remove(pROJECT);
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
