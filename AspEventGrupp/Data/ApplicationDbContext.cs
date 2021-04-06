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

            if ( Event.Any() )

            {
                return;
            }

            var Events = new Event[]
        {
            new Event{Title="En Fest", Adress="FestGatan", Date = DateTime.Now, Location="Feststaden", SpotsLeft=100, Description="En stor fest" }
        };

            await ContextSeed.SeedRoles(userManager, roleManager);
            await ContextSeed.SeedUser(userManager, roleManager);

            await AddRangeAsync(Events);

            await SaveChangesAsync();


        }


    }




}
