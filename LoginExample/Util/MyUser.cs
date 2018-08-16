using LoginExample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginExample.Util
{
    public class MyUser
    {
        public static bool IsAdmin(Controller controller) {
            if (controller.User.Identity.IsAuthenticated)
            {
                var user = controller.User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var userRoles = userManager.GetRoles(user.GetUserId());
                return userRoles[0].Equals("Admin");
            }
            return false;
        }
    }
}