namespace CijferRegistratie.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CijferRegistratie.Models.Auth;
    using CijferRegistratie.Models.MVC;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="Configuration" />
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// The Seed
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        protected override void Seed(AppDbContext context)
        {
            CreateRoles(context);

            CreateUsers(context);
        }

        private static void CreateUsers(AppDbContext context)
        {
            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);

            if (!context.Users.Any(u => u.UserName == "admin@cijferregistratie.com"))
            {
                var user = new AppUser
                {
                    UserName = "admin@cijferregistratie.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "AppAdmin");
            }

            if (!context.Users.Any(u => u.UserName == "administratie@cijferregistratie.com"))
            {
                var user = new AppUser
                {
                    UserName = "administratie@cijferregistratie.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "docent@cijferregistratie.com"))
            {
                var user = new AppUser
                {
                    UserName = "docent@cijferregistratie.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Teacher");
            }

            if (!context.Users.Any(u => u.UserName == "student@cijferregistratie.com"))
            {
                var user = new AppUser
                {
                    UserName = "student@cijferregistratie.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Student");
            }
        }

        private static void CreateRoles(AppDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "AppAdmin"
                    });
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Admin"
                    });
            }

            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Teacher"
                    });
            }

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Student"
                    });
            }
        }
    }
}
