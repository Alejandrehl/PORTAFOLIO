using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Portafolio.Models;

[assembly: OwinStartupAttribute(typeof(Portafolio.Startup))]
namespace Portafolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        // In this method we will create default User roles and Admin user for login 
        private void CreateRolesAndUsers() {

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin")) {
                // First create a Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create super user admin who will maintain the website
                var user = new ApplicationUser();
                user.UserName = "Administrador";
                user.Email = "admin@cem.com";
                string userPWD = "Admin123.";
                var chkUser = UserManager.Create(user, userPWD);

                // Add default user to role admin
                if (chkUser.Succeeded) {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("LocalStudyCenter"))
            {
                var role = new IdentityRole();
                role.Name = "LocalStudyCenter";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Centro de estudio local";
                user.Email = "localstudycenter@cem.com";
                string userPWD = "Localstudycenter123.";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "LocalStudyCenter");
                }

            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("CelAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "CelAdmin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "CelAdmin";
                user.Email = "cel@cem.com";
                string userPWD = "Cel123.";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "CelAdmin");
                }

            }

            // creating student role  
            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Student";
                user.Email = "student@cem.com";
                string userPWD = "Student123.";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Student");
                }

            }

            // creating family role  
            if (!roleManager.RoleExists("Family"))
            {
                var role = new IdentityRole();
                role.Name = "Family";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Family";
                user.Email = "family@cem.com";
                string userPWD = "Family123.";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Family");
                }

            }

            // creating family role  
            if (!roleManager.RoleExists("InternationalAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "InternationalAdmin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "InternationalAdmin";
                user.Email = "InternationalAdmin@cem.com";
                string userPWD = "InternationalAdmin123.";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "InternationalAdmin");
                }

            }

            //// creating InternationalRelationsManager role  
            //if (!roleManager.RoleExists("InternationalRelations"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "InternationalRelations";
            //    roleManager.Create(role);

            //    var user = new ApplicationUser();
            //    user.UserName = "Departamento de relaciones internacionales";
            //    user.Email = "international@cem.com";
            //    string userPWD = "International123.";
            //    var chkUser = UserManager.Create(user, userPWD);

            //    if (chkUser.Succeeded)
            //    {
            //        var result = UserManager.AddToRole(user.Id, "InternationalRelations");
            //    }

            //}

        }
    }
}
