using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PruebaLucasFelizDextra.Models
{
    public class BibliotecaDbContext : IdentityDbContext<ApplicationUser>
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
