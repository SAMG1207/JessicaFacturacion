using JessicaFacturacion.Data;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository;
using JessicaFacturacion.Repository.GenericRepository.Interface;

namespace JessicaFacturacion.Repository.Cliente
{
    public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Models.Cliente?> GetClienteByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Cliente>> GetClientesByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
