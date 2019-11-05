using DemoSystem.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Admin.Security.Settings;
// http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
namespace WebApp.Admin.Security
{
    /// <summary>
    /// Provide funtionality for setting up the database for ApplicationDbContext .
    /// The specific functionality is to create the database if it does not exists.
    /// </summary>
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //To "seed" a database is to provide it with some initial data when the database is created.

            #region Seed the security roles
            // Make the Identities BLL instance to help us manage roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // the RoleManager<T> and RoleStore<T> are BLL classes that give flexibility to the design/structure of how were using Asp.NET Identity.
            //The IdentityRole is an Entity Class that represents a security role.

            foreach(var role in DefaultSecurityRoles)
            {
                roleManager.Create(new IdentityRole { Name = role });
            }
            #endregion
            #region seed the users
            var adminUser = new ApplicationUser
            {
                UserName = AdminUserName,
                Email = AdminEmail,
                EmailConfirmed = true,
            };

            //Instansiate the BLL user manager
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            // - The ApplicationUserManager is a BLL class in the websites App_Start/IdentityConfig.cs
            var result = userManager.Create(adminUser, AdminPassword);
            if(result.Succeeded)
            {
                //Get the ID that was generated for the user we created/added
                var adminId = userManager.FindByName(AdminUserName).Id;
                //Add the user to the Administrators role
                userManager.AddToRole(adminId, AdminRole);
            }

            var demoManager = new DemoController();
            var people = demoManager.ListPeople();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    PersonID = person.PersonID
                };
                result = userManager.Create(user,TempPassword);
                if(result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, UserRole);
                }
            }
            //
            #endregion
            //Note: Keep this call to the base class so it can do its seeding work.
            base.Seed(context);
        }
    }
}