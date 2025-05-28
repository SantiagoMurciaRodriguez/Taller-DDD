using System;
using System.Threading.Tasks;
using Booking.Application.Commands;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Domain.ValueObjects;

namespace Booking.Application.UseCases
{
    public class CrearReservaUseCase
    {
        private readonly IReservaRepository _reservaRepository;

        public CrearReservaUseCase(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Guid> Handle(CrearReservaCommand command)
        {
            // Aquí deberías obtener el pasajero y la ruta desde sus respectivos repositorios.
            // Por simplicidad, se crean objetos de ejemplo:
            var pasajero = new Pasajero(command.PasajeroId, "Nombre Ejemplo", "email@ejemplo.com");
            var ruta = new Ruta(command.RutaId, "Origen Ejemplo", "Destino Ejemplo");
            var cupo = new CupoDisponible(1); // Suponiendo que hay cupo disponible

            var reserva = new Reserva(pasajero, ruta, command.Fecha, cupo);

            await _reservaRepository.AddAsync(reserva);

            return reserva.Id;
        }
    }
}