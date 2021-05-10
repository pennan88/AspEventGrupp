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
using Microsoft.AspNetCore.Identity;

namespace AspEventGrupp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class AddEventModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AddEventModel(AspEventGrupp.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(this.User);
            Event.Organizer = user;
            try
            {
                await _context.Event.AddAsync(Event);
                await _context.SaveChangesAsync();

                return RedirectToPage(".././Index");
            }
            catch
            {
                return RedirectToPage(".././Error");
            }

        }
    }
}
