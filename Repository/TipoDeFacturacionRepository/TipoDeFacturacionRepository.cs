using JessicaFacturacion.Data;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.GenericRepository;

namespace JessicaFacturacion.Repository.TipoDeFacturacionRepository
{
    public class TipoDeFacturacionRepository : Repository<TipoFacturacion>, ITipoDeFacturacionRepository
    {
        private readonly AppDbContext _context;

        public TipoDeFacturacionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Aquí puedes implementar métodos específicos, por ejemplo:
        // public async Task<IEnumerable<TipoFacturacion>> GetTiposAsync() => await _context.TipoFacturaciones.ToListAsync();
    }
}
