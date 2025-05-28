using Microsoft.AspNetCore.Mvc;
using Booking.Application.Commands;
using Booking.Application.UseCases;
using Booking.Domain.Interfaces;
using Booking.API.Requests;
using Booking.API.Responses;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly CrearReservaUseCase _crearReservaUseCase;
        private readonly CancelarReservaUseCase _cancelarReservaUseCase;
        private readonly IReservaRepository _reservaRepository;

        public ReservasController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
            _crearReservaUseCase = new CrearReservaUseCase(reservaRepository);
            _cancelarReservaUseCase = new CancelarReservaUseCase(reservaRepository);
        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva([FromBody] CrearReservaRequest request)
        {
            var command = new CrearReservaCommand(request.PasajeroId, request.RutaId, request.Fecha);
            var reservaId = await _crearReservaUseCase.Handle(command);
            return CreatedAtAction(nameof(GetReserva), new { id = reservaId }, new { Id = reservaId });
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> CancelarReserva(Guid id)
        {
            var result = await _cancelarReservaUseCase.Handle(new CancelarReservaCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(Guid id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null)
                return NotFound();

            var response = new ReservaResponse
            {
                Id = reserva.Id,
                PasajeroId = reserva.Pasajero.Id,
                RutaId = reserva.Ruta.Id,
                Fecha = reserva.Fecha,
                Confirmada = reserva.Confirmada
            };

            return Ok(response);
        }
    }
}