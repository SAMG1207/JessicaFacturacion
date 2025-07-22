using AutoMapper;
using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;
using JessicaFacturacion.UnitOfWork;

namespace JessicaFacturacion.Services.ClienteService
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceCliente> _logger;
        public ServiceCliente(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ServiceCliente> logger)
        {    
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ActualizaCliente(ClienteUpdateRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(request.Id);
            if (cliente is null)
            {
                throw new Exceptions.Cliente.ClienteNoEncontradoException(request.Id);
            }
            _mapper.Map(request, cliente);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task Create(ClienteCreateRequest dTOCreateCliente, CancellationToken cancellationToken)
        {
            Cliente cliente = _mapper.Map<Cliente>(dTOCreateCliente);
            await _unitOfWork.ClienteRepository.AddAsync(cliente);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public Task<IEnumerable<Cliente>> GetClientes(CancellationToken cancellationToken)
        {
            return  _unitOfWork.ClienteRepository.GetAllAsync(cancellationToken); 
        }
    }
}
