using System;

namespace Booking.Domain.Entities
{
    public class Notificacion
    {
        public Guid Id { get; private set; }
        public Guid? ReservaId { get; private set; }
        public string Destinatario { get; private set; }
        public string Mensaje { get; private set; }
        public DateTime Fecha { get; private set; }
        public bool Enviada { get; private set; }

        public Notificacion(Guid? reservaId, string destinatario, string mensaje)
        {
            Id = Guid.NewGuid();
            ReservaId = reservaId;
            Destinatario = destinatario;
            Mensaje = mensaje;
            Fecha = DateTime.UtcNow;
            Enviada = false;
        }

        public void MarcarComoEnviada()
        {
            Enviada = true;
        }
    }
}