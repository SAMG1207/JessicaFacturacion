using AutoMapper;
using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.Cliente;

namespace JessicaFacturacion.Services.ClienteService
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceCliente> _logger;
        public ServiceCliente(IClienteRepository clienteRepository, IMapper mapper, ILogger<ServiceCliente> logger)
        {    
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Create(DTOCreateCliente dTOCreateCliente)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(dTOCreateCliente);
                var result = await _clienteRepository.AddAsync(cliente);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creando cliente");
                return false;
            }
     
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.GetAllAsync(); 
        }
    }
}
