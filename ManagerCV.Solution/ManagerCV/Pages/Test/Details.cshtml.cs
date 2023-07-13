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
    public class DetailsModel : PageModel
    {
        private readonly ManagerCVAPI.Model.ApplicationDbContext _context;

        public DetailsModel(ManagerCVAPI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

      public Sede Sede { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sedi == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedi.FirstOrDefaultAsync(m => m.Id == id);
            if (sede == null)
            {
                return NotFound();
            }
            else 
            {
                Sede = sede;
            }
            return Page();
        }
    }
}
