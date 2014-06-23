using FamileLMS.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamileLMS.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FamileLMS.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FamileLMS.UI.Models.ApplicationDbContext context)
        {
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            var userValidator = mgr.UserValidator as UserValidator<ApplicationUser>;
            userValidator.AllowOnlyAlphanumericUserNames = false; //allows email as username b/c by default only allows alphanumeric


            if(roleMgr.RoleExists("Admin"))
                
                return;
            CreateRoles(roleMgr);
            CreateAdmin(mgr);
            CreateTeacher(mgr);
            CreateStudent(mgr);
            CreateParent(mgr);

        }

        private void CreateParent(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "JD@mail.com",
                FirstName = "John",
                LastName = "Doe",
                SuggestedAccountRole = "Parent",
                IsApproved = true
            };

            mgr.Create(user, "test123");
            mgr.AddToRole(user.Id, "Parent");
        }

        private void CreateStudent(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "Student@mail.com",
                FirstName = "Eugene",
                LastName = "Doe",
                SuggestedAccountRole = "Student",
                IsApproved = true,
                GradeLevel = 7
            };
            mgr.Create(user, "test123");
            mgr.AddToRole(user.Id, "Student");
        }

        private void CreateAdmin(UserManager<ApplicationUser> mgr)
        {

            var user = new ApplicationUser()
            {
                UserName = "Admin@mail.com",
                FirstName = "Sarah",
                LastName = "Patel",
                SuggestedAccountRole = "Admin",
                IsApproved = true
            };
            mgr.Create(user, "test123");
            mgr.AddToRole(user.Id, "Admin");

        }

        private void CreateTeacher(UserManager<ApplicationUser> mgr)
        {

            var user = new ApplicationUser()
            {
                UserName = "Teacher@mail.com",
                FirstName = "Bryan",
                LastName = "Overland",
                SuggestedAccountRole = "Teacher",
                IsApproved = true,
                
            };
            mgr.Create(user, "test123");
            mgr.AddToRole(user.Id, "Teacher");

        }

        private void CreateRoles(RoleManager<IdentityRole> roleMgr)
        {
            roleMgr.Create(new IdentityRole("Admin"));
            roleMgr.Create(new IdentityRole("Teacher"));
            roleMgr.Create(new IdentityRole("Parent"));
            roleMgr.Create(new IdentityRole("Student"));
        }
    }
}
