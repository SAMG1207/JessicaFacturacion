using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;
using JessicaFacturacion.UnitOfWork;

namespace JessicaFacturacion.Services.TiposDeFacturacionService
{
    public class TiposDeFacturacionService(IUnitOfWork unitOfWork) : ITiposDeFacturacionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Task<IEnumerable<TipoFacturacion>> GetTiposFacturacion()
        {
            return _unitOfWork.TipoDeFacturacionRepository.GetAllAsync();
        }
    }
}