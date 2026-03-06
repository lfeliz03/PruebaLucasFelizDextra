using System.ComponentModel.DataAnnotations;

namespace PruebaLucasFelizDextra.Models
{
    public class Autor
    {
        [Key]
        public int Autor_Id { get; set; }
        [StringLength(100)]
        public required string Nombre { get; set; }
        [StringLength(100)]
        public required string Nacionalidad { get; set; }
    }
}
