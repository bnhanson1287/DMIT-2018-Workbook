using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
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

            //TODO: Move these hard-coded security roles to Web.config

            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });
            #endregion
            #region seed the users
            #endregion
            //Note: Keep this call to the base calss so it can do its seeding work.
            base.Seed(context);
        }
    }
}