using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerCVAPI.Model;

namespace ManagerCV.Pages.Test
{
    public class EditModel : PageModel
    {
        private readonly ManagerCVAPI.Model.ApplicationDbContext _context;

        public EditModel(ManagerCVAPI.Model.ApplicationDbContext context)
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

            var sede =  await _context.Sedi.FirstOrDefaultAsync(m => m.Id == id);
            if (sede == null)
            {
                return NotFound();
            }
            Sede = sede;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(Sede.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SedeExists(int id)
        {
          return (_context.Sedi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
