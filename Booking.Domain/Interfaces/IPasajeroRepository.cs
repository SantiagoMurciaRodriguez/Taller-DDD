using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IPasajeroRepository
    {
        Task<Pasajero?> GetByIdAsync(Guid id);
        Task<IEnumerable<Pasajero>> GetAllAsync();
        Task AddAsync(Pasajero pasajero);
        Task UpdateAsync(Pasajero pasajero);
        Task DeleteAsync(Guid id);
    }
}