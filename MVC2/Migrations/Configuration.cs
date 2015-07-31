namespace MVC2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using MVC2.Models;
using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //ApplicationDbContext context = new ApplicationDbContext();

        protected override void Seed(ApplicationDbContext context)
        {

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Moderator" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.Email == "antonio.raynor@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "antonio.raynor@gmail.com",
                    Email = "antonio.raynor@gmail.com",
                    FirstName = "Antonio",
                    LastName = "Raynor",
                    DisplayName = "Antonio"
                };

                manager.Create(user, "Anivr@2142");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "Moderator");
                //manager.AddToRoles(user.Id, new string[] { "Admin", "Moderator" });

            }

            if (!context.Users.Any(u => u.Email == "bdavis@coderfoundry.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                    FirstName = "Bobby",
                    LastName = "Davis",
                    DisplayName = "Bobby Davis"
                };

                manager.Create(user, "password1");
                //manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "Moderator");
                // manager.AddToRoles(user.Id, new string[] { "Admin", "Moderator" });

            }
            CustomSeeder(context);

        }

        private CustomSeeder(ApplicationDbContext db)
        {
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            students.ForEach(s => context.Students.Add(s));
            db.SaveChanges();


            var posts = new List<Post>
            {
                new Post { Title = "", AuthorId = "", Body = "", Created = DateTime.UtcNow },
                new Post { Title = "", AuthorId = "", Body = "", Created = "" },
                new Post { Title = "", AuthorId = "", Body = "", Created = "" },
                new Post { Title = "", AuthorId = "", Body = "", Created = "" },
                new Post { Title = "", AuthorId = "", Body = "", Created = "" }
            }
            posts.ForEach(p => db.Posts.Add(p));
            db.SaveChanges();
        }
    }
}
