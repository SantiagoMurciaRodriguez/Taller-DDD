using System;

namespace Booking.API.Responses
{
    public class PagoResponse
    {
        public Guid Id { get; set; }
        public Guid ReservaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Confirmado { get; set; }
    }
}