using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;

namespace JessicaFacturacion.Services.TiposDeFacturacionService
{
    public class TiposDeFacturacionService : ITiposDeFacturacionService
    {
        private readonly ITipoDeFacturacionRepository _tipoDeFacturacionRepository;

        public TiposDeFacturacionService(ITipoDeFacturacionRepository tipoDeFacturacionRepository)
        {
            _tipoDeFacturacionRepository = tipoDeFacturacionRepository;
        }
        public async Task<IEnumerable<TipoFacturacion>> GetTiposFacturacion()
        {
            return await _tipoDeFacturacionRepository.GetAllAsync();
        }
    }

}