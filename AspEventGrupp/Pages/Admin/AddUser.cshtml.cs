using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspEventGrupp.Data;
using AspEventGrupp.Models;

namespace AspEventGrupp.Pages.Admin
{
    public class AddUserModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;

        public AddUserModel(AspEventGrupp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User Users { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(Users);
            await _context.SaveChangesAsync();

            return RedirectToPage(".././Index");
        }
    }
}
