using Biblioteca_central.models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_central.Data
{
    public class AppDbContext : DbContext
    {
        internal object Livro;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
            public DbSet<Livro> livro {  get; set; }
        public object Livros { get; internal set; }
    }
}
