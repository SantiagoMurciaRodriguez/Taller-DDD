using Microsoft.AspNetCore.Mvc;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.API.Requests;
using Booking.API.Responses;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionRepository _notificacionRepository;

        public NotificacionesController(INotificacionRepository notificacionRepository)
        {
            _notificacionRepository = notificacionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearNotificacion([FromBody] CrearNotificacionRequest request)
        {
            var notificacion = new Notificacion(request.ReservaId, request.Destinatario, request.Mensaje);
            await _notificacionRepository.AddAsync(notificacion);
            return CreatedAtAction(nameof(GetNotificacion), new { id = notificacion.Id }, new { Id = notificacion.Id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificacion(Guid id)
        {
            var notificacion = await _notificacionRepository.GetByIdAsync(id);
            if (notificacion == null)
                return NotFound();

            var response = new NotificacionResponse
            {
                Id = notificacion.Id,
                ReservaId = notificacion.ReservaId,
                Destinatario = notificacion.Destinatario,
                Mensaje = notificacion.Mensaje,
                Fecha = notificacion.Fecha,
                Enviada = notificacion.Enviada
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificaciones()
        {
            var notificaciones = await _notificacionRepository.GetAllAsync();
            var response = notificaciones.Select(n => new NotificacionResponse
            {
                Id = n.Id,
                ReservaId = n.ReservaId,
                Destinatario = n.Destinatario,
                Mensaje = n.Mensaje,
                Fecha = n.Fecha,
                Enviada = n.Enviada
            });
            return Ok(response);
        }

        [HttpPost("{id}/marcar-enviada")]
        public async Task<IActionResult> MarcarComoEnviada(Guid id)
        {
            var notificacion = await _notificacionRepository.GetByIdAsync(id);
            if (notificacion == null)
                return NotFound();

            notificacion.MarcarComoEnviada();
            await _notificacionRepository.UpdateAsync(notificacion);
            return NoContent();
        }
    }
}