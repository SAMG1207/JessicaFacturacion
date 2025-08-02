using JessicaFacturacion.DTO.Cita;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Services.CitasService
{
    public interface ICitaService
    {
        Task<IEnumerable<Cita>> GetCitasByMonth(int month, int year);
        Task<IEnumerable<Cita>> GetCitasByClienteId (int clienteId);
        Task<IEnumerable<Cita>> GetCitasByPacientesId(int clienteId);
        Task<Cita> AddCita(CreateCitaRequest createCitaRequest);
        Task CancelCita(int citaId);
    }
}
