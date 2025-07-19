
using JessicaFacturacion.Data;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Repository.Logger
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly AppDbContext _context;

        public LoggerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LoggerPersonalizado loggerP)
        {
            await _context.logger.AddAsync(loggerP);
        }
    }
}
