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
    public class BACKLOGsController : Controller
    {
        private dolansoftEntities db = new dolansoftEntities();

        // GET: BACKLOGs
        public ActionResult Index()
        {
            var bACKLOGs = db.BACKLOGs.Include(b => b.PROJECT);
            return View(bACKLOGs.ToList());
        }

        // GET: BACKLOGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACKLOG bACKLOG = db.BACKLOGs.Find(id);
            if (bACKLOG == null)
            {
                return HttpNotFound();
            }
            return View(bACKLOG);
        }

        // GET: BACKLOGs/Create
        public ActionResult Create()
        {
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS");
            return View();
        }

        // POST: BACKLOGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BACKLOG_ID,PROJECT_ID")] BACKLOG bACKLOG)
        {
            if (ModelState.IsValid)
            {
                db.BACKLOGs.Add(bACKLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            return View(bACKLOG);
        }

        // GET: BACKLOGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACKLOG bACKLOG = db.BACKLOGs.Find(id);
            if (bACKLOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            return View(bACKLOG);
        }

        // POST: BACKLOGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BACKLOG_ID,PROJECT_ID")] BACKLOG bACKLOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bACKLOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECTs, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            return View(bACKLOG);
        }

        // GET: BACKLOGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACKLOG bACKLOG = db.BACKLOGs.Find(id);
            if (bACKLOG == null)
            {
                return HttpNotFound();
            }
            return View(bACKLOG);
        }

        // POST: BACKLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BACKLOG bACKLOG = db.BACKLOGs.Find(id);
            db.BACKLOGs.Remove(bACKLOG);
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
