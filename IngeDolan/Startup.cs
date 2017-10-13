using IngeDolan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(IngeDolan.Startup))]
namespace IngeDolan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            dolansoftEntities baseDatos = new dolansoftEntities();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin Role  
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Then we add all Permisos to Role (16 Permisos)
                for (int i = 1; i <= 24; i++)
                {
                    var rolPermisosEntry = new ROLE();
                    rolPermisosEntry.PERMISSION = i;
                    rolPermisosEntry.ROLE_TYPE = role.Id;
                    baseDatos.ROLES.Add(rolPermisosEntry);
                }

                //Here we create a Admin super user who will maintain the website   
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                string userPWD = "Admin.123";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                    //Create User
                    var userEntry = new USER();
                    userEntry.USERS_ID = 000000000;
                    userEntry.USERNAME = "Administrador";
                    userEntry.STUDENT_ID = user.Id;
                    baseDatos.USERS.Add(userEntry);
                }
                baseDatos.SaveChanges();
            }

            // creating Creating Desarrollador role    
            if (!roleManager.RoleExists("Desarrollador"))
            {
                var role = new IdentityRole();
                role.Name = "Desarrollador";
                roleManager.Create(role);
            }

            // creating Creating Cliente role    
            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);
            }
        }
    }
}
