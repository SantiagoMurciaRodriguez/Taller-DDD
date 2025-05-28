using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Domain.Aggregates;
using Booking.Domain.ValueObjects;
using Booking.Domain.Aggregates;

namespace Booking.Domain.Entities
{
    public class Reserva : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Pasajero Pasajero { get; private set; }
        public Ruta Ruta { get; private set; }
        public DateTime Fecha { get; private set; }
        public CupoDisponible Cupo { get; private set; }
        public bool Confirmada { get; private set; }

        public Reserva(Pasajero pasajero, Ruta ruta, DateTime fecha, CupoDisponible cupo)
        {
            Id = Guid.NewGuid();
            Pasajero = pasajero;
            Ruta = ruta;
            Fecha = fecha;
            Cupo = cupo;
            Confirmada = false;
        }

        public void Confirmar()
        {
            Confirmada = true;
        }

        public void Cancelar()
        {
            Confirmada = false;
        }
    }
}
