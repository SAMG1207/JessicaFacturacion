using JessicaFacturacion.Data;
using JessicaFacturacion.DTO.Cita;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace JessicaFacturacion.Repository.CitaRepository
{
    public class CitaRepository(AppDbContext context) : Repository<Cita>(context), ICitaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AnulaCita(int citaId)
        {
            var cita = await _context.Citas.FindAsync(citaId);
            cita.CancelCita();
        }

        public async Task<IEnumerable<Cita>> GetCitasByClienteId(int clienteId)
        {
            return await _context.Citas
                .Include(c=>c.Paciente)
                .ThenInclude(p => p.Cliente)
                .Where(c => c.Paciente.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByMonthAndYear(int month, int year)
        {
            return await _context.Citas
                .Where(c => c.FechaCita.Month == month && c.FechaCita.Year == year)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByPacienteId(int pacienteId)
        {
            return await _context.Citas
                .Where(c=>c.PacienteId == pacienteId)
                .ToListAsync();
        }

    }

}
