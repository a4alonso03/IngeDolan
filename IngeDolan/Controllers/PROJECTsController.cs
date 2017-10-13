﻿using IngeDolan.App_Start;
using IngeDolan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;


namespace IngeDolan.Controllers
{
    public class PROJECTsController : ToastrController
    {
        private dolansoftEntities db = new dolansoftEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        private bool checkPowers(string permiso)
        {
            String userID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (Request.IsAuthenticated)
            {
                var rol = context.Users.Find(userID).Roles.First();
                var permisoID = db.PERMISSIONs.Where(m => m.NAMES == permiso).First().PERMISSION_ID;
                var listaRoles = db.ROLES.Where(m => m.PERMISSION == permisoID).ToList().Select(n => n.ROLE_TYPE);
                bool userRol = listaRoles.Contains(rol.RoleId);
                return userRol;
            }
            else { return false; }
        }

        // GET: PROJECTs
        public ActionResult Index()
        {
            if (!checkPowers("Consultar Lista de Proyectos"))
            {
                this.AddToastMessage("Acceso Denegado", "No tienes permiso para consultar Proyectos!", ToastType.Warning);
                return RedirectToAction("Denied", "Other");
            }

            var pROJECTs = db.PROJECTs.Include(p => p.USERS);
            return View(pROJECTs.ToList());
        }

        // GET: PROJECTs/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE");
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

            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE", pROJECT.LEADER_ID);
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
