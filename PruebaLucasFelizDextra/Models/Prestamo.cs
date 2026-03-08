using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.Models
{
    public class Prestamo
    {
        [Key]
        public int Prestamo_Id { get; set; }
        public int Libro_Id { get; set; } // FK
        public Libro Libro { get; set; } // Propiedad de navegación
        public required DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
