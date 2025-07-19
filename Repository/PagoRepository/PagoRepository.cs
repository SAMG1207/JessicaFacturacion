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
            var cita = await _context.Citas.
                 Include(c => c.Pago)
                 .FirstOrDefaultAsync(c=>c.Id == citaId);
            return cita?.Pago;
        }

        public async Task<IEnumerable<Pago>> GetPagosByClienteId(int clienteId)
        {
           var pagos = await _context.Pagos
                .Where(p=>p.TipoServicio.ClienteId == clienteId)
                .Include(p=>p.TipoServicio)
                .ToListAsync();
            return pagos;
        }
    }
}
