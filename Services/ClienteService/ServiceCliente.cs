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

        public async Task ActualizaCliente(ClienteUpdateRequest request)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
            {
                throw new Exceptions.Cliente.ClienteNoEncontradoException(request.Id);
            }
            _mapper.Map(request, cliente);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Create(ClienteCreateRequest dTOCreateCliente)
        {
            Cliente cliente = _mapper.Map<Cliente>(dTOCreateCliente);
            await _unitOfWork.ClienteRepository.AddAsync(cliente);    
        }

        public Task<IEnumerable<Cliente>> GetClientes()
        {
            return  _unitOfWork.ClienteRepository.GetAllAsync(); 
        }
    }
}
