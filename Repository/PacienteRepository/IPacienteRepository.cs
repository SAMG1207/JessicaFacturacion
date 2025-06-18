using JessicaFacturacion.Repository.GenericRepository.Interface;

namespace JessicaFacturacion.Repository.PacienteRepository
{
    public interface IPacienteRepository : IRepository<Models.Paciente>
    {
        Task<Models.Paciente?>GetPacienteByDNI(string dni);

        Task<IEnumerable<Models.Paciente>> GetPacientesByCliente(int clienteId);
    }
}
