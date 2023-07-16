using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagerCV.Pages
{
    public class ElencoSediModel : PageModel
    {
        [BindProperty]
        public int? Ricerca { get; set; }
        public List<Sede> ListaSedi { get; set; }
        private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7036")
        };
        private readonly string uri = "api/Sedi";
        public ElencoSediModel()
        {
            ListaSedi = new List<Sede>();
        }
        public async Task<IActionResult> OnGet()
        {
            List<Sede>? sediDaApi = await client.GetFromJsonAsync<List<Sede>>(uri);
            ListaSedi = sediDaApi!;
            return Page();
        }
        public async Task<IActionResult> OnPostById()
        {
            List<Sede>? sediDaApi = await client.GetFromJsonAsync<List<Sede>>($"api/Sedi/{Ricerca}");
            ListaSedi = sediDaApi!;
            return Page();
        }
    }
}
