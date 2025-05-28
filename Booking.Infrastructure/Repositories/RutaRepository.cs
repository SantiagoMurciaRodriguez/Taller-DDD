using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        private readonly List<Ruta> _rutas = new();

        public Task<Ruta?> GetByIdAsync(Guid id)
        {
            var ruta = _rutas.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(ruta);
        }

        public Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return Task.FromResult(_rutas.AsEnumerable());
        }

        public Task AddAsync(Ruta ruta)
        {
            _rutas.Add(ruta);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Ruta ruta)
        {
            var index = _rutas.FindIndex(r => r.Id == ruta.Id);
            if (index != -1)
                _rutas[index] = ruta;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var ruta = _rutas.FirstOrDefault(r => r.Id == id);
            if (ruta != null)
                _rutas.Remove(ruta);
            return Task.CompletedTask;
        }
    }
}