using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IRutaRepository
    {
        Task<Ruta?> GetByIdAsync(Guid id);
        Task<IEnumerable<Ruta>> GetAllAsync();
        Task AddAsync(Ruta ruta);
        Task UpdateAsync(Ruta ruta);
        Task DeleteAsync(Guid id);
    }
}