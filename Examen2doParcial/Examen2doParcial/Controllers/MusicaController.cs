using Examen2doParcial.Context;
using Examen2doParcial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen2doParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA-LEER")]
        public IActionResult lista()
        {
            var uni = this._context.musicas.ToList();
            return Ok(uni);
        }
        [HttpPost]
        [Route("CREAR-Musica")]
        public IActionResult CrearMusica([FromBody] Musica nuevaMusica)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.musicas.Add(nuevaMusica);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

        [HttpPut("EDITAR/{Id_Musica}")]
        public IActionResult EditarMusica(int Id_Musica, [FromBody] Musica MusicaActualizada)
        {
            try
            {
                var MusicaExistente = _context.musicas.Find(Id_Musica);

                if (MusicaExistente == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    MusicaExistente.titulo = MusicaActualizada.titulo;
                    MusicaExistente.Genero = MusicaActualizada.Genero;
                    MusicaExistente.NumeroReproducciones = MusicaActualizada.NumeroReproducciones;

                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Edición exitosa" });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_Musica}")]
        public IActionResult EliminarMusica(int Id_Musica)
        {
            try
            {

                var musicas = _context.musicas.Find(Id_Musica);

                if (musicas == null)
                {
                    return NotFound();
                }

                _context.musicas.Remove(musicas);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
    }
}
