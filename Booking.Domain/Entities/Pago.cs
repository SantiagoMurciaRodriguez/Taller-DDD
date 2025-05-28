using System;

namespace Booking.Domain.Entities
{
    public class Pago
    {
        public Guid Id { get; private set; }
        public Guid ReservaId { get; private set; }
        public decimal Monto { get; private set; }
        public DateTime Fecha { get; private set; }
        public bool Confirmado { get; private set; }

        public Pago(Guid reservaId, decimal monto)
        {
            Id = Guid.NewGuid();
            ReservaId = reservaId;
            Monto = monto;
            Fecha = DateTime.UtcNow;
            Confirmado = false;
        }

        public void Confirmar()
        {
            Confirmado = true;
        }
    }
}