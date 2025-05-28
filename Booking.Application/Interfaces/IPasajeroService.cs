using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPasajeroService
{
    Task<PasajeroDTO> CrearPasajeroAsync(PasajeroDTO pasajero);
    Task<IEnumerable<PasajeroDTO>> ListarPasajerosAsync();
    Task<PasajeroDTO?> ObtenerPasajeroPorIdAsync(Guid pasajeroId);
}