using System;
using System.Threading.Tasks;

public interface INotificacionService
{
    Task EnviarNotificacionAsync(NotificacionDTO notificacion);
    Task<IEnumerable<NotificacionDTO>> ListarNotificacionesPorReservaAsync(Guid reservaId);
}