using System;

namespace Booking.API.Requests
{
    public class CrearNotificacionRequest
    {
        public Guid? ReservaId { get; set; }
        public string Destinatario { get; set; }
        public string Mensaje { get; set; }
    }
}