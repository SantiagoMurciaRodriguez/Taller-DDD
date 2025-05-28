using System;

namespace Booking.API.Requests
{
    public class CrearPagoRequest
    {
        public Guid ReservaId { get; set; }
        public decimal Monto { get; set; }
    }
}