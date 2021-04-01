using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspEventGrupp.Data;
using AspEventGrupp.Models;

namespace AspEventGrupp.Pages
{
    public class EventsModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;

        public EventsModel(AspEventGrupp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
