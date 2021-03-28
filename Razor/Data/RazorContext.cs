using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Razor.Data
{
    public class RazorContext : DbContext
    {
        public RazorContext (DbContextOptions<RazorContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Imovel> Imovel { get; set; }
    }
}
