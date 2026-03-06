using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.Models
{
    public class Libro
    {

        [Key]
        public int Libro_Id { get; set; }
        [StringLength(50)]
        public required string Titulo { get; set; }
        public int? Autor_Id { get; set; }
        public Autor? Autor { get; set; }
        public required int AnoPublicacion { get; set; }
        [StringLength(50)]
        public required string Genero { get; set; }
    }
}
