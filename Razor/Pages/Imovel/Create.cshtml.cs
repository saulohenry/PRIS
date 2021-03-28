using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Razor.Data;
using Model;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Razor.Pages.Imovel
{
    public class CreateModel : PageModel
    {
        HttpClient client;
        public CreateModel(Razor.Data.RazorContext context, HttpClient http)
        {
            client = http;
        }

        public IActionResult OnGet()
        {
            string url = "http://localhost:50000/imovel/details/" + Imovel.ID.ToString();
            string jsonString = JsonSerializer.Serialize<Model.Imovel>(Imovel);
            HttpContent cont = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Content.ReadAsStringAsync().Result.ToString(), null);

            return Page();
        }

        [BindProperty]
        public Model.Imovel Imovel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string url = "http://localhost:50000/imovel/create/" + Imovel.ID.ToString();
            string jsonString = JsonSerializer.Serialize<Model.Imovel>(Imovel);
            HttpContent cont = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> resp = client.PostAsync(url, cont);
            resp.Start();

            if (resp.Result.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Result.Content.ReadAsStringAsync().Result.ToString(), null);

            return RedirectToPage("./Index");
        }
    }
}
