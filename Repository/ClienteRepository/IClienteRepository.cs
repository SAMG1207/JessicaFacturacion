using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository.Interface;

namespace JessicaFacturacion.Repository.Cliente
{
    public interface IClienteRepository : IRepository<Models.Cliente>
    {
        // Aquí puedes agregar métodos específicos para el repositorio de Cliente
        // Por ejemplo:
        Task<Models.Cliente?> GetClienteByEmailAsync(string email);
        Task<Models.Cliente?> GetClientesByNombreAsync(string nombre);


    }
       
}
