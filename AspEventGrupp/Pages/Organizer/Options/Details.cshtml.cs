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

namespace AspEventGrupp.Pages.Organizer.Options
{
    [Authorize(Roles = "Organizer")]
    public class DetailsModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;

        public DetailsModel(AspEventGrupp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
