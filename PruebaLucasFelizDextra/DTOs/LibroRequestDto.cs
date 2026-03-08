using PruebaLucasFelizDextra.Models;
using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.DTOs
{
    public class LibroRequestDto
    {
        public required string Titulo { get; set; }
        public required int Autor_Id { get; set; }
        public required int AnoPublicacion { get; set; }
        public required string Genero { get; set; }
    }
}
