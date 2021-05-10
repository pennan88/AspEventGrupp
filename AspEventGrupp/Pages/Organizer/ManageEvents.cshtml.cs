using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspEventGrupp.Data;
using AspEventGrupp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspEventGrupp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class ManageEventsModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ManageEventsModel(AspEventGrupp.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            var organizerId = await _userManager.GetUserAsync(User);

            Event = await _context.Event
                .Where(o => o.Organizer.Id == organizerId.Id)
                .ToListAsync();
        }
    }
}
