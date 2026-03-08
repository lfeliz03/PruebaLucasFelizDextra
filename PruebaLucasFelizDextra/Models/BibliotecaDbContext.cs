using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PruebaLucasFelizDextra.Models
{
    public class BibliotecaDbContext : IdentityDbContext<ApplicationUser>
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Autor>(a =>
                a.HasData(
                        new Autor { Autor_Id = 1, Nombre = "Américo Lugo", Nacionalidad = "Dominicano" },
                        new Autor { Autor_Id = 2, Nombre = "Gabriel García Márquez", Nacionalidad = "Mexicano" },
                        new Autor { Autor_Id = 3, Nombre = "Miguel de Cervantes", Nacionalidad = "Venezolano" }
                    ));
            // Relación Autor (1) - Libro (N)
            builder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.Autor_Id);

            // Relación Libro (1) - Prestamo (N)
            builder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany(l => l.Prestamos)
                .HasForeignKey(p => p.Libro_Id);
            base.OnModelCreating(builder);
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
