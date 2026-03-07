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
    public class PrestamosController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;
        public PrestamosController(BibliotecaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoDevueltoResponseDto>>> GetNoDevueltos()
        {
            var noDevueltos = _context.Prestamos.Where(p => p.FechaDevolucion == null)
                .Include(l => l.Libro).ThenInclude(a => a.Autor);
            var noDevueltosResult = await noDevueltos.Select(n => new NoDevueltoResponseDto
            {
                Autor_Id = n.Libro.Autor.Autor_Id,
                Nombre = n.Libro.Autor.Nombre,
                Libro_Id = (int)n.Libro_Id,
                Titulo = n.Libro.Titulo
            }).ToListAsync();
            return Ok(noDevueltosResult);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPrestamo([FromBody] int libro_Id)
        {
            var libro = _context.Libros.Find(libro_Id);
            if (libro is null)
                return NotFound();
            var prestamo = new Prestamo()
            {
                Libro_Id = libro_Id,
                FechaPrestamo = DateTime.Now
            };
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return Ok("Libro prestado correctamente");
        }
        [HttpPut("{prestamo_Id}")]
        [Authorize]
        public async Task<IActionResult> DevolverLibro(int prestamo_Id)
        {
            var prestamo = _context.Prestamos.Find(prestamo_Id);
            if (prestamo is null)
                return NotFound();
            prestamo.FechaDevolucion = DateTime.Now;
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{prestamo_Id}")]
        [Authorize]
        public async Task<IActionResult> EliminarPrestamo(int prestamo_Id)
        {
            var prestamo = _context.Prestamos.Find(prestamo_Id);
            if (prestamo is null)
                return NotFound();
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
