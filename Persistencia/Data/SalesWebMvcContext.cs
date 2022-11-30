using Microsoft.EntityFrameworkCore;
using Entidades.Models;

namespace Persistencia.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutosRegistro> ProdutosRegistro { get; set; }
    }
}
