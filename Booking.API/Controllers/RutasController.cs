using Microsoft.AspNetCore.Mvc;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.API.Requests;
using Booking.API.Responses;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly IRutaRepository _rutaRepository;

        public RutasController(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRuta([FromBody] CrearRutaRequest request)
        {
            var ruta = new Ruta(Guid.NewGuid(), request.Origen, request.Destino);
            await _rutaRepository.AddAsync(ruta);
            return CreatedAtAction(nameof(GetRuta), new { id = ruta.Id }, new { Id = ruta.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetRutas()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            var response = rutas.Select(r => new RutaResponse
            {
                Id = r.Id,
                Origen = r.Origen,
                Destino = r.Destino
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRuta(Guid id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);
            if (ruta == null)
                return NotFound();

            var response = new RutaResponse
            {
                Id = ruta.Id,
                Origen = ruta.Origen,
                Destino = ruta.Destino
            };
            return Ok(response);
        }
    }
}