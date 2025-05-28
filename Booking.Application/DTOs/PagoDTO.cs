using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PagoDTO
{
    public Guid Id { get; set; }
    public Guid ReservaId { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
    public bool Confirmado { get; set; }
}
