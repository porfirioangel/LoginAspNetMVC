using LoginExample.Models;
using LoginExample.Util;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginExample.Startup))]
namespace LoginExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            Logger.WriteInfo("------------------");
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create an Admin role and a default Admin user.
            if (!roleManager.RoleExists("Admin"))
            {
                // Create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create Admin superuser
                var user = new ApplicationUser();
                user.UserName = "porfirioads";
                user.Email = "porfirioads@gmail.com";

                string userPWD = "Porfirioads1$";

                var chkUser = UserManager.Create(user, userPWD);

                // Add default user to Admin role
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // Create Manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            // Create Employee role
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}
