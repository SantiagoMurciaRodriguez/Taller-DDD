using System;
using System.Threading.Tasks;
using Booking.Application.Commands;
using Booking.Domain.Interfaces;

namespace Booking.Application.UseCases
{
    public class CancelarReservaUseCase
    {
        private readonly IReservaRepository _reservaRepository;

        public CancelarReservaUseCase(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<bool> Handle(CancelarReservaCommand command)
        {
            var reserva = await _reservaRepository.GetByIdAsync(command.ReservaId);
            if (reserva == null)
                return false;

            reserva.Cancelar();
            await _reservaRepository.UpdateAsync(reserva);

            return true;
        }
    }
}