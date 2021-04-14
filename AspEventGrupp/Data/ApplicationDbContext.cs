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
            Uri testimg = new Uri("https://st2.depositphotos.com/1594308/5547/i/600/depositphotos_55474203-stock-photo-v%C3%A4nner-dansa-p%C3%A5-fest.jpg");

            Uri[] EventImages = new Uri[]
            {
                new Uri("https://st2.depositphotos.com/1594308/5547/i/600/depositphotos_55474203-stock-photo-v%C3%A4nner-dansa-p%C3%A5-fest.jpg"),
                new Uri("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRrquL249FbvPceqapFg9X3YVrUpe2CQPilFi9PhWw5LeKQM-buP3ydBLMWT5qK1XQzcSQ&usqp=CAU"),
                new Uri("https://media.istockphoto.com/vectors/seamless-doodle-dogs-colorful-background-vector-id1006940504?k=6&m=1006940504&s=612x612&w=0&h=ZlONrOUVgU3pPAaGi1lITFRAMbj1fC4qXCdCsNXNcfE=")

            };

            var Events = new Event[]
        {
            new Event{Title="Fotbolls VM",
                Adress="Råsta Strandväg 1, 169 56 Solna",
                Date = DateTime.Now,
                Location="Friends Arena",
                Genre = "Sport",
                EventImage = EventImages[1].ToString(),
                SpotsLeft=6500,
                Description="Sverige spelar VM final mot Tysklad" },

            new Event{Title="Lady Gaga",
                Adress="Globentorget 2, 121 77 Johanneshov ",
                Date = DateTime.Now,
                Location="Globen",
                Genre = "Fest",
                EventImage = EventImages[0].ToString(),
                SpotsLeft=300,
                Description="Lady Gaga spelar i Globen" },

            new Event{Title="Supefest 3000",
                Adress="Festgatan 31, 420 69 Partystreet ",
                Date = DateTime.Now,
                Location="Månen",
                Genre = "Fest",
                EventImage = EventImages[0].ToString(),
                SpotsLeft=300,
                Description="En mycket stor fest" },

            new Event{Title="Böda Double Dog Show 2021",
                Adress="Kronocamping Böda Sand",
                Date = DateTime.Now,
                Location="Löttorp",
                Genre = "Internationell Hundutställning",
                EventImage = EventImages[2].ToString(),
                SpotsLeft=250,
                Description="Välkommen till internationell hundutställning med möjlighet att vinna svenskt certifikat och internationellt certifikat, CACIB." },
        };

            await ContextSeed.SeedRoles(userManager, roleManager);
            await ContextSeed.SeedUser(userManager, roleManager);

            await AddRangeAsync(Events);

            await SaveChangesAsync();


        }


    }




}
