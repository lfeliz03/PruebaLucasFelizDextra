using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaLucasFelizDextra.DTOs;
using PruebaLucasFelizDextra.Models;

namespace PruebaLucasFelizDextra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;
        public LibrosController(BibliotecaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroResposeDto>>> GetLibrosBefore2000Async()
        {
            var librosBefore2000 =await _context.Libros.Where(l => l.AnoPublicacion < 2000)
                .Select(l => new LibroResposeDto
                { Libro_Id = l.Libro_Id, Titulo = l.Titulo, AnoPublicacion = l.AnoPublicacion })
                .ToListAsync();
            return Ok( librosBefore2000);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLibro([FromBody]LibroRequestDto libroRequestDto)
        {
            var libro = new Libro()
            {
                Titulo = libroRequestDto.Titulo,
                Autor_Id = libroRequestDto.Autor_Id,
                AnoPublicacion = libroRequestDto.AnoPublicacion,
                Genero = libroRequestDto.Genero
            };
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return Ok("Libro creado correctamente");
        }
    }
}
