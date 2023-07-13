using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagerCVAPI.Model;

namespace ManagerCV.Pages.Test
{
    public class IndexModel : PageModel
    {
        private readonly ManagerCVAPI.Model.ApplicationDbContext _context;

        public IndexModel(ManagerCVAPI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sede> Sede { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sedi != null)
            {
                Sede = await _context.Sedi.ToListAsync();
            }
        }
    }
}
