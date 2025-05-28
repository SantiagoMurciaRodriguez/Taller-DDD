using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.Repositories
{
    public class PasajeroRepository : IPasajeroRepository
    {
        private readonly List<Pasajero> _pasajeros = new();

        public Task<Pasajero?> GetByIdAsync(Guid id)
        {
            var pasajero = _pasajeros.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pasajero);
        }

        public Task<IEnumerable<Pasajero>> GetAllAsync()
        {
            return Task.FromResult(_pasajeros.AsEnumerable());
        }

        public Task AddAsync(Pasajero pasajero)
        {
            _pasajeros.Add(pasajero);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Pasajero pasajero)
        {
            var index = _pasajeros.FindIndex(p => p.Id == pasajero.Id);
            if (index != -1)
                _pasajeros[index] = pasajero;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var pasajero = _pasajeros.FirstOrDefault(p => p.Id == id);
            if (pasajero != null)
                _pasajeros.Remove(pasajero);
            return Task.CompletedTask;
        }
    }
}
