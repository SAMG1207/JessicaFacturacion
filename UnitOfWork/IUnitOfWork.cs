using JessicaFacturacion.Repository.Cliente;
using JessicaFacturacion.Repository.FacturaRepository;
using JessicaFacturacion.Repository.Jessica;
using JessicaFacturacion.Repository.Logger;
using JessicaFacturacion.Repository.PacienteRepository;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;

namespace JessicaFacturacion.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPacienteRepository PacienteRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IJessicaRepository JessicaRepository { get; }
        ILoggerRepository LoggerRepository { get; }
        IPagoRepository PagoRepository { get; }

        ITipoDeFacturacionRepository TipoDeFacturacionRepository { get; }
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
