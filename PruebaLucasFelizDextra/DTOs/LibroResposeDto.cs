using PruebaLucasFelizDextra.Models;
using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.DTOs
{
    public class LibroResposeDto
    {
        public required int Libro_Id { get; set; }
        public required string Titulo { get; set; }
        public required int AnoPublicacion { get; set; }
    }
}
