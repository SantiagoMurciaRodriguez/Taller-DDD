using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly List<Pago> _pagos = new();

        public Task<Pago?> GetByIdAsync(Guid id)
        {
            var pago = _pagos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pago);
        }

        public Task<IEnumerable<Pago>> GetAllAsync()
        {
            return Task.FromResult(_pagos.AsEnumerable());
        }

        public Task AddAsync(Pago pago)
        {
            _pagos.Add(pago);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Pago pago)
        {
            var index = _pagos.FindIndex(p => p.Id == pago.Id);
            if (index != -1)
                _pagos[index] = pago;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var pago = _pagos.FirstOrDefault(p => p.Id == id);
            if (pago != null)
                _pagos.Remove(pago);
            return Task.CompletedTask;
        }
    }
}