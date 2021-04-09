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
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageUserModel(AspEventGrupp.Data.ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public List<IdentityRole> roles { get; set; }
        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
            roles = await _roleManager.Roles.ToListAsync();
        }
    }
}
