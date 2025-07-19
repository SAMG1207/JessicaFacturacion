using JessicaFacturacion.DTO.Paciente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.PacienteService
{
    public interface IPacienteService
    {
        Task Create(DTOCreatePaciente dTOCreatePaciente);

        Task<IEnumerable<Paciente>> GetPacientesByClienteId(int clienteId);

        Task<Paciente?> GetPacienteByDNI(string  dNI);
    }
}
