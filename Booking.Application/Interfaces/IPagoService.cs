using System;
using System.Threading.Tasks;

public interface IPagoService
{
    Task<PagoDTO> CrearPagoAsync(Guid reservaId, decimal monto);
    Task ConfirmarPagoAsync(Guid pagoId);
    Task<PagoDTO?> ObtenerPagoPorIdAsync(Guid pagoId);
}