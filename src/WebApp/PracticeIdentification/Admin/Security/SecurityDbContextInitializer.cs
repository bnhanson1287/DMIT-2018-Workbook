using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PracticeIdentification.Models;
using StaffSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeIdentification.Admin.Security
{
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Seed Security Roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });
            #endregion

            #region
            var adminUser = new ApplicationUser
            {
                UserName = "WebAdmin",
                Email = "DMIT2018@email.com",
                EmailConfirmed = true,
            };

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var result = userManager.Create(adminUser, "Pa$$word1");
            if(result.Succeeded)
            {
                var adminId = userManager.FindByName("WebAdmin").Id;

                userManager.AddToRole(adminId, "Administrators");
            }

            var staffManager = new StaffController();
            var staff = staffManager.ListStaff();
            foreach (var person in staff)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@email.com",
                    EmailConfirmed = true
                   
                };
                result = userManager.Create(user, "Pa$$word1");
                if (result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, "Registered Users");
                }
            }
                #endregion


                base.Seed(context);
        }
    }
}