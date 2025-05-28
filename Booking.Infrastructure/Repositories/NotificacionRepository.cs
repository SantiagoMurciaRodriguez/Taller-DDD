using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly List<Notificacion> _notificaciones = new();

        public Task<Notificacion?> GetByIdAsync(Guid id)
        {
            var notificacion = _notificaciones.FirstOrDefault(n => n.Id == id);
            return Task.FromResult(notificacion);
        }

        public Task<IEnumerable<Notificacion>> GetAllAsync()
        {
            return Task.FromResult(_notificaciones.AsEnumerable());
        }

        public Task AddAsync(Notificacion notificacion)
        {
            _notificaciones.Add(notificacion);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Notificacion notificacion)
        {
            var index = _notificaciones.FindIndex(n => n.Id == notificacion.Id);
            if (index != -1)
                _notificaciones[index] = notificacion;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var notificacion = _notificaciones.FirstOrDefault(n => n.Id == id);
            if (notificacion != null)
                _notificaciones.Remove(notificacion);
            return Task.CompletedTask;
        }
    }
}