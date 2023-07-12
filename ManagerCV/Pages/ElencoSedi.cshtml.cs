using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ManagerCV.Pages
{
    public class ElencoSediModel : PageModel
    {
        [BindProperty]
        public int? Ricerca { get; set; }
        public List<Sede> ListaSedi { get; set; }
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7036")
        };
        private string uri = "api/Sedi";
        public ElencoSediModel()
        {
            ListaSedi = new List<Sede>();
        }
        public async Task<IActionResult> OnGet()
        {
            ListaSedi = await client.GetFromJsonAsync<List<Sede>>(uri);
            return Page();
        }
        public async Task<IActionResult> OnPostById()
        {
            ListaSedi = await client.GetFromJsonAsync<List<Sede>>($"api/Sedi/{Ricerca}");
            return Page();
        }

    }
}
