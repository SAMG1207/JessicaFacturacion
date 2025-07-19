using JessicaFacturacion.Data;
using JessicaFacturacion.Repository.Cliente;
using JessicaFacturacion.Repository.FacturaRepository;
using JessicaFacturacion.Repository.Jessica;
using JessicaFacturacion.Repository.Logger;
using JessicaFacturacion.Repository.PacienteRepository;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;

namespace JessicaFacturacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IPacienteRepository PacienteRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IJessicaRepository JessicaRepository { get; }
        public ILoggerRepository LoggerRepository { get; }
        public IPagoRepository PagoRepository { get; }
        public ITipoDeFacturacionRepository TipoDeFacturacionRepository { get; }

        public UnitOfWork(
            AppDbContext appDbContext,
            IPacienteRepository pacienteRepository,
            IClienteRepository clienteRepository,
            IJessicaRepository jessicaRepository,
            ILoggerRepository loggerRepository,
            IPagoRepository pagoRepository,
            ITipoDeFacturacionRepository tipoDeFacturacionRepository)
        {
            _appDbContext = appDbContext;
            PacienteRepository = pacienteRepository;
            ClienteRepository = clienteRepository;
            JessicaRepository = jessicaRepository;
            LoggerRepository = loggerRepository;
            PagoRepository = pagoRepository;
            TipoDeFacturacionRepository = tipoDeFacturacionRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

    }
}
