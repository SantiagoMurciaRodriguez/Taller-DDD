using Microsoft.AspNetCore.Mvc;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.API.Requests;
using Booking.API.Responses;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoRepository _pagoRepository;

        public PagosController(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] CrearPagoRequest request)
        {
            var pago = new Pago(request.ReservaId, request.Monto);
            await _pagoRepository.AddAsync(pago);
            return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, new { Id = pago.Id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPago(Guid id)
        {
            var pago = await _pagoRepository.GetByIdAsync(id);
            if (pago == null)
                return NotFound();

            var response = new PagoResponse
            {
                Id = pago.Id,
                ReservaId = pago.ReservaId,
                Monto = pago.Monto,
                Fecha = pago.Fecha,
                Confirmado = pago.Confirmado
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _pagoRepository.GetAllAsync();
            var response = pagos.Select(p => new PagoResponse
            {
                Id = p.Id,
                ReservaId = p.ReservaId,
                Monto = p.Monto,
                Fecha = p.Fecha,
                Confirmado = p.Confirmado
            });
            return Ok(response);
        }

        [HttpPost("{id}/confirmar")]
        public async Task<IActionResult> ConfirmarPago(Guid id)
        {
            var pago = await _pagoRepository.GetByIdAsync(id);
            if (pago == null)
                return NotFound();

            pago.Confirmar();
            await _pagoRepository.UpdateAsync(pago);
            return NoContent();
        }
    }
}