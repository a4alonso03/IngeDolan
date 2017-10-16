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
            /*
            var auth = User.Identity.IsAuthenticated;
            if (auth == true)
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