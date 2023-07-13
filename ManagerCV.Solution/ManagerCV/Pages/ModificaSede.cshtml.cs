using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ManagerCV.Pages
{
    public class ModificaSedeModel : PageModel
    {
        [BindProperty]
        public Sede Sede { get; set; } = default!;
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7036")
        };
        private string uri = "api/Sedi";
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await client.GetFromJsonAsync<List<Sede>>($"api/Sedi/{id}") == null)
            {
                return NotFound();
            }

            var sede = await client.GetFromJsonAsync<List<Sede>>($"api/Sedi/{id}");
            if (sede == null)
            {
                return NotFound();
            }
            Sede = sede[0];
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await client.PutAsJsonAsync<Sede>(uri, Sede);
                return RedirectToPage("/ElencoSedi");
            }
        }

    }
}
