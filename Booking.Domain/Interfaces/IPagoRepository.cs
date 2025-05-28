using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IPagoRepository
    {
        Task<Pago?> GetByIdAsync(Guid id);
        Task<IEnumerable<Pago>> GetAllAsync();
        Task AddAsync(Pago pago);
        Task UpdateAsync(Pago pago);
        Task DeleteAsync(Guid id);
    }
}