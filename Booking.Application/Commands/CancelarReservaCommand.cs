using System;

namespace Booking.Application.Commands
{
    public class CancelarReservaCommand
    {
        public Guid ReservaId { get; set; }

        public CancelarReservaCommand(Guid reservaId)
        {
            ReservaId = reservaId;
        }
    }
}