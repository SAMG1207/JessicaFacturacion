using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository.Interface;
using JessicaFacturacion.Repository.UsuarioRepository;
using Microsoft.AspNetCore.Mvc;

namespace JessicaFacturacion.Repository.PacienteRepository
{
    public interface IPacienteRepository : IRepository<Models.Paciente>, IUsuarioRepository<Paciente>
    {
        Task<IEnumerable<Models.Paciente>> GetPacientesByCliente(int clienteId);  
    }
}
