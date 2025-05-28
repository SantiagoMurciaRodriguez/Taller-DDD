using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly List<Reserva> _reservas = new();

        public Task<Reserva?> GetByIdAsync(Guid id)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(reserva);
        }

        public Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return Task.FromResult(_reservas.AsEnumerable());
        }

        public Task AddAsync(Reserva reserva)
        {
            _reservas.Add(reserva);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Reserva reserva)
        {
            var index = _reservas.FindIndex(r => r.Id == reserva.Id);
            if (index != -1)
            {
                _reservas[index] = reserva;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                _reservas.Remove(reserva);
            }
            return Task.CompletedTask;
        }
    }
}