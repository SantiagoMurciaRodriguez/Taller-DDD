using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReservaDTO
{
    public Guid Id { get; set; }
    public PasajeroDTO Pasajero { get; set; }
    public RutaDTO Ruta { get; set; }
    public DateTime Fecha { get; set; }
    public int Cupo { get; set; }
    public bool Confirmada { get; set; }
}
