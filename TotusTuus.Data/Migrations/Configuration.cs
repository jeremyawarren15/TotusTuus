using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TotusTuus.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TotusTuus.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TotusTuus.Data.ApplicationDbContext context)
        {
            CreateRoles(context);

            CreateUsers(context);

            CreateParish(context);
        }

        private void CreateRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "SuperAdmin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
        }

        private static void CreateUsers(ApplicationDbContext context)
        {
            
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var superAdmin = new ApplicationUser { FirstName = "Super", LastName = "User", FullName = "Super User", UserName = "super@test.com", Email = "super@test.com" };
            var admin = new ApplicationUser { FirstName = "Admin", LastName = "User", FullName = "Admin User", UserName = "admin@test.com", Email = "admin@test.com" };

            if (!context.Users.Any(u => u.Email == superAdmin.Email))
            {
                manager.Create(superAdmin, "Test1!");
                manager.AddToRole(superAdmin.Id, "SuperAdmin");
            }

            if (!context.Users.Any(u => u.Email == admin.Email))
            {
                manager.Create(admin, "Test1!");
                manager.AddToRole(admin.Id, "Admin");
            }
        }

        private static void CreateParish(ApplicationDbContext context)
        {
            if (context.Parishes.Any()) return;

            var parish = new Parish()
            {
                ParishName = "St. John the Evangelist",
                City = "Indianapolis",
                Archdiocese = "Indianapolis",
                CreatedDate = DateTimeOffset.UtcNow,
                OfficePhoneNumber = "317-635-2021",
                Pastor = "Fr. Rick Nagel",
                PostalCode = "46225",
                State = "IN",
                StreetAddress = "126 W. Georgia St."
            };

            context.Parishes.AddOrUpdate(parish);
        }
    }
}
