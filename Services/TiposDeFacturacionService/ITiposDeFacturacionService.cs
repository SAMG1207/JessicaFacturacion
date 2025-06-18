using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.TiposDeFacturacionService
{
    public interface ITiposDeFacturacionService
    {
        Task<IEnumerable<TipoFacturacion>> GetTiposFacturacion();
    }
}
