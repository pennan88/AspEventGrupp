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

namespace AspEventGrupp.Pages
{
    [Authorize(Roles = "Admin")]
    public class ManageUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ManageUserModel(AspEventGrupp.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<User> MyUsers { get; set; }
        public User MyUser { get; set; }
        public async Task OnGetAsync()
        {
            MyUsers = await _context.Users.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {

            MyUsers = await _context.Users.ToListAsync();
            MyUser = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (MyUser != null)
            {
                if (!_userManager.IsInRoleAsync(MyUser, "Organizer").Result)
                {
                    await _userManager.AddToRoleAsync(MyUser, "Organizer");
                    await _userManager.RemoveFromRoleAsync(MyUser, "User");
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Admin/ManageUser");
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(MyUser, "Organizer");
                    await _userManager.AddToRoleAsync(MyUser, "User");
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Admin/ManageUser");
                }
            }
            return Page();
        }
    }
}
