using JessicaFacturacion.Data;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository;
using JessicaFacturacion.Repository.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace JessicaFacturacion.Repository.Cliente
{
    public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Models.Cliente> GetByDni(string dni)  
        {
            var cliente = await _context.Clientes
                .Where(c => c.DNI == dni)
                .FirstOrDefaultAsync();

            return cliente ?? throw new Exception("No se ha encontrado un cliente con ese dni");
        }

        public async Task<Models.Cliente> GetByEmail(string email)
        {
            var cliente = await _context.Clientes
            .Where(c => c.Email == email)
            .FirstOrDefaultAsync();

            return cliente ?? throw new Exception("No se ha encontrado un cliente con ese email");
        }

        public async Task<Models.Cliente?> GetClientesByNombreAsync(string nombre)
        {
            var cliente = await _context.Clientes
                .Where(c => c.Nombre == nombre)
                .FirstOrDefaultAsync();

            return cliente ?? throw new Exception("No se ha encontrado un cliente con ese email");
        }
    }
}
