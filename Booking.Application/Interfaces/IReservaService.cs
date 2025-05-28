using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Application.Commands;

public interface IReservaService
{
    Task<ReservaDTO> CrearReservaAsync(CrearReservaCommand command);
    Task CancelarReservaAsync(Guid reservaId);
    Task<ReservaDTO?> ObtenerReservaPorIdAsync(Guid reservaId);
    Task<IEnumerable<ReservaDTO>> ListarReservasAsync();
}