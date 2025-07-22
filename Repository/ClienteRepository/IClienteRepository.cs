using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository.Interface;
using JessicaFacturacion.Repository.UsuarioRepository;

namespace JessicaFacturacion.Repository.Cliente
{
    public interface IClienteRepository : IRepository<Models.Cliente>, IUsuarioRepository<Models.Cliente>
    {
        // Aquí puedes agregar métodos específicos para el repositorio de Cliente
        // Por ejemplo:
        Task<Models.Cliente?> GetClientesByNombreAsync(string nombre);
    }     
}
