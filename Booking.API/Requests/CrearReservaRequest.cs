using System;

namespace Booking.API.Requests
{
    public class CrearReservaRequest
    {
        public Guid PasajeroId { get; set; }
        public Guid RutaId { get; set; }
        public DateTime Fecha { get; set; }
    }
}