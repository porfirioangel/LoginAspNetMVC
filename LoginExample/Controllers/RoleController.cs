using LoginExample.Models;
using LoginExample.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginExample.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            if (User.Identity.IsAuthenticated)
            {
                if (!MyUser.IsAdmin(this))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }
    }
}