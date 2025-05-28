using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Pasajero
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }

        public Pasajero(Guid id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
        }
    }
}
