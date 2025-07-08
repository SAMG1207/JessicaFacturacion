using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository.Interface;

namespace JessicaFacturacion.Repository.FacturaRepository
{
    public interface IPagoRepository : IRepository<Pago>
    {
        Task<IEnumerable<Pago>> GetPagosByClienteId(int clienteId);

        Task<Pago>GetPagoByCitaId(int citaId);
    }
}
