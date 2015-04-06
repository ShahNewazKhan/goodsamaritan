namespace assn2.Migrations.IdentityMigrations
{
    using assn2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<assn2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
        }

        protected override void Seed(assn2.Models.ApplicationDbContext context)
        {

            var userstore = new UserStore<ApplicationUser>(context);
            var usermanager = new UserManager<ApplicationUser>(userstore);

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "Administrator") &&
                !context.Roles.Any(r => r.Name == "Worker") && 
                !context.Roles.Any(r => r.Name == "Report") )
            {
                var role = new IdentityRole { Name = "Administrator" };
                manager.Create(role);

                role = new IdentityRole { Name = "Worker" };
                manager.Create(role);

                role = new IdentityRole { Name = "Report" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "adam@gs.ca") &&
                !context.Users.Any(u => u.UserName == "rob@gs.ca") &&
                !context.Users.Any(u => u.UserName == "wendy@gs.ca"))
            {
                var adam = new ApplicationUser { UserName = "adam@gs.ca" };
                var wendy = new ApplicationUser { UserName = "wendy@gs.ca" };
                var rob = new ApplicationUser { UserName = "rob@gs.ca" };

                usermanager.Create(adam, "p@$$w0rd");
                usermanager.AddToRole(adam.Id, "Administrator");

                usermanager.Create(wendy, "p@$$w0rd");
                usermanager.AddToRole(wendy.Id, "Worker");

                usermanager.Create(rob, "p@$$w0rd");
                usermanager.AddToRole(rob.Id, "Report");
            }
        }
    }
}
