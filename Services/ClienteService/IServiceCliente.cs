using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.ClienteService
{
    public interface IServiceCliente
    {
        Task Create(ClienteCreateRequest dTOCreateCliente);

        Task<IEnumerable<Cliente>>GetClientes();

        Task ActualizaCliente(ClienteUpdateRequest request);
    }
}
