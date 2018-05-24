using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Portafolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                ViewBag.displayCelAdminMenu = "No";
                ViewBag.displayStudentMenu = "No";
                ViewBag.displayFamilyMenu = "No";
                ViewBag.displayInternationalRelationsMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                if (isCelAdmin()) {
                    ViewBag.displayCelAdminMenu = "Yes";
                }
                if (isStudent()) {
                    ViewBag.displayStudentMenu = "Yes";
                }
                if (isfamily()) {
                    ViewBag.displayFamilyMenu = "Yes";
                }
                if (isInternationalRelations()) {
                    ViewBag.displayInternationalRelationsMeny = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();

        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean isCelAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "CelAdmin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean isStudent()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Student")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean isfamily()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Family")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean isInternationalRelations()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "InternationalAdmin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public ActionResult Experiences()
        {
            return View();
        }
    }
}