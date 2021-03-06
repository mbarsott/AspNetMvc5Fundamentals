using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
//            var hasher = new PasswordHasher();
//            context.Users.AddOrUpdate(u=>u.UserName, new ApplicationUser
//            {
//                UserName = "mbarsott",
//                Email = "mbarsott@gmail.com",
//                PasswordHash = hasher.HashPassword("Asbasth8$")
//            });
            if (!context.Users.Any(u => u.UserName=="mbarsott"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {UserName = "mbarsott", Email = "mbarsott@gmail.com"};

                manager.Create(user, "Asbasth8$");

            }
        }
    }
}
