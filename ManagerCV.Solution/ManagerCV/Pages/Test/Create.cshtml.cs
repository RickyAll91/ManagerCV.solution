using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagerCVAPI.Model;

namespace ManagerCV.Pages.Test
{
    public class CreateModel : PageModel
    {
        private readonly ManagerCVAPI.Model.ApplicationDbContext _context;

        public CreateModel(ManagerCVAPI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sede Sede { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sedi == null || Sede == null)
            {
                return Page();
            }

            _context.Sedi.Add(Sede);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
