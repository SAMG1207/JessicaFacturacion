using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.ClienteService
{
    public interface IServiceCliente
    {
        Task<bool> Create(DTOCreateCliente dTOCreateCliente);

        Task<IEnumerable<Cliente>>GetClientes();
    }
}
