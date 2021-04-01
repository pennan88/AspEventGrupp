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
    public class ManageUserModel : PageModel
    {
        private readonly AspEventGrupp.Data.ApplicationDbContext _context;

        public ManageUserModel(AspEventGrupp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }
        public List<User>Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }
    }
}
