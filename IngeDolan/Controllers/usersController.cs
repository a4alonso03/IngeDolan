using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngeDolan.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using IngeDolan.App_Start;
using System.Web.Security;
using PagedList;

namespace IngeDolan.Controllers
{
    public class usersController : ToastrController
    {
        private dolansoftEntities db = new dolansoftEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        private bool checkPowers(string permiso)
        {
            String userID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var rol = context.Users.Find(userID).Roles.First();
            var permisoID = db.PERMISSIONs.Where(m => m.NAMES == permiso).First().PERMISSION_ID;
            var listaRoles = db.ROLES.Where(m => m.PERMISSION == permisoID).ToList().Select(n => n.ROLE_TYPE);
            bool userRol = listaRoles.Contains(rol.RoleId);

            return userRol;
        }

        // GET: users/Create
        public ActionResult Create()
        {
            if (!checkPowers("Crear Usuarios"))
            {
                //despliega mensaje en caso de no poder crear un usuario
                this.AddToastMessage("Acceso Denegado", "No tienes permiso para crear usuarios!", ToastType.Warning);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                try
                {

                    //generacion de contraseña provisional
                    string generatedPassword = Membership.GeneratePassword(12, 2);
                    //crea el usuario en la tabla de AspNetUsers
                    var result = await UserManager.CreateAsync(user, generatedPassword);

                    if (result.Succeeded)
                    {
                        // Crea el usuario en las tabla de Usuario
                        var userEntry = new USER();
                        userEntry.USERS_ID = model.Cedula;
                        userEntry.USERNAME = model.Nombre;
                        userEntry.STUDENT_ID = context.Users.Where(u => u.Email == model.Email).FirstOrDefault().Id;

                        db.USERS.Add(userEntry);
                        db.SaveChanges();
                        
                        //Envio de Correo
                        //string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account", model.Nombre, generatedPassword);

                        //crea la relacion del usuario con el rol
                        await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                        this.AddToastMessage("Usuario Creado", "El usuario " + model.Nombre + " se ha creado correctamente. Se envió un correo electronico de confirmación al usuario", ToastType.Success);
                        return RedirectToAction("Crear", "Usuarios");


                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }

                    await UserManager.DeleteAsync(user);
                    ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
                    // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario

                    this.AddToastMessage("Error", "Ha ocurrido un error al crear al usuario " + model.Nombre + ".", ToastType.Error);
                    return View(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    this.AddToastMessage("Error", "Ha ocurrido un error al crear al usuario " + model.Nombre + ".", ToastType.Error);
                    ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
                    return View(model);
                }

            }
            return View(model);
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

        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject, string usrName, string userPassword)
        {

            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);

            // Construye y envia el mensaje de confirmacion
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userID, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userID, subject, "Hola. <br><br>"
                + "Se ha creado el usuario " + usrName + " en nuestro Sistema de Control de Cambios.<br>"
                + "Su contraseña provisional es: \'" + userPassword + "\'"
                + "<br><b>Por favor cambia tu contraseña.</b><br>"
                + "<br>Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

            return callbackUrl;
        }
    }
}
