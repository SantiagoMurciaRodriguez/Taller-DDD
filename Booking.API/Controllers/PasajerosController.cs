using Microsoft.AspNetCore.Mvc;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.API.Requests;
using Booking.API.Responses;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosController : ControllerBase
    {
        private readonly IPasajeroRepository _pasajeroRepository;

        public PasajerosController(IPasajeroRepository pasajeroRepository)
        {
            _pasajeroRepository = pasajeroRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPasajero([FromBody] CrearPasajeroRequest request)
        {
            var pasajero = new Pasajero(Guid.NewGuid(), request.Nombre, request.Email);
            await _pasajeroRepository.AddAsync(pasajero);
            return CreatedAtAction(nameof(GetPasajero), new { id = pasajero.Id }, new { Id = pasajero.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetPasajeros()
        {
            var pasajeros = await _pasajeroRepository.GetAllAsync();
            var response = pasajeros.Select(p => new PasajeroResponse
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Email = p.Email
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPasajero(Guid id)
        {
            var pasajero = await _pasajeroRepository.GetByIdAsync(id);
            if (pasajero == null)
                return NotFound();

            var response = new PasajeroResponse
            {
                Id = pasajero.Id,
                Nombre = pasajero.Nombre,
                Email = pasajero.Email
            };
            return Ok(response);
        }
    }
}