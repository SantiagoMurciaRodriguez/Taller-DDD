using System;

namespace Booking.Application.Commands
{
    public class CrearReservaCommand
    {
        public Guid PasajeroId { get; set; }
        public Guid RutaId { get; set; }
        public DateTime Fecha { get; set; }

        public CrearReservaCommand(Guid pasajeroId, Guid rutaId, DateTime fecha)
        {
            PasajeroId = pasajeroId;
            RutaId = rutaId;
            Fecha = fecha;
        }
    }
}
