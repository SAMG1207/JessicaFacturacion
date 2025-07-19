using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.ClienteService
{
    public interface IServiceCliente
    {
        Task Create(DTOCreateCliente dTOCreateCliente);

        Task<IEnumerable<Cliente>>GetClientes();
    }
}
