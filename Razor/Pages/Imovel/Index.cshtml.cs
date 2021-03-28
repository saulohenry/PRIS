using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using Razor.Data;
using Repository.DAL;
using System.Net.Http;
using System.Text.Json;

namespace Razor.Pages.Imovel
{
    public class IndexModel : PageModel
    { 
        HttpClient _client;

        public IndexModel(HttpClient client)
        {
            _client = client;
        }

        public IList<Model.Imovel> Imovel { get;set; }

        public async Task OnGetAsync()
        {
             HttpResponseMessage resp = _client.GetAsync("http://localhost:50000/imovel/").Result;

            if(resp.IsSuccessStatusCode)
                Imovel = JsonSerializer.Deserialize<IList<Model.Imovel>>(resp.Content.ReadAsStringAsync().Result.ToString(), null);
        }
    }
}
