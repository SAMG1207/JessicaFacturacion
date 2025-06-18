using JessicaFacturacion.Models;

namespace JessicaFacturacion.Repository.Logger
{
    public interface ILoggerRepository
    {
        Task<bool>AddAsync(LoggerPersonalizado logger);
    }
}
