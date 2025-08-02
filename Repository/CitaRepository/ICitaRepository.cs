using JessicaFacturacion.Repository.GenericRepository.Interface;
using JessicaFacturacion.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using JessicaFacturacion.DTO.Cita;

namespace JessicaFacturacion.Repository.CitaRepository
{
    public interface ICitaRepository : IRepository<Cita>
    {
        Task<IEnumerable<Cita>> GetCitasByMonthAndYear(int month, int year);
        Task<IEnumerable<Cita>> GetCitasByPacienteId(int pacienteId);
        Task<IEnumerable<Cita>> GetCitasByClienteId(int clienteId);
        Task AnulaCita(int citaId);
    }
}
