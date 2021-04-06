using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspEventGrupp.Data;
using AspEventGrupp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspEventGrupp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class AddEventModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;

        public AddEventModel(AspEventGrupp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if ( !ModelState.IsValid )
            {
                return Page();
            }

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
