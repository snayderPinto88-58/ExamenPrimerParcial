using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examen2doParcial.Context;
using Examen2doParcial.Models;
using Examen2doParcial.Controllers;

namespace Examen2doParcial.Controllers
{

    
    public class DiscoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiscoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA-LEER")]
        public IActionResult lista()
        {
            var uni = this._context.discos.ToList();
            return Ok(uni);
        }
        [HttpPost]
        [Route("CREAR-Disco")]
        public IActionResult CrearDisco([FromBody] Disco nuevaDisco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.discos.Add(nuevaDisco);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

        [HttpPut("EDITAR/{Id_Disco}")]
        public IActionResult EditarDisco(int Id_Disco, [FromBody] Disco DiscoActualizada)
        {
            try
            {
                var DiscoExistente = _context.discos.Find(Id_Disco);

                if (DiscoExistente == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    DiscoExistente.titulo = DiscoActualizada.titulo;
                    DiscoExistente.autor = DiscoActualizada.autor;
                    DiscoExistente.year = DiscoActualizada.year;

                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Edición exitosa" });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_Disco}")]
        public IActionResult EliminarDisco(int Id_Disco)
        {
            try
            {

                var discos = _context.discos.Find(Id_Disco);

                if (discos == null)
                {
                    return NotFound();
                }

                _context.discos.Remove(discos);
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
