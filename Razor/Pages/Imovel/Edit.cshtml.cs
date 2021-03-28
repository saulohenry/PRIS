using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using Razor.Data;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Razor.Pages.Imovel
{
    public class EditModel : PageModel
    {

        HttpClient _client;

        public EditModel(HttpClient client)
        {
            _client = client;
        }

        [BindProperty]
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
            HttpResponseMessage resp = _client.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Content.ReadAsStringAsync().Result.ToString(), null);
         
            if (Imovel == null)
            {
                return NotFound();
            }
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

            string url = "http://localhost:50000/imovel/edit/" + Imovel.ID.ToString();
            string jsonString = JsonSerializer.Serialize<Model.Imovel>(Imovel);
            HttpContent cont = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> resp = _client.PostAsync(url, cont);
            resp.Start();

            if (resp.Result.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<Model.Imovel>(resp.Result.Content.ReadAsStringAsync().Result.ToString(), null);
            
            if (Imovel == null)
            {
                return NotFound();
            }


            return RedirectToPage("./Index");
        }

       
    }
}
