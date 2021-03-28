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
    public class DetailsModel : PageModel
    {
        HttpClient client;

        public DetailsModel(HttpClient http)
        {
            client = http;
        }

        public Model.Imovel Imovel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = "http://localhost:50000/imovel/details/" + Imovel.ID.ToString();
            string jsonString = JsonSerializer.Serialize<Model.Imovel>(Imovel);
            HttpContent cont = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Content.ReadAsStringAsync().Result.ToString(), null);


            if (Imovel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
