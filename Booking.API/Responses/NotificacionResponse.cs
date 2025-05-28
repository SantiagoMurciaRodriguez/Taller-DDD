using System;

namespace Booking.API.Responses
{
    public class NotificacionResponse
    {
        public Guid Id { get; set; }
        public Guid? ReservaId { get; set; }
        public string Destinatario { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public bool Enviada { get; set; }
    }
}