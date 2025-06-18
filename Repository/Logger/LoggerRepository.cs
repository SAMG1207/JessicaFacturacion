
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
        public async Task<bool> AddAsync(LoggerPersonalizado loggerP)
        {
            try
            {
                await _context.logger.AddAsync(loggerP);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
