using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ValueObjects
{
    public record CupoDisponible(int Valor)
    {
        public bool HayCupo() => Valor > 0;
        public CupoDisponible RestarCupo() => new CupoDisponible(Valor - 1);
    }
}
