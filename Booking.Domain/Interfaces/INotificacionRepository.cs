using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface INotificacionRepository
    {
        Task<Notificacion?> GetByIdAsync(Guid id);
        Task<IEnumerable<Notificacion>> GetAllAsync();
        Task AddAsync(Notificacion notificacion);
        Task UpdateAsync(Notificacion notificacion);
        Task DeleteAsync(Guid id);
    }
}