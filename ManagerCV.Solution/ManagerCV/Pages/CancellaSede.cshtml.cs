using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagerCV.Pages
{
    public class CancellaSedeModel : PageModel
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
            if (Sede == null)
            {
                return NotFound();
            }
            await client.DeleteAsync($"api/Sedi/{Sede.Id}");
            return RedirectToPage("/ElencoSedi");
        }
    }
}
