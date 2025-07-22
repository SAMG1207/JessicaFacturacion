using JessicaFacturacion.Data;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace JessicaFacturacion.Repository.PacienteRepository
{
    public class PacienteRepository(AppDbContext context) :  Repository<Paciente>(context), IPacienteRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Paciente> GetByDni(string dni)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.DNI == dni);
            return paciente;
        }

        public async Task<Paciente> GetByEmail(string email)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Email == email);
            return paciente;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesByCliente(int clienteId)
        {
            return await _context.Pacientes.Where(p=>p.ClienteId== clienteId).ToListAsync();
        }
    }
}
