using Microsoft.EntityFrameworkCore;

namespace CatalogoRoupas.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }
        public DbSet<CatalogoModel> Catalogo { get; set; }
    }
}
