using System;

namespace Booking.API.Responses
{
    public class ReservaResponse
    {
        public Guid Id { get; set; }
        public Guid PasajeroId { get; set; }
        public Guid RutaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Confirmada { get; set; }
    }
}
