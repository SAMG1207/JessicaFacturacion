using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.ClienteService
{
    public interface IServiceCliente
    {
        Task Create(ClienteCreateRequest request, CancellationToken cancellationToken);

        Task<IEnumerable<Cliente>>GetClientes(CancellationToken cancellationToken);

        Task ActualizaCliente(ClienteUpdateRequest request, CancellationToken cancellationToken);
    }
}
