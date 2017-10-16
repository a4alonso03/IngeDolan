using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IngeDolan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace IngeDolan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /* Crear usuario:
            if (User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var id = User.Identity.GetUserId();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var user = db.Users.Where(X => X.Id == id).FirstOrDefault();
                    var confirmed = user.EmailConfirmed;

                    var userManager = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(db));
                    var uzer = new ApplicationUser();
                    uzer.UserName = "admin";
                    uzer.Email = "admin@defauil.com";

                    var result = userManager.Create(uzer, "admin");
                }
            }
            */
            /* Roles
            if(User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var idUzer = User.Identity.GetUserId(); //Usuario actual

                    var roleManager = new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(db));

                    //Crear Rol
                    var result = roleManager.Create(new IdentityRole("Reviza_Proyectos"));
                    var userManager = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>(db) );

                    //Agregar Usuario a rol
                    result = userManager.AddToRole(idUzer, "Reviza_Proyectos");

                    // Usuario en rol?
                    var uzerInRole1 = userManager.IsInRole(idUzer, "Reviza_Proyectos");
                    var uzerInRole2 = userManager.IsInRole(idUzer, "TDC.Reportes.Distribuciones");

                    // Roles de usuario
                    var roles = userManager.GetRoles(idUzer);

                    // Remover usuario del rol
                    result userManager.RemoveFromRole(idUzer, "Reviza_Proyectos");
                    
                    // Borrar rol
                    var rol = roleManager.FindByName("ApruebaPrestamos");
                    roleManager.Delete(rolVendedor);
                }
            }
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}