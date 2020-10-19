using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherPortal.Pages.V2
{
    public class IndexModel : PageModel
    {
        private readonly TeacherDirectory.Services.AppDbContext _context;

        public IndexModel(TeacherDirectory.Services.AppDbContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; }

        public async Task OnGetAsync()
        {
            Teacher = await _context.Teachers.ToListAsync();
        }
    }
}
