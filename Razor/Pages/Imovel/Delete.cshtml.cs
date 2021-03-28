using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using Razor.Data;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Razor.Pages.Imovel
{
    public class DeleteModel : PageModel
    {
        HttpClient client;

        public DeleteModel(HttpClient client)
        {
            client = client;
        }

        [BindProperty]
        public Model.Imovel Imovel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = "http://localhost:50000/imovel/delete/" + Imovel.ID.ToString();
            string jsonString = JsonSerializer.Serialize<Model.Imovel>(Imovel);
            HttpContent cont = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> resp = client.PostAsync(url, cont);
            resp.Start();

            if (resp.Result.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Result.Content.ReadAsStringAsync().Result.ToString(), null);

            if (Imovel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = "http://localhost:50000/imovel/delete/" + Imovel.ID.ToString();
            Task<HttpResponseMessage> resp = client.GetAsync(url);
            resp.Start();

            return RedirectToPage("./Index");

        }
    }
}
