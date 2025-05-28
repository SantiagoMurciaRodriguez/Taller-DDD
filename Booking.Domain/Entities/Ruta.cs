using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Ruta
    {
        public Guid Id { get; private set; }
        public string Origen { get; private set; }
        public string Destino { get; private set; }

        public Ruta(Guid id, string origen, string destino)
        {
            Id = id;
            Origen = origen;
            Destino = destino;
        }
    }
}
