using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagerCV.Pages
{
    public class CreaSedeModel : PageModel
    {
        [BindProperty]
        public Sede Sede { get; set; } = default!;
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7036")
        };
        private string uri = "api/Sedi";
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync ()
        {
            if (!ModelState.IsValid || Sede == null)
            {
                return Page();
            }
            await client.PostAsJsonAsync<Sede>(uri, Sede);
            return RedirectToPage("/ElencoSedi");
        }
    }
}
