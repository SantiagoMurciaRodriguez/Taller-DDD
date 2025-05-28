using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRutaService
{
    Task<RutaDTO> CrearRutaAsync(RutaDTO ruta);
    Task<IEnumerable<RutaDTO>> ListarRutasAsync();
    Task<RutaDTO?> ObtenerRutaPorIdAsync(Guid rutaId);
}