using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEventGrupp.Models
{
    public class ContextSeed
    {

        public static async Task SeedRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Organizer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.User.ToString()));
        }

        public static async Task SeedUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var Users = new User[]
            {
                new User {FirstName = "Alexander",
                    LastName = "Fagrelius",
                    Email = "Mail@mail.com",
                    UserName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true},

                new User {FirstName = "Organiszer",
                    LastName = ".AB",
                    Email = "OrgMail@mail.com",
                    UserName = "Organizer",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true}
            };

            await userManager.CreateAsync(Users[0], "password");
            await userManager.AddToRoleAsync(Users[0], Enums.Roles.Admin.ToString());

            await userManager.CreateAsync(Users[1], "password");
            await userManager.AddToRoleAsync(Users[1], Enums.Roles.Organizer.ToString());
        }
    }


}
