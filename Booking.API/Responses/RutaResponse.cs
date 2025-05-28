using System;

namespace Booking.API.Responses
{
    public class RutaResponse
    {
        public Guid Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}