using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspEventGrupp.Data;
using AspEventGrupp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AspEventGrupp.Pages
{
    [Authorize]
    public class JoinEventModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public JoinEventModel(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
        [BindProperty]
        public Event MyEvent { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
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

            var userId = _userManager.GetUserId(User);

            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.JoinedEvents)
                .FirstOrDefaultAsync();

            if (!user.JoinedEvents.Contains(Event))
            {
                user.JoinedEvents.Add(Event);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
