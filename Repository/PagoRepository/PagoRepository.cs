using JessicaFacturacion.Data;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.FacturaRepository;
using JessicaFacturacion.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace JessicaFacturacion.Repository.PagoRepository
{   public class PagoRepository : Repository<Pago>, IPagoRepository
    {
        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Pago?> GetPagoByCitaId(int citaId)
        {
            int? pagoId = await _context.Citas
                .Where(c => c.Id == citaId)
                .Select(c => c.PagoId)
                .FirstOrDefaultAsync();

            if (pagoId == null)
            {
                return null;
            }

            var pago = await _context.Pagos.FindAsync(pagoId);
            return pago;
        }

        public Task<IEnumerable<Pago>> GetPagosByClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
