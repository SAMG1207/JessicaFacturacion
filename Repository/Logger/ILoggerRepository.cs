using JessicaFacturacion.Models;

namespace JessicaFacturacion.Repository.Logger
{
    public interface ILoggerRepository
    {
        Task AddAsync(LoggerPersonalizado logger);
    }
}
