using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NotificacionDTO
{
    public Guid Id { get; set; }
    public Guid? ReservaId { get; set; }
    public string Destinatario { get; set; }
    public string Mensaje { get; set; }
    public DateTime Fecha { get; set; }
    public bool Enviada { get; set; }
}
