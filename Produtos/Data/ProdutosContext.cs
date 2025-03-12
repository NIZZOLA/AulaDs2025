using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos.Models;

namespace Produtos.Data
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext (DbContextOptions<ProdutosContext> options)
            : base(options)
        {
        }

        public DbSet<Produtos.Models.ProdutosModel> ProdutosModel { get; set; } = default!;
    }
}
