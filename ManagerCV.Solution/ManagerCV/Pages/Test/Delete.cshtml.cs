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
    public class DeleteModel : PageModel
    {
        private readonly ManagerCVAPI.Model.ApplicationDbContext _context;

        public DeleteModel(ManagerCVAPI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sedi == null)
            {
                return NotFound();
            }
            var sede = await _context.Sedi.FindAsync(id);

            if (sede != null)
            {
                Sede = sede;
                _context.Sedi.Remove(Sede);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
