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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

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

            context.Parishes.Add(parish);
        }
    }
}
