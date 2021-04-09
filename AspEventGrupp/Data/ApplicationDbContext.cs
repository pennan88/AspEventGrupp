using AspEventGrupp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AspEventGrupp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }


        public async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            if (Event.Any())

            {
                return;
            }

            var Events = new Event[]
        {
            new Event{Title="Summerburst",
                Adress="Ullevigatan 5, 411 39 Göteborg",
                Date = DateTime.Now,
                Location="Ullevi",
                Genre = "Fest",
                SpotsLeft=6500,
                Description="En stor fest lokaliserad på Ullevi i Göteborg" },
            new Event{Title="Lady Gaga",
                Adress="Globentorget 2, 121 77 Johanneshov ",
                Date = DateTime.Now,
                Location="Globen",
                Genre = "Sport",
                SpotsLeft=300,
                Description="Lady Gaga spelar i Globen" },
            new Event{Title="Supefest 3000",
                Adress="Festgatan 31, 420 69 Partystreet ",
                Date = DateTime.Now,
                Location="Månen",
                Genre = "Fest",
                SpotsLeft=300,
                Description="En mycket stor fest" },
        };

            await ContextSeed.SeedRoles(userManager, roleManager);
            await ContextSeed.SeedUser(userManager, roleManager);

            await AddRangeAsync(Events);

            await SaveChangesAsync();


        }


    }




}
