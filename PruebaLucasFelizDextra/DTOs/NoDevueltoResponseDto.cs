using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.DTOs
{
    public class NoDevueltoResponseDto
    {
        public required int Autor_Id { get; set; }
        public required string Nombre { get; set; }
        public required int Libro_Id { get; set; }
        public required string Titulo { get; set; }
    }
}
