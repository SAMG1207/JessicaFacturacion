using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;

namespace JessicaFacturacion.Services.TiposDeFacturacionService
{
    public class TiposDeFacturacionService(ITipoDeFacturacionRepository tipoDeFacturacionRepository) : ITiposDeFacturacionService
    {
        private readonly ITipoDeFacturacionRepository _tipoDeFacturacionRepository = tipoDeFacturacionRepository;

        public Task<IEnumerable<TipoFacturacion>> GetTiposFacturacion()
        {
            return _tipoDeFacturacionRepository.GetAllAsync();
        }
    }

}